/*

Marker     changed by      date         Remarks

[001]      Abhinav       01/09/20011   ESMS Ref:43 - Print Shipping Notes on to the Allocation section on Goods Receiving Item report 
[002]      Vikas kumar   22/11/2011    ESMS Ref:21 - Add Country search option in Sales Order 
[003]      Vinay           21/08/2012  ESMS Ref:54 - If SO line created from Quote line then create hyperlink from sales order to quote
[004]      Vinay           04/02/2014   CR:- Add AS9120 Requirement in GT application
[005]      Aashu           10/07/2018   [REB-12593]:Show contract number under notes column.
[005]      Vinay           11/04/2018    [REB-11304]: CHG-570795 Hazarders product type
[006]      Aashu Singh     18/07/2018   REB-12614 :Sales order Confirmation requirements
[007]      Aashu Singh     17-Aug-2018  Provision to add Global Security in Sales Order
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
	public class SqlSalesOrderLineProvider : SalesOrderLineProvider {
		/// <summary>
		/// Count SalesOrderLine
		/// Calls [usp_count_SalesOrderLine_as_PurchaseRequisition_for_Client]
		/// </summary>
		public override Int32 CountAsPurchaseRequisitionForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_SalesOrderLine_as_PurchaseRequisition_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_SalesOrderLine]
        /// </summary>
        //[001],[007]Code Start
        public override List<SalesOrderLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.Int32? CountrySearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? unauthorisedOnly, System.Int32? IncludeOrderSent, System.String ContractNo, Boolean IsGlobalLogin, System.Int32? clientSearch)
        {
        //[001]Code End
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SalesOrderLine", cn);
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
                //[001]Code Start
                cmd.Parameters.Add("@CountrySearch", SqlDbType.Int).Value = CountrySearch;
                //[001]Code End
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanNo;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cmd.Parameters.Add("@UnauthorisedOnly", SqlDbType.Bit).Value = unauthorisedOnly;
                cmd.Parameters.Add("@IncludeSentOrder", SqlDbType.Int).Value = IncludeOrderSent;
                cmd.Parameters.Add("@ContractNo", SqlDbType.NVarChar).Value = ContractNo;
                //[007] start
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                //[007] end
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.Status = GetReaderValue_NullableInt32(reader, "Status", null);
                    obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", 0);
                    obj.ContractNo= GetReaderValue_String(reader, "ContractNo", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAllForShipping 
		/// Calls [usp_datalistnugget_SalesOrderLine_AllForShipping]
        /// </summary>
        public override List<SalesOrderLineDetails> DataListNuggetAllForShipping(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SalesOrderLine_AllForShipping", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanNo;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
                    obj.CreditStatus = GetReaderValue_String(reader, "CreditStatus", "");
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAsPurchaseRequisition 
		/// Calls [usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition]
        /// </summary
        public override List<SalesOrderLineDetails> DataListNuggetAsPurchaseRequisition(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition", cn);
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
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
                
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetReadyToShip 
		/// Calls [usp_datalistnugget_SalesOrderLine_ReadyToShip]
        /// </summary>
        public override List<SalesOrderLineDetails> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SalesOrderLine_ReadyToShip", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanNo;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete SalesOrderLine
		/// Calls [usp_delete_SalesOrderLine]
		/// </summary>
		public override bool Delete(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesOrderNo"></param>
        
        /// <returns></returns>
        public override Int32 CreateCloneSOLine(System.Int32? salesOrderNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.DateTime? poDeleveryDate, System.Int32? updatedBy, int? sourcingResultNo, int? SalesOrderLineID, System.Boolean? IsIPO, System.Int32? InternalPurchaseOrderNo, System.String Notes, System.String Instruction, Int32? Flag, System.Byte? productSource, out string Message)
        {
            Message = "";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Clone_SalesOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
              
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
                cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
                cmd.Parameters.Add("@PoDeleveryDate", SqlDbType.DateTime).Value = poDeleveryDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
              
                cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
                cmd.Parameters.Add("@IsIPO", SqlDbType.Bit).Value = IsIPO;
                cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = SalesOrderLineID;
                cmd.Parameters.Add("@InternalPurchaseOrderNo", SqlDbType.Int).Value = InternalPurchaseOrderNo;
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = Instruction;
                cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;
              
                cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
               
                cmd.Parameters.AddWithValue("@Message", 100);
                cmd.Parameters["@Message"].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;


                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                Message = cmd.Parameters["@Message"].Value.ToString();
                return (Int32)cmd.Parameters["@SalesOrderLineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to Create Clone", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
    

		//[004] code start
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SalesOrderLine]
		/// </summary>
        public override Int32 Insert(System.Int32? salesOrderNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? posted, System.Boolean? shipAsap, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? QuoteLineNo, System.Byte? productSource, int? sourcingResultNo, System.DateTime? poDeliveryDate, System.String mslLevel, System.String ContractNo, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNO", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Posted", SqlDbType.Bit).Value = posted;
				cmd.Parameters.Add("@ShipASAP", SqlDbType.Bit).Value = shipAsap;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[003] code start
                cmd.Parameters.Add("@QuoteLineNo", SqlDbType.Int).Value = QuoteLineNo;
                //[003] code end
                //[004] code start
                cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;

                cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
                //[004] code end
                cmd.Parameters.Add("@PODeliveryDate", SqlDbType.DateTime).Value = poDeliveryDate;

              
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cmd.Parameters.Add("@ContractNo", SqlDbType.NVarChar).Value = ContractNo;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SalesOrderLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[004] code end
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SalesOrderLine_from_QuoteLine]
		/// </summary>
		public override Int32 InsertFromQuoteLine(System.Int32? quoteLineId, System.Int32? salesOrderNo, System.DateTime? dateOrdered, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SalesOrderLine_from_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@DateOrdered", SqlDbType.DateTime).Value = dateOrdered;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SalesOrderLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_SalesOrderLine]
        /// </summary>
		public override List<SalesOrderLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo,bool? onlyFromIPO) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
                cmd.Parameters.Add("@OnlyFromIPO", SqlDbType.Bit).Value = onlyFromIPO;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearchAsPurchaseRequisition 
		/// Calls [usp_itemsearch_SalesOrderLine_as_PurchaseRequisition]
        /// </summary>
		public override List<SalesOrderLineDetails> ItemSearchAsPurchaseRequisition(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_SalesOrderLine_as_PurchaseRequisition", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.SerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListForAuthorisationByClientWithFilter 
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListForAuthorisationByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListForAuthorisationByDivisionWithFilter 
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Division_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListForAuthorisationByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_ForAuthorisation_by_Division_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListForAuthorisationByLoginWithFilter 
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Login_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListForAuthorisationByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_ForAuthorisation_by_Login_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListForAuthorisationByTeamWithFilter 
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Team_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListForAuthorisationByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_ForAuthorisation_by_Team_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListShipByClientWithFilter 
		/// Calls [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListShipByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_Ship_by_Client_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludeHistory", SqlDbType.Bit).Value = includeHistory;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListShipByDivisionWithFilter 
		/// Calls [usp_list_SalesOrderLine_Ship_by_Division_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListShipByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_Ship_by_Division_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludeHistory", SqlDbType.Bit).Value = includeHistory;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListShipByLoginWithFilter 
		/// Calls [usp_list_SalesOrderLine_Ship_by_Login_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListShipByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_Ship_by_Login_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludeHistory", SqlDbType.Bit).Value = includeHistory;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListShipByTeamWithFilter 
		/// Calls [usp_list_SalesOrderLine_Ship_by_Team_with_filter]
        /// </summary>
		public override List<SalesOrderLineDetails> ListShipByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_SalesOrderLine_Ship_by_Team_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.NVarChar).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludeHistory", SqlDbType.Bit).Value = includeHistory;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SalesOrderLine]
        /// </summary>
		public override SalesOrderLineDetails Get(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSalesOrderLineFromReader(reader);
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    //[003] code start
                    obj.QuoteLineNo = GetReaderValue_Int32(reader, "QuoteLineNo", 0);
                    //[003] code end
                    //[004] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    obj.SourcingResultNo = GetReaderValue_Int32(reader, "SourcingResultNo", 0);
                    //[004] code end
                    obj.IPOApprovedBy = GetReaderValue_NullableInt32(reader, "IPOApprovedBy", 0);
                   // obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderLineId", 0);
                    obj.IsIPOExist = GetReaderValue_Boolean(reader, "IsIPOCreated", false);
                    obj.IsIPO = GetReaderValue_Boolean(reader, "IsIPO", false);
                    obj.PODeliveryDate = GetReaderValue_NullableDateTime(reader, "PODeliveryDate", null);
                    obj.IsIPOAndPOOpen = GetReaderValue_Boolean(reader, "IsIPOAndPOOpen", false);
                    obj.SourcingResultUsedByOther = GetReaderValue_Boolean(reader, "SourcingResultUsedByOther", false);
                    obj.SerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.DutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    obj.CloneSerialNo = GetReaderValue_Int16(reader, "SOSerialNumber", 0);
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    obj.ContractNo = GetReaderValue_String(reader, "ContractNo", "");
                    //[005] code start
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
                    //[005] code end
                    //[006] start
                    obj.DateConfirmed = GetReaderValue_NullableDateTime(reader, "DateConfirmed", null);
                    //[006] end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetAllocation 
		/// Calls [usp_select_SalesOrderLine_Allocation]
        /// </summary>
		public override SalesOrderLineDetails GetAllocation(System.Int32? salesOrderLineId, System.Int32? allocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SalesOrderLine_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Value = allocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSalesOrderLineFromReader(reader);
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.PurchaseOrderId = GetReaderValue_NullableInt32(reader, "PurchaseOrderId", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
                    obj.ClientSupplierNo = GetReaderValue_NullableInt32(reader, "ClientSupplierNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetAsPurchaseRequisitionForPage 
		/// Calls [usp_select_SalesOrderLine_as_PurchaseRequisition_for_Page]
        /// </summary>
		public override SalesOrderLineDetails GetAsPurchaseRequisitionForPage(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SalesOrderLine_as_PurchaseRequisition_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSalesOrderLineFromReader(reader);
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetShippingStatusInfo 
		/// Calls [usp_select_SalesOrderLine_ShippingStatusInfo]
        /// </summary>
		public override SalesOrderLineDetails GetShippingStatusInfo(System.Int32? salesOrderLineId, System.Int32? allocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SalesOrderLine_ShippingStatusInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@AllocationID", SqlDbType.Int).Value = allocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSalesOrderLineFromReader(reader);
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0);
					obj.TermsInAdvanceOK = GetReaderValue_Int32(reader, "TermsInAdvanceOK", 0);
					obj.CreditLimitOK = GetReaderValue_Int32(reader, "CreditLimitOK", 0);
					obj.StockUnavailable = GetReaderValue_Boolean(reader, "StockUnavailable", false);
					obj.SalesOrderClosed = GetReaderValue_Boolean(reader, "SalesOrderClosed", false);
					obj.GoodsInInspected = GetReaderValue_Int32(reader, "GoodsInInspected", 0);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListClosedForSalesOrder 
		/// Calls [usp_selectAll_SalesOrderLine_closed_for_SalesOrder]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListClosedForSalesOrder(System.Int32? salesOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_closed_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.SerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    obj.IsIPO = GetReaderValue_Boolean(reader, "IsIPO", false);
                    obj.IsChecked = GetReaderValue_Boolean(reader, "IsChecked", false);
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
                    obj.IsIPOHeaderCreated = GetReaderValue_Boolean(reader, "IsIPOHeaderCreated", false);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNUmber", 0);
                    //[006] start
                    obj.IsConfirmed = GetReaderValue_Boolean(reader, "IsConfirmed", false);
                    //[006] end
                    obj.DateConfirmed = GetReaderValue_NullableDateTime(reader, "DateConfirmed", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// GetListForSalesOrder 
        /// Calls [usp_selectAll_SalesOrderLine_for_SalesOrder]
        /// </summary>
        public override List<SalesOrderLineDetails> GetListForConsolidateSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_ConsolidateSalesOrderLine_for_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value = includeInactive;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
                while (reader.Read())
                {
                    SalesOrderLineDetails obj = new SalesOrderLineDetails();
                   
                    obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", (byte)0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    //[004] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    obj.ContractNo = GetReaderValue_String(reader, "ContractNo", "");
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", null);
                   
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

		
        /// <summary>
        /// GetListForSalesOrder 
		/// Calls [usp_selectAll_SalesOrderLine_for_SalesOrder]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListForSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value = includeInactive;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ServiceCost = GetReaderValue_NullableDouble(reader, "ServiceCost", null);
					obj.ServicePrice = GetReaderValue_NullableDouble(reader, "ServicePrice", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    //[004] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    //[004] code end
                    obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
                    obj.SerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    obj.IsIPO = GetReaderValue_Boolean(reader, "IsIPO", false);
                    obj.IsChecked = GetReaderValue_Boolean(reader, "IsChecked", false);
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
                    obj.IsIPOHeaderCreated = GetReaderValue_Boolean(reader, "IsIPOHeaderCreated", false);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNUmber", 0);
                    obj.CloneID = GetReaderValue_NullableInt32(reader, "ClonedID", null);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[005] start
                    obj.ContractNo = GetReaderValue_String(reader, "ContractNo", "");
                    //[005] end
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
                    //[006] start
                    obj.IsConfirmed = GetReaderValue_Boolean(reader, "IsConfirmed", false);
                    //[006] end
                    obj.DateConfirmed = GetReaderValue_NullableDateTime(reader, "DateConfirmed", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForSalesOrder 
        /// Calls [usp_selectAll_SalesOrderLine_for_SerialNumber]
        /// </summary>
        public override List<SalesOrderLineDetails> GetListForSerial(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrderLine_for_SerialNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
                while (reader.Read())
                {
                    SalesOrderLineDetails obj = new SalesOrderLineDetails();
                    obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
                   // obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// GetListForService 
		/// Calls [usp_selectAll_SalesOrderLine_for_Service]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListForService(System.Int32? serviceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_for_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForShipping 
		/// Calls [usp_selectAll_SalesOrderLine_for_Shipping]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListForShipping(System.Int32? salesOrderNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_for_Shipping", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.ReadyToShip = GetReaderValue_NullableBoolean(reader, "ReadyToShip", null);
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.CreditStatus = GetReaderValue_String(reader, "CreditStatus", "");
                    obj.ReqSerialNumber = GetReaderValue_NullableBoolean(reader, "ReqSerialNo", false);
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListFromGoodsInLineForDocket 
		/// Calls [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.EarliestDatePromised = GetReaderValue_DateTime(reader, "EarliestDatePromised", DateTime.MinValue);
					obj.NumberOfLines = GetReaderValue_NullableInt32(reader, "NumberOfLines", null);
                    //[0001] code start
                    obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", ""); 
                    //[0001] code end
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", ""); 
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForSalesOrder 
		/// Calls [usp_selectAll_SalesOrderLine_open_for_SalesOrder]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListOpenForSalesOrder(System.Int32? salesOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_open_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.SerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    /*IPO related data start*/
                    obj.IsIPO = GetReaderValue_Boolean(reader, "IsIPO", false);
                    obj.IsChecked = GetReaderValue_Boolean(reader, "IsChecked", false);
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
                    obj.IsIPOHeaderCreated = GetReaderValue_Boolean(reader, "IsIPOHeaderCreated", false);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNUmber", 0);
                    obj.CloneID = GetReaderValue_NullableInt32(reader, "ClonedID", null);
                    /*IPO related data end*/
                    //[006] start
                    obj.IsConfirmed = GetReaderValue_Boolean(reader, "IsConfirmed", false);
                    //[006] end
                    obj.DateConfirmed = GetReaderValue_NullableDateTime(reader, "DateConfirmed", null);
                    lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListReportManualStock 
		/// Calls [usp_selectAll_SalesOrderLine_ReportManualStock]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListReportManualStock(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_ReportManualStock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
					obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                   
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListReportPO 
		/// Calls [usp_selectAll_SalesOrderLine_ReportPO]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListReportPO(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_ReportPO", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.Duty = GetReaderValue_NullableBoolean(reader, "Duty", null);
					obj.DutyRate = GetReaderValue_NullableDouble(reader, "DutyRate", null);
					obj.QuantitySupplied = GetReaderValue_NullableInt32(reader, "QuantitySupplied", null);
					obj.ShipInCost = GetReaderValue_Double(reader, "ShipInCost", 0);
					obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    obj.SerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int16(reader, "InternalPurchaseOrderNo", 0);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.IPOSupplierType = GetReaderValue_String(reader, "IPOSupplierType", "");
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.PODateOrdered = GetReaderValue_DateTime(reader, "PODateOrdered", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListReportPOStock 
		/// Calls [usp_selectAll_SalesOrderLine_ReportPOStock]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListReportPOStock(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_ReportPOStock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.Duty = GetReaderValue_NullableBoolean(reader, "Duty", null);
					obj.DutyRate = GetReaderValue_NullableDouble(reader, "DutyRate", null);
					obj.ShipInCost = GetReaderValue_Double(reader, "ShipInCost", 0);
					obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
					obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.SerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int16(reader, "InternalPurchaseOrderNo", 0);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.IPOSupplierType = GetReaderValue_String(reader, "IPOSupplierType", "");
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.PODateOrdered = GetReaderValue_DateTime(reader, "PODateOrdered", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListReportShipped 
		/// Calls [usp_selectAll_SalesOrderLine_ReportShipped]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListReportShipped(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_ReportShipped", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.Duty = GetReaderValue_NullableBoolean(reader, "Duty", null);
					obj.DutyRate = GetReaderValue_NullableDouble(reader, "DutyRate", null);
					obj.ShipInCost = GetReaderValue_Double(reader, "ShipInCost", 0);
					obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.SerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int16(reader, "InternalPurchaseOrderNo", 0);
                    obj.IPOSupplierType = GetReaderValue_String(reader, "IPOSupplierType", "");
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.PODateOrdered = GetReaderValue_DateTime(reader, "PODateOrdered", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListServiceForInvoice 
		/// Calls [usp_selectAll_SalesOrderLine_service_for_Invoice]
        /// </summary>
		public override List<SalesOrderLineDetails> GetListServiceForInvoice(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SalesOrderLine_service_for_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue);
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0);
					obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
					obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
					obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
					obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null);
					obj.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null);
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", "");
					obj.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", "");
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
					obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
					obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
					obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
					obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
					obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
					obj.DivisionNo2 = GetReaderValue_NullableInt32(reader, "DivisionNo2", null);
					obj.DateExported = GetReaderValue_NullableDateTime(reader, "DateExported", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_SalesOrderLine]
        /// </summary>
        public override List<SalesOrderLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
			try {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_SalesOrderLine_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_SalesOrderLine", cn);
                }
                				
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
				List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
				while (reader.Read()) {
					SalesOrderLineDetails obj = new SalesOrderLineDetails();
					obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
					obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.blnCRMA = GetReaderValue_NullableBoolean(reader, "IsCRMA", false);
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.IPOs = GetReaderValue_String(reader, "IPOs", "");
                    obj.IPOPrice = GetReaderValue_Double(reader, "IPOPrice", 0);
                    obj.IPOPriceWithCurrency = GetReaderValue_String(reader, "IPOCurrency", "");
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
				throw new Exception("Failed to get SalesOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SalesOrderLine
		/// Calls [usp_update_SalesOrderLine]
        /// </summary>
        public override bool Update(System.Int32? salesOrderLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? shipAsap, System.Boolean? inactive, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource, System.DateTime? poDeliveryDate, System.Int16? serialNo, System.String mslLevel, System.String ContractNo, System.Boolean? printHazardous, bool? isFormChanged)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@ShipASAP", SqlDbType.Bit).Value = shipAsap;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[004] code start
                cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;
                //[004] code end
                cmd.Parameters.Add("@PODelDate", SqlDbType.DateTime).Value = poDeliveryDate;
                cmd.Parameters.Add("@SOSerialNo", SqlDbType.Int).Value = serialNo;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cmd.Parameters.Add("@ContractNo", SqlDbType.NVarChar).Value = ContractNo;

                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
                //[006] start
                cmd.Parameters.Add("@IsFormChanged", SqlDbType.Bit).Value = isFormChanged;
                //[006] end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SalesOrderLine
		/// Calls [usp_update_SalesOrderLine_Close]
        /// </summary>
		public override bool UpdateClose(System.Int32? salesOrderLineId, System.Boolean? resetQuantity, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SalesOrderLine_Close", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@ResetQuantity", SqlDbType.Bit).Value = resetQuantity;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SalesOrderLine
		/// Calls [usp_update_SalesOrderLine_Post_or_Unpost]
        /// </summary>
		public override bool UpdatePostOrUnpost(System.Int32? salesOrderLineId, System.Boolean? posted, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SalesOrderLine_Post_or_Unpost", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@Posted", SqlDbType.Bit).Value = posted;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SalesOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        //[006]  start
        public override int SaveConfirmation(int salesOrderLineId, int salesOrderId, int buttonClicked)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrderLineConfirmation", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
                cmd.Parameters.Add("@salesOrderNo", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@buttonClicked", SqlDbType.Int).Value = buttonClicked;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                return ExecuteNonQuery(cmd);
                
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[006]  end
		
		
	}
}
