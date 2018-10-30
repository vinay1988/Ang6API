using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.BLL.Enumerations
{
    public partial class PurchaseQuoteStatus
    {
        [Serializable]
        public enum List
        {
            Open = 1,
            OutForQuotes = 2,
            SupplierQuoted = 3,
            ShareWithClient = 4,
            Imported = 5
        }	
    }
}
