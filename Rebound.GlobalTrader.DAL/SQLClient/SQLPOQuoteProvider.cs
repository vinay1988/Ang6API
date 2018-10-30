//Marker     changed by      date          Remarks
//[001]      Vinay           01/02/2016    CR-Generate BOM
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
    public class SqlPOQuoteProvider : POQuoteProvider
    {
       
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_PurchaseRequest]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String notes, System.Int32? companyNo, System.Int32? contactNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Boolean? closed,System.Int32? salesperson, System.Int32? division)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_PurchaseRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
               // cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = salesperson;
                cmd.Parameters.Add("@Division", SqlDbType.Int).Value = division;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@PurchaseRequestId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Price Request", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        ///// <summary>
        ///// Get 
        ///// Calls [usp_select_PurchaseRequest]
        ///// </summary>
        public override POQuoteDetails Get(System.Int32? poQuoteId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PurchaseRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Value = poQuoteId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetQuoteFromReader(reader);
                    POQuoteDetails obj = new POQuoteDetails();
                    obj.POQuoteId = GetReaderValue_Int32(reader, "PurchaseRequestId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.POQuoteNumber = GetReaderValue_Int32(reader, "PurchaseRequestNumber", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                   // obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    //obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    //obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesPersonNo = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.SalesPersonName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.PQStatus = GetReaderValue_Int32(reader, "PQStatus", 0);
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
                throw new Exception("Failed to get Price Request", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


     


        /// <summary>
        /// GetForPage 
        /// Calls [usp_select_PurchaseRequest_for_Page]
        /// </summary>
        public override POQuoteDetails GetForPage(System.Int32? poQuoteId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PurchaseRequest_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Value = poQuoteId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {                   
                    POQuoteDetails obj = new POQuoteDetails();
                    obj.POQuoteId = GetReaderValue_Int32(reader, "PurchaseRequestId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.POQuoteNumber = GetReaderValue_Int32(reader, "PurchaseRequestNumber", 0);
                    obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
                    obj.PRStatus = GetReaderValue_String(reader, "PRStatus", "");
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to get Price Request", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// GetCSVListForPurchaseQuote 
        /// Calls [usp_selectAll_CSV_for_PurchaseQuote]
        /// </summary>
        public override List<PDFDocumentDetails> GetCSVListForPurchaseQuote(System.Int32? purchaseQuoteNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CSV_for_PurchaseQuote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseQuoteNo", SqlDbType.Int).Value = purchaseQuoteNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "PurchaseQuoteCSVId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "PurchaseQuoteNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CSV list for Purchase Quote", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

     
        /// <summary>
        /// Update Quote
        /// Calls [usp_update_PurchaseRequest]
        /// </summary>
        public override bool Update(System.Int32? poQuoteId, System.String notes, System.Boolean? closed, System.Int32? contactNo, System.Int32? updatedBy, System.Int32? salesPerson, System.Int32? division)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_PurchaseRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Value = poQuoteId;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
               // cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = salesPerson;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = division;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Price Request", sqlex);
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
        /// Calls [usp_CSVImport]
        /// </summary>
        public override Int32 InsertCSV(System.Int32? ID, System.Int32? LoginID, System.Int32? clientNo, System.Int32? companyNo, System.String FileName, System.String Type)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_CSVImport", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = LoginID;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = Type;
              
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to Import CSV File", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Delete
        /// Calls [usp_PurchaseQuoteCsvDelete]
        /// </summary>
        public override bool DeletePurchaseQuoteCsv(System.Int32? PurchaseQuoteCSVId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_PurchaseQuoteCsvDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseQuoteCSVId", SqlDbType.Int).Value = PurchaseQuoteCSVId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete purchase quote CSV", sqlex);
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
