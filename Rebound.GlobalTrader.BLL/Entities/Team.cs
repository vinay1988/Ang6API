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
		public partial class Team : BizObject {
		
		#region Properties

		protected static DAL.TeamElement Settings {
			get { return Globals.Settings.Teams; }
		}

		/// <summary>
		/// TeamId
		/// </summary>
		public System.Int32 TeamId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// TeamName
		/// </summary>
		public System.String TeamName { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// NumberOfMembers
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Team]
		/// </summary>
		public static bool Delete(System.Int32? teamId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Team.Delete(teamId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Team_for_Client]
		/// </summary>
		public static List<Team> DropDownForClient(System.Int32? clientId) {
			List<TeamDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Team.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Team>();
			} else {
				List<Team> lst = new List<Team>();
				foreach (TeamDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Team obj = new Rebound.GlobalTrader.BLL.Team();
					obj.TeamId = objDetails.TeamId;
					obj.TeamName = objDetails.TeamName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Team]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String teamName, System.String notes, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Team.Insert(clientNo, teamName, notes, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Team]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Team.Insert(ClientNo, TeamName, Notes, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Team]
		/// </summary>
		public static Team Get(System.Int32? teamId) {
			Rebound.GlobalTrader.DAL.TeamDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Team.Get(teamId);
			if (objDetails == null) {
				return null;
			} else {
				Team obj = new Team();
				obj.TeamId = objDetails.TeamId;
				obj.ClientNo = objDetails.ClientNo;
				obj.TeamName = objDetails.TeamName;
				obj.Notes = objDetails.Notes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Team_for_Client]
		/// </summary>
		public static List<Team> GetListForClient(System.Int32? clientId) {
			List<TeamDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Team.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Team>();
			} else {
				List<Team> lst = new List<Team>();
				foreach (TeamDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Team obj = new Rebound.GlobalTrader.BLL.Team();
					obj.TeamId = objDetails.TeamId;
					obj.ClientNo = objDetails.ClientNo;
					obj.TeamName = objDetails.TeamName;
					obj.Notes = objDetails.Notes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.NumberOfMembers = objDetails.NumberOfMembers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Team]
		/// </summary>
		public static bool Update(System.Int32? teamId, System.Int32? clientNo, System.String teamName, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Team.Update(teamId, clientNo, teamName, notes, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Team]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Team.Update(TeamId, ClientNo, TeamName, Notes, UpdatedBy);
		}

        private static Team PopulateFromDBDetailsObject(TeamDetails obj) {
            Team objNew = new Team();
			objNew.TeamId = obj.TeamId;
			objNew.ClientNo = obj.ClientNo;
			objNew.TeamName = obj.TeamName;
			objNew.Notes = obj.Notes;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.NumberOfMembers = obj.NumberOfMembers;
            return objNew;
        }
		
		#endregion
		
	}
}