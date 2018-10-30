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

    public abstract class CreditLineProvider : DataAccess
    {
        static private CreditLineProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public CreditLineProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (CreditLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CreditLines.ProviderType));
                return _instance;
            }
        }
        public CreditLineProvider()
        {
            this.ConnectionString = Globals.Settings.CreditLines.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_CreditLine_for_Client]
        /// </summary>
        public abstract Int32 CountForClient(System.Int32? clientId);
        /// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_CreditLine]
        /// </summary>
        public abstract List<CreditLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String creditNotesSearch, System.String customerPoSearch, System.Int32? creditNoLo, System.Int32? creditNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? creditDateFrom, System.DateTime? creditDateTo, System.Boolean? PohubOnly, System.Int32? ClientInvoiceNoLo, System.Int32? ClientInvoiceNoHi, System.Boolean? blnHubCredit);
        /// <summary>
        /// Delete
        /// Calls [usp_delete_CreditLine]
        /// </summary>
        public abstract bool Delete(System.Int32? creditLineId);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CreditLine] 
        /// </summary>
        public abstract Int32 Insert(System.Int32? creditNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String customerPart, System.Double? landedCost, System.Int32? invoiceLineNo, System.Int32? customerRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? ClientInvoiceLineId, out int creditId, out int creditNumber);

        public abstract Int32 CreditNoteToPOHUB(System.String CreditLineID, System.Int32? UpdatedBy);

        /// <summary>
        /// Get
        /// Calls [usp_select_CreditLine]
        /// </summary>
        public abstract CreditLineDetails Get(System.Int32? creditLineId);
        /// <summary>
        /// GetListForCredit
        /// Calls [usp_selectAll_CreditLine_for_Credit]
        /// </summary>
        public abstract List<CreditLineDetails> GetListForCredit(System.Int32? creditId);
        /// <summary>
        /// Update
        /// Calls [usp_update_CreditLine]
        /// </summary>
        public abstract bool Update(System.Int32? creditLineId, System.Int32? quantity, System.Double? price, System.String part, System.String customerPart, System.Double? landedCost, System.String notes, System.Int32? updatedBy);

        #endregion

        /// <summary>
        /// Returns a new CreditLineDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual CreditLineDetails GetCreditLineFromReader(DbDataReader reader)
        {
            CreditLineDetails creditLine = new CreditLineDetails();
            if (reader.HasRows)
            {
                creditLine.CreditLineId = GetReaderValue_Int32(reader, "CreditLineId", 0); //From: [Table]
                creditLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
                creditLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_Allocation]
                creditLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_selectAll_Allocation]
                creditLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_selectAll_Allocation]
                creditLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_selectAll_Allocation]
                creditLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_selectAll_Allocation]
                creditLine.CreditNo = GetReaderValue_Int32(reader, "CreditNo", 0); //From: [Table]
                creditLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
                creditLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
                creditLine.Taxable = GetReaderValue_Boolean(reader, "Taxable", false); //From: [Table]
                creditLine.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_selectAll_Allocation]
                creditLine.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_selectAll_Allocation]
                creditLine.InvoiceLineNo = GetReaderValue_NullableInt32(reader, "InvoiceLineNo", null); //From: [Table]
                creditLine.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
                creditLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_selectAll_Allocation]
                creditLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                creditLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                creditLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
                creditLine.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null); //From: [Table]
                creditLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
                creditLine.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [Table]
                creditLine.CreditId = GetReaderValue_Int32(reader, "CreditId", 0); //From: [Table]
                creditLine.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0); //From: [Table]
                creditLine.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue); //From: [Table]
                creditLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_list_Activity_by_Client_with_filter]
                creditLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_list_Activity_by_Client_with_filter]
                creditLine.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
                creditLine.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [usp_selectAll_Allocation_for_SalesOrderLine]
                creditLine.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [usp_selectAll_Allocation]
                creditLine.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_select_Credit]
                creditLine.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
                creditLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_list_Activity_by_Client_with_filter]
                creditLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
                creditLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_selectAll_Allocation]
                creditLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
                creditLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_CreditLine]
                creditLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
                creditLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_selectAll_Allocation]
                creditLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_selectAll_Allocation]
                creditLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_selectAll_Allocation]
                creditLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_Allocation]
                creditLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
                creditLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
                creditLine.RaiserName = GetReaderValue_String(reader, "RaiserName", ""); //From: [usp_select_Credit]
                creditLine.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_selectAll_Allocation]
                creditLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [Table]
                creditLine.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
                creditLine.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue); //From: [Table]
            }
            return creditLine;
        }

        /// <summary>
        /// Returns a collection of CreditLineDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<CreditLineDetails> GetCreditLineCollectionFromReader(DbDataReader reader)
        {
            List<CreditLineDetails> creditLines = new List<CreditLineDetails>();
            while (reader.Read()) creditLines.Add(GetCreditLineFromReader(reader));
            return creditLines;
        }


    }
}