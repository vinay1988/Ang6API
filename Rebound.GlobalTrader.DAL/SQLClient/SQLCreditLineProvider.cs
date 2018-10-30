/* Marker     changed by      date         Remarks*/

//[001]      Shashi Keshar   25/10/2016  Search by Client Invoice 
//[002]      Aashu Singh     06-Sep-2018 REB-12877:Service Lines on credit notes show Rohs unknown.
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

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlCreditLineProvider : CreditLineProvider
    {
        /// <summary>
        /// Count CreditLine
        /// Calls [usp_count_CreditLine_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_CreditLine_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count CreditLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_CreditLine]
        /// </summary>
        public override List<CreditLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String creditNotesSearch, System.String customerPoSearch, System.Int32? creditNoLo, System.Int32? creditNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? creditDateFrom, System.DateTime? creditDateTo, System.Boolean? PohubOnly, System.Int32? ClientInvoiceNoLo, System.Int32? ClientInvoiceNoHi, System.Boolean? blnHubCredit)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand((blnHubCredit.Value) ? "usp_datalistnugget_HubCreditLine" : "usp_datalistnugget_CreditLine", cn);
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
                cmd.Parameters.Add("@CreditNotesSearch", SqlDbType.NVarChar).Value = creditNotesSearch;
                cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
                cmd.Parameters.Add("@CreditNoLo", SqlDbType.Int).Value = creditNoLo;
                cmd.Parameters.Add("@CreditNoHi", SqlDbType.Int).Value = creditNoHi;
                cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
                cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@CreditDateFrom", SqlDbType.DateTime).Value = creditDateFrom;
                cmd.Parameters.Add("@CreditDateTo", SqlDbType.DateTime).Value = creditDateTo;
                cmd.Parameters.Add("@PoHubOnly", SqlDbType.Bit).Value = PohubOnly;
                //[001] Start Here
                cmd.Parameters.Add("@ClientInvoiceNoLo", SqlDbType.Int).Value = ClientInvoiceNoLo;
                cmd.Parameters.Add("@ClientInvoiceNoHi", SqlDbType.Int).Value = ClientInvoiceNoHi;
                //[001] End Here
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CreditLineDetails> lst = new List<CreditLineDetails>();
                while (reader.Read())
                {
                    CreditLineDetails obj = new CreditLineDetails();
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientInvoiceNumber = GetReaderValue_NullableInt32(reader, "ClientInvoiceNumber", null);
                    obj.ClientInvoiceNo = GetReaderValue_NullableInt32(reader, "ClientInvoiceId", null);

                    
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CreditLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete CreditLine
        /// Calls [usp_delete_CreditLine]
        /// </summary>
        public override bool Delete(System.Int32? creditLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CreditLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditLineId", SqlDbType.Int).Value = creditLineId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete CreditLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_CreditLine]
        /// </summary>
        public override Int32 Insert(System.Int32? creditNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String customerPart, System.Double? landedCost, System.Int32? invoiceLineNo, System.Int32? customerRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? ClientInvoiceLineId, out int creditId, out int creditNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CreditLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditNo", SqlDbType.Int).Value = creditNo;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Taxable", SqlDbType.Bit).Value = taxable;
                cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
                cmd.Parameters.Add("@InvoiceLineNo", SqlDbType.Int).Value = invoiceLineNo;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
                cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientInvoiceLineId", SqlDbType.Int).Value = ClientInvoiceLineId;

                cmd.Parameters.Add("@CreditLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CreditNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                creditId = (Int32)(cmd.Parameters["@CreditId"].Value == null ? 0 : cmd.Parameters["@CreditId"].Value);
                creditNumber = (Int32)(cmd.Parameters["@CreditNumber"].Value == null ? 0 : cmd.Parameters["@CreditNumber"].Value);
                return (Int32)cmd.Parameters["@CreditLineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert CreditLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Get 
        /// Calls [usp_select_CreditLine]
        /// </summary>
        public override CreditLineDetails Get(System.Int32? creditLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CreditLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditLineId", SqlDbType.Int).Value = creditLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditLineFromReader(reader);
                    CreditLineDetails obj = new CreditLineDetails();
                    obj.CreditLineId = GetReaderValue_Int32(reader, "CreditLineId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.CreditNo = GetReaderValue_Int32(reader, "CreditNo", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.InvoiceLineNo = GetReaderValue_NullableInt32(reader, "InvoiceLineNo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    //[002] start
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    //[002] end
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
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
                throw new Exception("Failed to get CreditLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForCredit 
        /// Calls [usp_selectAll_CreditLine_for_Credit]
        /// </summary>
        public override List<CreditLineDetails> GetListForCredit(System.Int32? creditId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CreditLine_for_Credit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CreditLineDetails> lst = new List<CreditLineDetails>();
                while (reader.Read())
                {
                    CreditLineDetails obj = new CreditLineDetails();
                    obj.CreditLineId = GetReaderValue_Int32(reader, "CreditLineId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.CreditNo = GetReaderValue_Int32(reader, "CreditNo", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.InvoiceLineNo = GetReaderValue_NullableInt32(reader, "InvoiceLineNo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    //[002] start
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    //[002] end
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
                    obj.Ipo = GetReaderValue_Int32(reader, "ipo", 0);
                    obj.ParentCreditLineNo = GetReaderValue_Int32(reader, "ParentCreditLineNo", 0);
                    obj.ClientInvoiceLineId = GetReaderValue_Int32(reader, "ClientInvoiceLineId", 0);
                    obj.ParentCreditLineId = GetReaderValue_Int32(reader, "ParentCreditLineId", 0);
                    obj.DutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");                   
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CreditLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update CreditLine
        /// Calls [usp_update_CreditLine]
        /// </summary>
        public override bool Update(System.Int32? creditLineId, System.Int32? quantity, System.Double? price, System.String part, System.String customerPart, System.Double? landedCost, System.String notes, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CreditLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditLineId", SqlDbType.Int).Value = creditLineId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CreditLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_CreditLineToPOHUB]
        /// </summary>
        public override Int32 CreditNoteToPOHUB(System.String CreditLineID, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CreditLineToPOHUB", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@CreditLineID", SqlDbType.NVarChar).Value = CreditLineID;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert CreditLine", sqlex);
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