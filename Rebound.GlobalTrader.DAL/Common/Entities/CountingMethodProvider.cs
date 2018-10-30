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
	
	public abstract class CountingMethodProvider : DataAccess {
		static private CountingMethodProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CountingMethodProvider Instance {
			get {
				if (_instance == null) _instance = (CountingMethodProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CountingMethods.ProviderType));
				return _instance;
			}
		}
		public CountingMethodProvider() {
			this.ConnectionString = Globals.Settings.CountingMethods.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CountingMethod]
		/// </summary>
		public abstract bool Delete(System.Int32? countingMethodId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CountingMethod]
		/// </summary>
		public abstract List<CountingMethodDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CountingMethod]
		/// </summary>
		public abstract Int32 Insert(System.String countingMethodDescription, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_CountingMethod]
		/// </summary>
		public abstract CountingMethodDetails Get(System.Int32? countingMethodId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CountingMethod]
		/// </summary>
		public abstract List<CountingMethodDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_CountingMethod]
		/// </summary>
		public abstract bool Update(System.Int32? countingMethodId, System.String countingMethodDescription, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new CountingMethodDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CountingMethodDetails GetCountingMethodFromReader(DbDataReader reader) {
			CountingMethodDetails countingMethod = new CountingMethodDetails();
			if (reader.HasRows) {
				countingMethod.CountingMethodId = GetReaderValue_Int32(reader, "CountingMethodId", 0); //From: [Table]
				countingMethod.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", ""); //From: [Table]
				countingMethod.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				countingMethod.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				countingMethod.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return countingMethod;
		}
	
		/// <summary>
		/// Returns a collection of CountingMethodDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CountingMethodDetails> GetCountingMethodCollectionFromReader(DbDataReader reader) {
			List<CountingMethodDetails> countingMethods = new List<CountingMethodDetails>();
			while (reader.Read()) countingMethods.Add(GetCountingMethodFromReader(reader));
			return countingMethods;
		}
		
		
	}
}