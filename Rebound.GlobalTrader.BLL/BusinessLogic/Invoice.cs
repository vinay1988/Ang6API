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
    public partial class Invoice : BizObject {

        #region Properties

        private Address _objShipToAddress;
        public Address ShipToAddress {
            get {
                if (_objShipToAddress == null) _objShipToAddress = GetShipToAddress(ShipToAddressNo, CompanyShipTo);
                return _objShipToAddress;
            }
        }

        private Address _objBillToAddress;
        public Address BillToAddress {
            get {
                if (_objBillToAddress == null) _objBillToAddress = GetBillToAddress(BillToAddressNo, CompanyBillTo);
                return _objBillToAddress;
            }
        }

        #endregion

        #region Static Methods

        public static Address GetShipToAddress(int? intShipToAddressNo, string strAddress) {
            Address addr = new Address();
            if (string.IsNullOrEmpty(strAddress)) {
                addr = Address.Get(intShipToAddressNo);
            } else {
                addr = LongStringToAddress(strAddress);
            }
            return addr;
        }

        public static Address GetBillToAddress(int? intBillToAddressNo, string strAddress) {
            Address addr = new Address();
            if (string.IsNullOrEmpty(strAddress)) {
                addr = Address.Get(intBillToAddressNo);
            } else {
                addr = LongStringToAddress(strAddress);
            }
            return addr;
        }

        /// <summary>
        /// Turns a long string into an address object
        /// </summary>
        /// <param name="strAddress"></param>
        /// <returns></returns>
        private static Address LongStringToAddress(string strAddress) {
            Address addr = new Address();
            string[] aryLines = strAddress.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < aryLines.Length; i++) {
                switch (i) {
                    case 0: addr.AddressName = aryLines[i]; break;
                    case 1: addr.Line1 = aryLines[i]; break;
                    case 2: addr.Line2 = aryLines[i]; break;
                    case 3: addr.Line3 = aryLines[i]; break;
                    case 4: addr.City = aryLines[i]; break;
                    case 5: addr.State = aryLines[i]; break;
                    case 6: addr.ZIP = aryLines[i]; break;
                    case 7: addr.CountryName = aryLines[i]; break;
                }
            }
            return addr;
        }

        #endregion

    }
}