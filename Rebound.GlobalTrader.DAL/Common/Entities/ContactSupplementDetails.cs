using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class ContactSupplementDetails {
		
		#region Constructors
		
		public ContactSupplementDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// Birthday (from Table)
		/// </summary>
		public System.DateTime? Birthday { get; set; }
		/// <summary>
		/// PartnerName (from Table)
		/// </summary>
		public System.String PartnerName { get; set; }
		/// <summary>
		/// PartnerBirthday (from Table)
		/// </summary>
		public System.DateTime? PartnerBirthday { get; set; }
		/// <summary>
		/// Anniversary (from Table)
		/// </summary>
		public System.DateTime? Anniversary { get; set; }
		/// <summary>
		/// NumberOfChildren (from Table)
		/// </summary>
		public System.Int32? NumberOfChildren { get; set; }
		/// <summary>
		/// ChildName1 (from Table)
		/// </summary>
		public System.String ChildName1 { get; set; }
		/// <summary>
		/// ChildBirthday1 (from Table)
		/// </summary>
		public System.DateTime? ChildBirthday1 { get; set; }
		/// <summary>
		/// ChildName2 (from Table)
		/// </summary>
		public System.String ChildName2 { get; set; }
		/// <summary>
		/// ChildBirthday2 (from Table)
		/// </summary>
		public System.DateTime? ChildBirthday2 { get; set; }
		/// <summary>
		/// ChildName3 (from Table)
		/// </summary>
		public System.String ChildName3 { get; set; }
		/// <summary>
		/// ChildBirthday3 (from Table)
		/// </summary>
		public System.DateTime? ChildBirthday3 { get; set; }
		/// <summary>
		/// PersonalCellphone (from Table)
		/// </summary>
		public System.String PersonalCellphone { get; set; }
		/// <summary>
		/// FavouriteSport (from Table)
		/// </summary>
		public System.String FavouriteSport { get; set; }
		/// <summary>
		/// FavouriteTeam (from Table)
		/// </summary>
		public System.String FavouriteTeam { get; set; }
		/// <summary>
		/// Hobbies (from Table)
		/// </summary>
		public System.String Hobbies { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// GenderNo (from Table)
		/// </summary>
		public System.Int32? GenderNo { get; set; }
		/// <summary>
		/// MaritalStatusNo (from Table)
		/// </summary>
		public System.Int32? MaritalStatusNo { get; set; }
		/// <summary>
		/// ChildGenderNo1 (from Table)
		/// </summary>
		public System.Int32? ChildGenderNo1 { get; set; }
		/// <summary>
		/// ChildGenderNo2 (from Table)
		/// </summary>
		public System.Int32? ChildGenderNo2 { get; set; }
		/// <summary>
		/// ChildGenderNo3 (from Table)
		/// </summary>
		public System.Int32? ChildGenderNo3 { get; set; }
		/// <summary>
		/// MaritalStatusName (from usp_select_ContactSupplement)
		/// </summary>
		public System.String MaritalStatusName { get; set; }

		#endregion

	}
}