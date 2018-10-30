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
	public partial class Report : BizObject {

		#region Properties

		private List<ReportColumn> _lstColumns;
		public List<ReportColumn> Columns {
			get {
				if (_lstColumns == null) _lstColumns = GetColumns();
				return _lstColumns;
			}
		}

		#endregion

		#region Class Methods

		private List<ReportColumn> GetColumns() {
			List<ReportColumn> lst = BLL.ReportColumn.GetListForReport(ReportId);
			return lst;
		}

		#endregion
	}
}