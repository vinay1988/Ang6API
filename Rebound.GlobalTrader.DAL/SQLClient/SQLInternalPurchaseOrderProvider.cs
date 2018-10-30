/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for Purchage Order section
[002]      Vinay           01/11/2012   Add comma(,) seprated Debit and SRMA in purchase order section  
[003]      Vinay           17/01/2014   ESMS Ticket No : 95
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
    public class SqlInternalPurchaseOrderProvider : InternalPurchaseOrderProvider
    {



        public override int CountForClient(int? clientId)
        {
            throw new NotImplementedException();
        }

        public override int CountForCompany(int? companyId, bool? includeClosed)
        {
            throw new NotImplementedException();
        }

        public override int CountOpenForCompany(int? companyId)
        {
            throw new NotImplementedException();
        }

        public override int CountReceivingForClient(int? clientId)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int? purchaseOrderId)
        {
            throw new NotImplementedException();
        }

        public override int Insert(int? clientNo, int? companyNo, int? contactNo, DateTime? dateOrdered, int? warehouseNo, int? currencyNo, int? buyer, int? shipViaNo, string account, int? termsNo, string expediteNotes, DateTime? expediteDate, double? totalShipInCost, int? divisionNo, int? taxNo, string notes, string instructions, bool? paid, bool? confirmed, int? importCountryNo, string freeOnBoard, int? statusNo, bool? closed, int? incotermNo, int? updatedBy, string airwayBill)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> ItemSearch(int? clientId, int? orderBy, int? sortDir, int? pageIndex, int? pageSize, string contactSearch, string cmSearch, int? buyerSearch, bool? includeClosed, int? purchaseOrderNoLo, int? purchaseOrderNoHi, DateTime? dateOrderedFrom, DateTime? dateOrderedTo, DateTime? expediteDateFrom, DateTime? expediteDateTo)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> ItemSearchReceived(int? clientId, int? orderBy, int? sortDir, int? pageIndex, int? pageSize, string contactSearch, string cmSearch, int? buyerSearch, bool? includeClosed, int? purchaseOrderNoLo, int? purchaseOrderNoHi, DateTime? dateOrderedFrom, DateTime? dateOrderedTo)
        {
            throw new NotImplementedException();
        }

        public override InternalPurchaseOrderDetails Get(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderFromReader(reader);
                    InternalPurchaseOrderDetails obj = new InternalPurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
                    obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
                    obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
                    obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
                    obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
                    obj.Approver = GetReaderValue_String(reader, "Approver", "");
                    //[002] code start
                    obj.SupplierRMAIds = GetReaderValue_String(reader, "SupplierRMAIds", "");
                    obj.SupplierRMANumbers = GetReaderValue_String(reader, "SupplierRMANumbers", "");
                    obj.DebitIds = GetReaderValue_String(reader, "DebitIds", "");
                    obj.DebitNumbers = GetReaderValue_String(reader, "DebitNumbers", "");
                    //[002] code end
                    //[003] code start
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBillPO", "");
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    //[003] code end
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.EPRIds = GetReaderValue_String(reader, "EPRIds", "");
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");
                    obj.RegionNo = GetReaderValue_NullableInt32(reader, "RegionNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.PoBuyer = GetReaderValue_Int32(reader, "poBuyer", 0);
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);
                    obj.PoTermsName = GetReaderValue_String(reader, "PoTermsName", "");
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
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
                throw new Exception("Failed to get PurchaseOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override InternalPurchaseOrderDetails GetByNumber(int? purchaseOrderNumber, int? clientNo)
        {
            throw new NotImplementedException();
        }

        public override InternalPurchaseOrderDetails GetForPage(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrder_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderFromReader(reader);
                    InternalPurchaseOrderDetails obj = new InternalPurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
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
                throw new Exception("Failed to get InternalPurchaseOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override InternalPurchaseOrderDetails GetForPrint(int? internalPurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrder_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                 
                    InternalPurchaseOrderDetails obj = new InternalPurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
                    obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
                    obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
                    obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
                    obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
                    obj.Approver = GetReaderValue_String(reader, "Approver", "");
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.VATNO = GetReaderValue_String(reader, "VATNo", "");
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
               throw new Exception("Failed to get Internal Purchase Order", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetIDByNumber 
        /// Calls [usp_select_InternalPurchaseOrder_ID_by_Number]
        /// </summary>GetIDByNumber
        public override InternalPurchaseOrderDetails GetIDByNumber(System.Int32? internalPurchaseOrderNumber, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrder_ID_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InternalPurchaseOrderNumber", SqlDbType.Int).Value = internalPurchaseOrderNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderFromReader(reader);
                    InternalPurchaseOrderDetails obj = new InternalPurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
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
                throw new Exception("Failed to get Internal PurchaseOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

      

        public override InternalPurchaseOrderDetails GetNextNumber(int? clientNo, int? updatedBy)
        {
            throw new NotImplementedException();
        }

        public override InternalPurchaseOrderDetails GetStatus(int? purchaseOrderId)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListDueForClient(int? clientId, int? topToSelect)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListForCompany(int? companyId, bool? includeClosed)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListOpenForCompany(int? companyId)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListOpenForLogin(int? loginId, int? topToSelect)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListOverdueForCompany(int? companyId)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListOverdueForLogin(int? loginId, int? topToSelect)
        {
            throw new NotImplementedException();
        }

        public override List<InternalPurchaseOrderDetails> GetListRecentlyReceived(int? clientId, int? topToSelect)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// usp_update_InternalPurchaseOrder
        /// </summary>
        /// <param name="internalPOId"></param>
        /// <param name="currencyNo"></param>
        /// <param name="contactNo"></param>
        /// <param name="buyer"></param>
        /// <param name="divisionNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override bool Update(System.Int32? internalPOId, System.Int32? currencyNo, System.Int32? contactNo, System.Int32? buyer, System.Int32? divisionNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_InternalPurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InternalPurchaseOrderId", SqlDbType.Int).Value = internalPOId;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Internal purchase order", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override bool UpdateApprove(int? purchaseOrderId, int? approvedBy, bool? approve)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateClose(int? purchaseOrderId, int? updatedBy)
        {
            throw new NotImplementedException();
        }

        public override List<PDFDocumentDetails> GetPDFListForPurchageOrder(int? PurchaseOrderId)
        {
            throw new NotImplementedException();
        }

        public override int Insert(int? PurchaseOrderId, string Caption, string FileName, int? UpdatedBy)
        {
            throw new NotImplementedException();
        }

        public override bool DeletePurchaseOrderPDF(int? PurchaseOrderPdfId)
        {
            throw new NotImplementedException();
        }

        public override int InsertExpedite(int? purchaseOrderId, string expediteNotes, int? UpdatedBy)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// usp_dropdownlist_IPO
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>

        public override List<InternalPurchaseOrderDetails> IPODropDownList(System.Int32? docId)
        {
            //[001]Code End
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdownlist_IPO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@DocNo", SqlDbType.Int).Value = docId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<InternalPurchaseOrderDetails> lst = new List<InternalPurchaseOrderDetails>();
                while (reader.Read())
                {
                    InternalPurchaseOrderDetails obj = new InternalPurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
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
    }
}