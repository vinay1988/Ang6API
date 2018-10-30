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
	
	public abstract class ActivityProvider : DataAccess {
		static private ActivityProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ActivityProvider Instance {
			get {
				if (_instance == null) _instance = (ActivityProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Activitys.ProviderType));
				return _instance;
			}
		}
		public ActivityProvider() {
			this.ConnectionString = Globals.Settings.Activitys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// ListByClientWithFilter
		/// Calls [usp_list_Activity_by_Client_with_filter]
		/// </summary>
		public abstract List<ActivityDetails> ListByClientWithFilter(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch);
		/// <summary>
		/// ListByLoginWithFilter
		/// Calls [usp_list_Activity_by_Login_with_filter]
		/// </summary>
		public abstract List<ActivityDetails> ListByLoginWithFilter(System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch);
		/// <summary>
		/// 
		/// Calls [usp_prune_Activity]
		/// </summary>

		#endregion
				
		/// <summary>
		/// Returns a new ActivityDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ActivityDetails GetActivityFromReader(DbDataReader reader) {
			ActivityDetails activity = new ActivityDetails();
			if (reader.HasRows) {
				activity.ActivityId = GetReaderValue_Int32(reader, "ActivityId", 0); //From: [Table]
				activity.TableName = GetReaderValue_String(reader, "TableName", ""); //From: [Table]
				activity.KeyNo = GetReaderValue_Int32(reader, "KeyNo", 0); //From: [Table]
				activity.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				activity.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				activity.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				activity.RowId = GetReaderValue_Int32(reader, "RowId", 0); //From: [usp_list_Activity_by_Client_with_filter]
				activity.RowNumber = GetReaderValue_Int32(reader, "RowNumber", 0); //From: [usp_list_Activity_by_Client_with_filter]
				activity.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_list_Activity_by_Client_with_filter]
				activity.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				activity.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
				activity.PartName = GetReaderValue_String(reader, "PartName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				activity.RowValue = GetReaderValue_NullableDouble(reader, "RowValue", null); //From: [usp_list_Activity_by_Client_with_filter]
				activity.RowDate = GetReaderValue_DateTime(reader, "RowDate", DateTime.MinValue); //From: [usp_list_Activity_by_Client_with_filter]
				activity.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				activity.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
			}
			return activity;
		}
	
		/// <summary>
		/// Returns a collection of ActivityDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ActivityDetails> GetActivityCollectionFromReader(DbDataReader reader) {
			List<ActivityDetails> activitys = new List<ActivityDetails>();
			while (reader.Read()) activitys.Add(GetActivityFromReader(reader));
			return activitys;
		}
		
		
	}
}