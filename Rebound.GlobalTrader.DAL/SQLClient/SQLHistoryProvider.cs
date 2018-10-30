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
	public class SqlHistoryProvider : HistoryProvider {
		/// <summary>
		/// Delete History
		/// Calls [usp_delete_History]
		/// </summary>
		public override bool Delete(System.Int32? historyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_History", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@HistoryNo", SqlDbType.Int).Value = historyNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_History]
		/// </summary>
		public override Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.DateTime? offerStatusChangeDate, System.Int32? offerStatusChangeLoginNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_History", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OriginalEntryDate", SqlDbType.DateTime).Value = originalEntryDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@OfferStatusChangeDate", SqlDbType.DateTime).Value = offerStatusChangeDate;
				cmd.Parameters.Add("@OfferStatusChangeLoginNo", SqlDbType.Int).Value = offerStatusChangeLoginNo;
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@HistoryId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@HistoryId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_History]
        /// </summary>
		public override HistoryDetails Get(System.Int32? historyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_History", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HistoryNo", SqlDbType.Int).Value = historyNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetHistoryFromReader(reader);
					HistoryDetails obj = new HistoryDetails();
					obj.HistoryId = GetReaderValue_Int32(reader, "HistoryId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_History]
        /// </summary>
        public override List<HistoryDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal,bool? isPoHub)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
            string proc = "usp_source_History";
            proc = isPoHub == true ? "usp_source_HistoryPH" : proc;
			try {
                if (!hasServerLocal)
                    cn = new SqlConnection(this.GTConnectionString);
                else
                    cn = new SqlConnection(this.ConnectionString);

                cmd = new SqlCommand(proc, cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = index;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@FinishDate", SqlDbType.DateTime).Value = endDate;
				cn.Open();
				//DbDataReader reader = ExecuteReader(cmd);
                SqlDataReader reader = cmd.ExecuteReader();
				List<HistoryDetails> lst = new List<HistoryDetails>();
				while (reader.Read()) {
					HistoryDetails obj = new HistoryDetails();
					obj.HistoryId = GetReaderValue_Int32(reader, "HistoryId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    //[001] code start
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[001] code end
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
					lst.Add(obj);
					obj = null;
				}
                reader.NextResult();
                while (reader.Read())
                {
                    outDate = GetReaderValue_NullableDateTime(reader, "OutPutDate", null);
                }
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Historys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update History
		/// Calls [usp_update_History]
        /// </summary>
		public override bool Update(System.Int32? historyId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_History", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@HistoryId", SqlDbType.Int).Value = historyId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update History
		/// Calls [usp_update_History_for_sourcing]
        /// </summary>
		public override bool UpdateForSourcing(System.Int32? historyNo, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_History_for_sourcing", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@HistoryNo", SqlDbType.Int).Value = historyNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update History
		/// Calls [usp_update_History_OfferStatus]
        /// </summary>
		public override bool UpdateOfferStatus(System.Int32? historyNo, System.Int32? offerStatusNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_History_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@HistoryNo", SqlDbType.Int).Value = historyNo;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update History", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}