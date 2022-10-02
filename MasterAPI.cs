using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SRMasterGST
{
    public class MasterAPI
    {
        public const string NICGST = "https://einv-apisandbox.nic.in/api-error-codes-list.html";
        public const string MASTERGST = "https://mastergst.com/gst/e-invoice-api.html#/Get%20EInvoice%20Details";

        public const string URL_Base= "https://api.mastergst.com";
        public const string URL_AUTHENTICATION_GET = "/einvoice/authenticate";
        public const string URL_GSTN_DETAILS_GET = "/einvoice/type/GSTNDETAILS/version/V1_03";
        public const string URL_GET_SYNC_GSTIN_CP_DETAILS_GET = "/einvoice/type/SYNC_GSTIN_FROMCP/version/V1_03";
        public const string URL_GENERATE_IRN_POST = "/einvoice/type/GENERATE/version/V1_03";
        public const string URL_GET_IRN_BY_DOCDETAILS_GET = "/einvoice/type/GETIRNBYDOCDETAILS/version/V1_03";
        public const string URL_GET_EINVOICE_DETAILS_GET = "/einvoice/type/GETIRN/version/V1_03";
        public const string URL_CANCEL_IRN_POST = "​/einvoice/type/CANCEL/version/V1_03";
        public const string URL_GENERATE_EWAYBILL_POST = "/einvoice/type/GENERATE_EWAYBILL/version/V1_03";
        public const string URL_GET_EWAYBILL_DETAILS_BY_IRN_GET ="/einvoice/type/GETEWAYBILLIRN/version/V1_03";
    }

    public class URL_Parameters
    {
        //ALL PARAMETERS-----------------------------------------------------------------------------------
        public string registred_email { get; set; }     
        public string username { get; set; }            
        public string password { get; set; }            
        public string ip_address { get; set; }          
        public string client_id { get; set; }           
        public string client_secret { get; set; }       
        public string gstin { get; set; }               
        public string auth_token { get; set; }          

   
        //SETTING PARAMETERS USING CONSTRUCTOR---------------------------------------------------------------
        public URL_Parameters(string registred_email, string username, string password, string ip_address, string client_id, string client_secret, string gstin, string auth_token = null)
        {
            this.registred_email = registred_email;
            this.username = username;
            this.password = password;
            this.ip_address = ip_address;
            this.client_id = client_id;
            this.client_secret = client_secret;
            this.gstin = gstin;
            this.auth_token = auth_token;
        }
        
        //ALL API CALL---------------------------------------------------------------------------------------
        //SETTING AUTENTICATION API PARAMETERS [GET]
        public WebRequest setAuthenticationAPIParam()
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_AUTHENTICATION_GET + "?email=" + this.registred_email;
                var webRequest = System.Net.WebRequest.Create(URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("username", this.username);
                    webRequest.Headers.Add("password", this.password);
                    webRequest.Headers.Add("ip_address", this.ip_address);
                    webRequest.Headers.Add("client_id", this.client_id);
                    webRequest.Headers.Add("client_secret", this.client_secret);
                    webRequest.Headers.Add("gstin", this.gstin);
                }
                return webRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GSTN DETAILS API PARAMETERS [GET]
        public WebRequest setGstnDetailsAPIParam(string gstn)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GSTN_DETAILS_GET + "?param1=" + gstn + "&email=" + this.registred_email;

                var webRequest = System.Net.WebRequest.Create(URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("ip_address", this.ip_address);
                    webRequest.Headers.Add("client_id", this.client_id);
                    webRequest.Headers.Add("client_secret", this.client_secret);
                    webRequest.Headers.Add("username", this.username);
                    webRequest.Headers.Add("auth-token", this.auth_token);
                    webRequest.Headers.Add("gstin", this.gstin);
                }
                return webRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GSTN_CP DETAILS API PARAMETERS - RETURN OBJECT [GET]
        public WebRequest setSyncGstnDetailsAPIParam(string gstn)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GET_SYNC_GSTIN_CP_DETAILS_GET + "?param1=" + gstn + "&email=" + this.registred_email;

                WebRequest request = WebRequest.Create(URL); 
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 30000;
                request.Headers.Add("ip_address", this.ip_address);
                request.Headers.Add("client_id", this.client_id);
                request.Headers.Add("client_secret", this.client_secret);
                request.Headers.Add("username", this.username);
                request.Headers.Add("auth-token", this.auth_token);
                request.Headers.Add("gstin", this.gstin);
                
                return request; 
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GSTN_CP DETAILS API PARAMETERS - RETURN STRING RESPONSE [GET]
        public string GetSyncGSTINFromCPAPIParam(string gstn)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GET_SYNC_GSTIN_CP_DETAILS_GET + "?param1=" + gstn + "&email=" + this.registred_email;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("ip_address", this.ip_address);
                client.DefaultRequestHeaders.Add("client_id", this.client_id);
                client.DefaultRequestHeaders.Add("client_secret", this.client_secret);
                client.DefaultRequestHeaders.Add("username", this.username);
                client.DefaultRequestHeaders.Add("auth-token", this.auth_token);
                client.DefaultRequestHeaders.Add("gstin", this.gstin);

                var str = client.GetStringAsync(URL).Result; //response.Content.ReadAsStringAsync().Result;
                return str.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GENERATE IRN PARAMETERS [POST] 
        public WebRequest setGenerateIRNAPIParam(string generateIRNPostRequestBodyJSON)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GENERATE_IRN_POST + "?email=" + this.registred_email;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (httpWebRequest != null)
                {
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Timeout = 12000;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("ip_address", this.ip_address);
                    httpWebRequest.Headers.Add("client_id", this.client_id);
                    httpWebRequest.Headers.Add("client_secret", client_secret);
                    httpWebRequest.Headers.Add("username", this.username);
                    httpWebRequest.Headers.Add("auth-token", this.auth_token);
                    httpWebRequest.Headers.Add("gstin", this.gstin);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(generateIRNPostRequestBodyJSON);
                    }
                }
                return httpWebRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GET IRN DETAILS BY DOCUMENT DETAILS PARAMETERS [GET] 
        public WebRequest getIRNByDocDetailsAPIParam(string docType, string docnum, string docdate, string supplierGstn=null)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GET_IRN_BY_DOCDETAILS_GET + "?param1=" + docType + "&email=" + this.registred_email + "&supplier_gstn="+supplierGstn;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (httpWebRequest != null)
                {
                    httpWebRequest.Method = "GET";
                    httpWebRequest.Timeout = 12000;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("ip_address", this.ip_address);
                    httpWebRequest.Headers.Add("client_id", this.client_id);
                    httpWebRequest.Headers.Add("client_secret", client_secret);
                    httpWebRequest.Headers.Add("username", this.username);
                    httpWebRequest.Headers.Add("auth-token", this.auth_token);
                    httpWebRequest.Headers.Add("gstin", this.gstin);

                    httpWebRequest.Headers.Add("docnum", docnum);
                    httpWebRequest.Headers.Add("docdate", docdate);
                }
                return httpWebRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING  GET EINVOICE DETAILS PARAMETERS [GET] 
        public WebRequest setGetEInvoiceDetailsAPIParam(string irn, string supplier_gstn=null)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GET_EINVOICE_DETAILS_GET + "?param1=" + irn + "&email=" + this.registred_email + "&supplier_gstn=" + supplier_gstn;
                var webRequest = System.Net.WebRequest.Create(URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("ip_address", this.ip_address);
                    webRequest.Headers.Add("client_id", this.client_id);
                    webRequest.Headers.Add("client_secret", this.client_secret);
                    webRequest.Headers.Add("username", this.username);
                    webRequest.Headers.Add("auth-token", this.auth_token);
                    webRequest.Headers.Add("gstin", this.gstin);
                }
                return webRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING CANCEL IRN PARAMETERS [POST] 
        public WebRequest setCancelIRNAPIParam(string cancelIRNPostRequestBodyJSON)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_CANCEL_IRN_POST + "?email=" + this.registred_email;
                                
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (httpWebRequest != null)
                {
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Timeout = 12000;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("ip_address", this.ip_address);
                    httpWebRequest.Headers.Add("client_id", this.client_id);
                    httpWebRequest.Headers.Add("client_secret", client_secret);
                    httpWebRequest.Headers.Add("username", this.username);
                    httpWebRequest.Headers.Add("auth-token", this.auth_token);
                    httpWebRequest.Headers.Add("gstin", this.gstin); 
                    
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(cancelIRNPostRequestBodyJSON);
                    }
                }
                return httpWebRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }      

        //SETTING GENERATE EWAY BILL PARAMETERS [POST] 
        public WebRequest setGenerateEwaybillAPIParam(string generateEwayBillPostRequestBodyJSON)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GENERATE_EWAYBILL_POST + "?email=" + this.registred_email;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (httpWebRequest != null)
                {
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Timeout = 12000;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Headers.Add("ip_address", this.ip_address);
                    httpWebRequest.Headers.Add("client_id", this.client_id);
                    httpWebRequest.Headers.Add("client_secret", client_secret);
                    httpWebRequest.Headers.Add("username", this.username);
                    httpWebRequest.Headers.Add("auth-token", this.auth_token);
                    httpWebRequest.Headers.Add("gstin", this.gstin);

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(generateEwayBillPostRequestBodyJSON);
                    }
                }
                return httpWebRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //SETTING GET EWAYBILL DETAILS BY IRN PARAMETERS [GET]
        public WebRequest setGetEwaybillDetailsByIRNAPIParam(string irn, string supplier_gstn = null)
        {
            try
            {
                string URL = MasterAPI.URL_Base + MasterAPI.URL_GET_EWAYBILL_DETAILS_BY_IRN_GET + "?param1=" + irn + "&supplier_gstn=" + supplier_gstn + "&email=" + this.registred_email;
                var webRequest = System.Net.WebRequest.Create(URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("ip_address", this.ip_address);
                    webRequest.Headers.Add("client_id", this.client_id);
                    webRequest.Headers.Add("client_secret", this.client_secret);
                    webRequest.Headers.Add("username", this.username);
                    webRequest.Headers.Add("auth-token", this.auth_token);
                    webRequest.Headers.Add("gstin", this.gstin);
                }
                return webRequest;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //GENERATE JSON RESPONSE STRING FROM WEBREQUEST------------------------------------------------------
        public string getAPIResponseString(WebRequest httpWebRequest)
        {
            try
            {
                if (httpWebRequest != null)
                {
                    //*
                    using (System.IO.Stream stream = httpWebRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
                        {
                            string responseString = string.Empty;
                            responseString = streamReader.ReadToEnd();
                            return responseString;
                        }
                    }
                }
                return "Response Object Null!";
            }
            catch (WebException wexp)
            {
                using (var stream = wexp.Response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        Console.WriteLine("WEBEXCEPTION > " + reader.ReadToEnd());
                    }
                }
                throw wexp;
            }
            catch (Exception exp)
            {
                Console.WriteLine("INNER EXP > "+exp.InnerException.ToString());
                throw exp;
            }
        }

    }
}
