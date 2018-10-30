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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class TeamProvider : DataAccess {
		static private TeamProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public TeamProvider Instance {
			get {
				if (_instance == null) _instance = (TeamProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Teams.ProviderType));
				return _instance;
			}
		}
		public TeamProvider() {
			this.ConnectionString = Globals.Settings.Teams.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Team]
		/// </summary>
		public abstract bool Delete(System.Int32? teamId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Team_for_Client]
		/// </summary>
		public abstract List<TeamDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Team]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.String teamName, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Team]
		/// </summary>
		public abstract TeamDetails Get(System.Int32? teamId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Team_for_Client]
		/// </summary>
		public abstract List<TeamDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Team]
		/// </summary>
		public abstract bool Update(System.Int32? teamId, System.Int32? clientNo, System.String teamName, System.String notes, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new TeamDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual TeamDetails GetTeamFromReader(DbDataReader reader) {
			TeamDetails team = new TeamDetails();
			if (reader.HasRows) {
				team.TeamId = GetReaderValue_Int32(reader, "TeamId", 0); //From: [Table]
				team.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				team.TeamName = GetReaderValue_String(reader, "TeamName", ""); //From: [usp_select_Company]
				team.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				team.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				team.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				team.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null); //From: [usp_selectAll_Division_for_Client]
			}
			return team;
		}
	
		/// <summary>
		/// Returns a collection of TeamDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<TeamDetails> GetTeamCollectionFromReader(DbDataReader reader) {
			List<TeamDetails> teams = new List<TeamDetails>();
			while (reader.Read()) teams.Add(GetTeamFromReader(reader));
			return teams;
		}
		
		
	}
}