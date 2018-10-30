//Marker     Changed by      Date               Remarks
//[001]      Vinay           24/06/2013         CR:- Supplier Invoice
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

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class GlobalTaxProvider : DataAccess {
		static private GlobalTaxProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public GlobalTaxProvider Instance {
			get {
                if (_instance == null) _instance = (GlobalTaxProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GlobalTaxs.ProviderType));
				return _instance;
			}
		}
		public GlobalTaxProvider() {
            this.ConnectionString = Globals.Settings.GlobalTaxs.ConnectionString;
		}

		#region Method Registrations
		
	
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Tax]
		/// </summary>
		public abstract Int32 Insert( System.String taxName, System.String notes, System.Boolean? inactive, System.String taxCode, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode);
		/// <summary>
		/// Get
		/// Calls [usp_select_Tax]
		/// </summary>
        public abstract GlobalTaxDetails Get(System.Int32? taxId);
		/// <summary>
		/// GetListForClient
        /// Calls [usp_selectAll_GlobalTax_List]
		/// </summary>
        public abstract List<GlobalTaxDetails> GetListForClient();
		/// <summary>
		/// Update
		/// Calls [usp_update_GlobalTax]
		/// </summary>
		public abstract bool Update(System.Int32? taxId, System.String taxName, System.String notes, System.String taxCode, System.Boolean? inactive, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode);

        //[001] code start
        /// <summary>
        /// Get Tax Code according to client usp_dropdown_PurchaseGlobalTaxCode
        /// Call Proc [usp_dropdown_PurchaseGlobalTaxCode]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public abstract List<GlobalTaxDetails> DropDownPurchaseTaxCodeForClient();
        //[001] code end

		#endregion
				
		/// <summary>
		/// Returns a new TaxDetails instance filled with the DataReader's current record data
		/// </summary>        
        protected virtual GlobalTaxDetails GetTaxFromReader(DbDataReader reader)
        {
            GlobalTaxDetails tax = new GlobalTaxDetails();
			if (reader.HasRows) {
				tax.TaxId = GetReaderValue_Int32(reader, "TaxId", 0); //From: [Table]
				tax.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Country]
				tax.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				tax.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				tax.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				tax.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				tax.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				tax.TaxCode = GetReaderValue_String(reader, "TaxCode", ""); //From: [Table]
				tax.PrintNotes = GetReaderValue_String(reader, "PrintNotes", ""); //From: [usp_select_Invoice_for_Print]
			}
			return tax;
		}
	
		/// <summary>
		/// Returns a collection of TaxDetails objects with the data read from the input DataReader
		/// </summary>                
        protected virtual List<GlobalTaxDetails> GetTaxCollectionFromReader(DbDataReader reader)
        {
            List<GlobalTaxDetails> taxs = new List<GlobalTaxDetails>();
			while (reader.Read()) taxs.Add(GetTaxFromReader(reader));
			return taxs;
		}
		
		
	}
}