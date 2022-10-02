using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SRMasterGST
{
    //GENERATE IRN CLASS
    public class Generate_IRN
    {
        public string Version { get; set; }

        public class tranDtls
        {
            public string TaxSch { get; set; }
            public string SupTyp { get; set; }
            public string RegRev { get; set; }
            public string EcmGstin { get; set; }
            public string IgstOnIntra { get; set; }
        }
        public tranDtls TranDtls { get; set; }

        public class docDtls
        {
            public string Typ { get; set; }
            public string No { get; set; }
            public string Dt { get; set; }
        }
        public docDtls DocDtls { get; set; }

        public class sellerDtls
        {
            public string Gstin { get; set; }
            public string LglNm { get; set; }
            public string TrdNm { get; set; }
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Loc { get; set; }
            public int Pin { get; set; }
            public string Stcd { get; set; }
            public string Ph { get; set; }
            public string Em { get; set; }
        }
        public sellerDtls SellerDtls { get; set; }

        public class buyerDtls
        {
            public string Gstin { get; set; }
            public string LglNm { get; set; }
            public string TrdNm { get; set; }
            public string Pos { get; set; }
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Loc { get; set; }
            public int Pin { get; set; }
            public string Stcd { get; set; }
            public string Ph { get; set; }
            public string Em { get; set; }
        }
        public buyerDtls BuyerDtls { get; set; }

        public class dispDtls
        {
            public string Nm { get; set; }
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Loc { get; set; }
            public int Pin { get; set; }
            public string Stcd { get; set; }
        }
        public dispDtls DispDtls { get; set; }

        public class shipDtls
        {
            public string Gstin { get; set; }
            public string LglNm { get; set; }
            public string TrdNm { get; set; }
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Loc { get; set; }
            public int Pin { get; set; }
            public string Stcd { get; set; }
        }
        public shipDtls ShipDtls { get; set; }

        public class itemList
        {
            public string SlNo { get; set; }
            public string IsServc { get; set; }
            public string PrdDesc { get; set; }
            public string HsnCd { get; set; }
            public string Barcde { get; set; }

            public class bchDtls
            {
                public string Nm { get; set; }
                public string Expdt { get; set; }
                public string wrDt { get; set; }
            }
            public bchDtls BchDtls { get; set; }

            public decimal? Qty { get; set; }
            public decimal? FreeQty { get; set; }
            public string Unit { get; set; }
            public decimal? UnitPrice { get; set; }
            public decimal? TotAmt { get; set; }
            public decimal? Discount { get; set; }
            public decimal? PreTaxVal { get; set; }
            public decimal? AssAmt { get; set; }
            public decimal? GstRt { get; set; }
            public decimal? SgstAmt { get; set; }
            public decimal? IgstAmt { get; set; }
            public decimal? CgstAmt { get; set; }
            public decimal? CesRt { get; set; }
            public decimal? CesAmt { get; set; }
            public decimal? CesNonAdvlAmt { get; set; }
            public decimal? StateCesRt { get; set; }
            public decimal? StateCesAmt { get; set; }
            public decimal? StateCesNonAdvlAmt { get; set; }
            public decimal? OthChrg { get; set; }
            public decimal? TotItemVal { get; set; }
            public string OrdLineRef { get; set; }
            public string OrgCntry { get; set; }
            public string PrdSlNo { get; set; }

            public class attribDtls
            {
                public string Nm { get; set; }
                public string Val { get; set; }
            }
            public List<attribDtls> AttribDtls { get; set; }
        }
        public List<itemList> ItemList { get; set; }

        public class valDtls
        {
            public decimal? AssVal { get; set; }
            public decimal? CgstVal { get; set; }
            public decimal? SgstVal { get; set; }
            public decimal? IgstVal { get; set; }
            public decimal? CesVal { get; set; }
            public decimal? StCesVal { get; set; }
            public decimal? Discount { get; set; }
            public decimal? OthChrg { get; set; }
            public decimal? RndOffAmt { get; set; }
            public decimal? TotInvVal { get; set; }
            public decimal? TotInvValFc { get; set; }
        }
        public valDtls ValDtls { get; set; }

        public class payDtls
        {
            public string Nm { get; set; }
            public string Accdet { get; set; }
            public string Mode { get; set; }
            public string Fininsbr { get; set; }
            public string Payterm { get; set; }
            public string Payinstr { get; set; }
            public string Crtrn { get; set; }
            public string Dirdr { get; set; }
            public Int32? Crday { get; set; }
            public decimal? Paidamt { get; set; }
            public decimal? Paymtdue { get; set; }
        }
        public payDtls PayDtls { get; set; }

        public class refDtls
        {
            public string InvRm { get; set; }
            public class docPerdDtls
            {
                public string InvStDt { get; set; }
                public string InvEndDt { get; set; }
            }
            public docPerdDtls DocPerdDtls { get; set; }

            public class precDocDtls
            {
                public string InvNo { get; set; }
                public string InvDt { get; set; }
                public string OthRefNo { get; set; }
            }
            public List<precDocDtls> PrecDocDtls { get; set; }

            public class contrDtls
            {
                public string RecAdvRefr { get; set; }
                public string RecAdvDt { get; set; }
                public string Tendrefr { get; set; }
                public string Contrrefr { get; set; }
                public string Extrefr { get; set; }
                public string Projrefr { get; set; }
                public string Porefr { get; set; }
                public string PoRefDt { get; set; }
            }
            public List<contrDtls> ContrDtls { get; set; }
        }
        public refDtls RefDtls { get; set; }

        public class addlDocDtls
        {
            public string Url { get; set; }
            public string Docs { get; set; }
            public string Info { get; set; }
        }
        public List<addlDocDtls> AddlDocDtls { get; set; }


        public class expDtls
        {
            public string ShipBNo { get; set; }
            public string ShipBDt { get; set; }
            public string Port { get; set; }
            public string RefClm { get; set; }
            public string ForCur { get; set; }
            public string CntCode { get; set; }
        }
        public expDtls ExpDtls { get; set; }


        public class ewbDtls
        {
            public string Transid { get; set; }
            public string Transname { get; set; }
            public Int32? Distance { get; set; }
            public string Transdocno { get; set; }
            public string TransdocDt { get; set; }
            public string Vehno { get; set; }
            public string Vehtype { get; set; }
            public string TransMode { get; set; }
        }
        public ewbDtls EwbDtls { get; set; }
    }

    //CANCEL IRN CLASS
    public class Cancel_IRN
    {
        public string Irn { get; set; }
        public string CnlRsn { get; set; }
        public string CnlRem { get; set; }
    }

    //GENERATE EWAYBILL IRN CLASS
    public class Generate_Ewaybill_IRN
    {
        public string Irn { get; set; }
        public string Distance { get; set; }
        public string TransMode { get; set; }
        public string TransId { get; set; }
        public string TransName { get; set; }
        public string TransDocDt { get; set; }
        public string TransDocNo { get; set; }
        public string VehNo { get; set; }
        public string VehType { get; set; }
    }
    
    //POST REQUEST BODY MODEL CLASS
    public class PostRequestBody
    {
        public Generate_IRN generate_IRN { get; set; }
        public Cancel_IRN cancel_IRN { get; set; }
        public Generate_Ewaybill_IRN generate_Ewaybill_IRN { get; set; }

        //GENERATE IRN POST REQUEST BODY
        public Generate_IRN generateIRNRequestBody(DataRow dr)
        {
            //CREATING IRN CLASS OBJECT-----------------------------------
            this.generate_IRN = new Generate_IRN();


            //INITALIZING IRN OBJECT--------------------------------------
            generate_IRN.Version = (dr["Version"].ToString() == "" || dr["Version"].ToString().Length < 0) ? null : dr["Version"].ToString();


            //TranDyls------------------------------------------------------------------------------------	
            if (dr["Tran_TaxSch"].ToString().Trim() != "" && dr["Tran_TaxSch"].ToString().Trim().Length > 0)
            {
                generate_IRN.TranDtls = new Generate_IRN.tranDtls();
                generate_IRN.TranDtls.TaxSch = (dr["Tran_TaxSch"].ToString() == "" || dr["Tran_TaxSch"].ToString().Length < 0) ? null : dr["Tran_TaxSch"].ToString();
                generate_IRN.TranDtls.SupTyp = (dr["Tran_SupTyp"].ToString() == "" || dr["Tran_SupTyp"].ToString().Length < 0) ? null : dr["Tran_SupTyp"].ToString();
                generate_IRN.TranDtls.RegRev = (dr["Tran_RegRev"].ToString() == "" || dr["Tran_RegRev"].ToString().Length < 0) ? null : dr["Tran_RegRev"].ToString();
                generate_IRN.TranDtls.EcmGstin = (dr["Tran_EcmGstin"].ToString() == "" || dr["Tran_EcmGstin"].ToString().Length < 0) ? null : dr["Tran_EcmGstin"].ToString();
                generate_IRN.TranDtls.IgstOnIntra = (dr["Tran_IgstOnIntra"].ToString() == "" || dr["Tran_IgstOnIntra"].ToString().Length < 0) ? null : dr["Tran_IgstOnIntra"].ToString();
            }

            //DocDtls------------------------------------------------------------------------------------	
            if (dr["Doc_Typ"].ToString().Trim() != "" && dr["Doc_Typ"].ToString().Trim().Length > 0)
            {
                generate_IRN.DocDtls = new Generate_IRN.docDtls();
                generate_IRN.DocDtls.Typ = (dr["Doc_Typ"].ToString() == "" || dr["Doc_Typ"].ToString().Length < 0) ? null : dr["Doc_Typ"].ToString();
                generate_IRN.DocDtls.No = (dr["Doc_No"].ToString() == "" || dr["Doc_No"].ToString().Length < 0) ? null : dr["Doc_No"].ToString();
                generate_IRN.DocDtls.Dt = (dr["Doc_Dt"].ToString() == "" || dr["Doc_Dt"].ToString().Length < 0) ? null : dr["Doc_Dt"].ToString();
            }

            //SellerDtls------------------------------------------------------------------------------------	
            if (dr["Seller_Gstin"].ToString().Trim() != "" && dr["Seller_Gstin"].ToString().Trim().Length > 0)
            {
                generate_IRN.SellerDtls = new Generate_IRN.sellerDtls();
                generate_IRN.SellerDtls.Gstin = (dr["Seller_Gstin"].ToString() == "" || dr["Seller_Gstin"].ToString().Length < 0) ? null : dr["Seller_Gstin"].ToString();
                generate_IRN.SellerDtls.LglNm = (dr["Seller_LglNm"].ToString() == "" || dr["Seller_LglNm"].ToString().Length < 0) ? null : dr["Seller_LglNm"].ToString();
                generate_IRN.SellerDtls.TrdNm = (dr["Seller_TrdNm"].ToString() == "" || dr["Seller_TrdNm"].ToString().Length < 0) ? null : dr["Seller_TrdNm"].ToString();
                generate_IRN.SellerDtls.Addr1 = (dr["Seller_Addr1"].ToString() == "" || dr["Seller_Addr1"].ToString().Length < 0) ? null : dr["Seller_Addr1"].ToString();
                generate_IRN.SellerDtls.Addr2 = (dr["Seller_Addr2"].ToString() == "" || dr["Seller_Addr2"].ToString().Length < 0) ? null : dr["Seller_Addr2"].ToString();
                generate_IRN.SellerDtls.Loc = (dr["Seller_Loc"].ToString() == "" || dr["Seller_Loc"].ToString().Length < 0) ? null : dr["Seller_Loc"].ToString();
                generate_IRN.SellerDtls.Pin = (dr["Seller_Pin"].ToString() == "" || dr["Seller_Pin"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Seller_Pin"].ToString());
                generate_IRN.SellerDtls.Stcd = (dr["Seller_Stcd"].ToString() == "" || dr["Seller_Stcd"].ToString().Length < 0) ? null : dr["Seller_Stcd"].ToString();
                generate_IRN.SellerDtls.Ph = (dr["Seller_Ph"].ToString() == "" || dr["Seller_Ph"].ToString().Length < 0) ? null : dr["Seller_Ph"].ToString();
                generate_IRN.SellerDtls.Em = (dr["Seller_Em"].ToString() == "" || dr["Seller_Em"].ToString().Length < 0) ? null : dr["Seller_Em"].ToString();
            }

            //BuyerDtls------------------------------------------------------------------------------------		
            if (dr["Buyer_Gstin"].ToString().Trim() != "" && dr["Buyer_Gstin"].ToString().Trim().Length > 0)
            {
                generate_IRN.BuyerDtls = new Generate_IRN.buyerDtls();
                generate_IRN.BuyerDtls.Gstin = (dr["Buyer_Gstin"].ToString() == "" || dr["Buyer_Gstin"].ToString().Length < 0) ? null : dr["Buyer_Gstin"].ToString();
                generate_IRN.BuyerDtls.LglNm = (dr["Buyer_LglNm"].ToString() == "" || dr["Buyer_LglNm"].ToString().Length < 0) ? null : dr["Buyer_LglNm"].ToString();
                generate_IRN.BuyerDtls.TrdNm = (dr["Buyer_TrdNm"].ToString() == "" || dr["Buyer_TrdNm"].ToString().Length < 0) ? null : dr["Buyer_TrdNm"].ToString();
                generate_IRN.BuyerDtls.Pos = (dr["Buyer_Pos"].ToString() == "" || dr["Buyer_Pos"].ToString().Length < 0) ? null : dr["Buyer_Pos"].ToString();
                generate_IRN.BuyerDtls.Addr1 = (dr["Buyer_Addr1"].ToString() == "" || dr["Buyer_Addr1"].ToString().Length < 0) ? null : dr["Buyer_Addr1"].ToString();
                generate_IRN.BuyerDtls.Addr2 = (dr["Buyer_Addr2"].ToString() == "" || dr["Buyer_Addr2"].ToString().Length < 0) ? null : dr["Buyer_Addr2"].ToString();
                generate_IRN.BuyerDtls.Loc = (dr["Buyer_Loc"].ToString() == "" || dr["Buyer_Loc"].ToString().Length < 0) ? null : dr["Buyer_Loc"].ToString();
                generate_IRN.BuyerDtls.Pin = (dr["Buyer_Pin"].ToString() == "" || dr["Buyer_Pin"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Buyer_Pin"].ToString());
                generate_IRN.BuyerDtls.Stcd = (dr["Buyer_Stcd"].ToString() == "" || dr["Buyer_Stcd"].ToString().Length < 0) ? null : dr["Buyer_Stcd"].ToString();
                generate_IRN.BuyerDtls.Ph = (dr["Buyer_Ph"].ToString() == "" || dr["Buyer_Ph"].ToString().Length < 0) ? null : dr["Buyer_Ph"].ToString();
                generate_IRN.BuyerDtls.Em = (dr["Buyer_Em"].ToString() == "" || dr["Buyer_Em"].ToString().Length < 0) ? null : dr["Buyer_Em"].ToString();
            }

            //DispDtls------------------------------------------------------------------------------------		
            if (dr["Disp_Nm"].ToString().Trim() != "" && dr["Disp_Nm"].ToString().Trim().Length > 0) 
            {
                generate_IRN.DispDtls = new Generate_IRN.dispDtls();
                generate_IRN.DispDtls.Nm = (dr["Disp_Nm"].ToString() == "" || dr["Disp_Nm"].ToString().Length < 0) ? null : dr["Disp_Nm"].ToString();
                generate_IRN.DispDtls.Addr1 = (dr["Disp_Addr1"].ToString() == "" || dr["Disp_Addr1"].ToString().Length < 0) ? null : dr["Disp_Addr1"].ToString();
                generate_IRN.DispDtls.Addr2 = (dr["Disp_Addr2"].ToString() == "" || dr["Disp_Addr2"].ToString().Length < 0) ? null : dr["Disp_Addr2"].ToString();
                generate_IRN.DispDtls.Loc = (dr["Disp_Loc"].ToString() == "" || dr["Disp_Loc"].ToString().Length < 0) ? null : dr["Disp_Loc"].ToString();
                generate_IRN.DispDtls.Pin = (dr["Disp_Pin"].ToString() == "" || dr["Disp_Pin"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Disp_Pin"].ToString());
                generate_IRN.DispDtls.Stcd = (dr["Disp_Stcd"].ToString() == "" || dr["Disp_Stcd"].ToString().Length < 0) ? null : dr["Disp_Stcd"].ToString();
            }

            //ShipDtls------------------------------------------------------------------------------------	
            if(dr["Ship_Gstin"].ToString().Trim() != "" && dr["Ship_Gstin"].ToString().Trim().Length > 0) 
            {
                generate_IRN.ShipDtls = new Generate_IRN.shipDtls();
                generate_IRN.ShipDtls.Gstin = (dr["Ship_Gstin"].ToString() == "" || dr["Ship_Gstin"].ToString().Length < 0) ? null : dr["Ship_Gstin"].ToString();
                generate_IRN.ShipDtls.LglNm = (dr["Ship_LglNm"].ToString() == "" || dr["Ship_LglNm"].ToString().Length < 0) ? null : dr["Ship_LglNm"].ToString();
                generate_IRN.ShipDtls.TrdNm = (dr["Ship_TrdNm"].ToString() == "" || dr["Ship_TrdNm"].ToString().Length < 0) ? null : dr["Ship_TrdNm"].ToString();
                generate_IRN.ShipDtls.Addr1 = (dr["Ship_Addr1"].ToString() == "" || dr["Ship_Addr1"].ToString().Length < 0) ? null : dr["Ship_Addr1"].ToString();
                generate_IRN.ShipDtls.Addr2 = (dr["Ship_Addr2"].ToString() == "" || dr["Ship_Addr2"].ToString().Length < 0) ? null : dr["Ship_Addr2"].ToString();
                generate_IRN.ShipDtls.Loc = (dr["Ship_Loc"].ToString() == "" || dr["Ship_Loc"].ToString().Length < 0) ? null : dr["Ship_Loc"].ToString();
                generate_IRN.ShipDtls.Pin = (dr["Ship_Pin"].ToString() == "" || dr["Ship_Pin"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Ship_Pin"].ToString());
                generate_IRN.ShipDtls.Stcd = (dr["Ship_Stcd"].ToString() == "" || dr["Ship_Stcd"].ToString().Length < 0) ? null : dr["Ship_Stcd"].ToString();
            }

            //ItemList[]------------------------------------------------------------------------------------
            if (dr["Item_SlNo"].ToString().Trim() != "" && dr["Item_SlNo"].ToString().Trim().Length > 0)
            {
                generate_IRN.ItemList = new List<Generate_IRN.itemList>();
                generate_IRN.ItemList.Add(new Generate_IRN.itemList());
                generate_IRN.ItemList[0].SlNo = (dr["Item_SlNo"].ToString() == "" || dr["Item_SlNo"].ToString().Length < 0) ? null : dr["Item_SlNo"].ToString();
                generate_IRN.ItemList[0].IsServc = (dr["Item_IsServc"].ToString() == "" || dr["Item_IsServc"].ToString().Length < 0) ? null : dr["Item_IsServc"].ToString();
                generate_IRN.ItemList[0].PrdDesc = (dr["Item_PrdDesc"].ToString() == "" || dr["Item_PrdDesc"].ToString().Length < 0) ? null : dr["Item_PrdDesc"].ToString();
                generate_IRN.ItemList[0].HsnCd = (dr["Item_HsnCd"].ToString() == "" || dr["Item_HsnCd"].ToString().Length < 0) ? null : dr["Item_HsnCd"].ToString();
                generate_IRN.ItemList[0].Barcde = (dr["Item_Barcde"].ToString() == "" || dr["Item_Barcde"].ToString().Length < 0) ? null : dr["Item_Barcde"].ToString();

                //ItemList.BchDtls------------------------------------------------------------------------------------
                if (dr["Item_Bch_Nm"].ToString().Trim() != "" && dr["Item_Bch_Nm"].ToString().Trim().Length > 0)
                {
                    generate_IRN.ItemList[0].BchDtls = new Generate_IRN.itemList.bchDtls();
                    generate_IRN.ItemList[0].BchDtls.Nm = (dr["Item_Bch_Nm"].ToString() == "" || dr["Item_Bch_Nm"].ToString().Length < 0) ? null : dr["Item_Bch_Nm"].ToString();
                    generate_IRN.ItemList[0].BchDtls.Expdt = (dr["Item_Bch_ExpDt"].ToString() == "" || dr["Item_Bch_ExpDt"].ToString().Length < 0) ? null : dr["Item_Bch_ExpDt"].ToString();
                    generate_IRN.ItemList[0].BchDtls.wrDt = (dr["Item_Bch_WrDt"].ToString() == "" || dr["Item_Bch_WrDt"].ToString().Length < 0) ? null : dr["Item_Bch_WrDt"].ToString();
                }
                generate_IRN.ItemList[0].Qty = (dr["Item_Qty"].ToString() == "" || dr["Item_Qty"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_Qty"].ToString());
                generate_IRN.ItemList[0].FreeQty = (dr["Item_FreeQty"].ToString() == "" || dr["Item_FreeQty"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_FreeQty"].ToString());
                generate_IRN.ItemList[0].Unit = (dr["Item_Unit"].ToString() == "" || dr["Item_Unit"].ToString().Length < 0) ? null : dr["Item_Unit"].ToString();
                generate_IRN.ItemList[0].UnitPrice = (dr["Item_UnitPrice"].ToString() == "" || dr["Item_UnitPrice"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_UnitPrice"].ToString());
                generate_IRN.ItemList[0].TotAmt = (dr["Item_TotAmt"].ToString() == "" || dr["Item_TotAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_TotAmt"].ToString());
                generate_IRN.ItemList[0].Discount = (dr["Item_Discount"].ToString() == "" || dr["Item_Discount"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_Discount"].ToString());
                generate_IRN.ItemList[0].PreTaxVal = (dr["Item_PreTaxVal"].ToString() == "" || dr["Item_PreTaxVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_PreTaxVal"].ToString());
                generate_IRN.ItemList[0].AssAmt = (dr["Item_AssAmt"].ToString() == "" || dr["Item_AssAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_AssAmt"].ToString());
                generate_IRN.ItemList[0].GstRt = (dr["Item_GstRt"].ToString() == "" || dr["Item_GstRt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_GstRt"].ToString());
                generate_IRN.ItemList[0].SgstAmt = (dr["Item_SgstAmt"].ToString() == "" || dr["Item_SgstAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_SgstAmt"].ToString());
                generate_IRN.ItemList[0].IgstAmt = (dr["Item_IgstAmt"].ToString() == "" || dr["Item_IgstAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_IgstAmt"].ToString());
                generate_IRN.ItemList[0].CgstAmt = (dr["Item_CgstAmt"].ToString() == "" || dr["Item_CgstAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_CgstAmt"].ToString());
                generate_IRN.ItemList[0].CesRt = (dr["Item_CesRt"].ToString() == "" || dr["Item_CesRt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_CesRt"].ToString());
                generate_IRN.ItemList[0].CesAmt = (dr["Item_CesAmt"].ToString() == "" || dr["Item_CesAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_CesAmt"].ToString());
                generate_IRN.ItemList[0].CesNonAdvlAmt = (dr["Item_CesNonAdvlAmt"].ToString() == "" || dr["Item_CesNonAdvlAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_CesNonAdvlAmt"].ToString());
                generate_IRN.ItemList[0].StateCesRt = (dr["Item_StateCesRt"].ToString() == "" || dr["Item_StateCesRt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_StateCesRt"].ToString());
                generate_IRN.ItemList[0].StateCesAmt = (dr["Item_StateCesAmt"].ToString() == "" || dr["Item_StateCesAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_StateCesAmt"].ToString());
                generate_IRN.ItemList[0].StateCesNonAdvlAmt = (dr["Item_StateCesNonAdvlAmt"].ToString() == "" || dr["Item_StateCesNonAdvlAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_StateCesNonAdvlAmt"].ToString());
                generate_IRN.ItemList[0].OthChrg = (dr["Item_OthChrg"].ToString() == "" || dr["Item_OthChrg"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_OthChrg"].ToString());
                generate_IRN.ItemList[0].TotItemVal = (dr["Item_TotItemVal"].ToString() == "" || dr["Item_TotItemVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Item_TotItemVal"].ToString());
                generate_IRN.ItemList[0].OrdLineRef = (dr["Item_OrdLineRef"].ToString() == "" || dr["Item_OrdLineRef"].ToString().Length < 0) ? null : dr["Item_OrdLineRef"].ToString();
                generate_IRN.ItemList[0].OrgCntry = (dr["Item_OrgCntry"].ToString() == "" || dr["Item_OrgCntry"].ToString().Length < 0) ? null : dr["Item_OrgCntry"].ToString();
                generate_IRN.ItemList[0].PrdSlNo = (dr["Item_PrdSlNo"].ToString() == "" || dr["Item_PrdSlNo"].ToString().Length < 0) ? null : dr["Item_PrdSlNo"].ToString();
                //ItemList.AttribDtls[]------------------------------------------------------------------------------------
                if (dr["Item_Attrib_Nm"].ToString().Trim() != "" && dr["Item_Attrib_Nm"].ToString().Trim().Length > 0)
                {
                    generate_IRN.ItemList[0].AttribDtls = new List<Generate_IRN.itemList.attribDtls>();
                    generate_IRN.ItemList[0].AttribDtls.Add(new Generate_IRN.itemList.attribDtls());
                    generate_IRN.ItemList[0].AttribDtls[0].Nm = (dr["Item_Attrib_Nm"].ToString() == "" || dr["Item_Attrib_Nm"].ToString().Length < 0) ? null : dr["Item_Attrib_Nm"].ToString();
                    generate_IRN.ItemList[0].AttribDtls[0].Val = (dr["Item_Attrib_Val"].ToString() == "" || dr["Item_Attrib_Val"].ToString().Length < 0) ? null : dr["Item_Attrib_Val"].ToString();
                }
            }

            //ValDtls------------------------------------------------------------------------------------
            if (dr["Val_AssVal"].ToString().Trim() != "" && dr["Val_AssVal"].ToString().Trim().Length > 0)
            {
                generate_IRN.ValDtls = new Generate_IRN.valDtls();
                generate_IRN.ValDtls.AssVal = (dr["Val_AssVal"].ToString() == "" || dr["Val_AssVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_AssVal"].ToString());
                generate_IRN.ValDtls.CgstVal = (dr["Val_CgstVal"].ToString() == "" || dr["Val_CgstVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_CgstVal"].ToString());
                generate_IRN.ValDtls.SgstVal = (dr["Val_SgstVal"].ToString() == "" || dr["Val_SgstVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_SgstVal"].ToString());
                generate_IRN.ValDtls.IgstVal = (dr["Val_IgstVal"].ToString() == "" || dr["Val_IgstVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_IgstVal"].ToString());
                generate_IRN.ValDtls.CesVal = (dr["Val_CesVal"].ToString() == "" || dr["Val_CesVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_CesVal"].ToString());
                generate_IRN.ValDtls.StCesVal = (dr["Val_StCesVal"].ToString() == "" || dr["Val_StCesVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_StCesVal"].ToString());
                generate_IRN.ValDtls.Discount = (dr["Val_Discount"].ToString() == "" || dr["Val_Discount"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_Discount"].ToString());
                generate_IRN.ValDtls.OthChrg = (dr["Val_OthChrg"].ToString() == "" || dr["Val_OthChrg"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_OthChrg"].ToString());
                generate_IRN.ValDtls.RndOffAmt = (dr["Val_RndOffAmt"].ToString() == "" || dr["Val_RndOffAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_RndOffAmt"].ToString());
                generate_IRN.ValDtls.TotInvVal = (dr["Val_TotInvVal"].ToString() == "" || dr["Val_TotInvVal"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_TotInvVal"].ToString());
                generate_IRN.ValDtls.TotInvValFc = (dr["Val_TotInvValFc"].ToString() == "" || dr["Val_TotInvValFc"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Val_TotInvValFc"].ToString());
            }

            //PayDtls------------------------------------------------------------------------------------
            if (dr["Pay_Nm"].ToString().Trim() != "" && dr["Pay_Nm"].ToString().Trim().Length > 0) 
            {
                generate_IRN.PayDtls = new Generate_IRN.payDtls();
                generate_IRN.PayDtls.Nm = (dr["Pay_Nm"].ToString() == "" || dr["Pay_Nm"].ToString().Length < 0) ? null : dr["Pay_Nm"].ToString();
                generate_IRN.PayDtls.Accdet = (dr["Pay_AccDet"].ToString() == "" || dr["Pay_AccDet"].ToString().Length < 0) ? null : dr["Pay_AccDet"].ToString();
                generate_IRN.PayDtls.Mode = (dr["Pay_Mode"].ToString() == "" || dr["Pay_Mode"].ToString().Length < 0) ? null : dr["Pay_Mode"].ToString();
                generate_IRN.PayDtls.Fininsbr = (dr["Pay_FinInsBr"].ToString() == "" || dr["Pay_FinInsBr"].ToString().Length < 0) ? null : dr["Pay_FinInsBr"].ToString();
                generate_IRN.PayDtls.Payterm = (dr["Pay_PayTerm"].ToString() == "" || dr["Pay_PayTerm"].ToString().Length < 0) ? null : dr["Pay_PayTerm"].ToString();
                generate_IRN.PayDtls.Payinstr = (dr["Pay_PayInstr"].ToString() == "" || dr["Pay_PayInstr"].ToString().Length < 0) ? null : dr["Pay_PayInstr"].ToString();
                generate_IRN.PayDtls.Crtrn = (dr["Pay_CrTrn"].ToString() == "" || dr["Pay_CrTrn"].ToString().Length < 0) ? null : dr["Pay_CrTrn"].ToString();
                generate_IRN.PayDtls.Dirdr = (dr["Pay_DirDr"].ToString() == "" || dr["Pay_DirDr"].ToString().Length < 0) ? null : dr["Pay_DirDr"].ToString();
                generate_IRN.PayDtls.Crday = (dr["Pay_CrDay"].ToString() == "" || dr["Pay_CrDay"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Pay_CrDay"].ToString());
                generate_IRN.PayDtls.Paidamt = (dr["Pay_PaidAmt"].ToString() == "" || dr["Pay_PaidAmt"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Pay_PaidAmt"].ToString());
                generate_IRN.PayDtls.Paymtdue = (dr["Pay_PaymtDue"].ToString() == "" || dr["Pay_PaymtDue"].ToString().Length < 0) ? 0 : Convert.ToDecimal(dr["Pay_PaymtDue"].ToString());
            }

            //RefDtls------------------------------------------------------------------------------------
            if (dr["Ref_InvRm"].ToString().Trim() != "" && dr["Ref_InvRm"].ToString().Trim().Length > 0)
            {
                generate_IRN.RefDtls = new Generate_IRN.refDtls();
                generate_IRN.RefDtls.InvRm = (dr["Ref_InvRm"].ToString() == "" || dr["Ref_InvRm"].ToString().Length < 0) ? null : dr["Ref_InvRm"].ToString();
                //RefDtls.DocPerdDtls------------------------------------------------------------------------------------
                if (dr["Ref_DocPerd_InvStDt"].ToString().Trim() != "" && dr["Ref_DocPerd_InvStDt"].ToString().Trim().Length > 0)
                {
                    generate_IRN.RefDtls.DocPerdDtls = new Generate_IRN.refDtls.docPerdDtls();
                    generate_IRN.RefDtls.DocPerdDtls.InvStDt = (dr["Ref_DocPerd_InvStDt"].ToString() == "" || dr["Ref_DocPerd_InvStDt"].ToString().Length < 0) ? null : dr["Ref_DocPerd_InvStDt"].ToString();
                    generate_IRN.RefDtls.DocPerdDtls.InvEndDt = (dr["Ref_DocPerd_InvEndDt"].ToString() == "" || dr["Ref_DocPerd_InvEndDt"].ToString().Length < 0) ? null : dr["Ref_DocPerd_InvEndDt"].ToString();
                }
                //RefDtls.PrecDocDtls[]------------------------------------------------------------------------------------
                if (dr["Ref_PreDoc_InvNo"].ToString().Trim() != "" && dr["Ref_PreDoc_InvNo"].ToString().Trim().Length > 0)
                {
                    generate_IRN.RefDtls.PrecDocDtls = new List<Generate_IRN.refDtls.precDocDtls>();
                    generate_IRN.RefDtls.PrecDocDtls.Add(new Generate_IRN.refDtls.precDocDtls());
                    generate_IRN.RefDtls.PrecDocDtls[0].InvNo = (dr["Ref_PreDoc_InvNo"].ToString() == "" || dr["Ref_PreDoc_InvNo"].ToString().Length < 0) ? null : dr["Ref_PreDoc_InvNo"].ToString();
                    generate_IRN.RefDtls.PrecDocDtls[0].InvDt = (dr["Ref_PreDoc_InvDt"].ToString() == "" || dr["Ref_PreDoc_InvDt"].ToString().Length < 0) ? null : dr["Ref_PreDoc_InvDt"].ToString();
                    generate_IRN.RefDtls.PrecDocDtls[0].OthRefNo = (dr["Ref_PreDoc_OthRefNo"].ToString() == "" || dr["Ref_PreDoc_OthRefNo"].ToString().Length < 0) ? null : dr["Ref_PreDoc_OthRefNo"].ToString();
                }
                //RefDtls.ContrDtls[]------------------------------------------------------------------------------------
                if (dr["Ref_Contr_RecAdvRef"].ToString().Trim() != "" && dr["Ref_Contr_RecAdvRef"].ToString().Trim().Length > 0) 
                {
                    generate_IRN.RefDtls.ContrDtls = new List<Generate_IRN.refDtls.contrDtls>();
                    generate_IRN.RefDtls.ContrDtls.Add(new Generate_IRN.refDtls.contrDtls());
                    generate_IRN.RefDtls.ContrDtls[0].RecAdvRefr = (dr["Ref_Contr_RecAdvRef"].ToString() == "" || dr["Ref_Contr_RecAdvRef"].ToString().Length < 0) ? null : dr["Ref_Contr_RecAdvRef"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].RecAdvDt = (dr["Ref_Contr_RecAdvDt"].ToString() == "" || dr["Ref_Contr_RecAdvDt"].ToString().Length < 0) ? null : dr["Ref_Contr_RecAdvDt"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].Tendrefr = (dr["Ref_Contr_TendRefr"].ToString() == "" || dr["Ref_Contr_TendRefr"].ToString().Length < 0) ? null : dr["Ref_Contr_TendRefr"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].Contrrefr = (dr["Ref_Contr_ContrRef"].ToString() == "" || dr["Ref_Contr_ContrRef"].ToString().Length < 0) ? null : dr["Ref_Contr_ContrRef"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].Extrefr = (dr["Ref_Contr_ExtRefr"].ToString() == "" || dr["Ref_Contr_ExtRefr"].ToString().Length < 0) ? null : dr["Ref_Contr_ExtRefr"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].Projrefr = (dr["Ref_Contr_ProjRefr"].ToString() == "" || dr["Ref_Contr_ProjRefr"].ToString().Length < 0) ? null : dr["Ref_Contr_ProjRefr"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].Porefr = (dr["Ref_Contr_PORefr"].ToString() == "" || dr["Ref_Contr_PORefr"].ToString().Length < 0) ? null : dr["Ref_Contr_PORefr"].ToString();
                    generate_IRN.RefDtls.ContrDtls[0].PoRefDt = (dr["Ref_Contr_PORefDt"].ToString() == "" || dr["Ref_Contr_PORefDt"].ToString().Length < 0) ? null : dr["Ref_Contr_PORefDt"].ToString();
                }
            }

            //AddlDocDtls[]------------------------------------------------------------------------------------
            if (dr["AdDoc_Url"].ToString().Trim() != "" && dr["AdDoc_Url"].ToString().Trim().Length > 0) 
            {
                generate_IRN.AddlDocDtls = new List<Generate_IRN.addlDocDtls>();
                generate_IRN.AddlDocDtls.Add(new Generate_IRN.addlDocDtls());
                generate_IRN.AddlDocDtls[0].Url = (dr["AdDoc_Url"].ToString() == "" || dr["AdDoc_Url"].ToString().Length < 0) ? null : dr["AdDoc_Url"].ToString();
                generate_IRN.AddlDocDtls[0].Docs = (dr["AdDoc_Docs"].ToString() == "" || dr["AdDoc_Docs"].ToString().Length < 0) ? null : dr["AdDoc_Docs"].ToString();
                generate_IRN.AddlDocDtls[0].Info = (dr["AdDoc_Info"].ToString() == "" || dr["AdDoc_Info"].ToString().Length < 0) ? null : dr["AdDoc_Info"].ToString();
            }

            //ExpDtls------------------------------------------------------------------------------------
            if (dr["Exp_ShipBNo"].ToString().Trim() != "" && dr["Exp_ShipBNo"].ToString().Trim().Length > 0)
            {
                generate_IRN.ExpDtls = new Generate_IRN.expDtls();
                generate_IRN.ExpDtls.ShipBNo = (dr["Exp_ShipBNo"].ToString() == "" || dr["Exp_ShipBNo"].ToString().Length < 0) ? null : dr["Exp_ShipBNo"].ToString();
                generate_IRN.ExpDtls.ShipBDt = (dr["Exp_ShipBDt"].ToString() == "" || dr["Exp_ShipBDt"].ToString().Length < 0) ? null : dr["Exp_ShipBDt"].ToString();
                generate_IRN.ExpDtls.Port = (dr["Exp_Port"].ToString() == "" || dr["Exp_Port"].ToString().Length < 0) ? null : dr["Exp_Port"].ToString();
                generate_IRN.ExpDtls.RefClm = (dr["Exp_RefClm"].ToString() == "" || dr["Exp_RefClm"].ToString().Length < 0) ? null : dr["Exp_RefClm"].ToString();
                generate_IRN.ExpDtls.ForCur = (dr["Exp_ForCur"].ToString() == "" || dr["Exp_ForCur"].ToString().Length < 0) ? null : dr["Exp_ForCur"].ToString();
                generate_IRN.ExpDtls.CntCode = (dr["Exp_CntCode"].ToString() == "" || dr["Exp_CntCode"].ToString().Length < 0) ? null : dr["Exp_CntCode"].ToString();
            }

            //EwbDtls------------------------------------------------------------------------------------
            if (dr["Ewb_TransId"].ToString().Trim() != "" && dr["Ewb_TransId"].ToString().Trim().Length > 0)
            {
                generate_IRN.EwbDtls = new Generate_IRN.ewbDtls();
                generate_IRN.EwbDtls.Transid = (dr["Ewb_TransId"].ToString() == "" || dr["Ewb_TransId"].ToString().Length < 0) ? null : dr["Ewb_TransId"].ToString();
                generate_IRN.EwbDtls.Transname = (dr["Ewb_TransName"].ToString() == "" || dr["Ewb_TransName"].ToString().Length < 0) ? null : dr["Ewb_TransName"].ToString();
                generate_IRN.EwbDtls.Distance = (dr["Ewb_Distance"].ToString() == "" || dr["Ewb_Distance"].ToString().Length < 0) ? 0 : Convert.ToInt32(dr["Ewb_Distance"].ToString());
                generate_IRN.EwbDtls.Transdocno = (dr["Ewb_TransDocNo"].ToString() == "" || dr["Ewb_TransDocNo"].ToString().Length < 0) ? null : dr["Ewb_TransDocNo"].ToString();
                generate_IRN.EwbDtls.TransdocDt = (dr["Ewb_TransDocDt"].ToString() == "" || dr["Ewb_TransDocDt"].ToString().Length < 0) ? null : dr["Ewb_TransDocDt"].ToString();
                generate_IRN.EwbDtls.Vehno = (dr["Ewb_VehNo"].ToString() == "" || dr["Ewb_VehNo"].ToString().Length < 0) ? null : dr["Ewb_VehNo"].ToString();
                generate_IRN.EwbDtls.Vehtype = (dr["Ewb_VehType"].ToString() == "" || dr["Ewb_VehType"].ToString().Length < 0) ? null : dr["Ewb_VehType"].ToString();
                generate_IRN.EwbDtls.TransMode = (dr["Ewb_TransMode"].ToString() == "" || dr["Ewb_TransMode"].ToString().Length < 0) ? null : dr["Ewb_TransMode"].ToString();
            }
            return generate_IRN;
        }
        
        //CANCLE IRN POST REQUEST BODY
        public Cancel_IRN cancelRNRequestBody(string irn,string reason="1", string remark= "Wrong entry")
        {
            this.cancel_IRN = new Cancel_IRN();
            cancel_IRN.Irn = irn;
            cancel_IRN.CnlRsn = reason;
            cancel_IRN.CnlRem = remark;

            return cancel_IRN;
        }

        //GENERATE EWAYBILL IRN POST REQUEST BODY
        public Generate_Ewaybill_IRN generateEwaybillIRNRequestBody(DataRow dr)
        {
            this.generate_Ewaybill_IRN = new Generate_Ewaybill_IRN();

            generate_Ewaybill_IRN.Irn = (dr["Irn"].ToString() == "" || dr["Irn"].ToString().Length < 0) ? null : dr["Irn"].ToString();
            generate_Ewaybill_IRN.Distance = (dr["Distance"].ToString() == "" || dr["Distance"].ToString().Length < 0) ? null : dr["Distance"].ToString();
            generate_Ewaybill_IRN.TransMode = (dr["TransMode"].ToString() == "" || dr["TransMode"].ToString().Length < 0) ? null : dr["TransMode"].ToString();
            generate_Ewaybill_IRN.TransId = (dr["TransId"].ToString() == "" || dr["TransId"].ToString().Length < 0) ? null : dr["TransId"].ToString();
            generate_Ewaybill_IRN.TransName = (dr["TransName"].ToString() == "" || dr["TransName"].ToString().Length < 0) ? null : dr["TransName"].ToString();
            generate_Ewaybill_IRN.TransDocDt = (dr["TransDocDt"].ToString() == "" || dr["TransDocDt"].ToString().Length < 0) ? null : dr["TransDocDt"].ToString();
            generate_Ewaybill_IRN.TransDocNo = (dr["TransDocNo"].ToString() == "" || dr["TransDocNo"].ToString().Length < 0) ? null : dr["TransDocNo"].ToString();
            generate_Ewaybill_IRN.VehNo = (dr["VehNo"].ToString() == "" || dr["VehNo"].ToString().Length < 0) ? null : dr["VehNo"].ToString();
            generate_Ewaybill_IRN.VehType = (dr["VehType"].ToString() == "" || dr["VehType"].ToString().Length < 0) ? null : dr["VehType"].ToString();
            
            return generate_Ewaybill_IRN;
        }
    }
}
