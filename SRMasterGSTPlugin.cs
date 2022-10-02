using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SRMasterGST
{
    public class SRMasterGSTPlugin
    {
        //GENERATE IRN API
        public static void GenerateIRN_PluginAPI(URL_Parameters URLParam, DataTable dtInput, DataTable dtIRNSave, DataTable dtErrorSave)
        {
            try
            {
                //AUTHENTICATION TOKEN CREATION-----------------------------------------------
                URLParam.auth_token = JObject.Parse(URLParam.getAPIResponseString(URLParam.setAuthenticationAPIParam()))["data"]["AuthToken"].ToString();

                DataRow[] dr = dtInput.Select();
                //CALLING IRN GENERATING API FOR EACH VALID DATAROW-----------------------------------------------
                foreach (DataRow row in dr)
                {
                    //IRN GENERATION----------------------------------------------------------------------------
                    PostRequestBody prb = new PostRequestBody();
                    string jsonIRNRequestBody = JObject.Parse(JsonConvert.SerializeObject(prb.generateIRNRequestBody(row))).ToString();
                    string responseString = URLParam.getAPIResponseString(URLParam.setGenerateIRNAPIParam(jsonIRNRequestBody));

                    var status = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                    if (status == "1")
                    {
                        //IRN DETAILS INSERT-----------------------------------------------------------------------
                        DataRow dtIRN = dtIRNSave.NewRow();
                        dtIRN["eInvoiceRefNo"] = row["Erp_InvoiceId"].ToString();
                        dtIRN["AckNo"] = Convert.ToString(JObject.Parse(responseString)["data"]["AckNo"]);
                        dtIRN["AckDt"] = Convert.ToString(JObject.Parse(responseString)["data"]["AckDt"]);
                        dtIRN["IRN"] = Convert.ToString(JObject.Parse(responseString)["data"]["Irn"]);
                        dtIRN["SignedInvoice"] = Convert.ToString(JObject.Parse(responseString)["data"]["SignedInvoice"]);
                        dtIRN["SignedQRCode"] = Convert.ToString(JObject.Parse(responseString)["data"]["SignedQRCode"]);
                        dtIRN["Status"] = Convert.ToString(JObject.Parse(responseString)["data"]["Status"]);
                        dtIRN["EwbNo"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbNo"]);
                        dtIRN["EwbDt"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbDt"]);
                        dtIRN["EwbValidTill"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbValidTill"]);
                        dtIRN["Remarks"] = Convert.ToString(JObject.Parse(responseString)["data"]["Remarks"]);
                        dtIRN["status_cd"] = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                        dtIRN["status_desc"] = Convert.ToString(JObject.Parse(responseString)["status_desc"]);
                        dtIRNSave.Rows.Add(dtIRN);
                    }
                    else if (status == "0")
                    {
                        //ERROR DETAILS INSERT-----------------------------------------------------------------------
                        DataRow drError = dtErrorSave.NewRow();
                        drError["Erp_InvoiceId"] = row["Erp_InvoiceId"].ToString();
                        drError["status_cd"] = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                        string statusDesc = Convert.ToString(JObject.Parse(responseString)["status_desc"]);
                        statusDesc = statusDesc.Replace("[", string.Empty).Replace("]", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                        int i = statusDesc.IndexOf(":");
                        int j = statusDesc.IndexOf(",");
                        string ErrorCode = statusDesc.Substring(i + 1, j - i - 1).Replace("\"", "");
                        drError["ErrorCode"] = ErrorCode.ToString();
                        string ErrorMessage = statusDesc.Substring(j - 1);
                        i = ErrorMessage.IndexOf(":");
                        ErrorMessage = ErrorMessage.Substring(i + 1).Replace("\"", "");
                        drError["ErrorMessage"] = ErrorMessage.ToString();
                        dtErrorSave.Rows.Add(drError);
                    }
                    else
                    {
                        Console.WriteLine("IRN STATUS UNKNOWN (Status Code:" + status + ")");
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("INTERNAL APPLICATION ERROR : " + exp.Message);
            }
        }

        //CANCEL IRN API
        public static void cancelIRN_PluginAPI(URL_Parameters URLParam, DataTable dtIRNSave, DataTable dtCancelIRN)
        {
            try
            {
                //AUTHENTICATION TOKEN CREATION-----------------------------------------------
                System.Net.WebRequest wr1 = URLParam.setAuthenticationAPIParam();
                URLParam.auth_token = JObject.Parse(URLParam.getAPIResponseString(wr1))["data"]["AuthToken"].ToString();

                DataRow[] dr = dtIRNSave.Select();
                //CALLING CANCEL IRN GENERATING API FOR EACH VALID DATAROW-----------------------------------------------
                foreach (DataRow row in dr)
                {
                    var val = DateTime.Now.Subtract(DateTime.Parse(row["AckDt"].ToString())).TotalMinutes;

                    DataRow dtCancel = dtCancelIRN.NewRow();
                    dtCancel["eInvoiceId"] = row["eInvoiceId"].ToString();
                    dtCancel["Irn"] = row["Irn"].ToString();

                    if (val < 1440)
                    {
                        try
                        {
                            //CANCEL IRN GENERATION----------------------------------------------------------------------------
                            PostRequestBody prb = new PostRequestBody();
                            string jsonCancleIRNRequestBody = JObject.Parse(JsonConvert.SerializeObject(prb.cancelRNRequestBody(row["Irn"].ToString(), "1", row["CancelRemark"].ToString()))).ToString();

                            string responseString = URLParam.getAPIResponseString(URLParam.setCancelIRNAPIParam(jsonCancleIRNRequestBody));
                            Console.WriteLine("CANCEL RESPONSE>\t" + JObject.Parse(responseString).ToString());

                            if (JObject.Parse(responseString)["status_cd"].ToString() == "1")
                            {
                                dtCancel["CnlRem"] = "CANCELLED: " + row["CancelRemark"].ToString();
                                dtCancel["CnDate"] = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                                dtCancelIRN.Rows.Add(dtCancel);
                            }
                            else if (JObject.Parse(responseString)["status_cd"].ToString() == "0")
                            {
                                dtCancel["CnlRem"] = "NOT CANCELLED: " + JObject.Parse(responseString)["status_desc"].ToString();
                                dtCancel["CnDate"] = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                                dtCancelIRN.Rows.Add(dtCancel);
                            }
                            else
                            {
                                Console.WriteLine("UNKNOWN ERROR");
                            }
                        }
                        catch (Exception exp)
                        {
                            dtCancel["CnlRem"] = "SERVER ERROR: " + exp.Message;
                            dtCancel["CnDate"] = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                            dtCancelIRN.Rows.Add(dtCancel);
                        }
                    }
                    else
                    {
                        dtCancel["CnlRem"] = "IRN CANCELLATION FAILED: TIME WINDOW EXPIRED(24HRS)";
                        dtCancel["CnDate"] = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt"));
                        dtCancelIRN.Rows.Add(dtCancel);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("INTERNAL APPLICATION ERROR : "+ exp.Message);
            }
        }

        //GET IRN BY DOC DETAILS API
        public static void getIRNByDocDetails_PluginAPI(URL_Parameters URLParam, DataTable dtInput, DataTable dtIRNSave, DataTable dtErrorSave)
        {
            //AUTHENTICATION TOKEN CREATION-----------------------------------------------
            URLParam.auth_token = JObject.Parse(URLParam.getAPIResponseString(URLParam.setAuthenticationAPIParam()))["data"]["AuthToken"].ToString();

            DataRow[] dr = dtInput.Select();
            //CALLING IRN GENERATING API FOR EACH VALID DATAROW-----------------------------------------------
            foreach (DataRow row in dr)
            {
                string docType = row["Doc_Typ"].ToString();
                string docNum = row["Doc_No"].ToString();
                string docDate = row["Doc_Dt"].ToString();

                string responseString = JObject.Parse(URLParam.getAPIResponseString(URLParam.getIRNByDocDetailsAPIParam(docType, docNum, docDate))).ToString();

                var status = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                if (status == "1")
                {
                    //IRN DETAILS INSERT-----------------------------------------------------------------------
                    DataRow dtIRN = dtIRNSave.NewRow();
                    dtIRN["eInvoiceRefNo"] = row["Erp_InvoiceId"].ToString();
                    dtIRN["AckNo"] = Convert.ToString(JObject.Parse(responseString)["data"]["AckNo"]);
                    dtIRN["AckDt"] = Convert.ToString(JObject.Parse(responseString)["data"]["AckDt"]);
                    dtIRN["IRN"] = Convert.ToString(JObject.Parse(responseString)["data"]["Irn"]);
                    dtIRN["SignedInvoice"] = Convert.ToString(JObject.Parse(responseString)["data"]["SignedInvoice"]);
                    dtIRN["SignedQRCode"] = Convert.ToString(JObject.Parse(responseString)["data"]["SignedQRCode"]);
                    dtIRN["Status"] = Convert.ToString(JObject.Parse(responseString)["data"]["Status"]);
                    dtIRN["EwbNo"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbNo"]);
                    dtIRN["EwbDt"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbDt"]);
                    dtIRN["EwbValidTill"] = Convert.ToString(JObject.Parse(responseString)["data"]["EwbValidTill"]);
                    dtIRN["Remarks"] = Convert.ToString(JObject.Parse(responseString)["data"]["Remarks"]);
                    dtIRN["status_cd"] = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                    dtIRN["status_desc"] = Convert.ToString(JObject.Parse(responseString)["status_desc"]);
                    dtIRNSave.Rows.Add(dtIRN);
                }
                else if (status == "0")
                {
                    //ERROR DETAILS INSERT-----------------------------------------------------------------------
                    DataRow drError = dtErrorSave.NewRow();
                    drError["Erp_InvoiceId"] = row["Erp_InvoiceId"].ToString();
                    drError["status_cd"] = Convert.ToString(JObject.Parse(responseString)["status_cd"]);
                    string statusDesc = Convert.ToString(JObject.Parse(responseString)["status_desc"]);
                    statusDesc = statusDesc.Replace("[", string.Empty).Replace("]", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
                    int i = statusDesc.IndexOf(":");
                    int j = statusDesc.IndexOf(",");
                    string ErrorCode = statusDesc.Substring(i + 1, j - i - 1).Replace("\"", "");
                    drError["ErrorCode"] = ErrorCode.ToString();
                    string ErrorMessage = statusDesc.Substring(j - 1);
                    i = ErrorMessage.IndexOf(":");
                    ErrorMessage = ErrorMessage.Substring(i + 1).Replace("\"", "");
                    drError["ErrorMessage"] = ErrorMessage.ToString();
                    dtErrorSave.Rows.Add(drError);
                }
                else
                {
                    Console.WriteLine("SRMasterGSTPlugin.getIRNByDocDetails >\t APPLICATION ERROR!");
                }
            }
        }

        //GST DATATABLE
        public static DataTable DataTableForGST()
        {
            DataTable dtGSTSave = new DataTable("GST DETAILS DATATABLE");
            dtGSTSave.Clear();
            dtGSTSave.Columns.Add("Gstin");
            dtGSTSave.Columns.Add("TradeName");
            dtGSTSave.Columns.Add("LegalName");
            dtGSTSave.Columns.Add("AddrBnm");
            dtGSTSave.Columns.Add("AddrBno");
            dtGSTSave.Columns.Add("AddrFlno");
            dtGSTSave.Columns.Add("AddrSt");
            dtGSTSave.Columns.Add("AddrLoc");
            dtGSTSave.Columns.Add("StateCode");
            dtGSTSave.Columns.Add("AddrPncd");
            dtGSTSave.Columns.Add("TxpType");
            dtGSTSave.Columns.Add("Status");
            dtGSTSave.Columns.Add("BlkStatus");
            dtGSTSave.Columns.Add("DtReg");
            dtGSTSave.Columns.Add("DtDReg");
            dtGSTSave.Columns.Add("status_cd");
            dtGSTSave.Columns.Add("status_desc");
            return dtGSTSave;
        }

        //IRN DATATABLE
        public static DataTable DataTableForIRN()
        {
            DataTable dtIRNSave = new DataTable("IRN DATATABLE");
            dtIRNSave.Clear();
            dtIRNSave.Columns.Add("eInvoiceRefNo");
            dtIRNSave.Columns.Add("AckNo");
            dtIRNSave.Columns.Add("AckDt");
            dtIRNSave.Columns.Add("IRN");
            dtIRNSave.Columns.Add("SignedInvoice");
            dtIRNSave.Columns.Add("SignedQRCode");
            dtIRNSave.Columns.Add("Status");
            dtIRNSave.Columns.Add("EwbNo");
            dtIRNSave.Columns.Add("EwbDt");
            dtIRNSave.Columns.Add("EwbValidTill");
            dtIRNSave.Columns.Add("Remarks");
            dtIRNSave.Columns.Add("status_cd");
            dtIRNSave.Columns.Add("status_desc");
            return dtIRNSave;
        }

        //ERROR DATATABLE
        public static DataTable DataTableForError()
        {
            DataTable dtErrorSave = new DataTable("ERROR DATATABLE");
            dtErrorSave.Clear();
            dtErrorSave.Columns.Add("Erp_InvoiceId");
            dtErrorSave.Columns.Add("status_cd");
            dtErrorSave.Columns.Add("ErrorCode");
            dtErrorSave.Columns.Add("ErrorMessage");
            return dtErrorSave;
        }
        
        //CANCEL DATATABLE
        public static DataTable DataTableForCancelIRN()
        {
            DataTable dtErrorSave = new DataTable("CANCEL DATATABLE");
            dtErrorSave.Clear();
            dtErrorSave.Columns.Add("eInvoiceId");
            dtErrorSave.Columns.Add("Irn");
            dtErrorSave.Columns.Add("CnlRem");
            dtErrorSave.Columns.Add("CnDate");
            return dtErrorSave;
        }
        
        //PRINT DATATABLE DATATABLE
        public static void PrintDataTable(DataTable dt)
        {
            Console.WriteLine("PRINTING > " + dt.TableName.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.Write(column.ColumnName + " | \t");
                }
                Console.WriteLine();
                foreach (var item in dr.ItemArray)
                {
                    Console.Write(item + " | \t");
                }
                Console.WriteLine();
            }
        }
    }
}
