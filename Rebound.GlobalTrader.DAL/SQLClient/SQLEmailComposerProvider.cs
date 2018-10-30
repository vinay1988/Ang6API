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

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlEmailComposerProvider : EmailComposerProvider
    {
        /// <summary>
        /// usp_insert_EmailComposer
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public override Int32 Insert(System.Int32? clientNo, System.String subject, System.String EmailBody)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_EmailComposer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
                cmd.Parameters.Add("@EmailBody", SqlDbType.NVarChar).Value = EmailBody;
                cmd.Parameters.Add("@EmailComposerId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@EmailComposerId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert EmailComposer", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_update_EmailComposer
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        public override bool Update(System.Int32? clientNo, System.String subject, System.String EmailBody)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_EmailComposer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
                cmd.Parameters.Add("@EmailBody", SqlDbType.NVarChar).Value = EmailBody;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Email Composer", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_select_EmailComposerByClientNo
        /// </summary>
        /// <param name="ClientNo"></param>
        /// <returns></returns>
        public override EmailComposerDetails GetEmailComposerByClientNo(System.Int32? ClientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_EmailComposerByClientNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = ClientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    EmailComposerDetails obj = new EmailComposerDetails();
                    obj.EmailComposerId = GetReaderValue_Int32(reader, "EmailComposerId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.EmailBody = GetReaderValue_String(reader, "EmailBody", "");
                    obj.Subject = GetReaderValue_String(reader, "Subject", "");
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Email Composer", sqlex);
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
