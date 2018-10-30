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
	public class SqlMailGroupMemberProvider : MailGroupMemberProvider {
		/// <summary>
		/// Delete MailGroupMember
		/// Calls [usp_delete_MailGroupMember]
		/// </summary>
		public override bool Delete(System.Int32? mailGroupNo, System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_MailGroupMember", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailGroupNo", SqlDbType.Int).Value = mailGroupNo;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete MailGroupMember", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_MailGroupMember]
		/// </summary>
		public override Int32 Insert(System.Int32? mailGroupNo, System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_MailGroupMember", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailGroupNo", SqlDbType.Int).Value = mailGroupNo;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert MailGroupMember", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_MailGroupMember]
        /// </summary>
		public override List<MailGroupMemberDetails> GetList(System.Int32? mailGroupMemberId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailGroupMember", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailGroupMemberId", SqlDbType.Int).Value = mailGroupMemberId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailGroupMemberDetails> lst = new List<MailGroupMemberDetails>();
				while (reader.Read()) {
					MailGroupMemberDetails obj = new MailGroupMemberDetails();
					obj.MailGroupMemberId = GetReaderValue_Int32(reader, "MailGroupMemberId", 0);
					obj.MailGroupNo = GetReaderValue_Int32(reader, "MailGroupNo", 0);
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailGroupMembers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListByGroup 
		/// Calls [usp_selectAll_MailGroupMember_by_Group]
        /// </summary>
		public override List<MailGroupMemberDetails> GetListByGroup(System.Int32? mailGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailGroupMember_by_Group", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailGroupNo", SqlDbType.Int).Value = mailGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailGroupMemberDetails> lst = new List<MailGroupMemberDetails>();
				while (reader.Read()) {
					MailGroupMemberDetails obj = new MailGroupMemberDetails();
					obj.MailGroupMemberId = GetReaderValue_Int32(reader, "MailGroupMemberId", 0);
					obj.MailGroupNo = GetReaderValue_Int32(reader, "MailGroupNo", 0);
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailGroupMembers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}



        /// <summary>
        /// GetListByGroup 
        /// Calls [[usp_selectAll_MailGroupMember_by_GroupName]]
        /// </summary>
        public override List<MailGroupMemberDetails> GetEmailListByGroup(System.String mailGroupName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_MailGroupMember_by_GroupName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@MailGroupName", SqlDbType.NVarChar).Value = mailGroupName;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<MailGroupMemberDetails> lst = new List<MailGroupMemberDetails>();
                while (reader.Read())
                {
                    MailGroupMemberDetails obj = new MailGroupMemberDetails();
                    obj.EmailID = GetReaderValue_String(reader, "EMail", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get MailGroupMembers", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		

		
	}
}