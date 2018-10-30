/*
Marker     Changed by      Date          Remarks
[001]      Vinay           07/05/2012    This need to upload pdf document for goodsIn section
[002]      Vinay           18/09/2012    Ref:## - Display Purchase Country
[003]      Aashu           04/06/2018    Quick Jump in Global Warehouse
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

    public abstract class GoodsInProvider : DataAccess
    {
        static private GoodsInProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public GoodsInProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (GoodsInProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GoodsIns.ProviderType));
                return _instance;
            }
        }
        public GoodsInProvider()
        {
            this.ConnectionString = Globals.Settings.GoodsIns.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_GoodsIn_for_Client]
        /// </summary>
        public abstract Int32 CountForClient(System.Int32? clientId);
        /// <summary>
        /// Delete
        /// Calls [usp_delete_GoodsIn]
        /// </summary>
        public abstract bool Delete(System.Int32? goodsInId);
        //[002] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_GoodsIn]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.Int32? companyNo, System.String receivingNotes, System.DateTime? dateReceived, System.Int32? receivedBy, System.Int32? purchaseOrderNo, System.Int32? customerRmaNo, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? purchaseCountryNo);
        //[002] code end
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_GoodsIn]
        /// </summary>
        public abstract List<GoodsInDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String airWayBillSearch, System.String cmSearch, System.Int32? receivedBySearch, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Boolean IsGlobal);
        /// <summary>
        /// Get
        /// Calls [usp_select_GoodsIn]
        /// </summary>
        public abstract GoodsInDetails Get(System.Int32? goodsInId, bool? isHub);
        /// <summary>
        /// GetAsReceivedPO
        /// Calls [usp_select_GoodsIn_as_ReceivedPO]
        /// </summary>
        public abstract GoodsInDetails GetAsReceivedPO(System.Int32? purchaseOrderNo);
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_GoodsIn_by_Number]
        /// </summary>
        public abstract GoodsInDetails GetByNumber(System.Int32? goodsInNumber, System.Int32? clientNo);
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_GoodsIn_for_Page]
        /// </summary>
        public abstract GoodsInDetails GetForPage(System.Int32? goodsInId);
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_GoodsIn_for_Print]
        /// </summary>
        public abstract GoodsInDetails GetForPrint(System.Int32? goodsInId);
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_GoodsIn_ID_by_Number]
        /// </summary>
        //[003] start
        public abstract List<GoodsInDetails> GetIDByNumber(System.Int32? goodsInNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[003] end
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_GoodsIn_NextNumber]
        /// </summary>
        public abstract GoodsInDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
        /// <summary>
        /// Update
        /// Calls [usp_update_GoodsIn]
        /// </summary>
        public abstract bool Update(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.String supplierInvoice, System.DateTime? invoiceDate, System.Double? invoiceAmount, System.Double? bankFee, System.Int32? currencyNo, System.Int32? updatedBy);
        //[001] code start
        /// <summary>
        /// UpdateAccountingInfo
        /// Calls [usp_update_GoodsIn_AccountingInfo]
        /// </summary>
        public abstract bool UpdateAccountingInfo(System.Int32? goodsInId, System.Int32? updatedBy, System.Int32? PurchaseCountryNo);
        //[001] code end
        /// <summary>
        /// UpdateMainInfo
        /// Calls [usp_update_GoodsIn_MainInfo]
        /// </summary>
        public abstract bool UpdateMainInfo(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.Int32? updatedBy);
        // [001] code start
        /// <summary>
        /// Get PDF list for goodsIn
        /// Calls [usp_selectAll_PDF_for_GoodsIn]
        /// </summary>
        /// <param name="GoodsInId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForGoodsIn(System.Int32? GoodsInId);
        /// <summary>
        /// Insert PDF for goodsIn
        /// Calls [usp_insert_GoodsInPDF]
        /// </summary>
        /// <param name="GoodsInId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? GoodsInId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete goodsIn pdf
        /// Calls[usp_delete_GoodsInPDF]
        /// </summary>
        /// <param name="SalesOrderPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteGoodsInPDF(System.Int32? GoodsInPdfId);

        // [001] code start
        #endregion

        /// <summary>
        /// Returns a new GoodsInDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual GoodsInDetails GetGoodsInFromReader(DbDataReader reader)
        {
            GoodsInDetails goodsIn = new GoodsInDetails();
            if (reader.HasRows)
            {
                goodsIn.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0); //From: [Table]
                goodsIn.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0); //From: [Table]
                goodsIn.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
                goodsIn.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
                goodsIn.AirWayBill = GetReaderValue_String(reader, "AirWayBill", ""); //From: [Table]
                goodsIn.Reference = GetReaderValue_String(reader, "Reference", ""); //From: [Table]
                goodsIn.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
                goodsIn.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", ""); //From: [Table]
                goodsIn.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue); //From: [Table]
                goodsIn.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [Table]
                goodsIn.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
                goodsIn.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0); //From: [Table]
                goodsIn.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0); //From: [Table]
                goodsIn.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [Table]
                goodsIn.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", ""); //From: [Table]
                goodsIn.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null); //From: [Table]
                goodsIn.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null); //From: [Table]
                goodsIn.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null); //From: [Table]
                goodsIn.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                goodsIn.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                goodsIn.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null); //From: [Table]
                goodsIn.Tax = GetReaderValue_NullableDouble(reader, "Tax", null); //From: [Table]
                goodsIn.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null); //From: [Table]
                goodsIn.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null); //From: [Table]
                goodsIn.CanBeExported = GetReaderValue_Boolean(reader, "CanBeExported", false); //From: [Table]
                goodsIn.Exported = GetReaderValue_Boolean(reader, "Exported", false); //From: [Table]
                goodsIn.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_Debit]
                goodsIn.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_itemsearch_Debit]
                goodsIn.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_itemsearch_GoodsIn]
                goodsIn.ReceiverName = GetReaderValue_String(reader, "ReceiverName", ""); //From: [usp_itemsearch_GoodsIn]
                goodsIn.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_Debit]
                goodsIn.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_GoodsIn]
                goodsIn.GoodsInValue = GetReaderValue_NullableDouble(reader, "GoodsInValue", null); //From: [usp_select_GoodsIn]
                goodsIn.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [Table]
                goodsIn.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Debit]
                goodsIn.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Debit]
                goodsIn.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Debit]
                goodsIn.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_GoodsIn]
                goodsIn.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [usp_select_GoodsIn]
                goodsIn.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [Table]
                goodsIn.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_itemsearch_Debit]
                goodsIn.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Debit]
                goodsIn.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [Table]
                goodsIn.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_select_Debit]
                goodsIn.ReceivedByName = GetReaderValue_String(reader, "ReceivedByName", ""); //From: [usp_select_GoodsIn_as_ReceivedPO]
                goodsIn.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
                goodsIn.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_Debit]
                goodsIn.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null); //From: [usp_select_GoodsIn_as_ReceivedPO]
                goodsIn.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", ""); //From: [usp_select_GoodsIn_for_Page]
                goodsIn.SupplierTelephone = GetReaderValue_String(reader, "SupplierTelephone", ""); //From: [usp_select_GoodsIn_for_Print]
                goodsIn.SupplierFax = GetReaderValue_String(reader, "SupplierFax", ""); //From: [usp_select_GoodsIn_for_Print]
            }
            return goodsIn;
        }

        /// <summary>
        /// Returns a collection of GoodsInDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<GoodsInDetails> GetGoodsInCollectionFromReader(DbDataReader reader)
        {
            List<GoodsInDetails> goodsIns = new List<GoodsInDetails>();
            while (reader.Read()) goodsIns.Add(GetGoodsInFromReader(reader));
            return goodsIns;
        }


    }
}