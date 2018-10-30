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
		public partial class ProductSource : BizObject {
		
		#region Properties

            protected static DAL.ProductSourceElement Settings
            {
                get { return Globals.Settings.ProductSources; }
		}

		/// <summary>
            /// ProductSourceId
		/// </summary>
        public System.Int32 ProductSourceId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_ProductSource]
		/// </summary>
        public static List<ProductSource> DropDown()
        {
            List<ProductSourceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ProductSource.DropDown();
			if (lstDetails == null) {
                return new List<ProductSource>();
			} else {
                List<ProductSource> lst = new List<ProductSource>();
                foreach (ProductSourceDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ProductSource obj = new Rebound.GlobalTrader.BLL.ProductSource();
                    obj.ProductSourceId = objDetails.ProductSourceId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		
		
		#endregion
		
	}
}