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
	
	public abstract class SiteSectionProvider : DataAccess {
		static private SiteSectionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SiteSectionProvider Instance {
			get {
				if (_instance == null) _instance = (SiteSectionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SiteSections.ProviderType));
				return _instance;
			}
		}
		public SiteSectionProvider() {
			this.ConnectionString = Globals.Settings.SiteSections.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SiteSection]
		/// </summary>
		public abstract List<SiteSectionDetails> GetList();

		#endregion
				
		/// <summary>
		/// Returns a new SiteSectionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SiteSectionDetails GetSiteSectionFromReader(DbDataReader reader) {
			SiteSectionDetails siteSection = new SiteSectionDetails();
			if (reader.HasRows) {
				siteSection.SiteSectionId = GetReaderValue_Int32(reader, "SiteSectionId", 0); //From: [Table]
				siteSection.SiteSectionName = GetReaderValue_String(reader, "SiteSectionName", ""); //From: [usp_selectAll_SecurityFunction_Section]
				siteSection.Description = GetReaderValue_String(reader, "Description", ""); //From: [Table]
				siteSection.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
			}
			return siteSection;
		}
	
		/// <summary>
		/// Returns a collection of SiteSectionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SiteSectionDetails> GetSiteSectionCollectionFromReader(DbDataReader reader) {
			List<SiteSectionDetails> siteSections = new List<SiteSectionDetails>();
			while (reader.Read()) siteSections.Add(GetSiteSectionFromReader(reader));
			return siteSections;
		}
		
		
	}
}