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
	public class SqlDebitLineProvider : DebitLineProvider {
		/// <summary>
		/// Count DebitLine
		/// Calls [usp_count_DebitLine_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_DebitLine_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_DebitLine]
        /// </summary>
        public override List<DebitLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String debitNotesSearch, System.String supplierInvoiceSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo, System.Boolean? PohubOnly, Boolean IsGlobalLogin, System.Int32? clientSearchId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_DebitLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@DebitNotesSearch", SqlDbType.NVarChar).Value = debitNotesSearch;
				cmd.Parameters.Add("@SupplierInvoiceSearch", SqlDbType.NVarChar).Value = supplierInvoiceSearch;
				cmd.Parameters.Add("@DebitNoLo", SqlDbType.Int).Value = debitNoLo;
				cmd.Parameters.Add("@DebitNoHi", SqlDbType.Int).Value = debitNoHi;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
				cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
				cmd.Parameters.Add("@DebitDateFrom", SqlDbType.DateTime).Value = debitDateFrom;
				cmd.Parameters.Add("@DebitDateTo", SqlDbType.DateTime).Value = debitDateTo;
                cmd.Parameters.Add("@PoHubOnly", SqlDbType.Bit).Value = PohubOnly;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cmd.Parameters.Add("@ClientSearchId", SqlDbType.Int).Value = clientSearchId;

				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitLineDetails> lst = new List<DebitLineDetails>();
				while (reader.Read()) {
					DebitLineDetails obj = new DebitLineDetails();
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.IPOCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", 0);
                    obj.IPOCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DebitLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete DebitLine
		/// Calls [usp_delete_DebitLine]
		/// </summary>
		public override bool Delete(System.Int32? debitLineId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_DebitLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitLineId", SqlDbType.Int).Value = debitLineId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_DebitLine]
		/// </summary>
        public override Int32 Insert(System.Int32? debitNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String supplierPart, System.Double? landedCost, System.Int32? purchaseOrderLineNo, System.Int32? supplierRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, out int debitId, out int debitNumber, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_DebitLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitNo", SqlDbType.Int).Value = debitNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Taxable", SqlDbType.Bit).Value = taxable;
				cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
				cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
				cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
				cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@DebitLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DebitId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DebitNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                debitId = (Int32)(cmd.Parameters["@DebitId"].Value == null ? 0 : cmd.Parameters["@DebitId"].Value);
                debitNumber = (Int32)(cmd.Parameters["@DebitNumber"].Value == null ? 0 : cmd.Parameters["@DebitNumber"].Value);
				return (Int32)cmd.Parameters["@DebitLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_DebitLine_by_Shipping_SRMALine]
		/// </summary>
		public override Int32 InsertByShippingSRMALine(System.Int32? debitNo, System.Int32? supplierRmaLineId, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy,out int debitId, out int debitNumber) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_DebitLine_by_Shipping_SRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitNo", SqlDbType.Int).Value = debitNo;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = allocationNo;
				cmd.Parameters.Add("@QuantityShipped", SqlDbType.Int).Value = quantityShipped;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@DebitLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DebitId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DebitNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                debitId = (Int32)(cmd.Parameters["@DebitId"].Value == null ? 0 : cmd.Parameters["@DebitId"].Value);
                debitNumber = (Int32)(cmd.Parameters["@DebitNumber"].Value == null ? 0 : cmd.Parameters["@DebitNumber"].Value);
				return (Int32)cmd.Parameters["@DebitLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_DebitLine]
        /// </summary>
		public override DebitLineDetails Get(System.Int32? debitLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_DebitLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitLineId", SqlDbType.Int).Value = debitLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDebitLineFromReader(reader);
					DebitLineDetails obj = new DebitLineDetails();
					obj.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0);
					obj.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForDebit 
		/// Calls [usp_selectAll_DebitLine_for_Debit]
        /// </summary>
		public override List<DebitLineDetails> GetListForDebit(System.Int32? debitId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_DebitLine_for_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitLineDetails> lst = new List<DebitLineDetails>();
				while (reader.Read()) {
					DebitLineDetails obj = new DebitLineDetails();
					obj.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0);
					obj.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ParentDebitLineNo = GetReaderValue_Int32(reader, "ParentDebitLineNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DebitLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForDebit 
        /// Calls [usp_selectAll_DebitLine_for_Debit_Print]
        /// </summary>
        public override List<DebitLineDetails> GetListForDebitPrint(System.Int32? debitId, System.Boolean? IsHUBDebit)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_DebitLine_for_Debit_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
                cmd.Parameters.Add("@IsHUBdebitNo", SqlDbType.Bit).Value = IsHUBDebit;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<DebitLineDetails> lst = new List<DebitLineDetails>();
                while (reader.Read())
                {
                    DebitLineDetails obj = new DebitLineDetails();
                    obj.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0);
                    obj.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
                    obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
                    obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get DebitLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// GetListForSupplierRMA 
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMA]
        /// </summary>
		public override List<DebitLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_DebitLine_for_SupplierRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitLineDetails> lst = new List<DebitLineDetails>();
				while (reader.Read()) {
					DebitLineDetails obj = new DebitLineDetails();
					obj.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0);
					obj.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DebitLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplierRMALine 
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMALine]
        /// </summary>
		public override List<DebitLineDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_DebitLine_for_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitLineDetails> lst = new List<DebitLineDetails>();
				while (reader.Read()) {
					DebitLineDetails obj = new DebitLineDetails();
					obj.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0);
					obj.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DebitLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update DebitLine
		/// Calls [usp_update_DebitLine]
        /// </summary>
        public override bool Update(System.Int32? debitLineId, System.Int32? quantity, System.Double? price, System.String part, System.String supplierPart, System.String notes, System.Int32? updatedBy, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_DebitLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitLineId", SqlDbType.Int).Value = debitLineId;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update DebitLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}