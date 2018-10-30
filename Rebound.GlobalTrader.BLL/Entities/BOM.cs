//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
//[002]      Umendra Gupta    30/08/2018    Add ClientCode,ReceivedBy and SalesPerson field
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
    public partial class BOM : BizObject
    {

        #region Properties

        protected static DAL.BOMElement Settings
        {
            get { return Globals.Settings.BOM; }
        }
        /// <summary>
        /// BOMId
        /// </summary>
        public System.Int32 BOMId { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// BOMName
        /// </summary>
        public System.String BOMName { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// BOMCode
        /// </summary>
        public System.String BOMCode { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean Inactive { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }

        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary> 
        /// Company No
        /// </summary>
        public System.Int32? CompanyNo { get; set; }
        /// <summary>
        ///Company Name
        ///</summary>
        public System.String CompanyName { get; set; }
        /// <summary> 
        /// Contact No
        /// </summary>
        public System.Int32? ContactNo { get; set; }
        /// <summary>
        ///Contact Name
        ///</summary>
        public System.String ContactName { get; set; }
        /// <summary>
        ///Update Requirement
        ///</summary>
        public System.Int32? UpdateRequirement { get; set; }
        /// <summary>
        ///BOM Status
        ///</summary>
        public System.String BOMStatus { get; set; }
        /// <summary>
        ///Status
        ///</summary>
        public System.Int32? Status { get; set; }
        /// <summary>
        ///Client Code
        ///</summary>
        public System.String ClientCode { get; set; }//[002]
        /// <summary>
        ///ReceivedBy
        ///</summary>
        public System.String ReceivedBy { get; set; }//[002]
        /// SalesPerson
        /// </summary>
        public System.Int32? SalesPerson { get; set; }//[002]
        /// <summary>
		/// <summary>
		/// CountForClient
        public System.Int32? RequestToPOHubBy { get; set; }
        public System.DateTime? DateRequestToPOHub { get; set; }
        public System.Int32? ReleaseBy { get; set; }
        public System.DateTime? DateRelease { get; set; }
        public System.Int32? BomCount { get; set; }
        public System.Int32? CurrencyNo { get; set; }
        public System.String CurrencyCode { get; set; }
     
        public int? StatusValue { get; set; }
        public System.String Currency_Code { get; set; }
        public string ClientName { get; set; }
        public System.String CurrentSupplier { get; set; }
        public System.DateTime? QuoteRequired { get; set; }
        public string UpdatedByList { get; set; }
        public double TotalBomLinePrice { get; set; }
        public int POCurrencyNo { get; set; }
        public System.Int32? AllItemHasSourcing { get; set; }
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        public System.Int32 AssignUserNo { get; set; }

        public string Releasedby { get; set; }
        public string Requestedby { get; set; }
        public string AssignedUser { get; set; }
        public int NoBidCount { get; set; }
        public System.String DivisionName { get; set; }

        public System.Int32? UpdateByPH { get; set; }
        public System.String ValidationMessage { get; set; }
        public System.Boolean IsReqInValid { get; set; }
        public System.Int32? Contact2Id { get; set; }
        public System.String Contact2Name { get; set; }
        public System.String SalesmanName { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_BOM]
        /// </summary>
        public static Int32 CountForBOM(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.CountForBOM(clientId);
        }		/// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_BOM]
        /// </summary>
        //public static List<BOM> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? BOMIdLo, System.Int32? BOMIdHi, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo)
        public static List<BOM> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String BOMCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? isAssignToMe, int? assignedUser, System.Int32? intDivisionNo, System.Int32? salesPerson)
 
        {
            List<BOMDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, BOMCode, bomName, isPOHub, selectedClientNo, bomStatus, isAssignToMe, assignedUser, intDivisionNo, salesPerson);
            if (lstDetails == null)
            {
                return new List<BOM>();
            }
            else
            {
                List<BOM> lst = new List<BOM>();
                foreach (BOMDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.BOM obj = new Rebound.GlobalTrader.BLL.BOM();
                    obj.BOMId = objDetails.BOMId;
                    obj.BOMCode = objDetails.BOMCode.TrimEnd();
                    obj.BOMName = objDetails.BOMName;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Inactive = objDetails.Inactive;
                    obj.BOMStatus = objDetails.BOMStatus;
                    obj.DLUP = objDetails.DLUP;
                    obj.QuoteRequired = objDetails.QuoteRequired;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TotalBomLinePrice = objDetails.TotalBomLinePrice;
                    obj.DateRequestToPOHub = objDetails.DateRequestToPOHub;
                    obj.POCurrencyNo = objDetails.POCurrencyNo;
                    obj.AssignedUser = objDetails.AssignedUser;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.ClientCode = objDetails.ClientCode;//[002]
                    obj.Requestedby = objDetails.Requestedby;//[002]
                    obj.SalesmanName = objDetails.SalesmanName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Delete
        /// Calls [usp_delete_BOM]
        /// </summary>
        public static bool Delete(System.Int32? bomId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.Delete(bomId);
        }        
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_BOM_for_Client]
		/// </summary>
        public static List<BOM> DropDownForClient(System.Int32? clientId, System.Int32? CompanyId)
        {
            List<BOMDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.DropDownForClient(clientId, CompanyId);
            if (lstDetails == null)
            {
                return new List<BOM>();
            }
            else
            {
                List<BOM> lst = new List<BOM>();
                foreach (BOMDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.BOM obj = new Rebound.GlobalTrader.BLL.BOM();
                    obj.BOMId = objDetails.BOMId;
                    obj.BOMName = objDetails.BOMName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_BOM]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.String bomName, System.String notes, System.String bomCode, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Boolean? inactive, System.Int32? updateRequirement, System.Int32? status, System.Int32? currencyNo, System.String currentSupplier, System.DateTime? quoteRequired, System.Boolean? AS9120, System.Int32? Contact2Id, System.Int32 AssignUserNo, out System.String ValidationMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.BOM.Insert(clientNo, bomName, notes, bomCode, updatedBy, companyId, contactId, inactive, updateRequirement, status, currencyNo, currentSupplier, quoteRequired, AS9120,Contact2Id, AssignUserNo, out ValidationMessage);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_BOM]
        /// </summary>
        public Int32 Insert()
        {
            String ValidationMessage = null;            
            int creditLineId = Rebound.GlobalTrader.DAL.SiteProvider.BOM.Insert(ClientNo, BOMName, Notes, BOMCode, UpdatedBy, CompanyNo, ContactNo, Inactive, UpdateRequirement, Status, CurrencyNo, CurrentSupplier, QuoteRequired, AS9120,Contact2Id, AssignUserNo, out ValidationMessage);
            this.ValidationMessage = ValidationMessage;
            return creditLineId;
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_BOM]
        /// </summary>
        public static BOM Get(System.Int32? bomId)
        {
            Rebound.GlobalTrader.DAL.BOMDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.Get(bomId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                BOM obj = new BOM();
                obj.BOMId = objDetails.BOMId;
                //obj.ClientNo = objDetails.ClientNo;
                obj.BOMName = objDetails.BOMName;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.Notes = objDetails.Notes;
                obj.BOMCode = objDetails.BOMCode;
                obj.Inactive = objDetails.Inactive;
                obj.ContactNo = objDetails.ContactNo;
                obj.ContactName = objDetails.ContactName;
                obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                obj.DateRequestToPOHub = objDetails.DateRequestToPOHub;
                obj.ReleaseBy = objDetails.ReleaseBy;
                obj.DateRelease = objDetails.DateRelease;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.BOMStatus = objDetails.BOMStatus;
                obj.BomCount = objDetails.BomCount;
                obj.StatusValue = objDetails.StatusValue;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Currency_Code = objDetails.Currency_Code;
                obj.CurrentSupplier = objDetails.CurrentSupplier;
                obj.QuoteRequired = objDetails.QuoteRequired;
                obj.AllItemHasSourcing = objDetails.AllItemHasSourcing;
                obj.AS9120=objDetails.AS9120;
                obj.Requestedby = objDetails.Requestedby;
                obj.Releasedby = objDetails.Releasedby;
                obj.NoBidCount = objDetails.NoBidCount;
                obj.UpdateByPH = objDetails.UpdateByPH;
                obj.AssignedUser = objDetails.AssignedUser;
                obj.Contact2Id = objDetails.Contact2Id;
                obj.Contact2Name = objDetails.Contact2Name;
                obj.ValidationMessage = objDetails.ValidationMessage;
                obj.IsReqInValid = objDetails.IsReqInValid;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_BOM_for_Page]
        /// </summary>
        public static BOM GetForPage(System.Int32? bomId)
        {
            Rebound.GlobalTrader.DAL.BOMDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetForPage(bomId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                BOM obj = new BOM();
                obj.BOMId = objDetails.BOMId;
                obj.BOMName = objDetails.BOMName;
                obj.ClientNo = objDetails.ClientNo;
                obj.Inactive = objDetails.Inactive;
                obj.BOMStatus = objDetails.BOMStatus;
                obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_BOM]
        /// </summary>
        public static bool Update(System.Int32? bomId, System.Int32? clientNo, System.String bomName, System.String notes, System.String bomCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Int32? currencyNo, System.String currentSupplier, System.DateTime? quoteRequired, System.Boolean? AS9120, System.Int32? contact2Id)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.Update(bomId, clientNo, bomName, notes, bomCode, inactive, updatedBy, companyId, contactId, currencyNo, currentSupplier, quoteRequired, AS9120, contact2Id);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_BOM]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.Update(BOMId, ClientNo, BOMName, Notes, BOMCode, Inactive, UpdatedBy, CompanyNo, ContactNo,CurrencyNo,CurrentSupplier,QuoteRequired,AS9120,Contact2Id);
        }
        /// <summary>
        /// UpdateDelete
        /// Calls [usp_update_BOM_Delete]
        /// </summary>
        public static bool UpdateDelete(System.Int32? BOMId, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.UpdateDelete(BOMId, updatedBy);
        }

        private static BOM PopulateFromDBDetailsObject(BOMDetails obj)
        {
            BOM objNew = new BOM();
            objNew.BOMId = obj.BOMId;
            objNew.ClientNo = obj.ClientNo;
            objNew.BOMName = obj.BOMName;
            objNew.Notes = obj.Notes;
            objNew.BOMCode = obj.BOMCode;
            objNew.Inactive = obj.Inactive;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            return objNew;
        }

        //[001] code start
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_BOM]
        /// </summary>
        public static List<BOM> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            List<BOMDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.AutoSearch(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<BOM>();
            }
            else
            {
                List<BOM> lst = new List<BOM>();
                foreach (BOMDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.BOM obj = new Rebound.GlobalTrader.BLL.BOM();
                    obj.BOMId = objDetails.BOMId;
                    obj.BOMName = objDetails.BOMName;
                    obj.BOMCode = objDetails.BOMCode;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[001] code end

        /// <summary>
        /// Update
        /// Calls [usp_update_BOM_POHubQuote]
        /// </summary>
        public static bool UpdatePurchaseQuote(System.Int32? BOMId, System.Int32? updatedBy, System.Int32? bomStatus, System.Int32 AssignUserNo, out System.String ValidateMessage)
        {
            string ValidationMessage = null;
            bool Isupdated = Rebound.GlobalTrader.DAL.SiteProvider.BOM.UpdatePurchaseQuote(BOMId, updatedBy, bomStatus, AssignUserNo,out ValidateMessage);
            ValidationMessage = ValidateMessage;            
            return Isupdated;
        }

        /// <summary>
        /// GetListReadyForClient
        /// Calls [usp_selectAll_BOM]
        /// </summary>
        public static List<BOM> GetBomList(System.Int32? clientId, System.Boolean? isPoHUB, System.Int32? topToSelect, System.Int32? bomStatus,System.Int32? updatedBy)
        {
            List<BOMDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetBomList(clientId, isPoHUB, topToSelect, bomStatus,updatedBy);
            if (lstDetails == null)
            {
                return new List<BOM>();
            }
            else
            {
                List<BOM> lst = new List<BOM>();
                foreach (BOMDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.BOM obj = new Rebound.GlobalTrader.BLL.BOM();
                    obj.BOMId = objDetails.BOMId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ClientName = objDetails.ClientName;
                    obj.BOMCode = objDetails.BOMCode;
                    obj.BOMName = objDetails.BOMName;
                    obj.DLUP = objDetails.DLUP;
                    obj.StatusValue = objDetails.StatusValue;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.QuoteRequired = objDetails.QuoteRequired;
                    obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetCSVListForBOM
        /// Calls [usp_selectAll_CSV_for_BOM]
        /// </summary>
        public static List<PDFDocument> GetCSVListForBOM(System.Int32? bomNo)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetCSVListForBOM(bomNo);
            if (lstDetails == null)
            {
                return new List<PDFDocument>();
            }
            else
            {
                List<PDFDocument> lst = new List<PDFDocument>();
                foreach (PDFDocumentDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PDFDocument obj = new Rebound.GlobalTrader.BLL.PDFDocument();
                    obj.PDFDocumentId = objDetails.PDFDocumentId;
                    obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// UpdateBOMByPH
        /// Calls [usp_update_BOMByPH]
        /// </summary>
        public static bool UpdateBOMByPH(System.String BOMIdList, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.UpdateBOMByPH(BOMIdList, updatedBy);
        }

        /// <summary>
        /// Delete
        /// Calls [usp_IpoBomCsvDelete]
        /// </summary>
        public static bool DeleteBomCsv(System.Int32? BomCSVId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.DeleteBomCsv(BomCSVId);
        }


        /// <summary>
        /// DropDownForClient
        /// Calls [usp_GetUpdatedByListFromBOMIdList]
        /// </summary>
        public static BOM GetUpdatedByListFromBOMIdList(System.String BOMIdList)
        {
            BOMDetails lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetUpdatedByListFromBOMIdList(BOMIdList);           
               // BOM lst = new BOM();
              Rebound.GlobalTrader.BLL.BOM obj = new Rebound.GlobalTrader.BLL.BOM();
              obj.BOMName = lstDetails.BOMName;
              obj.UpdatedByList = lstDetails.UpdatedByList;                                    
                lstDetails = null;
                return obj;
            
        }


        /// <summary>
        /// Update
        /// 
        /// </summary>
        public static bool UpdateBOMStatusToClosed(System.Int32? BOMId, System.Int32? updatedBy, System.Int32? bomStatus)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.BOM.UpdateBOMStatusToClosed(BOMId, updatedBy, bomStatus);
        }


        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_BOM_ID_by_Name]
        /// </summary>
        public static BOM GetIDByNumber(System.String bomName, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.BOMDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetIDByNumber(bomName, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                BOM obj = new BOM();
                obj.BOMId = objDetails.BOMId;
                objDetails = null;
                return obj;
            }
        }

        // [001] code start
        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_StockPDF_for_Stock]
        /// </summary>
        public static List<StockImage> GetImageListForReq(System.Int32? sourcingResultNo, System.String fileType)
        {
            List<StockImageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.BOM.GetImageListForReq(sourcingResultNo, fileType);
            if (lstDetails == null)
            {
                return new List<StockImage>();
            }
            else
            {
                List<StockImage> lst = new List<StockImage>();
                foreach (StockImageDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.StockImage obj = new Rebound.GlobalTrader.BLL.StockImage();
                    obj.StockImageId = objDetails.StockImageId;
                    //obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.ImageName = objDetails.ImageName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.By = objDetails.UpdatedByName;
                    obj.DLUP = objDetails.DLUP;
                    obj.ImageDocumentRefNo = objDetails.ImageDocumentRefNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        #endregion

    }
}
