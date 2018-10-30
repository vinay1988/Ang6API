/*
Marker     Changed by      Date          Remarks
[0001]      Abhinav         09/04/2014    ESMS #120 Add Reason1,Reason2,Comments fields in NPR
[0002]      Raushan         13/04/2015    NPR Search     
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public abstract class ReportNPRProvider : DataAccess 
    {
        static private ReportNPRProvider _instance = null;
        /// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReportNPRProvider Instance {
			get {
                if (_instance == null) _instance = (ReportNPRProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ReportNPRs.ProviderType));
				return _instance;
			}
		}
        public ReportNPRProvider()
        {
			this.ConnectionString = Globals.Settings.ReportNPRs.ConnectionString;
        }
        #region Method Registrations
        /// <summary>
        /// ReportNPR
        /// Calls [usp_report_NPR]
        /// </summary>
        public abstract ReportNPRDetails GetGoodsInLineById(System.Int32 goodsInLineId);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_ReportNPR]
        /// </summary>
        //[0001] start
        public abstract Int32 Insert(System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean? supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy, System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.Double? unitCost, System.String changeLog, System.Int32? qtyAdvised, System.String nprReason1, System.String nprReason2, System.String nprComment,System.String salesAcion);
        /// <summary>
        ////[0001] end
        /// Insert
        /// Calls [usp_update_ReportNPR]
        /// </summary>
        /// //[0001] start
        public abstract bool Update(System.Int32 nprId, System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean? supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy, System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.String changesLog, System.Double? unitCost, System.Int32? qtyAdvised, System.String nprReason1, System.String nprReason2, System.String nprComment, System.String salesAcion);
        /// <summary>
        /// //[0001] end
        /// Get NPR by Id
        /// calls [usp_select_NPRbyId]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public abstract ReportNPRDetails Get(System.Int32 nprId, System.Int32? clientNo);

        /// <summary>
        /// Delete NPR by Id
        /// Calls [usp_delete_nprReport]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public abstract bool Delete(System.Int32? nprId);

        /// <summary>
        /// usp_select_NPRLog
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public abstract List<ReportNPRDetails> GetNPRLog(System.Int32? nprId);
        /// <summary>
        /// usp_select_NPR_CompanyID
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public abstract int? getNPRCompanyID(System.Int32? SalesorderNo, System.Int32? ClientNo);
        /// <summary>
        /// Insert NPR Email Log
        /// Call [usp_insert_Email_NPR_Log]
        /// </summary>
        /// <param name="nprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 InsertEmailNPRLog(System.Int32? nprId, System.String details, System.Int32? updatedBy);


        public abstract List<ReportNPRDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nprSearch, System.String cmSearch, System.String action, System.Int32? isCompleted, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? nprRaisedDateFrom, System.DateTime? nprRaisedDateTo, System.Int32? isAuthorised);

        #endregion
    }
}
