using System;
using System.Collections.Generic;
using System.Text;

namespace Rebound.GlobalTrader.BLL {
    public partial class GoodsInLine : BizObject {

        public bool HasPhotos {
            get { return CountPhotos > 0; }
        }

        private bool _blnCountedPhotos = false;
        private int _intCountPhotos = 0;
        public int CountPhotos {
            get {
                if (StockNo == null) return 0;
                if (!_blnCountedPhotos) _intCountPhotos = StockImage.CountForStock(StockNo);
                _blnCountedPhotos = true;
                return _intCountPhotos;
            }
        }
    }
}
