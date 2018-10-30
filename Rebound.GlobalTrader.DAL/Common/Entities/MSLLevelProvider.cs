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
	
	public abstract class MSLLevelProvider : DataAccess {
		static private MSLLevelProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MSLLevelProvider Instance {
			get {
                if (_instance == null) _instance = (MSLLevelProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MSLLevels.ProviderType));
				return _instance;
			}
		}
		public MSLLevelProvider() {
            this.ConnectionString = Globals.Settings.MSLLevels.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DropDown
        /// Calls [usp_dropdown_MSLLevel]
		/// </summary>
		public abstract List<MSLLevelDetails> DropDown();

        #endregion
    }
}