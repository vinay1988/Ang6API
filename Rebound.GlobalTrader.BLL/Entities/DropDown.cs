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
		public partial class DropDown : BizObject {
		
		#region Properties

		protected static DAL.DropDownElement Settings {
			get { return Globals.Settings.DropDowns; }
		}

		/// <summary>
		/// DropDownId
		/// </summary>
		public System.Int32 DropDownId { get; set; }		
		/// <summary>
		/// ShortName
		/// </summary>
		public System.String ShortName { get; set; }		
		/// <summary>
		/// Description
		/// </summary>
		public System.String Description { get; set; }		

		#endregion
		
		#region Methods
		

        private static DropDown PopulateFromDBDetailsObject(DropDownDetails obj) {
            DropDown objNew = new DropDown();
			objNew.DropDownId = obj.DropDownId;
			objNew.ShortName = obj.ShortName;
			objNew.Description = obj.Description;
            return objNew;
        }
		
		#endregion
		
	}
}