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
	
	public abstract class TaxProvider : DataAccess {
		static private TaxProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public TaxProvider Instance {
			get {
				if (_instance == null) _instance = (TaxProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Taxs.ProviderType));
				return _instance;
			}
		}
		public TaxProvider() {
			this.ConnectionString = Globals.Settings.Taxs.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Tax]
		/// </summary>
		public abstract bool Delete(System.Int32? taxId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Tax_for_Client]
		/// </summary>
		public abstract List<TaxDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Tax]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String taxName, System.String notes, System.Boolean? inactive, System.String taxCode, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode);
		/// <summary>
		/// Get
		/// Calls [usp_select_Tax]
		/// </summary>
		public abstract TaxDetails Get(System.Int32? taxId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Tax_for_Client]
		/// </summary>
		public abstract List<TaxDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Tax]
		/// </summary>
		public abstract bool Update(System.Int32? taxId, System.Int32? clientNo, System.String taxName, System.String notes, System.String taxCode, System.Boolean? inactive, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode);

        //[001] code start
        /// <summary>
        /// Get Tax Code according to client
        /// Call Proc [usp_dropdown_PurchaseTaxCode_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public abstract List<TaxDetails> DropDownPurchaseTaxCodeForClient(System.Int32? clientId);
        //[001] code end

		#endregion
				
		/// <summary>
		/// Returns a new TaxDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual TaxDetails GetTaxFromReader(DbDataReader reader) {
			TaxDetails tax = new TaxDetails();
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
		protected virtual List<TaxDetails> GetTaxCollectionFromReader(DbDataReader reader) {
			List<TaxDetails> taxs = new List<TaxDetails>();
			while (reader.Read()) taxs.Add(GetTaxFromReader(reader));
			return taxs;
		}
		
		
	}
}