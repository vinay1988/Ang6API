using System;
using System.Collections.Generic;
using System.Text;

namespace Rebound.GlobalTrader.BLL {
	public partial class DebitLine : BizObject {

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
