//Marker     Changed by      Date               Remarks
//[001]      Vinay           24/06/2013         CR:- Supplier Invoice
//[002]      Vinay           15/07/2013         ESMS Ref##-37 Add New Column named as purchage code under Setup => Company Settings => Tax Section 
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
	public class SqlTaxProvider : TaxProvider {
		/// <summary>
		/// Delete Tax
		/// Calls [usp_delete_Tax]
		/// </summary>
		public override bool Delete(System.Int32? taxId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Tax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Tax", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Tax_for_Client]
        /// </summary>
		public override List<TaxDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Tax_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TaxDetails> lst = new List<TaxDetails>();
				while (reader.Read()) {
					TaxDetails obj = new TaxDetails();
					obj.TaxId = GetReaderValue_Int32(reader, "TaxId", 0);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Taxs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Tax]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String taxName, System.String notes, System.Boolean? inactive, System.String taxCode, System.String printNotes, System.Int32? updatedBy, System.String purchaseTaxCode)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Tax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@TaxName", SqlDbType.NVarChar).Value = taxName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
				cmd.Parameters.Add("@PrintNotes", SqlDbType.NVarChar).Value = printNotes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@PurchaseTaxCode", SqlDbType.NVarChar).Value = purchaseTaxCode;
                //[001] code end
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@TaxId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Tax", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Tax]
        /// </summary>
		public override TaxDetails Get(System.Int32? taxId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Tax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTaxFromReader(reader);
					TaxDetails obj = new TaxDetails();
					obj.TaxId = GetReaderValue_Int32(reader, "TaxId", 0);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.TaxCode = GetReaderValue_String(reader, "TaxCode", "");
					obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Tax", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Tax_for_Client]
        /// </summary>
		public override List<TaxDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Tax_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TaxDetails> lst = new List<TaxDetails>();
				while (reader.Read()) {
					TaxDetails obj = new TaxDetails();
					obj.TaxId = GetReaderValue_Int32(reader, "TaxId", 0);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.TaxCode = GetReaderValue_String(reader, "TaxCode", "");
                    //[002] code start
                    obj.PurchaseTaxCode = GetReaderValue_String(reader, "PurchaseTaxCode", "");
                    //[002] code end
					obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Taxs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Tax
		/// Calls [usp_update_Tax]
        /// </summary>
		public override bool Update(System.Int32? taxId, System.Int32? clientNo, System.String taxName, System.String notes, System.String taxCode, System.Boolean? inactive, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Tax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@TaxName", SqlDbType.NVarChar).Value = taxName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@PrintNotes", SqlDbType.NVarChar).Value = printNotes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@PurchaseTaxCode", SqlDbType.NVarChar).Value = purchaseTaxCode;
                //[001] code end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Tax", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        //[001] code start
        /// <summary>
        /// Get Tax Code according to client
        /// Call Proc [usp_dropdown_PurchaseTaxCode_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public override List<TaxDetails> DropDownPurchaseTaxCodeForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_PurchaseTaxCode_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<TaxDetails> lst = new List<TaxDetails>();
                while (reader.Read())
                {
                    TaxDetails obj = new TaxDetails();
                    obj.TaxId = GetReaderValue_Int32(reader, "TaxId", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxCode = GetReaderValue_String(reader, "PurchaseTaxCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Taxs", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end
		
		
		
		
	}
}