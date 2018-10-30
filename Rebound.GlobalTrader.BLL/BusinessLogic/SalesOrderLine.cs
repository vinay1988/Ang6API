//------------------------------------------------------------------------------------------
// - add IsService property
// - fix display of ShippingStatus for Services
//
// - add IsShipped, IsAllocated properties
//------------------------------------------------------------------------------------------
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
	public partial class SalesOrderLine : BizObject {

		//Is the line taxable?
		//Requires fields: Taxable
		public bool IsLineTaxable {
			get {
				return (Taxable == "Y" || Taxable == "1");
			}
		}

		//Is the line shipped?
		//Requires fields: QuantityShipped, Quantity, ServiceNo, ServiceShipped
		public bool IsShipped {
			get {
				if (IsService) {
					return ServiceShipped;
				} else {
					return QuantityShipped >= Quantity;
				}
			}
		}

		//Is the line allocated?
		//Requires fields: QuantityAllocated, Quantity, QuantityShipped;
		public bool IsAllocated {
			get {
				if (IsService) {
					return true;
				} else {
					return QuantityAllocated >= (Quantity - QuantityShipped);
				}
			}
		}

		private List<LineCannotShipReasonList> _lstLineCannotShipReasons = null;
		public List<LineCannotShipReasonList> LineCannotShipReasons {
			get {
				if (_lstLineCannotShipReasons == null) {
					_lstLineCannotShipReasons = new List<LineCannotShipReasonList>();
					BLL.SalesOrderLine sol = BLL.SalesOrderLine.GetShippingStatusInfo(SalesOrderLineId, AllocationId);
					if (sol != null) {
						//check if SO is closed (i.e. Shipped)
						if (sol.SalesOrderClosed || sol.Closed) {
							_lstLineCannotShipReasons.Add(LineCannotShipReasonList.Shipped);
						} else {
							//check if Terms were in advance and this isn't paid yet
							if (!Convert.ToBoolean(sol.TermsInAdvanceOK)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.TermsInAdvanceNotOK);

							//check if stock is in quarantine
							if (!sol.IsService) {
								if (sol.StockUnavailable) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.StockInQuarantine);
							}

							//check if SO is not authorised
							if (Convert.ToBoolean(sol.Unauthorised)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.Unauthorised);

							//check if GoodsIn is inspected (ignored for manual stock and services)
							if (!sol.IsService) {
								if (!Convert.ToBoolean(sol.GoodsInInspected)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.NotInspected);
							}

							//check if customer is over credit limit
							if (!Convert.ToBoolean(sol.CreditLimitOK)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.CompanyOverCreditLimit);

							//check if stock is allocated
							if (!sol.IsService) {
								if (sol.QuantityAllocated <= 0) {
									_lstLineCannotShipReasons.Add(LineCannotShipReasonList.Unallocated);
								} else {
									//check of there is some stock
									if (sol.QuantityInStock <= 0) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.NoneInStock);
								}
							}

							//check if Customer is On Stop
							if (Convert.ToBoolean(sol.CompanyOnStop)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.CompanyOnStop);

                            //check if Customer status is M and datepromised is not reside in current month
                            if (!string.IsNullOrEmpty(CreditStatus)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.OnHoldStatus);

                            //Check if the line is service and not posted 
                            if (sol.IsService)
                            {
                                if (!Convert.ToBoolean(sol.Posted)) _lstLineCannotShipReasons.Add(LineCannotShipReasonList.NotPosted);
                            }

						}
					}
				}
				return _lstLineCannotShipReasons;
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

		public enum LineCannotShipReasonList {
			Shipped,
			TermsInAdvanceNotOK,
			StockInQuarantine,
			Unauthorised,
			NotInspected,
			CompanyOverCreditLimit,
			Unallocated,
			NoneInStock,
			CompanyOnStop,
			ReadyToShip,
            OnHoldStatus,
            NotPosted
		}

	}
}