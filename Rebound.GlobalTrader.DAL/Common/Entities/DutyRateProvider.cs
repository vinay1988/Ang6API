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
	
	public abstract class DutyRateProvider : DataAccess {
		static private DutyRateProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DutyRateProvider Instance {
			get {
				if (_instance == null) _instance = (DutyRateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.DutyRates.ProviderType));
				return _instance;
			}
		}
		public DutyRateProvider() {
			this.ConnectionString = Globals.Settings.DutyRates.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_DutyRate]
		/// </summary>
		public abstract bool Delete(System.Int32? dutyRateId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_DutyRate]
		/// </summary>
		public abstract Int32 Insert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalDutyRate]
        /// </summary>
        public abstract Int32 GlobalInsert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy);
        /// <summary>
		/// Get
		/// Calls [usp_select_DutyRate]
		/// </summary>
		public abstract DutyRateDetails Get(System.Int32? dutyRateId);
		/// <summary>
		/// GetCurrentForProduct
		/// Calls [usp_select_DutyRate_Current_for_Product]
		/// </summary>
		public abstract DutyRateDetails GetCurrentForProduct(System.Int32? productNo, System.DateTime? datePoint);
		/// <summary>
		/// GetListForProduct
		/// Calls [usp_selectAll_DutyRate_for_Product]
		/// </summary>
		public abstract List<DutyRateDetails> GetListForProduct(System.Int32? productId);
        /// <summary>
        /// GetListForProduct
        /// Calls [usp_selectAll_DutyRate_for_GlobalProduct]
        /// </summary>
        public abstract List<DutyRateDetails> GetListForGlobalProduct(System.Int32? productId);
		/// <summary>
		/// Update
		/// Calls [usp_update_DutyRate]
		/// </summary>
		public abstract bool Update(System.Int32? dutyRateId, System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new DutyRateDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DutyRateDetails GetDutyRateFromReader(DbDataReader reader) {
			DutyRateDetails dutyRate = new DutyRateDetails();
			if (reader.HasRows) {
				dutyRate.DutyRateId = GetReaderValue_Int32(reader, "DutyRateId", 0); //From: [Table]
				dutyRate.DutyDate = GetReaderValue_NullableDateTime(reader, "DutyDate", null); //From: [Table]
				dutyRate.DutyRateValue = GetReaderValue_NullableDouble(reader, "DutyRateValue", null); //From: [Table]
				dutyRate.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0); //From: [usp_selectAll_Allocation]
				dutyRate.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				dutyRate.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return dutyRate;
		}
	
		/// <summary>
		/// Returns a collection of DutyRateDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DutyRateDetails> GetDutyRateCollectionFromReader(DbDataReader reader) {
			List<DutyRateDetails> dutyRates = new List<DutyRateDetails>();
			while (reader.Read()) dutyRates.Add(GetDutyRateFromReader(reader));
			return dutyRates;
		}
		
		
	}
}