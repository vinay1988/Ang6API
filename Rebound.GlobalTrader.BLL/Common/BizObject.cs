using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

namespace Rebound.GlobalTrader.BLL {
	public abstract class BizObject {
		protected const int MAXROWS = int.MaxValue;
		protected const int TOPTORETURN = 20;

		public static int MaxRows = MAXROWS;

		protected static string CurrentUserName {
			get {
				string userCode = "";
				userCode = "Bob";
				return userCode;
			}
		}

        

		protected static IPrincipal CurrentUser {
			get { return HttpContext.Current.User; }
		}
		protected static string CurrentUserLogin {
			get {
				string userName = "";
				if (HttpContext.Current.User.Identity.IsAuthenticated)
					userName = HttpContext.Current.User.Identity.Name;
				return userName;
			}
		}
		protected static string CurrentUserIP {
			get { return HttpContext.Current.Request.UserHostAddress; }
		}
		protected static int GetPageIndex(int startRowIndex, int maximumRows) {
			if (maximumRows <= 0)
				return 0;
			else
				return (int)Math.Floor((double)startRowIndex / (double)maximumRows);
		}
		protected static string ConvertNullToEmptyString(string input) {
			return (input == null ? "" : input);
		}
		protected static int ConvertNullToIntZero(int? input) {
			return (input == null ? 0 : (int)input);
		}
		protected static float ConvertNullToFloatZero(float? input) {
			return (input == null ? 0 : (float)input);
		}
		protected static DateTime ConvertNullToMinDate(DateTime? input) {
			return (input == null ? DateTime.MinValue : (DateTime)input);
		}
		protected static DateTime? ConvertMinDateToNull(DateTime input) {
			return (input == DateTime.MinValue ? null : (DateTime?)input);
		}

        /// <summary>
        /// Create By Vinay: 1st Dec 2017: It is a common property for all module
        /// Need to assign if the product is Inacive
        /// </summary>
        public System.Boolean? ProductInactive { get; set; }
	}
}