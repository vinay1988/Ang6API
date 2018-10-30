using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL 
{
    public abstract class SupplierInvoiceLineProvider : DataAccess
    {
        static private SupplierInvoiceLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
        static public SupplierInvoiceLineProvider Instance
        {
			get {
                if (_instance == null) _instance = (SupplierInvoiceLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SupplierInvoiceLines.ProviderType));
				return _instance;
			}
		}
        public SupplierInvoiceLineProvider()
        {
			this.ConnectionString = Globals.Settings.SupplierInvoiceLines.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// usp_selectAll_SupplierInvoiceLine_for_SupplierInvoice
        /// </summary>
        /// <param name="SupplierInvoiceId"></param>
        /// <returns></returns>
        public abstract List<SupplierInvoiceLineDetails> GetListForSupplierInvoiceLine(System.Int32? SupplierInvoiceId);
        /// <summary>
        /// Get goods in line of the supplier
        /// Call Proc [usp_itemsearch_SupplierInvoice_GoodsInLine]
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortDir"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="companyNo"></param>
        /// <param name="includeInvoiced"></param>
        /// <param name="giLineDateFrom"></param>
        /// <param name="giLineDateTo"></param>
        /// <returns></returns>
        public abstract List<SupplierInvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo, System.Boolean? IsPoHub, bool? isClientInvoice, System.Int32? poNoLo, System.Int32? poNoHi);
        /// <summary>
        /// usp_insert_SupplierInvoiceLine
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="supplierInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 InsertSupplierInvoiceLine(System.Int32 goodsInLineId, System.Int32 supplierInvoiceNo, System.Int32 updatedBy,bool? isPoHub);

        /// <summary>
        /// Delete Supplier Invoice Line
        /// Call Proc [usp_delete_SupplierInvoiceLine]
        /// </summary>
        /// <param name="supplierInvoiceLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool Delete(System.Int32? supplierInvoiceLineId, System.Int32? updatedBy);
        #endregion
    }
}
