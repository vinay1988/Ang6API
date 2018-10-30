/*
Marker     changed by      date         Remarks
[001]      Vinay           19/07/2012   Display invoice email status report
[002]      Vinay           22/11/2012   Add Failed only  filter
*/
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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Report : BizObject {
		
		#region Properties

		protected static DAL.ReportElement Settings {
			get { return Globals.Settings.Reports; }
		}

		/// <summary>
		/// ReportId
		/// </summary>
		public System.Int32 ReportId { get; set; }		
		/// <summary>
		/// ReportName
		/// </summary>
		public System.String ReportName { get; set; }		
		/// <summary>
		/// ReportCategoryNo
		/// </summary>
		public System.Int32? ReportCategoryNo { get; set; }		
		/// <summary>
		/// StoredProcName
		/// </summary>
		public System.String StoredProcName { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// AvailableAsPDF
		/// </summary>
		public System.Boolean AvailableAsPDF { get; set; }		
		/// <summary>
		/// SortOrder
		/// </summary>
		public System.Int32? SortOrder { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ReportCategoryName
		/// </summary>
		public System.String ReportCategoryName { get; set; }		
		/// <summary>
		/// ReportCategorySortOrder
		/// </summary>
		public System.Int32? ReportCategorySortOrder { get; set; }		
		/// <summary>
		/// ReportCategoryGroupNo
		/// </summary>
		public System.Int32? ReportCategoryGroupNo { get; set; }		
		/// <summary>
		/// ReportCategoryGroupName
		/// </summary>
		public System.String ReportCategoryGroupName { get; set; }		
		/// <summary>
		/// ReportCategoryGroupSortOrder
		/// </summary>
		public System.String ReportCategoryGroupSortOrder { get; set; }
        public System.Boolean? HUBReport { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Report]
		/// </summary>
		public static bool Delete(System.Int32? reportId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Delete(reportId);
		}

		/// <summary>
		/// Report101
		/// Calls [usp_report_Report_101]
		/// </summary>
        public static List<List<object>> Report101(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report101(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report102
		/// Calls [usp_report_Report_102]
		/// </summary>
		public static List<List<object>> Report102(System.Int32? clientNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report102(clientNo);
		}

		/// <summary>
		/// Report103
		/// Calls [usp_report_Report_103]
		/// </summary>
		public static List<List<object>> Report103(System.Int32? clientNo, System.Int32? salesman) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report103(clientNo, salesman);
		}

		/// <summary>
		/// Report104
		/// Calls [usp_report_Report_104]
		/// </summary>
		public static List<List<object>> Report104(System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report104(startDate, endDate);
		}

		/// <summary>
		/// Report105
		/// Calls [usp_report_Report_105]
		/// </summary>
		public static List<List<object>> Report105(System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report105(startDate, endDate);
		}

		/// <summary>
		/// Report107
		/// Calls [usp_report_Report_107]
		/// </summary>
		public static List<List<object>> Report107(System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report107(startDate, endDate);
		}

		/// <summary>
		/// Report108
		/// Calls [usp_report_Report_108]
		/// </summary>
		public static List<List<object>> Report108(System.Int32? loginId, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report108(loginId, startDate, endDate);
		}

		/// <summary>
		/// Report109
		/// Calls [usp_report_Report_109]
		/// </summary>
        public static List<List<object>> Report109(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report109(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report110
		/// Calls [usp_report_Report_110]
		/// </summary>
        public static List<List<object>> Report110(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report110(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report111
		/// Calls [usp_report_Report_111]
		/// </summary>
		public static List<List<object>> Report111() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report111();
		}

		/// <summary>
		/// Report112
		/// Calls [usp_report_Report_112]
		/// </summary>
		public static List<List<object>> Report112() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report112();
		}

		/// <summary>
		/// Report113
		/// Calls [usp_report_Report_113]
		/// </summary>
        public static List<List<object>> Report113(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report113(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report114
		/// Calls [usp_report_Report_114]
		/// </summary>
        public static List<List<object>> Report114(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report114(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report117
		/// Calls [usp_report_Report_117]
		/// </summary>
        public static List<List<object>> Report117(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report117(clientNo, excludeOnStop, includeUnpaid, dueDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report118
		/// Calls [usp_report_Report_118]
		/// </summary>
        public static List<List<object>> Report118(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report118(clientNo, excludeOnStop, includeUnpaid, dueDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report119
		/// Calls [usp_report_Report_119]
		/// </summary>
		public static List<List<object>> Report119(System.Int32? clientNo, System.Int32? salesman, System.DateTime? dueDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report119(clientNo, salesman, dueDate);
		}

		/// <summary>
		/// Report120
		/// Calls [usp_report_Report_120]
		/// </summary>
        public static List<List<object>> Report120(System.Int32? clientNo, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report120(clientNo, dueDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report121
		/// Calls [usp_report_Report_121]
		/// </summary>
        public static List<List<object>> Report121(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.String status, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report121(clientNo, startDate, endDate, status,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report121A
		/// Calls [usp_report_Report_121A]
		/// </summary>
		public static List<List<object>> Report121A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.String status) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report121A(clientNo, salesman, startDate, endDate, status);
		}

		/// <summary>
		/// Report121B
		/// Calls [usp_report_Report_121B]
		/// </summary>
		public static List<List<object>> Report121B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate, System.String status) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report121B(clientNo, buyer, startDate, endDate, status);
		}

		/// <summary>
		/// Report122
		/// Calls [usp_report_Report_122]
		/// </summary>
		public static List<List<object>> Report122(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly, System.String location) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report122(clientNo, warehouseNo, valueStockOnly, location);
		}

		/// <summary>
		/// Report122A
		/// Calls [usp_report_Report_122A]
		/// </summary>
		public static List<List<object>> Report122A(System.Int32? clientNo, System.Int32? warehouseNo, System.Int32? lotNo, System.Boolean? valueStockOnly, System.String location) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report122A(clientNo, warehouseNo, lotNo, valueStockOnly, location);
		}

		/// <summary>
		/// Report122B
		/// Calls [usp_report_Report_122B]
		/// </summary>
		public static List<List<object>> Report122B() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report122B();
		}

		/// <summary>
		/// Report123
		/// Calls [usp_report_Report_123]
		/// </summary>
        public static List<List<object>> Report123(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report123(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report123A
		/// Calls [usp_report_Report_123A]
		/// </summary>
        public static List<List<object>> Report123A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report123A(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report124
		/// Calls [usp_report_Report_124]
		/// </summary>
        public static List<List<object>> Report124(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeShipping, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report124(clientNo, startDate, endDate, includeShipping,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report124A
		/// Calls [usp_report_Report_124A]
		/// </summary>
		public static List<List<object>> Report124A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report124A(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report124B
		/// Calls [usp_report_Report_124B]
		/// </summary>
        public static List<List<object>> Report124B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report124B(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report125
		/// Calls [usp_report_Report_125]
		/// </summary>
        public static List<List<object>> Report125(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report125(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report125A
		/// Calls [usp_report_Report_125A]
		/// </summary>
		public static List<List<object>> Report125A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report125A(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report125B
		/// Calls [usp_report_Report_125B]
		/// </summary>
        public static List<List<object>> Report125B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report125B(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report126
		/// Calls [usp_report_Report_126]
		/// </summary>
		public static List<List<object>> Report126(System.Int32? clientNo, System.Int32? salesman) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report126(clientNo, salesman);
		}

		/// <summary>
		/// Report128
		/// Calls [usp_report_Report_128]
		/// </summary>
        public static List<List<object>> Report128(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report128(clientNo, startDate, endDate, postedOnly,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report128A
		/// Calls [usp_report_Report_128A]
		/// </summary>
		public static List<List<object>> Report128A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report128A(clientNo, salesman, startDate, endDate, postedOnly);
		}

		/// <summary>
		/// Report129
		/// Calls [usp_report_Report_129]
		/// </summary>
        public static List<List<object>> Report129(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report129(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report130
		/// Calls [usp_report_Report_130]
		/// </summary>
        public static List<List<object>> Report130(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report130(clientNo, startDate, endDate, includeCredits, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report130A
		/// Calls [usp_report_Report_130A]
		/// </summary>
        public static List<List<object>> Report130A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report130A(clientNo, startDate, endDate, includeCredits, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report130B
		/// Calls [usp_report_Report_130B]
		/// </summary>
        public static List<List<object>> Report130B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report130B(clientNo, startDate, endDate, includeCredits,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report133
		/// Calls [usp_report_Report_133]
		/// </summary>
		public static List<List<object>> Report133(System.Int32? clientNo, System.Boolean? includeOnOrder, System.Boolean? unallocatedOnly, System.Boolean? includeLotsOnHold) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report133(clientNo, includeOnOrder, unallocatedOnly, includeLotsOnHold);
		}

		/// <summary>
		/// Report133A
		/// Calls [usp_report_Report_133A]
		/// </summary>
		public static List<List<object>> Report133A() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report133A();
		}

		/// <summary>
		/// Report137
		/// Calls [usp_report_Report_137]
		/// </summary>
        public static List<List<object>> Report137(System.Int32? clientNo, System.Int32? lotNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report137(clientNo, lotNo, startDate, endDate, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report139
		/// Calls [usp_report_Report_139]
		/// </summary>
        public static List<List<object>> Report139(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report139(clientNo, startDate, endDate, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report139A
		/// Calls [usp_report_Report_139A]
		/// </summary>
        public static List<List<object>> Report139A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report139A(clientNo, startDate, endDate, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report139B
		/// Calls [usp_report_Report_139B]
		/// </summary>
        public static List<List<object>> Report139B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report139B(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report143
		/// Calls [usp_report_Report_143]
		/// </summary>
		public static List<List<object>> Report143(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report143(clientNo, warehouseNo, valueStockOnly);
		}

		/// <summary>
		/// Report143A
		/// Calls [usp_report_Report_143A]
		/// </summary>
		public static List<List<object>> Report143A() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report143A();
		}

		/// <summary>
		/// Report144
		/// Calls [usp_report_Report_144]
		/// </summary>
        public static List<List<object>> Report144(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report144(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report144A
		/// Calls [usp_report_Report_144A]
		/// </summary>
        public static List<List<object>> Report144A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report144A(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report144B
		/// Calls [usp_report_Report_144B]
		/// </summary>
		public static List<List<object>> Report144B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report144B(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report147
		/// Calls [usp_report_Report_147]
		/// </summary>
        public static List<List<object>> Report147(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report147(clientNo, startDate, endDate, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report147A
		/// Calls [usp_report_Report_147A]
		/// </summary>
        public static List<List<object>> Report147A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report147A(clientNo, startDate, endDate, intLoginId, ViewMyReport);
		}

		/// <summary>
		/// Report147B
		/// Calls [usp_report_Report_147B]
		/// </summary>
        public static List<List<object>> Report147B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report147B(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report149
		/// Calls [usp_report_Report_149]
		/// </summary>
		public static List<List<object>> Report149(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report149(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report150
		/// Calls [usp_report_Report_150]
		/// </summary>
        public static List<List<object>> Report150(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report150A
		/// Calls [usp_report_Report_150A]
		/// </summary>
        public static List<List<object>> Report150A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150A(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report150B
		/// Calls [usp_report_Report_150B]
		/// </summary>
		public static List<List<object>> Report150B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150B(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report150C
		/// Calls [usp_report_Report_150C]
		/// </summary>
		public static List<List<object>> Report150C(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150C(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report150D
		/// Calls [usp_report_Report_150D]
		/// </summary>
        public static List<List<object>> Report150D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150D(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report150E
		/// Calls [usp_report_Report_150E]
		/// </summary>
        public static List<List<object>> Report150E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report150E(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report153
		/// Calls [usp_report_Report_153]
		/// </summary>
        public static List<List<object>> Report153(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report153A
		/// Calls [usp_report_Report_153A]
		/// </summary>
        public static List<List<object>> Report153A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153A(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report153B
		/// Calls [usp_report_Report_153B]
		/// </summary>
		public static List<List<object>> Report153B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153B(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report153C
		/// Calls [usp_report_Report_153C]
		/// </summary>
        public static List<List<object>> Report153C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153C(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report153D
		/// Calls [usp_report_Report_153D]
		/// </summary>
        public static List<List<object>> Report153D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153D(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report153E
		/// Calls [usp_report_Report_153E]
		/// </summary>
		public static List<List<object>> Report153E(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report153E(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report156
		/// Calls [usp_report_Report_156]
		/// </summary>
        public static List<List<object>> Report156(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report156A
		/// Calls [usp_report_Report_156A]
		/// </summary>
        public static List<List<object>> Report156A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156A(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report156B
		/// Calls [usp_report_Report_156B]
		/// </summary>
		public static List<List<object>> Report156B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156B(clientNo, buyer, startDate, endDate);
		}

		/// <summary>
		/// Report156C
		/// Calls [usp_report_Report_156C]
		/// </summary>
		public static List<List<object>> Report156C(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156C(clientNo, buyer, startDate, endDate);
		}

		/// <summary>
		/// Report156D
		/// Calls [usp_report_Report_156D]
		/// </summary>
        public static List<List<object>> Report156D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156D(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report156E
		/// Calls [usp_report_Report_156E]
		/// </summary>
        public static List<List<object>> Report156E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report156E(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report159
		/// Calls [usp_report_Report_159]
		/// </summary>
        public static List<List<object>> Report159(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report159A
		/// Calls [usp_report_Report_159A]
		/// </summary>
		public static List<List<object>> Report159A(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159A(clientNo, buyer, startDate, endDate);
		}

		/// <summary>
		/// Report159B
		/// Calls [usp_report_Report_159B]
		/// </summary>
        public static List<List<object>> Report159B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159B(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report159C
		/// Calls [usp_report_Report_159C]
		/// </summary>
        public static List<List<object>> Report159C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159C(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report159D
		/// Calls [usp_report_Report_159D]
		/// </summary>
		public static List<List<object>> Report159D(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159D(clientNo, buyer, startDate, endDate);
		}

		/// <summary>
		/// Report159E
		/// Calls [usp_report_Report_159E]
		/// </summary>
        public static List<List<object>> Report159E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report159E(clientNo, companyNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report162
		/// Calls [usp_report_Report_162]
		/// </summary>
		public static List<List<object>> Report162(System.Int32? clientNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report162(clientNo);
		}

		/// <summary>
		/// Report176
		/// Calls [usp_report_Report_176]
		/// </summary>
		public static List<List<object>> Report176(System.Int32? clientNo, System.DateTime? dueDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report176(clientNo, dueDate);
		}

		/// <summary>
		/// Report177
		/// Calls [usp_report_Report_177]
		/// </summary>
        public static List<List<object>> Report177(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report177(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report181
		/// Calls [usp_report_Report_181]
		/// </summary>
		public static List<List<object>> Report181(System.Int32? clientNo, System.Int32? warehouseNo, System.String location) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report181(clientNo, warehouseNo, location);
		}

		/// <summary>
		/// Report181A
		/// Calls [usp_report_Report_181A]
		/// </summary>
		public static List<List<object>> Report181A() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report181A();
		}

		/// <summary>
		/// Report182
		/// Calls [usp_report_Report_182]
		/// </summary>
		public static List<List<object>> Report182(System.Int32? clientNo, System.DateTime? cutOffDate, System.Int32? salesman, System.String companyGrouping, System.Boolean? includeNever) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report182(clientNo, cutOffDate, salesman, companyGrouping, includeNever);
		}

		/// <summary>
		/// Report183
		/// Calls [usp_report_Report_183]
		/// </summary>
		public static List<List<object>> Report183(System.Int32? clientNo, System.DateTime? cutOffDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report183(clientNo, cutOffDate);
		}

		/// <summary>
		/// Report184
		/// Calls [usp_report_Report_184]
		/// </summary>
		public static List<List<object>> Report184(System.Int32? clientNo, System.Int32? employee, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report184(clientNo, employee, startDate, endDate);
		}

		/// <summary>
		/// Report185
		/// Calls [usp_report_Report_185]
		/// </summary>
        public static List<List<object>> Report185(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report185(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report185A
		/// Calls [usp_report_Report_185A]
		/// </summary>
        public static List<List<object>> Report185A(System.Int32? clientNo, System.Int32? companyNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report185A(clientNo, companyNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report185B
		/// Calls [usp_report_Report_185B]
		/// </summary>
		public static List<List<object>> Report185B(System.Int32? clientNo, System.Int32? salesman) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report185B(clientNo, salesman);
		}

		/// <summary>
		/// Report188
		/// Calls [usp_report_Report_188]
		/// </summary>
		public static List<List<object>> Report188(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report188(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report189
		/// Calls [usp_report_Report_189]
		/// </summary>
		public static List<List<object>> Report189(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report189(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report190
		/// Calls [usp_report_Report_190]
		/// </summary>
		public static List<List<object>> Report190(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report190(clientNo, salesman, startDate, endDate);
		}

		/// <summary>
		/// Report191
		/// Calls [usp_report_Report_191]
		/// </summary>
		public static List<List<object>> Report191(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report191(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report192
		/// Calls [usp_report_Report_192]
		/// </summary>
        public static List<List<object>> Report192(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report192(clientNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report193
		/// Calls [usp_report_Report_193]
		/// </summary>
        public static List<List<object>> Report193(System.Int32? clientNo, System.Int32? countryNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report193(clientNo, countryNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report194
		/// Calls [usp_report_Report_194]
		/// </summary>
        public static List<List<object>> Report194(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report194(clientNo, warehouseNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report195
		/// Calls [usp_report_Report_195]
		/// </summary>
        public static List<List<object>> Report195(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report195(clientNo, warehouseNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report195A
		/// Calls [usp_report_Report_195A]
		/// </summary>
		public static List<List<object>> Report195A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report195A(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report196
		/// Calls [usp_report_Report_196]
		/// </summary>
        public static List<List<object>> Report196(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report196(clientNo, warehouseNo, startDate, endDate,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report196A
		/// Calls [usp_report_Report_196A]
		/// </summary>
		public static List<List<object>> Report196A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report196A(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report197
		/// Calls [usp_report_Report_197]
		/// </summary>
		public static List<List<object>> Report197(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report197(clientNo, warehouseNo, startDate, endDate);
		}

		/// <summary>
		/// Report197A
		/// Calls [usp_report_Report_197A]
		/// </summary>
		public static List<List<object>> Report197A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report197A(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report198
		/// Calls [usp_report_Report_198]
		/// </summary>
		public static List<List<object>> Report198(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report198(clientNo, warehouseNo, startDate, endDate);
		}

		/// <summary>
		/// Report198A
		/// Calls [usp_report_Report_198A]
		/// </summary>
		public static List<List<object>> Report198A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report198A(clientNo, startDate, endDate);
		}

		/// <summary>
		/// Report199
		/// Calls [usp_report_Report_199]
		/// </summary>
		public static List<List<object>> Report199(System.Int32? clientNo, System.Int32? countryNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report199(clientNo, countryNo);
		}

		/// <summary>
		/// Report200
		/// Calls [usp_report_Report_200]
		/// </summary>
        public static List<List<object>> Report200(System.Int32? clientNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report200(clientNo, lateOnly,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report201
		/// Calls [usp_report_Report_201]
		/// </summary>
        public static List<List<object>> Report201(System.Int32? clientNo, System.Int32? companyNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report201(clientNo, companyNo, lateOnly,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report202
		/// Calls [usp_report_Report_202]
		/// </summary>
        public static List<List<object>> Report202(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report202(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report203
		/// Calls [usp_report_Report_203]
		/// </summary>
        public static List<List<object>> Report203(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report203(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report204
		/// Calls [usp_report_Report_204]
		/// </summary>
        public static List<List<object>> Report204(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report204(clientNo,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report205
		/// Calls [usp_report_Report_205]
		/// </summary>
        public static List<List<object>> Report205(System.Int32? clientId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report205(clientId, startDate, endDate, includeUnconfirmed,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report205A
		/// Calls [usp_report_Report_205A]
		/// </summary>
		public static List<List<object>> Report205A(System.Int32? clientId, System.Int32? supplierId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report205A(clientId, supplierId, startDate, endDate, includeUnconfirmed);
		}

		/// <summary>
		/// Report205B
		/// Calls [usp_report_Report_205B]
		/// </summary>
		public static List<List<object>> Report205B(System.Int32? clientId, System.Int32? companyType, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report205B(clientId, companyType, startDate, endDate, includeUnconfirmed);
		}

		/// <summary>
		/// Report206A
		/// Calls [usp_report_Report_206A]
		/// </summary>
		public static List<List<object>> Report206A(System.Int32? clientNo, System.Boolean? invalidOnly) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report206A(clientNo, invalidOnly);
		}

		/// <summary>
		/// Report206B
		/// Calls [usp_report_Report_206B]
		/// </summary>
        public static List<List<object>> Report206B(System.Int32? clientNo, System.Boolean? invalidOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report206B(clientNo, invalidOnly,intLoginId,ViewMyReport);
		}

		/// <summary>
		/// Report207
		/// Calls [usp_report_Report_207]
		/// </summary>
		public static List<List<object>> Report207(System.Int32? warehouseNo, System.Int32? topToSelect) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report207(warehouseNo, topToSelect);
		}
        //[001],[002] code start
        /// <summary>
        /// Report208
        /// Calls [usp_report_Report_124C]
        /// </summary>
        public static List<List<object>> Report124C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? failedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report124C(clientNo, startDate, endDate, failedOnly,intLoginId,ViewMyReport);
        }

        /// <summary>
        /// Report210
        /// Calls [usp_report_Report_210]
        /// </summary>
        public static List<List<object>> Report210(System.Decimal? percentage, Int32 lotId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Report.Report210(percentage, lotId);
        }

        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Report]
		/// </summary>
		public static Report Get(System.Int32? reportId) {
			Rebound.GlobalTrader.DAL.ReportDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Report.Get(reportId);
			if (objDetails == null) {
				return null;
			} else {
				Report obj = new Report();
				obj.ReportId = objDetails.ReportId;
				obj.ReportName = objDetails.ReportName;
				obj.ReportCategoryNo = objDetails.ReportCategoryNo;
				obj.StoredProcName = objDetails.StoredProcName;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Inactive = objDetails.Inactive;
				obj.AvailableAsPDF = objDetails.AvailableAsPDF;
				obj.SortOrder = objDetails.SortOrder;
				obj.ReportCategoryName = objDetails.ReportCategoryName;
				obj.ReportCategorySortOrder = objDetails.ReportCategorySortOrder;
				obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
				obj.ReportCategoryGroupName = objDetails.ReportCategoryGroupName;
				obj.ReportCategoryGroupSortOrder = objDetails.ReportCategoryGroupSortOrder;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCategory
		/// Calls [usp_selectAll_Report_for_Category]
		/// </summary>
		public static List<Report> GetListForCategory(System.Int32? reportCategoryNo) {
			List<ReportDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Report.GetListForCategory(reportCategoryNo);
			if (lstDetails == null) {
				return new List<Report>();
			} else {
				List<Report> lst = new List<Report>();
				foreach (ReportDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Report obj = new Rebound.GlobalTrader.BLL.Report();
					obj.ReportId = objDetails.ReportId;
					obj.ReportName = objDetails.ReportName;
					obj.ReportCategoryNo = objDetails.ReportCategoryNo;
					obj.StoredProcName = objDetails.StoredProcName;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Inactive = objDetails.Inactive;
					obj.AvailableAsPDF = objDetails.AvailableAsPDF;
					obj.SortOrder = objDetails.SortOrder;
					obj.ReportCategoryName = objDetails.ReportCategoryName;
					obj.ReportCategorySortOrder = objDetails.ReportCategorySortOrder;
					obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
					obj.ReportCategoryGroupName = objDetails.ReportCategoryGroupName;
					obj.ReportCategoryGroupSortOrder = objDetails.ReportCategoryGroupSortOrder;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCategoryAndLogin
		/// Calls [usp_selectAll_Report_for_Category_and_Login]
		/// </summary>
		public static List<Report> GetListForCategoryAndLogin(System.Int32? reportCategoryNo, System.Int32? loginNo) {
			List<ReportDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Report.GetListForCategoryAndLogin(reportCategoryNo, loginNo);
			if (lstDetails == null) {
				return new List<Report>();
			} else {
				List<Report> lst = new List<Report>();
				foreach (ReportDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Report obj = new Rebound.GlobalTrader.BLL.Report();
					obj.ReportId = objDetails.ReportId;
					obj.ReportName = objDetails.ReportName;
					obj.ReportCategoryNo = objDetails.ReportCategoryNo;
					obj.StoredProcName = objDetails.StoredProcName;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Inactive = objDetails.Inactive;
					obj.AvailableAsPDF = objDetails.AvailableAsPDF;
					obj.SortOrder = objDetails.SortOrder;
					obj.ReportCategoryName = objDetails.ReportCategoryName;
					obj.ReportCategorySortOrder = objDetails.ReportCategorySortOrder;
					obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
					obj.ReportCategoryGroupName = objDetails.ReportCategoryGroupName;
					obj.ReportCategoryGroupSortOrder = objDetails.ReportCategoryGroupSortOrder;
                    obj.HUBReport = objDetails.HUBReport;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListInSameGroupForLogin
		/// Calls [usp_selectAll_Report_in_same_Group_for_Login]
		/// </summary>
		public static List<Report> GetListInSameGroupForLogin(System.Int32? loginNo, System.Int32? reportId) {
			List<ReportDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Report.GetListInSameGroupForLogin(loginNo, reportId);
			if (lstDetails == null) {
				return new List<Report>();
			} else {
				List<Report> lst = new List<Report>();
				foreach (ReportDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Report obj = new Rebound.GlobalTrader.BLL.Report();
					obj.ReportId = objDetails.ReportId;
					obj.ReportCategoryNo = objDetails.ReportCategoryNo;
					obj.ReportCategoryGroupNo = objDetails.ReportCategoryGroupNo;
					obj.ReportName = objDetails.ReportName;
					obj.ReportCategoryName = objDetails.ReportCategoryName;
					obj.ReportCategoryGroupName = objDetails.ReportCategoryGroupName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static Report PopulateFromDBDetailsObject(ReportDetails obj) {
            Report objNew = new Report();
			objNew.ReportId = obj.ReportId;
			objNew.ReportName = obj.ReportName;
			objNew.ReportCategoryNo = obj.ReportCategoryNo;
			objNew.StoredProcName = obj.StoredProcName;
			objNew.Inactive = obj.Inactive;
			objNew.AvailableAsPDF = obj.AvailableAsPDF;
			objNew.SortOrder = obj.SortOrder;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ReportCategoryName = obj.ReportCategoryName;
			objNew.ReportCategorySortOrder = obj.ReportCategorySortOrder;
			objNew.ReportCategoryGroupNo = obj.ReportCategoryGroupNo;
			objNew.ReportCategoryGroupName = obj.ReportCategoryGroupName;
			objNew.ReportCategoryGroupSortOrder = obj.ReportCategoryGroupSortOrder;
            return objNew;
        }
		
		#endregion
		
	}
}