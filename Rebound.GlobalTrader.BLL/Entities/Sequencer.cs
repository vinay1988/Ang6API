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
		public partial class Sequencer : BizObject {
		
		#region Properties

		protected static DAL.SequencerElement Settings {
			get { return Globals.Settings.Sequencers; }
		}

		/// <summary>
		/// SystemDocumentNo
		/// </summary>
		public System.Int32 SystemDocumentNo { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// NextNumber
		/// </summary>
		public System.Int32 NextNumber { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Sequencer]
		/// </summary>
		public static Int32 Insert(System.Int32? systemDocumentNo, System.Int32? clientNo, System.Int32? nextNumber, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.Insert(systemDocumentNo, clientNo, nextNumber, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Sequencer]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.Insert(SystemDocumentNo, ClientNo, NextNumber, UpdatedBy);
		}
		/// <summary>
		/// InsertDefaults
		/// Calls [usp_insert_Sequencer_Defaults]
		/// </summary>
		public static Int32 InsertDefaults(System.Int32? clientNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.InsertDefaults(clientNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Sequencer]
		/// </summary>
		public static Sequencer Get(System.Int32? systemDocumentNo, System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.SequencerDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.Get(systemDocumentNo, clientId);
			if (objDetails == null) {
				return null;
			} else {
				Sequencer obj = new Sequencer();
				obj.SystemDocumentNo = objDetails.SystemDocumentNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.NextNumber = objDetails.NextNumber;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Sequencer]
		/// </summary>
		public static List<Sequencer> GetList() {
			List<SequencerDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.GetList();
			if (lstDetails == null) {
				return new List<Sequencer>();
			} else {
				List<Sequencer> lst = new List<Sequencer>();
				foreach (SequencerDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Sequencer obj = new Rebound.GlobalTrader.BLL.Sequencer();
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.NextNumber = objDetails.NextNumber;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Sequencer_for_Client]
		/// </summary>
		public static List<Sequencer> GetListForClient(System.Int32? clientId) {
			List<SequencerDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Sequencer>();
			} else {
				List<Sequencer> lst = new List<Sequencer>();
				foreach (SequencerDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Sequencer obj = new Rebound.GlobalTrader.BLL.Sequencer();
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.NextNumber = objDetails.NextNumber;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Sequencer]
		/// </summary>
		public static bool Update(System.Int32? systemDocumentNo, System.Int32? clientNo, System.Int32? nextNumber, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.Update(systemDocumentNo, clientNo, nextNumber, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Sequencer]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.Update(SystemDocumentNo, ClientNo, NextNumber, UpdatedBy);
		}
		/// <summary>
		/// UpdateNextNumber
		/// Calls [usp_update_Sequencer_NextNumber]
		/// </summary>
		public static bool UpdateNextNumber(System.Int32? clientNo, System.Int32? systemDocumentNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Sequencer.UpdateNextNumber(clientNo, systemDocumentNo, updatedBy);
		}

        private static Sequencer PopulateFromDBDetailsObject(SequencerDetails obj) {
            Sequencer objNew = new Sequencer();
			objNew.SystemDocumentNo = obj.SystemDocumentNo;
			objNew.ClientNo = obj.ClientNo;
			objNew.NextNumber = obj.NextNumber;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}