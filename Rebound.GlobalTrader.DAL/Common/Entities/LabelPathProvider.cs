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
	
	public abstract class LabelPathProvider : DataAccess {
		static private LabelPathProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public LabelPathProvider Instance {
			get {
                if (_instance == null) _instance = (LabelPathProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.LabelPath.ProviderType));
				return _instance;
			}
		}
        public LabelPathProvider()
        {
            this.ConnectionString = Globals.Settings.LabelPath.ConnectionString;
		}

		#region Method Registrations
				
		/// <summary>
        /// DropDownForLabelPath
        /// Calls [usp_dropdown_LabelPath]
		/// </summary>
        public abstract List<LabelPathDetails> DropDownForPrinter(System.Int32? clientId);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_LabelPath]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="labelPath"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy);
        /// <summary>
        /// Calls [usp_update_LabelPath]
        /// </summary>
        /// <param name="labelPathId"></param>
        /// <param name="clientNo"></param>
        /// <param name="labelPath"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool Update(System.Int32? labelPathId, System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy);
        /// <summary>
        /// Call [usp_selectAll_LabelPath_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public abstract List<LabelPathDetails> GetListForClient(System.Int32? clientId);

		#endregion
		
	}
}