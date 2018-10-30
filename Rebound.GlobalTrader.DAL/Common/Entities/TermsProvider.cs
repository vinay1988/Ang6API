//Marker     changed by      date         Remarks
//[001]      Vinay           28/11/2012   Apply a bank fee charge to the customers final invoice
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
	
	public abstract class TermsProvider : DataAccess {
		static private TermsProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public TermsProvider Instance {
			get {
				if (_instance == null) _instance = (TermsProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Termss.ProviderType));
				return _instance;
			}
		}
		public TermsProvider() {
			this.ConnectionString = Globals.Settings.Termss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Terms]
		/// </summary>
		public abstract bool Delete(System.Int32? termsId);
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_Terms_Buy_for_Client]
		/// </summary>
		public abstract List<TermsDetails> DropDownBuyForClient(System.Int32? clientId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Terms_for_Client]
		/// </summary>
		public abstract List<TermsDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_Terms_Sell_for_Client]
		/// </summary>
		public abstract List<TermsDetails> DropDownSellForClient(System.Int32? clientId);
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Terms]
		/// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee, System.Boolean? isApplyPOBankFee, System.Double? poBankFee);
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Terms]
		/// </summary>
		public abstract TermsDetails Get(System.Int32? termsId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Terms_for_Client]
		/// </summary>
		public abstract List<TermsDetails> GetListForClient(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize);
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Terms]
		/// </summary>
        public abstract bool Update(System.Int32? termsId, System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee, System.Boolean? isApplyPOBankFee, System.Double? poBankFee);
        //[001] code end
		#endregion
				
		/// <summary>
		/// Returns a new TermsDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual TermsDetails GetTermsFromReader(DbDataReader reader) {
			TermsDetails terms = new TermsDetails();
			if (reader.HasRows) {
				terms.TermsId = GetReaderValue_Int32(reader, "TermsId", 0); //From: [Table]
				terms.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				terms.Days = GetReaderValue_Int32(reader, "Days", 0); //From: [Table]
				terms.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_datalistnugget_Company_as_Customers]
				terms.Buy = GetReaderValue_Boolean(reader, "Buy", false); //From: [Table]
				terms.Sell = GetReaderValue_Boolean(reader, "Sell", false); //From: [Table]
				terms.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false); //From: [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
				terms.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				terms.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				terms.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return terms;
		}
	
		/// <summary>
		/// Returns a collection of TermsDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<TermsDetails> GetTermsCollectionFromReader(DbDataReader reader) {
			List<TermsDetails> termss = new List<TermsDetails>();
			while (reader.Read()) termss.Add(GetTermsFromReader(reader));
			return termss;
		}
		
		
	}
}