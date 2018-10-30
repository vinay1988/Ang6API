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
	
	public abstract class GlobalTaxRateProvider : DataAccess {
		static private GlobalTaxRateProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public GlobalTaxRateProvider Instance {
			get {
				if (_instance == null) _instance = (GlobalTaxRateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GlobalTaxRates.ProviderType));
				return _instance;
			}
		}
        public GlobalTaxRateProvider()
        {
            this.ConnectionString = Globals.Settings.GlobalTaxRates.ConnectionString;
		}

		#region Method Registrations
		
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_TaxRate]
		/// </summary>
		public abstract Int32 Insert(System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_TaxRate]
		/// </summary>
        public abstract GlobalTaxRateDetails Get(System.Int32? taxRateId);
			/// <summary>
			/// <summary>
		/// GetListForTax
		/// Calls [usp_selectAll_TaxRate_for_Tax]
		/// </summary>
        public abstract List<GlobalTaxRateDetails> GetListForTax(System.Int32? taxId);
		/// <summary>
		/// Update
		/// Calls [usp_update_TaxRate]
		/// </summary>
		public abstract bool Update(System.Int32? taxRateId, System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new TaxRateDetails instance filled with the DataReader's current record data
		/// </summary>        
        protected virtual GlobalTaxRateDetails GetTaxRateFromReader(DbDataReader reader)
        {
            GlobalTaxRateDetails taxRate = new GlobalTaxRateDetails();
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
        protected virtual List<GlobalTaxRateDetails> GetTaxRateCollectionFromReader(DbDataReader reader)
        {
            List<GlobalTaxRateDetails> taxRates = new List<GlobalTaxRateDetails>();
			while (reader.Read()) taxRates.Add(GetTaxRateFromReader(reader));
			return taxRates;
		}
		
		
	}
}