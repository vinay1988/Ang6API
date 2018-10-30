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
	
	public abstract class ProductSourceProvider : DataAccess {
		static private ProductSourceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ProductSourceProvider Instance {
			get {
				if (_instance == null) _instance = (ProductSourceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ProductSources.ProviderType));
				return _instance;
			}
		}
        public ProductSourceProvider()
        {
			this.ConnectionString = Globals.Settings.ProductSources.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_ProductSource]
		/// </summary>
		public abstract List<ProductSourceDetails> DropDown();

        #endregion

    }
}