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
	
	public abstract class SitePageProvider : DataAccess {
		static private SitePageProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SitePageProvider Instance {
			get {
				if (_instance == null) _instance = (SitePageProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SitePages.ProviderType));
				return _instance;
			}
		}
		public SitePageProvider() {
			this.ConnectionString = Globals.Settings.SitePages.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SitePage]
		/// </summary>
		public abstract List<SitePageDetails> GetList();
		/// <summary>
		/// GetListHavingSecurityFunctionBySiteSection
		/// Calls [usp_selectAll_SitePage_having_SecurityFunction_by_SiteSection]
		/// </summary>
		public abstract List<SitePageDetails> GetListHavingSecurityFunctionBySiteSection(System.Int32? siteSectionNo);

		#endregion
				
		/// <summary>
		/// Returns a new SitePageDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SitePageDetails GetSitePageFromReader(DbDataReader reader) {
			SitePageDetails sitePage = new SitePageDetails();
			if (reader.HasRows) {
				sitePage.SitePageId = GetReaderValue_Int32(reader, "SitePageId", 0); //From: [Table]
				sitePage.ShortName = GetReaderValue_String(reader, "ShortName", ""); //From: [Table]
				sitePage.Description = GetReaderValue_String(reader, "Description", ""); //From: [Table]
				sitePage.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				sitePage.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null); //From: [Table]
				sitePage.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				sitePage.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return sitePage;
		}
	
		/// <summary>
		/// Returns a collection of SitePageDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SitePageDetails> GetSitePageCollectionFromReader(DbDataReader reader) {
			List<SitePageDetails> sitePages = new List<SitePageDetails>();
			while (reader.Read()) sitePages.Add(GetSitePageFromReader(reader));
			return sitePages;
		}
		
		
	}
}