using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL.SqlClient {
	public class SqlContactSupplementProvider : ContactSupplementProvider {
		/// <summary>
		/// Delete ContactSupplement
		/// Calls [usp_delete_ContactSupplement]
		/// </summary>
		public override bool Delete(System.Int32? contactNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ContactSupplement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ContactSupplement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_ContactSupplement]
		/// </summary>
		public override Int32 Insert(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_ContactSupplement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@GenderNo", SqlDbType.Int).Value = genderNo;
				cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = birthday;
				cmd.Parameters.Add("@MaritalStatusNo", SqlDbType.Int).Value = maritalStatusNo;
				cmd.Parameters.Add("@PartnerName", SqlDbType.NVarChar).Value = partnerName;
				cmd.Parameters.Add("@PartnerBirthday", SqlDbType.DateTime).Value = partnerBirthday;
				cmd.Parameters.Add("@Anniversary", SqlDbType.DateTime).Value = anniversary;
				cmd.Parameters.Add("@NumberOfChildren", SqlDbType.Int).Value = numberOfChildren;
				cmd.Parameters.Add("@ChildName1", SqlDbType.NVarChar).Value = childName1;
				cmd.Parameters.Add("@ChildGenderNo1", SqlDbType.Int).Value = childGenderNo1;
				cmd.Parameters.Add("@ChildBirthday1", SqlDbType.DateTime).Value = childBirthday1;
				cmd.Parameters.Add("@ChildName2", SqlDbType.NVarChar).Value = childName2;
				cmd.Parameters.Add("@ChildGenderNo2", SqlDbType.Int).Value = childGenderNo2;
				cmd.Parameters.Add("@ChildBirthday2", SqlDbType.DateTime).Value = childBirthday2;
				cmd.Parameters.Add("@ChildName3", SqlDbType.NVarChar).Value = childName3;
				cmd.Parameters.Add("@ChildGenderNo3", SqlDbType.Int).Value = childGenderNo3;
				cmd.Parameters.Add("@ChildBirthday3", SqlDbType.DateTime).Value = childBirthday3;
				cmd.Parameters.Add("@PersonalCellphone", SqlDbType.NVarChar).Value = personalCellphone;
				cmd.Parameters.Add("@FavouriteSport", SqlDbType.NVarChar).Value = favouriteSport;
				cmd.Parameters.Add("@FavouriteTeam", SqlDbType.NVarChar).Value = favouriteTeam;
				cmd.Parameters.Add("@Hobbies", SqlDbType.NVarChar).Value = hobbies;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert ContactSupplement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_ContactSupplement]
        /// </summary>
		public override ContactSupplementDetails Get(System.Int32? contactNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ContactSupplement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetContactSupplementFromReader(reader);
					ContactSupplementDetails obj = new ContactSupplementDetails();
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Birthday = GetReaderValue_NullableDateTime(reader, "Birthday", null);
					obj.PartnerName = GetReaderValue_String(reader, "PartnerName", "");
					obj.PartnerBirthday = GetReaderValue_NullableDateTime(reader, "PartnerBirthday", null);
					obj.Anniversary = GetReaderValue_NullableDateTime(reader, "Anniversary", null);
					obj.NumberOfChildren = GetReaderValue_NullableInt32(reader, "NumberOfChildren", null);
					obj.ChildName1 = GetReaderValue_String(reader, "ChildName1", "");
					obj.ChildBirthday1 = GetReaderValue_NullableDateTime(reader, "ChildBirthday1", null);
					obj.ChildName2 = GetReaderValue_String(reader, "ChildName2", "");
					obj.ChildBirthday2 = GetReaderValue_NullableDateTime(reader, "ChildBirthday2", null);
					obj.ChildName3 = GetReaderValue_String(reader, "ChildName3", "");
					obj.ChildBirthday3 = GetReaderValue_NullableDateTime(reader, "ChildBirthday3", null);
					obj.PersonalCellphone = GetReaderValue_String(reader, "PersonalCellphone", "");
					obj.FavouriteSport = GetReaderValue_String(reader, "FavouriteSport", "");
					obj.FavouriteTeam = GetReaderValue_String(reader, "FavouriteTeam", "");
					obj.Hobbies = GetReaderValue_String(reader, "Hobbies", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.GenderNo = GetReaderValue_NullableInt32(reader, "GenderNo", null);
					obj.MaritalStatusNo = GetReaderValue_NullableInt32(reader, "MaritalStatusNo", null);
					obj.ChildGenderNo1 = GetReaderValue_NullableInt32(reader, "ChildGenderNo1", null);
					obj.ChildGenderNo2 = GetReaderValue_NullableInt32(reader, "ChildGenderNo2", null);
					obj.ChildGenderNo3 = GetReaderValue_NullableInt32(reader, "ChildGenderNo3", null);
					obj.MaritalStatusName = GetReaderValue_String(reader, "MaritalStatusName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ContactSupplement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ContactSupplement
		/// Calls [usp_update_ContactSupplement]
        /// </summary>
		public override bool Update(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ContactSupplement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@GenderNo", SqlDbType.Int).Value = genderNo;
				cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = birthday;
				cmd.Parameters.Add("@MaritalStatusNo", SqlDbType.Int).Value = maritalStatusNo;
				cmd.Parameters.Add("@PartnerName", SqlDbType.NVarChar).Value = partnerName;
				cmd.Parameters.Add("@PartnerBirthday", SqlDbType.DateTime).Value = partnerBirthday;
				cmd.Parameters.Add("@Anniversary", SqlDbType.DateTime).Value = anniversary;
				cmd.Parameters.Add("@NumberOfChildren", SqlDbType.Int).Value = numberOfChildren;
				cmd.Parameters.Add("@ChildName1", SqlDbType.NVarChar).Value = childName1;
				cmd.Parameters.Add("@ChildGenderNo1", SqlDbType.Int).Value = childGenderNo1;
				cmd.Parameters.Add("@ChildBirthday1", SqlDbType.DateTime).Value = childBirthday1;
				cmd.Parameters.Add("@ChildName2", SqlDbType.NVarChar).Value = childName2;
				cmd.Parameters.Add("@ChildGenderNo2", SqlDbType.Int).Value = childGenderNo2;
				cmd.Parameters.Add("@ChildBirthday2", SqlDbType.DateTime).Value = childBirthday2;
				cmd.Parameters.Add("@ChildName3", SqlDbType.NVarChar).Value = childName3;
				cmd.Parameters.Add("@ChildGenderNo3", SqlDbType.Int).Value = childGenderNo3;
				cmd.Parameters.Add("@ChildBirthday3", SqlDbType.DateTime).Value = childBirthday3;
				cmd.Parameters.Add("@PersonalCellphone", SqlDbType.NVarChar).Value = personalCellphone;
				cmd.Parameters.Add("@FavouriteSport", SqlDbType.NVarChar).Value = favouriteSport;
				cmd.Parameters.Add("@FavouriteTeam", SqlDbType.NVarChar).Value = favouriteTeam;
				cmd.Parameters.Add("@Hobbies", SqlDbType.NVarChar).Value = hobbies;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ContactSupplement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}