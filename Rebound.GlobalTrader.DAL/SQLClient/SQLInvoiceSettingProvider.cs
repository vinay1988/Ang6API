
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
    public class SqlInvoiceSettingProvider : InvoiceSettingProvider
    {

        /// <summary>
        /// Insert
        /// Calls [usp_insert_InvoiceSchedule]
        /// </summary>
        public override Int32 Insert(System.Int32? duration, DateTime? startdate, System.Boolean? isActive, System.Boolean? grouped, System.Int32? createdBy, Int32? clientNo) 
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            int status=default(int);
            try 
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_InvoiceSchedule", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DURATION", SqlDbType.Int).Value = duration;
               // cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = null;
                cmd.Parameters.Add("@GROUPED", SqlDbType.Bit).Value = grouped;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = createdBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 0;
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                Int32.TryParse(cmd.Parameters["@Status"].Value !=null?cmd.Parameters["@Status"].Value.ToString():"", out status);
                return status;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("failed to insert data", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Source 
        /// Calls [usp_select_InvoiceSchedule]
        /// </summary>
        public override InvoiceSettingDetails Get(System.Int32? Id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InvoiceSchedule", cn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())                {
                    InvoiceSettingDetails obj = new InvoiceSettingDetails();
                    obj.ID = GetReaderValue_Int32(reader, "ScheduledInvoiceId", 0);
                    obj.Duration = GetReaderValue_Int32(reader, "Duration", 0); 
                    obj.StartDate = GetReaderValue_DateTime(reader, "StartDate", DateTime.Now);
                    obj.IsActive = GetReaderValue_NullableBoolean(reader, "IsActive", false);
                    obj.Grouped = GetReaderValue_NullableBoolean(reader, "IsGrouped", false);
                    obj.IsLocked = GetReaderValue_NullableBoolean(reader, "IsLocked", false);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
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
                throw new Exception("Failed to get data", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Source 
        /// Calls [usp_selectAll_InvoiceSchedule]
        /// </summary>
        public override List<InvoiceSettingDetails> GetData(int? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_InvoiceSchedule", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InvoiceSettingDetails> lstData = new List<InvoiceSettingDetails>();
                while (reader.Read())
                {
                    InvoiceSettingDetails obj = new InvoiceSettingDetails();
                    obj.ID = GetReaderValue_Int32(reader, "ScheduledInvoiceId", 0);
                    obj.Duration = GetReaderValue_Int32(reader, "Duration", 0);
                   // obj.StartDate = GetReaderValue_DateTime(reader, "StartDate", DateTime.Now);
                    obj.IsActive = GetReaderValue_NullableBoolean(reader, "IsActive", false);
                    obj.Grouped = GetReaderValue_NullableBoolean(reader, "IsGrouped", false);
                    obj.IsLocked = GetReaderValue_NullableBoolean(reader, "IsLocked", false);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", null);
                    obj.LastRun = GetReaderValue_NullableDateTime(reader, "LastRun", null);
                    lstData.Add(obj);
                    obj = null;
                }
                return lstData;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get data", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Calls [usp_Update_InvoiceSchedule]
        /// </summary>
        public override bool Update(System.Int32 Id, System.Int32 duration, System.DateTime startDate, System.Boolean? isActive, System.Boolean? grouped, System.Int32? updatedBy,int? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Update_InvoiceSchedule", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DURATION", SqlDbType.Int).Value = duration;
               // cmd.Parameters.Add("@STARTDATE", SqlDbType.DateTime).Value = null;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive ?? false;
                cmd.Parameters.Add("@ISGROUPED", SqlDbType.Bit).Value = grouped??false;
                cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CLIENTNO", SqlDbType.Int).Value = clientNo; 
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update data", sqlex);
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
