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
	public class SqlPrinterProvider : PrinterProvider {
				
		
        /// <summary>
        /// DropDownForPrinter 
        /// Calls [usp_dropdown_PrinterAll]
        /// </summary>
        public override List<PrinterDetails> DropDownForPrinter(System.Int32? clientId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_PrinterAll", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<PrinterDetails> lst = new List<PrinterDetails>();
				while (reader.Read()) {
                    PrinterDetails obj = new PrinterDetails();
                    obj.PrinterId = GetReaderValue_Int32(reader, "PrinterId", 0);
                    obj.PrinterName = GetReaderValue_String(reader, "PrinterName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Printers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// Calls [usp_insert_Printer]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="printerName"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override int Insert(System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Printer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@PrinterName", SqlDbType.NVarChar).Value = printerName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@InActive", SqlDbType.Bit).Value = inActive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PrinterId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@PrinterId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Printer", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update Printer
        /// Calls [usp_update_Printer]
        /// </summary>
        public override bool Update(System.Int32? printerId, System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Printer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PrinterId", SqlDbType.Int).Value = printerId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@PrinterName", SqlDbType.NVarChar).Value = printerName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@InActive", SqlDbType.Bit).Value = inActive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Printer", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Call [usp_selectAll_Printer_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public override List<PrinterDetails> GetListForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Printer_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PrinterDetails> lst = new List<PrinterDetails>();
                while (reader.Read())
                {
                    PrinterDetails obj = new PrinterDetails();
                    obj.PrinterId = GetReaderValue_Int32(reader, "PrinterId", 0);
                    obj.PrinterName = GetReaderValue_String(reader, "PrinterName", "");
                    obj.PrinterDescription = GetReaderValue_String(reader, "PrinterDescription", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.UpdatedBy = GetReaderValue_Int32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Printers", sqlex);
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