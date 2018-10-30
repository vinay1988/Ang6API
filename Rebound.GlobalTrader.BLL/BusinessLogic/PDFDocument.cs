/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document
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


namespace Rebound.GlobalTrader.BLL
{
  public  partial class PDFDocument : BizObject 
    {

        #region Properties

        private string _strUpdatedByName = null;
        public string UpdatedByName
        {
            get
            {
                if (_strUpdatedByName == null)
                {
                    _strUpdatedByName = "";
                    if (UpdatedBy != null)
                    {
                        BLL.Login lg = BLL.Login.GetName(UpdatedBy);
                        if (lg != null) _strUpdatedByName = lg.EmployeeName;
                        lg = null;
                    }
                }
                return _strUpdatedByName;
            }
        }

        #endregion
    }
}
