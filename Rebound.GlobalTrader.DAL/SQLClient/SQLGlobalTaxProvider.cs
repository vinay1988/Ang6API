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
	public class SqlGlobalTaxProvider : GlobalTaxProvider {
			
		
		/// <summary>
		/// Create a new row
        /// Calls [usp_insert_GlobalTax]
		/// </summary>
        public override Int32 Insert( System.String taxName, System.String notes, System.Boolean? inactive, System.String taxCode, System.String printNotes, System.Int32? updatedBy, System.String purchaseTaxCode)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GlobalTax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
			
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
        /// Calls [usp_select_GlobalTax]
        /// </summary>
		public override GlobalTaxDetails Get(System.Int32? taxId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GlobalTax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTaxFromReader(reader);
					GlobalTaxDetails obj = new GlobalTaxDetails();
					obj.TaxId = GetReaderValue_Int32(reader, "GlobalTaxId", 0);
                    obj.TaxName = GetReaderValue_String(reader, "GlobalTaxName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.TaxCode = GetReaderValue_String(reader, "GlobalTaxCode", "");
					obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Global Tax", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
        /// Calls [usp_selectAll_GlobalTax_List]
        /// </summary>
		public override List<GlobalTaxDetails> GetListForClient() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GlobalTax_List", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<GlobalTaxDetails> lst = new List<GlobalTaxDetails>();
				while (reader.Read()) {
					GlobalTaxDetails obj = new GlobalTaxDetails();
					obj.TaxId = GetReaderValue_Int32(reader, "GlobalTaxId", 0);
                    obj.TaxName = GetReaderValue_String(reader, "GlobalTaxName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.TaxCode = GetReaderValue_String(reader, "GlobalTaxCode", "");
                    //[002] code start
                    obj.PurchaseTaxCode = GetReaderValue_String(reader, "PurchaseGlobalTaxCode", "");
                    //[002] code end
					obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Global Taxs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Global Tax
        /// Calls [usp_update_GlobalTax]
        /// </summary>
		public override bool Update(System.Int32? taxId, System.String taxName, System.String notes, System.String taxCode, System.Boolean? inactive, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GlobalTax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
			
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
        /// Get Global Tax Code according to client
        /// Call Proc [usp_dropdown_PurchaseGlobalTaxCode]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public override List<GlobalTaxDetails> DropDownPurchaseTaxCodeForClient()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_PurchaseGlobalTaxCode", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GlobalTaxDetails> lst = new List<GlobalTaxDetails>();
                while (reader.Read())
                {
                    GlobalTaxDetails obj = new GlobalTaxDetails();
                    obj.TaxId = GetReaderValue_Int32(reader, "GlobalTaxId", 0);
                    obj.TaxName = GetReaderValue_String(reader, "GlobalTaxName", "");
                    obj.TaxCode = GetReaderValue_String(reader, "PurchaseGlobalTaxCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Global Taxs", sqlex);
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