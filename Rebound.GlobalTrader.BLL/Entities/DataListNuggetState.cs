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
		public partial class DataListNuggetState : BizObject {
		
		#region Properties

		protected static DAL.DataListNuggetStateElement Settings {
			get { return Globals.Settings.DataListNuggetStates; }
		}

		/// <summary>
		/// DataListNuggetStateID
		/// </summary>
		public System.Int32 DataListNuggetStateID { get; set; }		
		/// <summary>
		/// DataListNuggetNo
		/// </summary>
		public System.Int32 DataListNuggetNo { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// SubType
		/// </summary>
		public System.String SubType { get; set; }		
		/// <summary>
		/// StateText
		/// </summary>
		public System.String StateText { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// DeleteAllForLogin
		/// Calls [usp_delete_DataListNuggetState_All_for_Login]
		/// </summary>
		public static bool DeleteAllForLogin(System.Int32? loginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DataListNuggetState.DeleteAllForLogin(loginNo);
		}
		/// <summary>
		/// DeleteForDLNAndLogin
		/// Calls [usp_delete_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public static bool DeleteForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DataListNuggetState.DeleteForDLNAndLogin(dataListNuggetNo, subType, loginNo);
		}
		/// <summary>
		/// GetForDLNAndLogin
		/// Calls [usp_select_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public static DataListNuggetState GetForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo) {
			Rebound.GlobalTrader.DAL.DataListNuggetStateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.DataListNuggetState.GetForDLNAndLogin(dataListNuggetNo, subType, loginNo);
			if (objDetails == null) {
				return null;
			} else {
				DataListNuggetState obj = new DataListNuggetState();
				obj.DataListNuggetStateID = objDetails.DataListNuggetStateID;
				obj.DataListNuggetNo = objDetails.DataListNuggetNo;
				obj.LoginNo = objDetails.LoginNo;
				obj.SubType = objDetails.SubType;
				obj.StateText = objDetails.StateText;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// UpdateForDLNAndLogin
		/// Calls [usp_update_DataListNuggetState_for_DLN_and_Login]
		/// </summary>
		public static bool UpdateForDLNAndLogin(System.Int32? dataListNuggetNo, System.String subType, System.Int32? loginNo, System.String stateText) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DataListNuggetState.UpdateForDLNAndLogin(dataListNuggetNo, subType, loginNo, stateText);
		}

        private static DataListNuggetState PopulateFromDBDetailsObject(DataListNuggetStateDetails obj) {
            DataListNuggetState objNew = new DataListNuggetState();
			objNew.DataListNuggetStateID = obj.DataListNuggetStateID;
			objNew.DataListNuggetNo = obj.DataListNuggetNo;
			objNew.LoginNo = obj.LoginNo;
			objNew.SubType = obj.SubType;
			objNew.StateText = obj.StateText;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}