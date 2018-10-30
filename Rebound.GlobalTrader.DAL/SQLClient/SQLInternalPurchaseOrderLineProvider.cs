/* Marker     changed by      date         Remarks  
   [001]      Vikas kumar     22/11/2011  ESMS Ref:21 - Add Country search option in Purchase Order 
   [002]      Vinay           18/09/2012    Ref:## - Display Purchase Country
   [003]      Raushan         27/02/2014    Ref:## - Supplier RMA-ISCRMA
   [004]      Aashu Singh     25/06/2018    Show supplier warranty for ipo line detail
   [005]      Aashu Singh     29/06/2018    Save msl detail.
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
    public class SqlInternalPurchaseOrderLineProvider : InternalPurchaseOrderLineProvider
    {
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_PurchaseOrderLine]
        /// </summary>
        //[001]Code Start
        public override List<InternalPurchaseOrderLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? CountrySearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Boolean? recentOnly, System.Int32? ClientSearch)
        {
        //[001]Code End
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_InternalPurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
                //[001]Code Start
                cmd.Parameters.Add("@CountrySearch", SqlDbType.Int).Value = CountrySearch;
                //[001]Code End
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@ExpediteDateFrom", SqlDbType.DateTime).Value = expediteDateFrom;
				cmd.Parameters.Add("@ExpediteDateTo", SqlDbType.DateTime).Value = expediteDateTo;
				cmd.Parameters.Add("@DeliveryDateFrom", SqlDbType.DateTime).Value = deliveryDateFrom;
				cmd.Parameters.Add("@DeliveryDateTo", SqlDbType.DateTime).Value = deliveryDateTo;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = ClientSearch;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
               
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderLineDetails> lst = new List<InternalPurchaseOrderLineDetails>();
				while (reader.Read()) {
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "InternalPurchaseOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.Status = GetReaderValue_NullableInt32(reader, "Status", null);
					obj.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.IPOStatus = GetReaderValue_NullableInt32(reader, "IPOStatus", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// usp_update_InternalPurchaseOrderLine
        /// </summary>
        /// <param name="purchaseOrderLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns> 
        public override bool Update(int? internalPurchaseOrderLineId, double? price, string notes, string receivingNotes, double? ShipInCost, System.Int32? ProductNo, int? updatedBy, System.String mslLevel)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {               
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_InternalPurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InternalPurchaseOrderLineId", SqlDbType.Int).Value = internalPurchaseOrderLineId;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;

                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ShipInCost", SqlDbType.Float).Value = ShipInCost;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = ProductNo;
                //[005] start
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                //[005] end
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to update InternalPurchaseOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<InternalPurchaseOrderLineDetails> DataListNuggetAllForReceiving(int? clientId, int? orderBy, int? sortDir, int? pageIndex, int? pageSize, string partSearch, string contactSearch, string cmSearch, int? buyerSearch, bool? recentOnly, bool? includeClosed, int? purchaseOrderNoLo, int? purchaseOrderNoHi, DateTime? dateOrderedFrom, DateTime? dateOrderedTo, DateTime? expediteDateFrom, DateTime? expediteDateTo, DateTime? deliveryDateFrom, DateTime? deliveryDateTo)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderLineDetails> DataListNuggetReadyToReceive(int? clientId, int? orderBy, int? sortDir, int? pageIndex, int? pageSize, string partSearch, string contactSearch, string cmSearch, int? buyerSearch, int? purchaseOrderNoLo, int? purchaseOrderNoHi, DateTime? dateOrderedFrom, DateTime? dateOrderedTo, DateTime? expediteDateFrom, DateTime? expediteDateTo, DateTime? deliveryDateFrom, DateTime? deliveryDateTo)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int? purchaseOrderLineId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override int Insert(int? fromPurchaseOrderLineNo,System.Int32? purchaseOrderLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_InternalPurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromPurchaseOrderLineNo", SqlDbType.Int).Value = fromPurchaseOrderLineNo;
                cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert InternalPurchaseOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override int InsertFromSalesOrderLine(int? salesOrderLineId, int? purchaseOrderNo, int? updatedBy)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderLineDetails> ItemSearch(int? clientId, int? orderBy, int? sortDir, int? pageIndex, int? pageSize, string partSearch, string cmSearch, bool? includeClosed, int? purchaseOrderNoLo, int? purchaseOrderNoHi, DateTime? dateOrderedFrom, DateTime? dateOrderedTo, DateTime? deliveryDateFrom, DateTime? deliveryDateTo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// [usp_select_InternalPurchaseOrderLine]
        /// </summary>
        /// <param name="internalPurchaseOrderLineId"></param>
        /// <returns></returns>
        public override InternalPurchaseOrderLineDetails Get(int? internalPurchaseOrderLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderLineId", SqlDbType.Int).Value = internalPurchaseOrderLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", 0);
                    obj.InternalPurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderLineNo", 0);                    
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[002] code start
                    obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
                    //[002 code end
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end

                    //[004] start
                    obj.SupplierWarranty = GetReaderValue_Int32(reader, "SupplierWarranty", 0);
                    //[004] end
                    obj.MSLLevel = GetReaderValue_String(reader, "POMSLLevel", "");

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
                throw new Exception("Failed to get PurchaseOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override InternalPurchaseOrderLineDetails GetForSupplierRMALine(int? purchaseOrderLineId)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderLineDetails> GetListCandidatesForSupplierRMA(int? supplierRmaId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// usp_selectAll_InternalPurchaseOrderLine_closed_for_InternalPurchaseOrder
        /// </summary>
        /// <param name="internalPurchaseOrderId"></param>
        /// <returns></returns>
        public override List<InternalPurchaseOrderLineDetails> GetListClosedForPurchaseOrder(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_InternalPurchaseOrderLine_closed_for_InternalPurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderLineDetails> lst = new List<InternalPurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", 0);
                    obj.InternalPurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderLineNo", 0);
                    obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "InternalPurchaseOrderLineId", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    //[005] start
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[005] end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PurchaseOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_selectAll_InternalPurchaseOrderLine_for_InternalPurchaseOrder
        /// </summary>
        /// <param name="internalPurchaseOrderId"></param>
        /// <returns></returns>
        public override List<InternalPurchaseOrderLineDetails> GetListForPurchaseOrder(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_InternalPurchaseOrderLine_for_InternalPurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderLineDetails> lst = new List<InternalPurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", 0);
                    obj.InternalPurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderLineNo", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    //[005] start
                    obj.MSLLevel = GetReaderValue_String(reader, "POMSLLevel", "");
                    //[005] end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PurchaseOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<InternalPurchaseOrderLineDetails> GetListForSupplierRMA(int? supplierRmaId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// usp_selectAll_InternalPurchaseOrderLine_open_for_InternalPurchaseOrder
        /// </summary>
        /// <param name="internalPurchaseOrderId"></param>
        /// <returns></returns>
        public override List<InternalPurchaseOrderLineDetails> GetListOpenForPurchaseOrder(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_InternalPurchaseOrderLine_open_for_InternalPurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderLineDetails> lst = new List<InternalPurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", 0);
                    obj.InternalPurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderLineNo", 0);
                    obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "InternalPurchaseOrderLineId", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    //[005] start
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[005] end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get InternalPurchaseOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<InternalPurchaseOrderLineDetails> GetListReceivingForPurchaseOrder(int? purchaseOrderId)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderLineDetails> GetListTodayForClient(int? clientId, int? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_InternalPurchaseOrderLine_today_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
               
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderLineDetails> lst = new List<InternalPurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    InternalPurchaseOrderLineDetails obj = new InternalPurchaseOrderLineDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.CreateDate = GetReaderValue_DateTime(reader, "CreateDate", DateTime.MinValue);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Internal PurchaseOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<InternalPurchaseOrderLineDetails> Source(int? clientId, string partSearch, int? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateClose(int? purchaseOrderLineId, int? updatedBy)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateClosedStatus(int? purchaseOrderLineNo)
        {
            throw new NotImplementedException();
        }

        public override bool UpdatePostOrUnpost(int? purchaseOrderLineId, bool? posted, int? updatedBy)
        {
            throw new NotImplementedException();
        }
    }
}