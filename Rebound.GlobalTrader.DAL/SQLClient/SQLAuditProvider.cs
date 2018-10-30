/*
Marker     Changed by      Date         Remarks
[001]      Aashu           19/06/2018   REB-11552: Change how the how the IPO/PO expedite message work
*/
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
	public class SqlAuditProvider : AuditProvider {
		/// <summary>
		/// Delete Audit
		/// Calls [usp_delete_Audit]
		/// </summary>
		public override bool Delete(System.Int32? auditId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Audit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AuditId", SqlDbType.Int).Value = auditId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Audit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListApprovalForPurchaseOrder 
		/// Calls [usp_selectAll_Audit_approval_for_PurchaseOrder]
        /// </summary>
		public override List<AuditDetails> GetListApprovalForPurchaseOrder(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_approval_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListAuthorisationForSalesOrder 
		/// Calls [usp_selectAll_Audit_authorisation_for_SalesOrder]
        /// </summary>
		public override List<AuditDetails> GetListAuthorisationForSalesOrder(System.Int32? salesOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_authorisation_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListCreditHistoryForCompany 
		/// Calls [usp_selectAll_Audit_creditHistory_for_Company]
        /// </summary>
		public override List<AuditDetails> GetListCreditHistoryForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_creditHistory_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListInsuranceHistoryForCompany 
        /// Calls [usp_selectAll_Insurance_History_for_Company]
        /// </summary>
        public override List<AuditDetails> GetListInsuranceHistoryForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Insurance_History_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<AuditDetails> lst = new List<AuditDetails>();
                while (reader.Read())
                {
                    AuditDetails obj = new AuditDetails();
                    obj.InsHistoryId = GetReaderValue_Int32(reader, "InsHistoryId", 0);
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                    obj.InsuredAmount = GetReaderValue_NullableDouble(reader, "InsuredAmount", null);
                    obj.InsuredAmountNew = GetReaderValue_NullableDouble(reader, "InsuredAmountNew", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.InsuranceFileNo = GetReaderValue_String(reader, "InsuranceFileNo", "");
                    obj.InsuranceFileNoNew = GetReaderValue_String(reader, "InsuranceFileNoNew", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Audits", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
        /// <summary>
        /// GetListForGoodsInLine 
		/// Calls [usp_selectAll_Audit_for_GoodsInLine]
        /// </summary>
		public override List<AuditDetails> GetListForGoodsInLine(System.Int32? goodsInLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_GoodsInLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
				cn.Open();

				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrder 
		/// Calls [usp_selectAll_Audit_for_PurchaseOrder]
        /// </summary>
		public override List<AuditDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrderLine 
		/// Calls [usp_selectAll_Audit_for_PurchaseOrderLine]
        /// </summary>
		public override List<AuditDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForQuote 
		/// Calls [usp_selectAll_Audit_for_Quote]
        /// </summary>
		public override List<AuditDetails> GetListForQuote(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForQuoteLine 
		/// Calls [usp_selectAll_Audit_for_QuoteLine]
        /// </summary>
		public override List<AuditDetails> GetListForQuoteLine(System.Int32? quoteLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSalesOrder 
		/// Calls [usp_selectAll_Audit_for_SalesOrder]
        /// </summary>
		public override List<AuditDetails> GetListForSalesOrder(System.Int32? salesOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSalesOrderLine 
		/// Calls [usp_selectAll_Audit_for_SalesOrderLine]
        /// </summary>
		public override List<AuditDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Audit_for_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AuditDetails> lst = new List<AuditDetails>();
				while (reader.Read()) {
					AuditDetails obj = new AuditDetails();
					obj.AuditId = GetReaderValue_Int32(reader, "AuditId", 0);
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0);
					obj.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.ExternalPart = GetReaderValue_String(reader, "ExternalPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null);
					obj.Note = GetReaderValue_String(reader, "Note", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Audits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_selectAll_Audit_approval_for_Expedite]
        /// </summary>
        public override List<AuditDetails> GetListExpediteForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Audit_approval_for_Expedite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<AuditDetails> lst = new List<AuditDetails>();
                while (reader.Read())
                {
                    AuditDetails obj = new AuditDetails();
                    obj.AuditId = GetReaderValue_Int32(reader, "POExpediteNotesId", 0);
                    obj.Note = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.POLineNos = GetReaderValue_String(reader, "POLineNos", "");
                    //[001] start
                    obj.IsMailSent = GetReaderValue_String(reader, "IsMailSent", "");
                    //[001] end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
               
                throw new Exception("Failed to get Expedite", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



        /// <summary>
        /// Calls [usp_selectAll_Audit_approval_for_Expedite]
        /// </summary>
        public override List<AuditDetails> GetListExpediteForHUBRFQ(System.Int32? HUBRFQId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_HUBRFQ_Expedite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@HUBRFQId", SqlDbType.Int).Value = HUBRFQId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<AuditDetails> lst = new List<AuditDetails>();
                while (reader.Read())
                {
                    AuditDetails obj = new AuditDetails();
                    obj.AuditId = GetReaderValue_Int32(reader, "HUBRFQExpediteNotesId", 0);
                    obj.Note = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.ReqNos = GetReaderValue_String(reader, "ReqNo", "");
                    obj.To = GetReaderValue_String(reader, "AssignTo", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {

                throw new Exception("Failed to get Expedite", sqlex);
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