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
	
	public abstract class ReportParameterProvider : DataAccess {
		static private ReportParameterProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportParameterProvider Instance {
			get {
				if (_instance == null) _instance = (ReportParameterProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportParameters.ProviderType));
				return _instance;
			}
		}
		public ReportParameterProvider() {
			this.ConnectionString = Globals.Settings.ReportParameters.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetListForReport
		/// Calls [usp_selectAll_ReportParameter_for_Report]
		/// </summary>
		public abstract List<ReportParameterDetails> GetListForReport(System.Int32? reportNo);

		#endregion
				
		/// <summary>
		/// Returns a new ReportParameterDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportParameterDetails GetReportParameterFromReader(DbDataReader reader) {
			ReportParameterDetails reportParameter = new ReportParameterDetails();
			if (reader.HasRows) {
				reportParameter.ReportParameterId = GetReaderValue_Int32(reader, "ReportParameterId", 0); //From: [Table]
				reportParameter.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null); //From: [Table]
				reportParameter.ParameterName = GetReaderValue_String(reader, "ParameterName", ""); //From: [Table]
				reportParameter.Description = GetReaderValue_String(reader, "Description", ""); //From: [Table]
				reportParameter.ReportParameterTypeNo = GetReaderValue_NullableInt32(reader, "ReportParameterTypeNo", null); //From: [Table]
				reportParameter.DropDownNo = GetReaderValue_NullableInt32(reader, "DropDownNo", null); //From: [Table]
				reportParameter.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
				reportParameter.ComboAutoSearchNo = GetReaderValue_NullableInt32(reader, "ComboAutoSearchNo", null); //From: [Table]
				reportParameter.Optional = GetReaderValue_Boolean(reader, "Optional", false); //From: [Table]
			}
			return reportParameter;
		}
	
		/// <summary>
		/// Returns a collection of ReportParameterDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportParameterDetails> GetReportParameterCollectionFromReader(DbDataReader reader) {
			List<ReportParameterDetails> reportParameters = new List<ReportParameterDetails>();
			while (reader.Read()) reportParameters.Add(GetReportParameterFromReader(reader));
			return reportParameters;
		}
		
		
	}
}