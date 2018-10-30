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
	
	public abstract class DataListNuggetStateProvider : DataAccess {
		static private DataListNuggetStateProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DataListNuggetStateProvider Instance {
			get {
				if (_instance == null) _instance = (DataListNuggetStateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.DataListNuggetStates.ProviderType));
				return _instance;
			}
		}
		public DataListNuggetStateProvider() {
			this.ConnectionString = Globals.Settings.DataListNuggetStates.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DeleteAllForLogin
		/// Calls [usp_delete_DataListNuggetState_All_for_Login]
		/// </summary>
		public abstract bool DeleteAllForLogin(System.Int32? loginNo);
		/// <summary>
		/// DeleteForDLNAndLogin
		/// Calls [usp_delete_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public abstract bool DeleteForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo);
		/// <summary>
		/// GetForDLNAndLogin
		/// Calls [usp_select_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public abstract DataListNuggetStateDetails GetForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo);
		/// <summary>
		/// UpdateForDLNAndLogin
		/// Calls [usp_update_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public abstract bool UpdateForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo, System.String stateText);

		#endregion
				
		/// <summary>
		/// Returns a new DataListNuggetStateDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DataListNuggetStateDetails GetDataListNuggetStateFromReader(DbDataReader reader) {
			DataListNuggetStateDetails dataListNuggetState = new DataListNuggetStateDetails();
			if (reader.HasRows) {
				dataListNuggetState.DataListNuggetStateID = GetReaderValue_Int32(reader, "DataListNuggetStateID", 0); //From: [Table]
				dataListNuggetState.DataListNuggetNo = GetReaderValue_Int32(reader, "DataListNuggetNo", 0); //From: [Table]
				dataListNuggetState.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				dataListNuggetState.SubType = GetReaderValue_String(reader, "SubType", ""); //From: [Table]
				dataListNuggetState.StateText = GetReaderValue_String(reader, "StateText", ""); //From: [Table]
				dataListNuggetState.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return dataListNuggetState;
		}
	
		/// <summary>
		/// Returns a collection of DataListNuggetStateDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DataListNuggetStateDetails> GetDataListNuggetStateCollectionFromReader(DbDataReader reader) {
			List<DataListNuggetStateDetails> dataListNuggetStates = new List<DataListNuggetStateDetails>();
			while (reader.Read()) dataListNuggetStates.Add(GetDataListNuggetStateFromReader(reader));
			return dataListNuggetStates;
		}
		
		
	}
}