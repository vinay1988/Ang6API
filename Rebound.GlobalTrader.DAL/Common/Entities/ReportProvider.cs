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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class ReportProvider : DataAccess {
		static private ReportProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportProvider Instance {
			get {
				if (_instance == null) _instance = (ReportProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Reports.ProviderType));
				return _instance;
			}
		}
		public ReportProvider() {
			this.ConnectionString = Globals.Settings.Reports.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Report]
		/// </summary>
		public abstract bool Delete(System.Int32? reportId);
		/// <summary>
		/// Report101
		/// Calls [usp_report_Report_101]
		/// </summary>
        public abstract List<List<object>> Report101(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report102
		/// Calls [usp_report_Report_102]
		/// </summary>
		public abstract List<List<object>> Report102(System.Int32? clientNo);
		/// <summary>
		/// Report103
		/// Calls [usp_report_Report_103]
		/// </summary>
		public abstract List<List<object>> Report103(System.Int32? clientNo, System.Int32? salesman);
		/// <summary>
		/// Report104
		/// Calls [usp_report_Report_104]
		/// </summary>
		public abstract List<List<object>> Report104(System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report105
		/// Calls [usp_report_Report_105]
		/// </summary>
		public abstract List<List<object>> Report105(System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report107
		/// Calls [usp_report_Report_107]
		/// </summary>
		public abstract List<List<object>> Report107(System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report108
		/// Calls [usp_report_Report_108]
		/// </summary>
		public abstract List<List<object>> Report108(System.Int32? loginId, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report109
		/// Calls [usp_report_Report_109]
		/// </summary>
        public abstract List<List<object>> Report109(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report110
		/// Calls [usp_report_Report_110]
		/// </summary>
        public abstract List<List<object>> Report110(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report111
		/// Calls [usp_report_Report_111]
		/// </summary>
		public abstract List<List<object>> Report111();
		/// <summary>
		/// Report112
		/// Calls [usp_report_Report_112]
		/// </summary>
		public abstract List<List<object>> Report112();
		/// <summary>
		/// Report113
		/// Calls [usp_report_Report_113]
		/// </summary>
        public abstract List<List<object>> Report113(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report114
		/// Calls [usp_report_Report_114]
		/// </summary>
        public abstract List<List<object>> Report114(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report117
		/// Calls [usp_report_Report_117]
		/// </summary>
        public abstract List<List<object>> Report117(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report118
		/// Calls [usp_report_Report_118]
		/// </summary>
        public abstract List<List<object>> Report118(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report119
		/// Calls [usp_report_Report_119]
		/// </summary>
		public abstract List<List<object>> Report119(System.Int32? clientNo, System.Int32? salesman, System.DateTime? dueDate);
		/// <summary>
		/// Report120
		/// Calls [usp_report_Report_120]
		/// </summary>
        public abstract List<List<object>> Report120(System.Int32? clientNo, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report121
		/// Calls [usp_report_Report_121]
		/// </summary>
        public abstract List<List<object>> Report121(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.String status, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report121A
		/// Calls [usp_report_Report_121A]
		/// </summary>
		public abstract List<List<object>> Report121A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.String status);
		/// <summary>
		/// Report121B
		/// Calls [usp_report_Report_121B]
		/// </summary>
		public abstract List<List<object>> Report121B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate, System.String status);
		/// <summary>
		/// Report122
		/// Calls [usp_report_Report_122]
		/// </summary>
		public abstract List<List<object>> Report122(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly, System.String location);
		/// <summary>
		/// Report122A
		/// Calls [usp_report_Report_122A]
		/// </summary>
		public abstract List<List<object>> Report122A(System.Int32? clientNo, System.Int32? warehouseNo, System.Int32? lotNo, System.Boolean? valueStockOnly, System.String location);
		/// <summary>
		/// Report122B
		/// Calls [usp_report_Report_122B]
		/// </summary>
		public abstract List<List<object>> Report122B();
		/// <summary>
		/// Report123
		/// Calls [usp_report_Report_123]
		/// </summary>
        public abstract List<List<object>> Report123(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report123A
		/// Calls [usp_report_Report_123A]
		/// </summary>
        public abstract List<List<object>> Report123A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report124
		/// Calls [usp_report_Report_124]
		/// </summary>
        public abstract List<List<object>> Report124(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeShipping, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report124A
		/// Calls [usp_report_Report_124A]
		/// </summary>
		public abstract List<List<object>> Report124A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report124B
		/// Calls [usp_report_Report_124B]
		/// </summary>
        public abstract List<List<object>> Report124B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report125
		/// Calls [usp_report_Report_125]
		/// </summary>
        public abstract List<List<object>> Report125(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report125A
		/// Calls [usp_report_Report_125A]
		/// </summary>
		public abstract List<List<object>> Report125A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report125B
		/// Calls [usp_report_Report_125B]
		/// </summary>
        public abstract List<List<object>> Report125B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report126
		/// Calls [usp_report_Report_126]
		/// </summary>
		public abstract List<List<object>> Report126(System.Int32? clientNo, System.Int32? salesman);
		/// <summary>
		/// Report128
		/// Calls [usp_report_Report_128]
		/// </summary>
        public abstract List<List<object>> Report128(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report128A
		/// Calls [usp_report_Report_128A]
		/// </summary>
		public abstract List<List<object>> Report128A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly);
		/// <summary>
		/// Report129
		/// Calls [usp_report_Report_129]
		/// </summary>
        public abstract List<List<object>> Report129(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report130
		/// Calls [usp_report_Report_130]
		/// </summary>
        public abstract List<List<object>> Report130(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report130A
		/// Calls [usp_report_Report_130A]
		/// </summary>
        public abstract List<List<object>> Report130A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report130B
		/// Calls [usp_report_Report_130B]
		/// </summary>
        public abstract List<List<object>> Report130B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report133
		/// Calls [usp_report_Report_133]
		/// </summary>
		public abstract List<List<object>> Report133(System.Int32? clientNo, System.Boolean? includeOnOrder, System.Boolean? unallocatedOnly, System.Boolean? includeLotsOnHold);
		/// <summary>
		/// Report133A
		/// Calls [usp_report_Report_133A]
		/// </summary>
		public abstract List<List<object>> Report133A();
		/// <summary>
		/// Report137
		/// Calls [usp_report_Report_137]
		/// </summary>
        public abstract List<List<object>> Report137(System.Int32? clientNo, System.Int32? lotNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report139
		/// Calls [usp_report_Report_139]
		/// </summary>
        public abstract List<List<object>> Report139(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report139A
		/// Calls [usp_report_Report_139A]
		/// </summary>
        public abstract List<List<object>> Report139A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report139B
		/// Calls [usp_report_Report_139B]
		/// </summary>
        public abstract List<List<object>> Report139B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report143
		/// Calls [usp_report_Report_143]
		/// </summary>
		public abstract List<List<object>> Report143(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly);
		/// <summary>
		/// Report143A
		/// Calls [usp_report_Report_143A]
		/// </summary>
		public abstract List<List<object>> Report143A();
		/// <summary>
		/// Report144
		/// Calls [usp_report_Report_144]
		/// </summary>
        public abstract List<List<object>> Report144(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report144A
		/// Calls [usp_report_Report_144A]
		/// </summary>
        public abstract List<List<object>> Report144A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report144B
		/// Calls [usp_report_Report_144B]
		/// </summary>
		public abstract List<List<object>> Report144B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report147
		/// Calls [usp_report_Report_147]
		/// </summary>
        public abstract List<List<object>> Report147(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report147A
		/// Calls [usp_report_Report_147A]
		/// </summary>
        public abstract List<List<object>> Report147A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report147B
		/// Calls [usp_report_Report_147B]
		/// </summary>
        public abstract List<List<object>> Report147B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report149
		/// Calls [usp_report_Report_149]
		/// </summary>
		public abstract List<List<object>> Report149(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report150
		/// Calls [usp_report_Report_150]
		/// </summary>
        public abstract List<List<object>> Report150(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report150A
		/// Calls [usp_report_Report_150A]
		/// </summary>
        public abstract List<List<object>> Report150A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report150B
		/// Calls [usp_report_Report_150B]
		/// </summary>
		public abstract List<List<object>> Report150B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report150C
		/// Calls [usp_report_Report_150C]
		/// </summary>
		public abstract List<List<object>> Report150C(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report150D
		/// Calls [usp_report_Report_150D]
		/// </summary>
        public abstract List<List<object>> Report150D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report150E
		/// Calls [usp_report_Report_150E]
		/// </summary>
        public abstract List<List<object>> Report150E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report153
		/// Calls [usp_report_Report_153]
		/// </summary>
        public abstract List<List<object>> Report153(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report153A
		/// Calls [usp_report_Report_153A]
		/// </summary>
        public abstract List<List<object>> Report153A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report153B
		/// Calls [usp_report_Report_153B]
		/// </summary>
		public abstract List<List<object>> Report153B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report153C
		/// Calls [usp_report_Report_153C]
		/// </summary>
        public abstract List<List<object>> Report153C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report153D
		/// Calls [usp_report_Report_153D]
		/// </summary>
        public abstract List<List<object>> Report153D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report153E
		/// Calls [usp_report_Report_153E]
		/// </summary>
		public abstract List<List<object>> Report153E(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report156
		/// Calls [usp_report_Report_156]
		/// </summary>
        public abstract List<List<object>> Report156(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report156A
		/// Calls [usp_report_Report_156A]
		/// </summary>
        public abstract List<List<object>> Report156A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report156B
		/// Calls [usp_report_Report_156B]
		/// </summary>
		public abstract List<List<object>> Report156B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report156C
		/// Calls [usp_report_Report_156C]
		/// </summary>
		public abstract List<List<object>> Report156C(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report156D
		/// Calls [usp_report_Report_156D]
		/// </summary>
        public abstract List<List<object>> Report156D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report156E
		/// Calls [usp_report_Report_156E]
		/// </summary>
        public abstract List<List<object>> Report156E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report159
		/// Calls [usp_report_Report_159]
		/// </summary>
        public abstract List<List<object>> Report159(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report159A
		/// Calls [usp_report_Report_159A]
		/// </summary>
		public abstract List<List<object>> Report159A(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report159B
		/// Calls [usp_report_Report_159B]
		/// </summary>
        public abstract List<List<object>> Report159B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report159C
		/// Calls [usp_report_Report_159C]
		/// </summary>
        public abstract List<List<object>> Report159C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report159D
		/// Calls [usp_report_Report_159D]
		/// </summary>
		public abstract List<List<object>> Report159D(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report159E
		/// Calls [usp_report_Report_159E]
		/// </summary>
        public abstract List<List<object>> Report159E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report162
		/// Calls [usp_report_Report_162]
		/// </summary>
		public abstract List<List<object>> Report162(System.Int32? clientNo);
		/// <summary>
		/// Report176
		/// Calls [usp_report_Report_176]
		/// </summary>
		public abstract List<List<object>> Report176(System.Int32? clientNo, System.DateTime? dueDate);
		/// <summary>
		/// Report177
		/// Calls [usp_report_Report_177]
		/// </summary>
        public abstract List<List<object>> Report177(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report181
		/// Calls [usp_report_Report_181]
		/// </summary>
		public abstract List<List<object>> Report181(System.Int32? clientNo, System.Int32? warehouseNo, System.String location);
		/// <summary>
		/// Report181A
		/// Calls [usp_report_Report_181A]
		/// </summary>
		public abstract List<List<object>> Report181A();
		/// <summary>
		/// Report182
		/// Calls [usp_report_Report_182]
		/// </summary>
		public abstract List<List<object>> Report182(System.Int32? clientNo, System.DateTime? cutOffDate, System.Int32? salesman, System.String companyGrouping, System.Boolean? includeNever);
		/// <summary>
		/// Report183
		/// Calls [usp_report_Report_183]
		/// </summary>
		public abstract List<List<object>> Report183(System.Int32? clientNo, System.DateTime? cutOffDate);
		/// <summary>
		/// Report184
		/// Calls [usp_report_Report_184]
		/// </summary>
		public abstract List<List<object>> Report184(System.Int32? clientNo, System.Int32? employee, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report185
		/// Calls [usp_report_Report_185]
		/// </summary>
        public abstract List<List<object>> Report185(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report185A
		/// Calls [usp_report_Report_185A]
		/// </summary>
        public abstract List<List<object>> Report185A(System.Int32? clientNo, System.Int32? companyNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report185B
		/// Calls [usp_report_Report_185B]
		/// </summary>
		public abstract List<List<object>> Report185B(System.Int32? clientNo, System.Int32? salesman);
		/// <summary>
		/// Report188
		/// Calls [usp_report_Report_188]
		/// </summary>
		public abstract List<List<object>> Report188(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report189
		/// Calls [usp_report_Report_189]
		/// </summary>
		public abstract List<List<object>> Report189(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report190
		/// Calls [usp_report_Report_190]
		/// </summary>
		public abstract List<List<object>> Report190(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report191
		/// Calls [usp_report_Report_191]
		/// </summary>
		public abstract List<List<object>> Report191(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report192
		/// Calls [usp_report_Report_192]
		/// </summary>
        public abstract List<List<object>> Report192(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report193
		/// Calls [usp_report_Report_193]
		/// </summary>
        public abstract List<List<object>> Report193(System.Int32? clientNo, System.Int32? countryNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report194
		/// Calls [usp_report_Report_194]
		/// </summary>
        public abstract List<List<object>> Report194(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report195
		/// Calls [usp_report_Report_195]
		/// </summary>
        public abstract List<List<object>> Report195(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report195A
		/// Calls [usp_report_Report_195A]
		/// </summary>
		public abstract List<List<object>> Report195A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report196
		/// Calls [usp_report_Report_196]
		/// </summary>
        public abstract List<List<object>> Report196(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report196A
		/// Calls [usp_report_Report_196A]
		/// </summary>
		public abstract List<List<object>> Report196A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report197
		/// Calls [usp_report_Report_197]
		/// </summary>
		public abstract List<List<object>> Report197(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report197A
		/// Calls [usp_report_Report_197A]
		/// </summary>
		public abstract List<List<object>> Report197A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report198
		/// Calls [usp_report_Report_198]
		/// </summary>
		public abstract List<List<object>> Report198(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report198A
		/// Calls [usp_report_Report_198A]
		/// </summary>
		public abstract List<List<object>> Report198A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate);
		/// <summary>
		/// Report199
		/// Calls [usp_report_Report_199]
		/// </summary>
		public abstract List<List<object>> Report199(System.Int32? clientNo, System.Int32? countryNo);
		/// <summary>
		/// Report200
		/// Calls [usp_report_Report_200]
		/// </summary>
        public abstract List<List<object>> Report200(System.Int32? clientNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report201
		/// Calls [usp_report_Report_201]
		/// </summary>
        public abstract List<List<object>> Report201(System.Int32? clientNo, System.Int32? companyNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report202
		/// Calls [usp_report_Report_202]
		/// </summary>
        public abstract List<List<object>> Report202(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report203
		/// Calls [usp_report_Report_203]
		/// </summary>
        public abstract List<List<object>> Report203(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report204
		/// Calls [usp_report_Report_204]
		/// </summary>
        public abstract List<List<object>> Report204(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report205
		/// Calls [usp_report_Report_205]
		/// </summary>
        public abstract List<List<object>> Report205(System.Int32? clientId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report205A
		/// Calls [usp_report_Report_205A]
		/// </summary>
		public abstract List<List<object>> Report205A(System.Int32? clientId, System.Int32? supplierId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed);
		/// <summary>
		/// Report205B
		/// Calls [usp_report_Report_205B]
		/// </summary>
		public abstract List<List<object>> Report205B(System.Int32? clientId, System.Int32? companyType, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed);
		/// <summary>
		/// Report206A
		/// Calls [usp_report_Report_206A]
		/// </summary>
		public abstract List<List<object>> Report206A(System.Int32? clientNo, System.Boolean? invalidOnly);
		/// <summary>
		/// Report206B
		/// Calls [usp_report_Report_206B]
		/// </summary>
        public abstract List<List<object>> Report206B(System.Int32? clientNo, System.Boolean? invalidOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport);
		/// <summary>
		/// Report207
		/// Calls [usp_report_Report_207]
		/// </summary>
		public abstract List<List<object>> Report207(System.Int32? warehouseNo, System.Int32? topToSelect);
        //[001],[002] code start
        /// <summary>
        /// Report124C
        /// Calls [usp_report_Report_124C]
        /// </summary>
        public abstract List<List<object>> Report124C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? failedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport);
   
        /// <summary>
        /// Calls [usp_report_Report_210]
        /// </summary>
        /// <param name="clientNo">Client Id</param>
        /// <param name="lotId"> Lot Id</param>
        /// <returns></returns>
         public abstract List<List<object>> Report210(System.Decimal? percentage, System.Int32 lotId);
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Report]
		/// </summary>
		public abstract ReportDetails Get(System.Int32? reportId);
		/// <summary>
		/// GetListForCategory
		/// Calls [usp_selectAll_Report_for_Category]
		/// </summary>
		public abstract List<ReportDetails> GetListForCategory(System.Int32? reportCategoryNo);
		/// <summary>
		/// GetListForCategoryAndLogin
		/// Calls [usp_selectAll_Report_for_Category_and_Login]
		/// </summary>
		public abstract List<ReportDetails> GetListForCategoryAndLogin(System.Int32? reportCategoryNo, System.Int32? loginNo);
		/// <summary>
		/// GetListInSameGroupForLogin
		/// Calls [usp_selectAll_Report_in_same_Group_for_Login]
		/// </summary>
		public abstract List<ReportDetails> GetListInSameGroupForLogin(System.Int32? loginNo, System.Int32? reportId);

		#endregion
				
		/// <summary>
		/// Returns a new ReportDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReportDetails GetReportFromReader(DbDataReader reader) {
			ReportDetails report = new ReportDetails();
			if (reader.HasRows) {
				report.ReportId = GetReaderValue_Int32(reader, "ReportId", 0); //From: [Table]
				report.ReportName = GetReaderValue_String(reader, "ReportName", ""); //From: [Table]
				report.ReportCategoryNo = GetReaderValue_NullableInt32(reader, "ReportCategoryNo", null); //From: [Table]
				report.StoredProcName = GetReaderValue_String(reader, "StoredProcName", ""); //From: [Table]
				report.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				report.AvailableAsPDF = GetReaderValue_Boolean(reader, "AvailableAsPDF", false); //From: [Table]
				report.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
				report.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				report.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				report.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", ""); //From: [usp_select_Report]
				report.ReportCategorySortOrder = GetReaderValue_NullableInt32(reader, "ReportCategorySortOrder", null); //From: [usp_select_Report]
				report.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null); //From: [usp_select_Report]
				report.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", ""); //From: [usp_select_Report]
				report.ReportCategoryGroupSortOrder = GetReaderValue_String(reader, "ReportCategoryGroupSortOrder", ""); //From: [usp_select_Report]
			}
			return report;
		}
	
		/// <summary>
		/// Returns a collection of ReportDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReportDetails> GetReportCollectionFromReader(DbDataReader reader) {
			List<ReportDetails> reports = new List<ReportDetails>();
			while (reader.Read()) reports.Add(GetReportFromReader(reader));
			return reports;
		}
		
		
		protected virtual List<object> GetReportDataRowFromReader(DbDataReader reader) {
			List<object> lst = new List<object>(reader.FieldCount);
			for (int i = 0; i < reader.FieldCount; i++) lst.Add(reader.GetValue(i));
			return lst;
		}

		protected virtual List<List<object>> GetReportDataFromReader(DbDataReader reader) {
			List<List<object>> lstReports = new List<List<object>>();
			while (reader.Read()) lstReports.Add(GetReportDataRowFromReader(reader));
			return lstReports;
		}
	}
}