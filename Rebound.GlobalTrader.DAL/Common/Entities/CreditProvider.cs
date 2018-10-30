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

    public abstract class CreditProvider : DataAccess
    {
        static private CreditProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public CreditProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (CreditProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Credits.ProviderType));
                return _instance;
            }
        }
        public CreditProvider()
        {
            this.ConnectionString = Globals.Settings.Credits.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// CountForCompany
        /// Calls [usp_count_Credit_for_Company]
        /// </summary>
        public abstract Int32 CountForCompany(System.Int32? companyId);
        /// <summary>
        /// Delete
        /// Calls [usp_delete_Credit]
        /// </summary>
        public abstract bool Delete(System.Int32? creditId);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Credit]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? creditDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? salesman, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? invoiceNo, System.Int32? customerRmaNo, System.DateTime? referenceDate, System.String customerPo, System.String customerRma, System.String customerDebit, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy, System.Boolean isClientInvoice, System.Int32? clientInvoiceLineNo);
        /// <summary>
        /// Get
        /// Calls [usp_select_Credit]
        /// </summary>
        public abstract CreditDetails Get(System.Int32? creditId);
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_Credit_for_Page]
        /// </summary>
        public abstract CreditDetails GetForPage(System.Int32? creditId);
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_Credit_for_Print]
        /// </summary>
        public abstract CreditDetails GetForPrint(System.Int32? creditId);
        /// <summary>
        /// GetIdByNumber
        /// Calls [usp_select_Credit_Id_by_Number]
        /// </summary>
        public abstract CreditDetails GetIdByNumber(System.Int32? creditNumber, System.Int32? clientNo);
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_Credit_NextNumber]
        /// </summary>
        public abstract CreditDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_Credit_for_Company]
        /// </summary>
        public abstract List<CreditDetails> GetListForCompany(System.Int32? companyId);
        /// <summary>
        /// Update
        /// Calls [usp_update_Credit]
        /// </summary>
        public abstract bool Update(System.Int32? creditId, System.String customerPo, System.String customerRma, System.String customerDebit, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? salesman, System.Int32? raisedBy, System.DateTime? creditDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy, System.Double? exchangeRate);

        /// <summary>
        /// UpdateExport
        /// Calls [usp_update_Credit_Export]
        /// </summary>
        public abstract bool UpdateExport(System.Int32? creditId, System.Int32? exportedBy, System.Boolean? export);

        #endregion

        /// <summary>
        /// Returns a new CreditDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual CreditDetails GetCreditFromReader(DbDataReader reader)
        {
            CreditDetails credit = new CreditDetails();
            if (reader.HasRows)
            {
                credit.CreditId = GetReaderValue_Int32(reader, "CreditId", 0); //From: [Table]
                credit.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0); //From: [Table]
                credit.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
                credit.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
                credit.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
                credit.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue); //From: [Table]
                credit.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
                credit.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null); //From: [Table]
                credit.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
                credit.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
                credit.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
                credit.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
                credit.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
                credit.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [Table]
                credit.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
                credit.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
                credit.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null); //From: [Table]
                credit.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
                credit.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null); //From: [Table]
                credit.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue); //From: [Table]
                credit.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [Table]
                credit.CustomerRMA = GetReaderValue_String(reader, "CustomerRMA", ""); //From: [Table]
                credit.CustomerDebit = GetReaderValue_String(reader, "CustomerDebit", ""); //From: [Table]
                credit.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                credit.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                credit.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [Table]
                credit.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0); //From: [Table]
                credit.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
                credit.DivisionNo2 = GetReaderValue_NullableInt32(reader, "DivisionNo2", null); //From: [Table]
                credit.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_select_Credit]
                credit.CustomerCode = GetReaderValue_String(reader, "CustomerCode", ""); //From: [usp_select_Credit]
                credit.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_Credit]
                credit.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Credit]
                credit.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Credit]
                credit.RaiserName = GetReaderValue_String(reader, "RaiserName", ""); //From: [usp_select_Credit]
                credit.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_Credit]
                credit.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Credit]
                credit.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
                credit.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", ""); //From: [usp_select_Credit]
                credit.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Credit]
                credit.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null); //From: [usp_select_Credit]
                credit.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null); //From: [usp_select_Credit]
                credit.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_select_Credit]
                credit.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [usp_select_Credit]
                credit.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null); //From: [usp_select_Credit]
                credit.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null); //From: [usp_select_Credit]
                credit.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_Credit]
                credit.CreditValue = GetReaderValue_NullableDouble(reader, "CreditValue", null); //From: [usp_select_Credit]
                credit.CreditCost = GetReaderValue_NullableDouble(reader, "CreditCost", null); //From: [usp_select_Credit]
                credit.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_Credit]
                credit.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_Credit]
                credit.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_Credit_for_Print]
                credit.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_Credit_for_Print]
                credit.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_Credit_for_Print]
            }
            return credit;
        }

        /// <summary>
        /// Returns a collection of CreditDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<CreditDetails> GetCreditCollectionFromReader(DbDataReader reader)
        {
            List<CreditDetails> credits = new List<CreditDetails>();
            while (reader.Read()) credits.Add(GetCreditFromReader(reader));
            return credits;
        }


    }
}