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
using Rebound.GlobalTrader.DAL.Common.Entities;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class PurchaseRequestLineDetailProvider : DataAccess { 
		static private PurchaseRequestLineDetailProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public PurchaseRequestLineDetailProvider Instance {
			get {
                if (_instance == null) _instance = (PurchaseRequestLineDetailProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.PurchaseRequestLineDetails.ProviderType));
				return _instance;
			}
		}
        public PurchaseRequestLineDetailProvider()
        {
            this.ConnectionString = Globals.Settings.PurchaseRequestLineDetails.ConnectionString;
		}

		#region Method Registrations
        /// <summary>
        /// GetListLines
        /// Calls [usp_selectAll_PurchaseRequestLineDetail]
        /// </summary>
        public abstract List<PurchaseRequestLineDetailDetails> GetListLines(System.Int32? purchaseRequestNo);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_PurchaseRequestLineDetail]
        /// </summary>
        public abstract Int32 Insert(int? purchaseRequestLineNo, int? supplier, double? price, string spq, string leadTime, string rohs, string factorySealed, string msl, string manufacturerName, string dateCode, string packageType, string productType, string mOQ, string totalQSA, string lTB, string notes, int? updatedBy, System.Int32? currencyNo, System.Int32? mslLevel);
        /// Delete
        /// Calls [usp_delete_PurchaseRequestLineDetail]
        /// </summary>
        public abstract bool Delete(System.Int32? purchaseRequestLineDetailId);

        public abstract bool Update(System.Int32? purchaseRequestLineDetailId, int? purchaseRequestLineNo, int? CompanyNo, double? Price, string spq, string leadTime, string rohs, string factorySealed, string msl, string manufacturerName, string dateCode, string packageType, string productType, string mOQ, string totalQSA, string lTB, string notes, int? updatedBy, System.Int32? currencyNo, System.Int32? mslLevelNo);

        public abstract PurchaseRequestLineDetailDetails Get(System.Int32? purchaseRequestLineDetailId);  
		#endregion						     
	}
}
