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
	
	public abstract class TaxRateProvider : DataAccess {
		static private TaxRateProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public TaxRateProvider Instance {
			get {
				if (_instance == null) _instance = (TaxRateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.TaxRates.ProviderType));
				return _instance;
			}
		}
		public TaxRateProvider() {
			this.ConnectionString = Globals.Settings.TaxRates.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_TaxRate]
		/// </summary>
		public abstract bool Delete(System.Int32? taxRateId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_TaxRate]
		/// </summary>
		public abstract Int32 Insert(System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_TaxRate]
		/// </summary>
		public abstract TaxRateDetails Get(System.Int32? taxRateId);
		/// <summary>
		/// Get2ForTaxAndDate
		/// Calls [usp_select_TaxRate_2_for_Tax_and_Date]
		/// </summary>
		public abstract TaxRateDetails Get2ForTaxAndDate(System.Int32? taxNo, System.Int32? clientNo, System.DateTime? taxPoint);
		/// <summary>
		/// GetForTaxAndDate
		/// Calls [usp_select_TaxRate_for_Tax_and_Date]
		/// </summary>
		public abstract TaxRateDetails GetForTaxAndDate(System.Int32? taxNo, System.Int32? clientNo, System.DateTime? taxPoint);
		/// <summary>
		/// GetListForTax
		/// Calls [usp_selectAll_TaxRate_for_Tax]
		/// </summary>
		public abstract List<TaxRateDetails> GetListForTax(System.Int32? taxId);
		/// <summary>
		/// Update
		/// Calls [usp_update_TaxRate]
		/// </summary>
		public abstract bool Update(System.Int32? taxRateId, System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new TaxRateDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual TaxRateDetails GetTaxRateFromReader(DbDataReader reader) {
			TaxRateDetails taxRate = new TaxRateDetails();
			if (reader.HasRows) {
				taxRate.TaxRateId = GetReaderValue_Int32(reader, "TaxRateId", 0); //From: [Table]
				taxRate.TaxDate = GetReaderValue_DateTime(reader, "TaxDate", DateTime.MinValue); //From: [Table]
				taxRate.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
				taxRate.Rate1 = GetReaderValue_NullableDouble(reader, "Rate1", null); //From: [Table]
				taxRate.Rate2 = GetReaderValue_NullableDouble(reader, "Rate2", null); //From: [Table]
				taxRate.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				taxRate.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				taxRate.CurrentTaxRate = GetReaderValue_NullableDouble(reader, "CurrentTaxRate", null); //From: [usp_select_TaxRate_2_for_Tax_and_Date]
			}
			return taxRate;
		}
	
		/// <summary>
		/// Returns a collection of TaxRateDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<TaxRateDetails> GetTaxRateCollectionFromReader(DbDataReader reader) {
			List<TaxRateDetails> taxRates = new List<TaxRateDetails>();
			while (reader.Read()) taxRates.Add(GetTaxRateFromReader(reader));
			return taxRates;
		}
		
		
	}
}