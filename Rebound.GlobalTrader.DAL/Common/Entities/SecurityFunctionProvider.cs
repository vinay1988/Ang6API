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
	
	public abstract class SecurityFunctionProvider : DataAccess {
		static private SecurityFunctionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SecurityFunctionProvider Instance {
			get {
				if (_instance == null) _instance = (SecurityFunctionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SecurityFunctions.ProviderType));
				return _instance;
			}
		}
		public SecurityFunctionProvider() {
			this.ConnectionString = Globals.Settings.SecurityFunctions.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityFunction]
		/// </summary>
		public abstract SecurityFunctionDetails Get(System.Int32? securityFunctionNo);
		/// <summary>
		/// GetBySitePage
		/// Calls [usp_select_SecurityFunction_by_SitePage]
		/// </summary>
		public abstract SecurityFunctionDetails GetBySitePage(System.Int32? sitePageNo);
		/// <summary>
		/// GetPermissionByLogin
		/// Calls [usp_select_SecurityFunction_Permission_by_Login]
		/// </summary>
		public abstract SecurityFunctionDetails GetPermissionByLogin(System.Int32? securityFunctionNo, System.Int32? loginNo);
		/// <summary>
		/// GetReportPermissionForLogin
		/// Calls [usp_select_SecurityFunction_Report_Permission_for_Login]
		/// </summary>
		public abstract SecurityFunctionDetails GetReportPermissionForLogin(System.Int32? loginNo, System.Int32? reportNo);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SecurityFunction]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetList();
		/// <summary>
		/// GetListBySitePage
		/// Calls [usp_selectAll_SecurityFunction_by_SitePage]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListBySitePage(System.Int32? sitePageNo);
		/// <summary>
		/// GetListGeneral
		/// Calls [usp_selectAll_SecurityFunction_General]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListGeneral();
		/// <summary>
		/// GetListGeneralPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_Login]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListGeneralPermissionsByLogin(System.Int32? loginNo);
		/// <summary>
		/// GetListGeneralPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_SecurityGroup]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListGeneralPermissionsBySecurityGroup(System.Int32? securityGroupId);
		/// <summary>
		/// GetListPage
		/// Calls [usp_selectAll_SecurityFunction_Page]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPage();
		/// <summary>
		/// GetListPageBySiteSection
		/// Calls [usp_selectAll_SecurityFunction_Page_by_SiteSection]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPageBySiteSection(System.Int32? siteSectionNo);
		/// <summary>
		/// GetListPagePermissionsByPage
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPagePermissionsByPage(System.Int32? pageId);
		/// <summary>
		/// GetListPagePermissionsByPageAndLogin
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page_and_Login]
		/// </summary>
        public abstract List<SecurityFunctionDetails> GetListPagePermissionsByPageAndLogin(System.Int32? sitePageNo, System.Int32? loginNo, System.Boolean? dataHasOtherClient);
		/// <summary>
		/// GetListPagePermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPagePermissionsBySecurityGroup(System.Int32? securityGroupId);
		/// <summary>
		/// GetListPagePermissionsBySecurityGroupAndPage
		/// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup_and_Page]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPagePermissionsBySecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId);
		/// <summary>
		/// GetListPermissionsByLoginAndReport
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_Report]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPermissionsByLoginAndReport(System.Int32? loginNo, System.Int32? reportNo);
		/// <summary>
		/// GetListPermissionsByLoginAndSitePage
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SitePage]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListPermissionsByLoginAndSitePage(System.Int32? loginNo, System.Int32? sitePageNo);
		/// <summary>
		/// GetListPermissionsByLoginAndSiteSection
		/// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SiteSection]
		/// </summary>
        public abstract List<SecurityFunctionDetails> GetListPermissionsByLoginAndSiteSection(System.Int32? loginNo, System.Int32? siteSectionNo, System.Boolean? isDataOtherClient);
		/// <summary>
		/// GetListReport
		/// Calls [usp_selectAll_SecurityFunction_Report]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListReport();
		/// <summary>
		/// GetListReportPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_Login]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListReportPermissionsByLogin(System.Int32? loginNo);
		/// <summary>
		/// GetListReportPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_SecurityGroup]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListReportPermissionsBySecurityGroup(System.Int32? securityGroupId);
		/// <summary>
		/// GetListSection
		/// Calls [usp_selectAll_SecurityFunction_Section]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListSection(System.Int32? sectionNo);
		/// <summary>
		/// GetListSectionPermissionsByLogin
		/// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_Login]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListSectionPermissionsByLogin(System.Int32? loginNo);
		/// <summary>
		/// GetListSectionPermissionsBySecurityGroup
		/// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_SecurityGroup]
		/// </summary>
		public abstract List<SecurityFunctionDetails> GetListSectionPermissionsBySecurityGroup(System.Int32? securityGroupId);

        /// <summary>
        /// CheckAdminPermissionsByLogin
        /// Calls [usp_check_admin_Permissions_by_Login]
        /// </summary>
        public abstract SecurityFunctionDetails CheckAdminPermissionsByLogin(System.Int32? loginNo);

        /// <summary>
        /// GetListGeneralPermissionsBySecurityGroup
        /// Calls [usp_selectAll_GlobalSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public abstract List<SecurityFunctionDetails> GetListGeneralPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId);

        /// <summary>
        /// GetListSectionPermissionsByGlobalSecurityGroup
        /// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_GlobalSecurityGroup]
        /// </summary>
        public abstract List<SecurityFunctionDetails> GetListSectionPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId);

        /// <summary>
        /// GetListPagePermissionsByGlobalSecurityGroupAndPage
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_GlobalSecurityGroup_and_Page]
        /// </summary>
        public abstract List<SecurityFunctionDetails> GetListPagePermissionsByGlobalSecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId);

        /// <summary>
        /// GetListBySitePage
        /// Calls [usp_selectAll_GlobalSecurityFunction_by_SitePage]
        /// </summary>
        public abstract List<SecurityFunctionDetails> GetGlobalListBySitePage(System.Int32? sitePageNo);

		#endregion
				
		/// <summary>
		/// Returns a new SecurityFunctionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SecurityFunctionDetails GetSecurityFunctionFromReader(DbDataReader reader) {
			SecurityFunctionDetails securityFunction = new SecurityFunctionDetails();
			if (reader.HasRows) {
				securityFunction.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0); //From: [Table]
				securityFunction.FunctionName = GetReaderValue_String(reader, "FunctionName", ""); //From: [Table]
				securityFunction.Description = GetReaderValue_String(reader, "Description", ""); //From: [Table]
				securityFunction.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null); //From: [Table]
				securityFunction.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null); //From: [Table]
				securityFunction.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null); //From: [Table]
				securityFunction.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				securityFunction.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				securityFunction.InitiallyProhibitedForNewLogins = GetReaderValue_Boolean(reader, "InitiallyProhibitedForNewLogins", false); //From: [Table]
				securityFunction.DisplaySortOrder = GetReaderValue_NullableInt32(reader, "DisplaySortOrder", null); //From: [Table]
				securityFunction.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null); //From: [usp_select_SecurityFunction_Permission_by_Login]
				securityFunction.ReportId = GetReaderValue_Int32(reader, "ReportId", 0); //From: [Table]
				securityFunction.ReportName = GetReaderValue_String(reader, "ReportName", ""); //From: [Table]
				securityFunction.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", ""); //From: [usp_select_Report]
				securityFunction.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", ""); //From: [usp_select_Report]
				securityFunction.SiteSectionName = GetReaderValue_String(reader, "SiteSectionName", ""); //From: [usp_selectAll_SecurityFunction_Section]
			}
			return securityFunction;
		}
	
		/// <summary>
		/// Returns a collection of SecurityFunctionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SecurityFunctionDetails> GetSecurityFunctionCollectionFromReader(DbDataReader reader) {
			List<SecurityFunctionDetails> securityFunctions = new List<SecurityFunctionDetails>();
			while (reader.Read()) securityFunctions.Add(GetSecurityFunctionFromReader(reader));
			return securityFunctions;
		}
		
		
	}
}