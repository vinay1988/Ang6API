/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for supplierRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[003]      Aashu Singh     06/07/2018   Save internal log for SRMA
*/
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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL
{

    public abstract class SupplierRmaProvider : DataAccess
    {
        static private SupplierRmaProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public SupplierRmaProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (SupplierRmaProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SupplierRmas.ProviderType));
                return _instance;
            }
        }
        public SupplierRmaProvider()
        {
            this.ConnectionString = Globals.Settings.SupplierRmas.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_SupplierRMA_for_Client]
        /// </summary>
        public abstract Int32 CountForClient(System.Int32? clientId);
        /// <summary>
        /// CountForCompany
        /// Calls [usp_count_SupplierRMA_for_Company]
        /// </summary>
        public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete);
        /// <summary>
        /// CountShippingForClient
        /// Calls [usp_count_SupplierRMA_shipping_for_Client]
        /// </summary>
        public abstract Int32 CountShippingForClient(System.Int32? clientId);
        /// <summary>
        /// Delete
        /// Calls [usp_delete_SupplierRMA]
        /// </summary>
        public abstract bool Delete(System.Int32? supplierRmaId);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SupplierRMA]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? purchaseOrderNo, System.Int32? authorisedBy, System.DateTime? supplierRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? shipToAddressNo, System.String reference, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy);
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_SupplierRMA]
        /// </summary>
        public abstract List<SupplierRmaDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo);
        /// <summary>
        /// Get
        /// Calls [usp_select_SupplierRMA]
        /// </summary>
        public abstract SupplierRmaDetails Get(System.Int32? supplierRmaId);
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_SupplierRMA_by_Number]
        /// </summary>
        public abstract SupplierRmaDetails GetByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo);
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_SupplierRMA_for_Page]
        /// </summary>
        public abstract SupplierRmaDetails GetForPage(System.Int32? supplierRmaId);
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_SupplierRMA_for_Print]
        /// </summary>
        public abstract SupplierRmaDetails GetForPrint(System.Int32? supplierRmaId, bool IsHUBsupplierRmaId);
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_SupplierRMA_ID_by_Number]
        /// </summary>
        //[002] start
        public abstract List<SupplierRmaDetails> GetIDByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[002] end
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_SupplierRMA_NextNumber]
        /// </summary>
        public abstract SupplierRmaDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_SupplierRMA_for_Company]
        /// </summary>
        public abstract List<SupplierRmaDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete);
        /// <summary>
        /// Update
        /// Calls [usp_update_SupplierRMA]
        /// </summary>
        public abstract bool Update(System.Int32? supplierRmaId, System.String notes, System.String instructions, System.String reference, System.Int32? shipToAddressNo, System.DateTime? supplierRmaDate, System.Int32? shipViaNo, System.String account, System.Int32? incotermNo, System.Int32? updatedBy, bool? isLockUpdateClient);
        // [001] code start
        /// <summary>
        /// Get PDF list for supplier rma
        /// Calls [usp_selectAll_PDF_for_SupplierRMA]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForSupplierRMA(System.Int32? SupplierRMAId);
        /// <summary>
        /// Insert PDF for supplier rma
        /// Calls [usp_insert_SupplierRMAPDF]
        /// </summary>
        /// <param name="SupplierRMAId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? SupplierRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete supplier rma pdf
        /// Calls[usp_delete_CutomerRMAPDF]
        /// </summary>
        /// <param name="SupplierRMAPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteSupplierRMAPDF(System.Int32? SupplierRMAPdfId);
        
        // [001] code end
        //[003] start
        public abstract Int32 InsertSRMAInternalLog(System.Int32 SupplierRMAId, System.String notes, System.Int32 UpdatedBy);
        public abstract List<SupplierRmaDetails> GetSRMAInternalLog(System.Int32 supplierRmaNumber);
        //[003] end
        #endregion

        /// <summary>
        /// Returns a new SupplierRmaDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual SupplierRmaDetails GetSupplierRmaFromReader(DbDataReader reader)
        {
            SupplierRmaDetails supplierRma = new SupplierRmaDetails();
            if (reader.HasRows)
            {
                supplierRma.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0); //From: [Table]
                supplierRma.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
                supplierRma.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
                supplierRma.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0); //From: [Table]
                supplierRma.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0); //From: [Table]
                supplierRma.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue); //From: [Table]
                supplierRma.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
                supplierRma.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
                supplierRma.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
                supplierRma.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
                supplierRma.ShipToAddressNo = GetReaderValue_Int32(reader, "ShipToAddressNo", 0); //From: [Table]
                supplierRma.Reference = GetReaderValue_String(reader, "Reference", ""); //From: [Table]
                supplierRma.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
                supplierRma.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
                supplierRma.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
                supplierRma.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                supplierRma.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                supplierRma.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
                supplierRma.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_PurchaseOrder]
                supplierRma.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_itemsearch_PurchaseOrder]
                supplierRma.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [Table]
                supplierRma.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_PurchaseOrder]
                supplierRma.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", ""); //From: [usp_select_SupplierRMA]
                supplierRma.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
                supplierRma.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_PurchaseOrder]
                supplierRma.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
                supplierRma.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_SalesOrder]
                supplierRma.CustomerCode = GetReaderValue_String(reader, "CustomerCode", ""); //From: [usp_select_SalesOrder]
                supplierRma.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
                supplierRma.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [Table]
                supplierRma.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null); //From: [usp_selectAll_SalesOrder_open_for_Login]
                supplierRma.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null); //From: [usp_select_SupplierRMA]
                supplierRma.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_PurchaseOrder_for_Print]
                supplierRma.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_PurchaseOrder_for_Print]
                supplierRma.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_PurchaseOrder]
                supplierRma.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_PurchaseOrder_for_Print]
            }
            return supplierRma;
        }

        /// <summary>
        /// Returns a collection of SupplierRmaDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<SupplierRmaDetails> GetSupplierRmaCollectionFromReader(DbDataReader reader)
        {
            List<SupplierRmaDetails> supplierRmas = new List<SupplierRmaDetails>();
            while (reader.Read()) supplierRmas.Add(GetSupplierRmaFromReader(reader));
            return supplierRmas;
        }


    }
}