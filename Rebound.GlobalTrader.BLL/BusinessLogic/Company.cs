/*

Marker     changed by      date         Remarks

[001]      Abhinav       20/03/2012   ESMS Ref:14 - Tax Information


*/

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
	public partial class Company : BizObject {

		#region Properties

		private Address _objDefaultBillingAddress;
		public Address DefaultBillingAddress {
			get {
				if (_objDefaultBillingAddress == null) _objDefaultBillingAddress = GetDefaultBillingAddress(CompanyId);
				if (_objDefaultBillingAddress == null) _objDefaultBillingAddress = new Address();
				return _objDefaultBillingAddress;
			}
		}

		private Address _objDefaultShippingAddress;
		public Address DefaultShippingAddress {
			get {
				if (_objDefaultShippingAddress == null) _objDefaultShippingAddress = GetDefaultShippingAddress(CompanyId);
				if (_objDefaultShippingAddress == null) _objDefaultShippingAddress = new Address();
				return _objDefaultShippingAddress;
			}
		}

        private Address _objCompanyAddress;
        public Address ShippingAddress
        {
            get
            {
                if (_objCompanyAddress == null) _objCompanyAddress = GetShippingAddress(intAddressID);
                if (_objCompanyAddress == null) _objCompanyAddress = new Address();
                return _objCompanyAddress;
            }
        }


		#endregion

		#region Static Methods

		public static Address GetDefaultBillingAddress(int? intCompanyID) {
			Address addr = null;
			if (intCompanyID != null) addr = Address.GetDefaultBillingForCompany(intCompanyID);
			if (addr == null) addr = new Address();
			return addr;
		}

		public static Address GetDefaultShippingAddress(int? intCompanyID) {
			Address addr = null;
			if (intCompanyID != null) addr = Address.GetDefaultShippingForCompany(intCompanyID);
			if (addr == null) addr = new Address();
			return addr;
		}
        // [001] code start
        public static Address GetShippingAddress(int? intAddressID)
        {
            Address addr = null;
            if (intAddressID != null) addr = Address.Get(intAddressID);
            if (addr == null) addr = new Address();
            return addr;
        }
        // [001] code end
		#endregion

	}
}