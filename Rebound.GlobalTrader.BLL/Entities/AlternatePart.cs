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
		public partial class AlternatePart : BizObject {
		
		#region Properties

		protected static DAL.AlternatePartElement Settings {
			get { return Globals.Settings.AlternateParts; }
		}

		/// <summary>
		/// AlternatePartId
		/// </summary>
		public System.Int32 AlternatePartId { get; set; }		
		/// <summary>
		/// PartNo
		/// </summary>
		public System.Int32 PartNo { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// ROHSCompliant
		/// </summary>
		public System.Boolean ROHSCompliant { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_AlternatePart]
		/// </summary>
		public static bool Delete(System.Int32? alternatePartId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Delete(alternatePartId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_AlternatePart]
		/// </summary>
		public static Int32 Insert(System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Insert(partNo, fullPart, part, rohsCompliant, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_AlternatePart]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Insert(PartNo, FullPart, Part, ROHSCompliant, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_AlternatePart]
		/// </summary>
		public static AlternatePart Get(System.Int32? alternatePartId) {
			Rebound.GlobalTrader.DAL.AlternatePartDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Get(alternatePartId);
			if (objDetails == null) {
				return null;
			} else {
				AlternatePart obj = new AlternatePart();
				obj.AlternatePartId = objDetails.AlternatePartId;
				obj.PartNo = objDetails.PartNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHSCompliant = objDetails.ROHSCompliant;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_AlternatePart]
		/// </summary>
		public static bool Update(System.Int32? alternatePartId, System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Update(alternatePartId, partNo, fullPart, part, rohsCompliant, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_AlternatePart]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.AlternatePart.Update(AlternatePartId, PartNo, FullPart, Part, ROHSCompliant, UpdatedBy);
		}

        private static AlternatePart PopulateFromDBDetailsObject(AlternatePartDetails obj) {
            AlternatePart objNew = new AlternatePart();
			objNew.AlternatePartId = obj.AlternatePartId;
			objNew.PartNo = obj.PartNo;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ROHSCompliant = obj.ROHSCompliant;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}