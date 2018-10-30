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
	public partial class InvoiceLine : BizObject {

		/// <summary>
		/// Is the line taxable?
		/// Requires fields: Taxable
		/// </summary>
		public bool IsLineTaxable {
			get {
				return (Taxable == "Y" || Taxable == "1");
			}
		}

		/// <summary>
		/// Is the line a service?
		/// Requires fields: ServiceNo
		/// </summary>
		public bool IsService {
			get {
				return (ServiceNo > 0);
			}
		}
	}
}