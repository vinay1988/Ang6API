//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
//[002]    Shashi Keshar     22/02/2016     BOM for Dash Board
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
    public class SqlCSVExportLogProvider : CSVExportLogProvider
    {	      
		
		/// <summary>
		/// Create a new row
        /// Calls [usp_insert_CSVExportLog]
		/// </summary>
        public override Int32 Insert(System.Int32? CompanyNo, System.String Filename, System.Int32? updatedBy, System.String Section, System.String SendmailID, System.Int32? PurchaseQuoteNo, System.String strSubject, System.String strMessage)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CSVExportLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = CompanyNo;
                cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;	
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Section", SqlDbType.VarChar).Value = Section;
                cmd.Parameters.Add("@SendMailGroupID", SqlDbType.VarChar).Value = SendmailID;
                cmd.Parameters.Add("@PurchaseQuoteNo", SqlDbType.Int).Value = PurchaseQuoteNo;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = strSubject;
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = strMessage;
				cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                if (ret == -1)
                {
                    return ret;
                }
                return (Int32)cmd.Parameters["@Id"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
                throw new Exception("Failed to insert CSVExportLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Create a new row
        /// Calls [usp_create_SaveMailLog]
        /// </summary>
        public override Int32 InsertMailLog(System.String CompanyName, System.Int32? Id, string Type)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_create_SaveMailLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = Id;
               
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret == -1)
                {
                    return ret;
                }
                return (Int32)cmd.Parameters["@Id"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to create Log", sqlex);
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
