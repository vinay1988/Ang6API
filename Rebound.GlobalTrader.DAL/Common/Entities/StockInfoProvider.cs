using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public abstract class StockInfoProvider : DataAccess
    {
        static private StockInfoProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
        static public StockInfoProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (StockInfoProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.StockInfos.ProviderType));
                return _instance;
            }
        }
        public StockInfoProvider()
        {
            this.ConnectionString = Globals.Settings.StockInfos.ConnectionString;
            this.GTConnectionString = Globals.Settings.StockInfos.GTConnectionString;
        }
        #region Method Registrations
        /// <summary>
        /// Insert
        /// Calls [usp_insert_StockInfo]
        /// </summary>
        public abstract Int32 Insert(System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? supplierNo, System.String notes, System.String alternatePart, System.Int32? clientNo, System.Int32? updatedBy);

        /// <summary>
        /// Insert
        /// Calls [usp_update_StockInfo]
        /// </summary>
        public abstract bool Update(System.Int32? stockInfoId, System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? supplierNo, System.String notes, System.String alternatePart, System.Int32? clientNo, System.Int32? updatedBy);
        /// <summary>
        /// usp_ValidateAlternatePart
        /// </summary>
        /// <param name="alternatePart"></param>
        /// <returns></returns>
        public abstract bool ValidateAlternatePart(System.String alternatePart,System.Int32? stockInfoId);

        /// <summary>
        /// Source
        /// Calls [usp_source_StockInfo]
        /// </summary>
        public abstract List<StockInfoDetails> Source(System.Int32? clientId, System.String partSearch, bool IsServerLocal);

        /// <summary>
        /// Calls [usp_select_StockInfo]
        /// </summary>
        public abstract StockInfoDetails Get(System.Int32? stockInfoId);

        #endregion
    }
}
