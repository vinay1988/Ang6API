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
	
	public abstract class ReportParameterTypeProvider : DataAccess {
		static private ReportParameterTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportParameterTypeProvider Instance {
			get {
				if (_instance == null) _instance = (ReportParameterTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportParameterTypes.ProviderType));
				return _instance;
			}
		}
		public ReportParameterTypeProvider() {
			this.ConnectionString = Globals.Settings.ReportParameterTypes.ConnectionString;
		}

		#region Method Registrations
		

		#endregion
				
		/// <summary>
		/// Returns a new ReportParameterTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportParameterTypeDetails GetReportParameterTypeFromReader(DbDataReader reader) {
			ReportParameterTypeDetails reportParameterType = new ReportParameterTypeDetails();
			if (reader.HasRows) {
				reportParameterType.ReportParameterTypeId = GetReaderValue_Int32(reader, "ReportParameterTypeId", 0); //From: [Table]
				reportParameterType.ReportParameterName = GetReaderValue_String(reader, "ReportParameterName", ""); //From: [Table]
			}
			return reportParameterType;
		}
	
		/// <summary>
		/// Returns a collection of ReportParameterTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportParameterTypeDetails> GetReportParameterTypeCollectionFromReader(DbDataReader reader) {
			List<ReportParameterTypeDetails> reportParameterTypes = new List<ReportParameterTypeDetails>();
			while (reader.Read()) reportParameterTypes.Add(GetReportParameterTypeFromReader(reader));
			return reportParameterTypes;
		}
		
		
	}
}