using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL 
{
    public abstract class ClientInvoiceLineProvider : DataAccess
    {
        static private ClientInvoiceLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
        static public ClientInvoiceLineProvider Instance
        {
			get {
                if (_instance == null) _instance = (ClientInvoiceLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ClientInvoiceLines.ProviderType));
				return _instance;
			}
		}
        public ClientInvoiceLineProvider()
        {
            this.ConnectionString = Globals.Settings.ClientInvoiceLines.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// usp_selectAll_ClientInvoiceLine_for_ClientInvoice
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public abstract List<ClientInvoiceLineDetails> GetListForClientInvoiceLine(System.Int32? ClientInvoiceId);
        /// <summary>
        /// Get goods in line of the Client
        /// Call Proc [usp_itemsearch_ClientInvoice_GoodsInLine]
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
        public abstract List<ClientInvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo);
        /// <summary>
        /// usp_insert_ClientInvoiceLine
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="ClientInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 InsertClientInvoiceLine(System.Int32 goodsInLineId, System.Int32 ClientInvoiceNo, System.Int32 updatedBy);

        /// <summary>
        /// Delete Client Invoice Line
        /// Call Proc [usp_delete_ClientInvoiceLine]
        /// </summary>
        /// <param name="ClientInvoiceLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool Delete(System.Int32? ClientInvoiceLineId, System.Int32? updatedBy);

        /// <summary>
        /// ItemSearch
        /// Calls [usp_getClientInvoice]
        /// </summary>GetClientInvoice
        public abstract List<ClientInvoiceLineDetails> GetClientInvoice(System.Int32? ClientInvoiceId, System.Int32? clientInvoiceLineNo);


        /// <summary>
        /// Get
        /// Calls [usp_select_ClientInvoiceLine]
        /// </summary>
        public abstract ClientInvoiceLineDetails Get(System.Int32? clientInvoiceLineId);
        #endregion
    }
}
