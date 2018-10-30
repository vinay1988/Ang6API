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
	
	public abstract class ReportColumnFormatProvider : DataAccess {
		static private ReportColumnFormatProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportColumnFormatProvider Instance {
			get {
				if (_instance == null) _instance = (ReportColumnFormatProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportColumnFormats.ProviderType));
				return _instance;
			}
		}
		public ReportColumnFormatProvider() {
			this.ConnectionString = Globals.Settings.ReportColumnFormats.ConnectionString;
		}

		#region Method Registrations
		

		#endregion
				
		/// <summary>
		/// Returns a new ReportColumnFormatDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportColumnFormatDetails GetReportColumnFormatFromReader(DbDataReader reader) {
			ReportColumnFormatDetails reportColumnFormat = new ReportColumnFormatDetails();
			if (reader.HasRows) {
				reportColumnFormat.ReportColumnFormatId = GetReaderValue_Int32(reader, "ReportColumnFormatId", 0); //From: [Table]
				reportColumnFormat.ReportColumnFormatName = GetReaderValue_String(reader, "ReportColumnFormatName", ""); //From: [Table]
			}
			return reportColumnFormat;
		}
	
		/// <summary>
		/// Returns a collection of ReportColumnFormatDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportColumnFormatDetails> GetReportColumnFormatCollectionFromReader(DbDataReader reader) {
			List<ReportColumnFormatDetails> reportColumnFormats = new List<ReportColumnFormatDetails>();
			while (reader.Read()) reportColumnFormats.Add(GetReportColumnFormatFromReader(reader));
			return reportColumnFormats;
		}
		
		
	}
}