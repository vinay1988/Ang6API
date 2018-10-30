/*
Marker      ChangedBy          ChangedDate     Remarks
[001]       Aashu Singh        06-Aug-2018     REB-12084:Lock PO lines when EPR is authorised 
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
	public class SqlEPRProvider : EPRProvider {


        /// <summary>
        /// Delete EPR by Id
        /// Calls [usp_delete_EPR]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public override bool Delete(System.Int32? nprId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_EPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EPRId", SqlDbType.Int).Value = nprId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete EPR", sqlex);
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
		/// Calls [usp_insert_EPR]
		/// </summary>
		public override Int32 Insert(EPRDetails objEPR) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_EPR", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = objEPR.PurchaseOrderId;
                cmd.Parameters.Add("@PurchaseOrderNumber", SqlDbType.Int).Value = objEPR.PurchaseOrderNumber;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = objEPR.IsNew;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = objEPR.CompanyName;
                cmd.Parameters.Add("@OrderValue", SqlDbType.Decimal).Value = objEPR.OrderValue;
                cmd.Parameters.Add("@CurrencyCode", SqlDbType.VarChar).Value = objEPR.CurrencyCode;
                cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = objEPR.DeliveryDate;
                cmd.Parameters.Add("@InAdvance", SqlDbType.Bit).Value = objEPR.InAdvance;
                cmd.Parameters.Add("@UponReceipt", SqlDbType.Bit).Value = objEPR.UponReceipt;
                cmd.Parameters.Add("@NetSpecify", SqlDbType.Int).Value = objEPR.NetSpecify;
                cmd.Parameters.Add("@OtherSpecify", SqlDbType.NVarChar).Value = objEPR.OtherSpecify;
                cmd.Parameters.Add("@TT", SqlDbType.Bit).Value = objEPR.TT;
                cmd.Parameters.Add("@Cheque", SqlDbType.Bit).Value = objEPR.Cheque;
                cmd.Parameters.Add("@CreditCard", SqlDbType.Bit).Value = objEPR.CreditCard;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = objEPR.Comments;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = objEPR.Name;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objEPR.Address;
                cmd.Parameters.Add("@Tel", SqlDbType.VarChar).Value = objEPR.Tel;
                cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = objEPR.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objEPR.Email;

                cmd.Parameters.Add("@Name1", SqlDbType.VarChar).Value = objEPR.Name1;
                cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = objEPR.Address1;
                cmd.Parameters.Add("@Tel1", SqlDbType.VarChar).Value = objEPR.Tel1;
                cmd.Parameters.Add("@Fax1", SqlDbType.VarChar).Value = objEPR.Fax1;
                cmd.Parameters.Add("@Email1", SqlDbType.VarChar).Value = objEPR.Email1;

                cmd.Parameters.Add("@Name2", SqlDbType.VarChar).Value = objEPR.Name2;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = objEPR.Address2;
                cmd.Parameters.Add("@Tel2", SqlDbType.VarChar).Value = objEPR.Tel2;
                cmd.Parameters.Add("@Fax2", SqlDbType.VarChar).Value = objEPR.Fax2;
                cmd.Parameters.Add("@Email2", SqlDbType.VarChar).Value = objEPR.Email2;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = objEPR.Comment;

                cmd.Parameters.Add("@ProFormaAttached", SqlDbType.Bit).Value = objEPR.ProFormaAttached;
                cmd.Parameters.Add("@RaisedByNo", SqlDbType.Int).Value = objEPR.RaisedByNo;
                cmd.Parameters.Add("@RaisedByDate", SqlDbType.DateTime).Value = objEPR.RaisedByDate;
                cmd.Parameters.Add("@SORSigned", SqlDbType.Bit).Value = objEPR.SORSigned;
                cmd.Parameters.Add("@ForStock", SqlDbType.Bit).Value = objEPR.ForStock;
                cmd.Parameters.Add("@ValuesCorrect", SqlDbType.Bit).Value = objEPR.ValuesCorrect;
                cmd.Parameters.Add("@Authorized", SqlDbType.VarChar).Value = objEPR.Authorized;
                cmd.Parameters.Add("@AuthorizedDate", SqlDbType.DateTime).Value = objEPR.AuthorizedDate;
                cmd.Parameters.Add("@ERAIMember", SqlDbType.Bit).Value = objEPR.ERAIMember;
                cmd.Parameters.Add("@ERAIReported", SqlDbType.Bit).Value = objEPR.ERAIReported;
                cmd.Parameters.Add("@DebitNotes", SqlDbType.Bit).Value = objEPR.DebitNotes;
                cmd.Parameters.Add("@APOpenOrders", SqlDbType.Bit).Value = objEPR.APOpenOrders;
                cmd.Parameters.Add("@ACTotalValue", SqlDbType.Decimal).Value = objEPR.ACTotalValue;
                cmd.Parameters.Add("@ACTotalValue1", SqlDbType.Decimal).Value = objEPR.ACTotalValue1;
                cmd.Parameters.Add("@SLComment", SqlDbType.NVarChar).Value = objEPR.SLComment;
                cmd.Parameters.Add("@SLTerms", SqlDbType.VarChar).Value = objEPR.SLTerms;
                cmd.Parameters.Add("@SLOverdue", SqlDbType.Bit).Value = objEPR.SLOverdue;
                cmd.Parameters.Add("@SLTotalValue", SqlDbType.Decimal).Value = objEPR.SLTotalValue;

                cmd.Parameters.Add("@PaymentAuthorizedBy", SqlDbType.VarChar).Value = objEPR.PaymentAuthorizedBy;
                cmd.Parameters.Add("@Countersigned", SqlDbType.VarChar).Value = objEPR.Countersigned;
                cmd.Parameters.Add("@PaymentAuthorizedDate", SqlDbType.DateTime).Value = objEPR.PaymentAuthorizedDate;
                cmd.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objEPR.SupplierCode;
                cmd.Parameters.Add("@EPRCompletedByNo", SqlDbType.Int).Value = objEPR.EPRCompletedByNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = objEPR.UpdatedBy;
                cmd.Parameters.Add("@ChangeLog", SqlDbType.VarChar).Value = objEPR.EPRChange;
                //[001] start
                cmd.Parameters.Add("@POLineIds", SqlDbType.Xml).Value = objEPR.POLineIds;
                //[001] end
                cmd.Parameters.Add("@EPRId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@EPRId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert EPR", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
       
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_EPR]
        /// </summary>
        public override EPRDetails Get(System.Int32? eprId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_EPR", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@EprId", SqlDbType.Int).Value = eprId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
                    EPRDetails obj = new EPRDetails();
                    obj.EPRId = GetReaderValue_Int32(reader, "EPRId", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.IsNew = GetReaderValue_Boolean(reader, "IsNew", false);
                    obj.OrderValue = GetReaderValue_Double(reader, "OrderValue", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode","");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.InAdvance =GetReaderValue_Boolean(reader, "InAdvance", false);
                    obj.UponReceipt=GetReaderValue_Boolean(reader, "UponReceipt", false);
                    obj.NetSpecify = GetReaderValue_NullableInt32(reader, "NetSpecify",null);
                    obj.OtherSpecify= GetReaderValue_String(reader, "OtherSpecify","");
                    obj.TT=GetReaderValue_Boolean(reader, "TT", false);
                    obj.Cheque = GetReaderValue_Boolean(reader, "Cheque", false);
                    obj.CreditCard = GetReaderValue_Boolean(reader, "CreditCard", false);
                    obj.Comments = GetReaderValue_String(reader, "Comments","");
                    obj.Name  = GetReaderValue_String(reader, "Name","");
                    obj.Address = GetReaderValue_String(reader, "Address","");
                    obj.Tel = GetReaderValue_String(reader, "Tel","");
                    obj.Fax  = GetReaderValue_String(reader, "Fax","");
                    obj.Email = GetReaderValue_String(reader, "Email","");
                    obj.Name1  = GetReaderValue_String(reader, "Name1","");
                    obj.Address1  = GetReaderValue_String(reader, "Address1","");
                    obj.Tel1  = GetReaderValue_String(reader, "Tel1","");
                    obj.Fax1  = GetReaderValue_String(reader, "Fax1","");
                    obj.Email1  = GetReaderValue_String(reader, "Email1","");
                    obj.Comment  = GetReaderValue_String(reader, "Comment","");
                    obj.Name2  = GetReaderValue_String(reader, "Name2","");
                    obj.Address2 = GetReaderValue_String(reader, "Address2","");
                    obj.Tel2 = GetReaderValue_String(reader, "Tel2","");
                    obj.Fax2 = GetReaderValue_String(reader, "Fax2","");
                    obj.Email2 = GetReaderValue_String(reader, "Email2","");
                    obj.ProFormaAttached = GetReaderValue_Boolean(reader, "ProFormaAttached", false);
                    obj.RaisedBy = GetReaderValue_String(reader, "RaisedBy","");
                    obj.RaisedByDate = GetReaderValue_NullableDateTime(reader, "RaisedByDate", null);
                    obj.SORSigned = GetReaderValue_Boolean(reader, "SORSigned", false);
                    obj.ForStock = GetReaderValue_Boolean(reader, "ForStock", false);
                    obj.ValuesCorrect = GetReaderValue_Boolean(reader, "ValuesCorrect", false);
                    obj.Authorized  = GetReaderValue_String(reader, "Authorized","");
                    obj.AuthorizedDate = GetReaderValue_NullableDateTime(reader, "AuthorizedDate", null);
                    obj.ERAIMember = GetReaderValue_Boolean(reader, "ERAIMember", false);
                    obj.ERAIReported = GetReaderValue_Boolean(reader, "ERAIReported", false);
                    obj.DebitNotes= GetReaderValue_Boolean(reader, "DebitNotes", false);
                    obj.APOpenOrders= GetReaderValue_Boolean(reader, "APOpenOrders", false);
                    obj.ACTotalValue = GetReaderValue_Double(reader, "ACTotalValue", 0);
                    obj.ACTotalValue1 = GetReaderValue_Double(reader, "ACTotalValue1", 0);
                    obj.SLComment = GetReaderValue_String(reader, "SLComment", "");
                    obj.SLTerms = GetReaderValue_String(reader, "SLTerms", "");
                    obj.SLOverdue = GetReaderValue_Boolean(reader, "SLOverdue", false);
                    obj.SLTotalValue = GetReaderValue_Double(reader, "SLTotalValue", 0);
                    obj.PaymentAuthorizedBy = GetReaderValue_String(reader, "PaymentAuthorizedBy", "");
                    obj.Countersigned = GetReaderValue_String(reader, "Countersigned", "");
                    obj.PaymentAuthorizedDate = GetReaderValue_NullableDateTime(reader, "PaymentAuthorizedDate", null);
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.EPRCompletedByNo = GetReaderValue_NullableInt32(reader, "EPRCompletedByNo", null);
                    obj.EPRCompletedByName = GetReaderValue_String(reader, "EPRCompletedBy", "");
                    obj.RaisedByNo = GetReaderValue_NullableInt32(reader, "RaisedByNo", 0);
                    //[001] start
                    obj.POLineSerialNo = GetReaderValue_String(reader, "POLineSerialNo", "");
                    //[001] end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get EPR", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Get 
        /// Calls [usp_select_EPR]
        /// </summary>
        public override List<EPRDetails> ListEPR(System.Int32? poId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_ListEPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PoId", SqlDbType.Int).Value = poId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<EPRDetails> lst = new List<EPRDetails>();
                while (reader.Read())
                {
                    EPRDetails obj = new EPRDetails();
                    obj.EPRId = GetReaderValue_Int32(reader, "EPRId", 0);
                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.IsNew = GetReaderValue_Boolean(reader, "IsNew", false);
                    obj.OrderValue = GetReaderValue_Double(reader, "OrderValue", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
                    obj.UponReceipt = GetReaderValue_Boolean(reader, "UponReceipt", false);
                     obj.NetSpecify = GetReaderValue_NullableInt32(reader, "NetSpecify",null);
                    obj.OtherSpecify = GetReaderValue_String(reader, "OtherSpecify", "");
                    obj.TT = GetReaderValue_Boolean(reader, "TT", false);
                    obj.Cheque = GetReaderValue_Boolean(reader, "Cheque", false);
                    obj.CreditCard = GetReaderValue_Boolean(reader, "CreditCard", false);
                    obj.Comments = GetReaderValue_String(reader, "Comments", "");
                    obj.Name = GetReaderValue_String(reader, "Name", "");
                    obj.Address = GetReaderValue_String(reader, "Address", "");
                    obj.Tel = GetReaderValue_String(reader, "Tel", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.Email = GetReaderValue_String(reader, "Email", "");
                    obj.Name1 = GetReaderValue_String(reader, "Name1", "");
                    obj.Address1 = GetReaderValue_String(reader, "Address1", "");
                    obj.Tel1 = GetReaderValue_String(reader, "Tel1", "");
                    obj.Fax1 = GetReaderValue_String(reader, "Fax1", "");
                    obj.Email1 = GetReaderValue_String(reader, "Email1", "");
                    obj.Comment = GetReaderValue_String(reader, "Comment", "");
                    obj.Name2 = GetReaderValue_String(reader, "Name2", "");
                    obj.Address2 = GetReaderValue_String(reader, "Address2", "");
                    obj.Tel2 = GetReaderValue_String(reader, "Tel2", "");
                    obj.Fax2 = GetReaderValue_String(reader, "Fax2", "");
                    obj.Email2 = GetReaderValue_String(reader, "Email2", "");
                    obj.ProFormaAttached = GetReaderValue_Boolean(reader, "ProFormaAttached", false);
                    obj.RaisedBy = GetReaderValue_String(reader, "RaisedBy", "");
                    obj.RaisedByDate = GetReaderValue_NullableDateTime(reader, "RaisedByDate", null);
                    obj.SORSigned = GetReaderValue_Boolean(reader, "SORSigned", false);
                    obj.ForStock = GetReaderValue_Boolean(reader, "ForStock", false);
                    obj.ValuesCorrect = GetReaderValue_Boolean(reader, "ValuesCorrect", false);
                    obj.Authorized = GetReaderValue_String(reader, "Authorized", "");
                    obj.AuthorizedDate = GetReaderValue_NullableDateTime(reader, "AuthorizedDate", null);
                    obj.ERAIMember = GetReaderValue_Boolean(reader, "ERAIMember", false);
                    obj.ERAIReported = GetReaderValue_Boolean(reader, "ERAIReported", false);
                    obj.DebitNotes = GetReaderValue_Boolean(reader, "DebitNotes", false);
                    obj.APOpenOrders = GetReaderValue_Boolean(reader, "APOpenOrders", false);
                    obj.ACTotalValue = GetReaderValue_Double(reader, "ACTotalValue", 0);
                    obj.ACTotalValue1 = GetReaderValue_Double(reader, "ACTotalValue1", 0);
                    obj.SLComment = GetReaderValue_String(reader, "SLComment", "");
                    obj.SLTerms = GetReaderValue_String(reader, "SLTerms", "");
                    obj.SLOverdue = GetReaderValue_Boolean(reader, "SLOverdue", false);
                    obj.SLTotalValue = GetReaderValue_Double(reader, "SLTotalValue", 0);
                    obj.PaymentAuthorizedBy = GetReaderValue_String(reader, "SLTerms", "");
                    obj.Countersigned = GetReaderValue_String(reader, "Countersigned", "");
                    obj.PaymentAuthorizedDate = GetReaderValue_NullableDateTime(reader, "PaymentAuthorizedDate", null);
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    lst.Add(obj);
					obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get EPR", sqlex);
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
        /// Calls [usp_Update_EPR]
        /// </summary>
        public override bool Update(EPRDetails objEPR)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Update_EPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EprId", SqlDbType.Int).Value = objEPR.EPRId;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = objEPR.PurchaseOrderId;
                cmd.Parameters.Add("@PurchaseOrderNumber", SqlDbType.Int).Value = objEPR.PurchaseOrderNumber;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = objEPR.IsNew;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = objEPR.CompanyName;
                cmd.Parameters.Add("@OrderValue", SqlDbType.Decimal).Value = objEPR.OrderValue;
                cmd.Parameters.Add("@CurrencyCode", SqlDbType.VarChar).Value = objEPR.CurrencyCode;
                cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = objEPR.DeliveryDate;
                cmd.Parameters.Add("@InAdvance", SqlDbType.Bit).Value = objEPR.InAdvance;
                cmd.Parameters.Add("@UponReceipt", SqlDbType.Bit).Value = objEPR.UponReceipt;
                cmd.Parameters.Add("@NetSpecify", SqlDbType.Int).Value = objEPR.NetSpecify;
                cmd.Parameters.Add("@OtherSpecify", SqlDbType.NVarChar).Value = objEPR.OtherSpecify;
                cmd.Parameters.Add("@TT", SqlDbType.Bit).Value = objEPR.TT;
                cmd.Parameters.Add("@Cheque", SqlDbType.Bit).Value = objEPR.Cheque;
                cmd.Parameters.Add("@CreditCard", SqlDbType.Bit).Value = objEPR.CreditCard;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = objEPR.Comments;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = objEPR.Name;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objEPR.Address;
                cmd.Parameters.Add("@Tel", SqlDbType.VarChar).Value = objEPR.Tel;
                cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = objEPR.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objEPR.Email;

                cmd.Parameters.Add("@Name1", SqlDbType.VarChar).Value = objEPR.Name1;
                cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = objEPR.Address1;
                cmd.Parameters.Add("@Tel1", SqlDbType.VarChar).Value = objEPR.Tel1;
                cmd.Parameters.Add("@Fax1", SqlDbType.VarChar).Value = objEPR.Fax1;
                cmd.Parameters.Add("@Email1", SqlDbType.VarChar).Value = objEPR.Email1;

                cmd.Parameters.Add("@Name2", SqlDbType.VarChar).Value = objEPR.Name2;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = objEPR.Address2;
                cmd.Parameters.Add("@Tel2", SqlDbType.VarChar).Value = objEPR.Tel2;
                cmd.Parameters.Add("@Fax2", SqlDbType.VarChar).Value = objEPR.Fax2;
                cmd.Parameters.Add("@Email2", SqlDbType.VarChar).Value = objEPR.Email2;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = objEPR.Comment;

                cmd.Parameters.Add("@ProFormaAttached", SqlDbType.Bit).Value = objEPR.ProFormaAttached;
                cmd.Parameters.Add("@RaisedByNo", SqlDbType.Int).Value = objEPR.RaisedByNo;
                cmd.Parameters.Add("@RaisedByDate", SqlDbType.DateTime).Value = objEPR.RaisedByDate;
                cmd.Parameters.Add("@SORSigned", SqlDbType.Bit).Value = objEPR.SORSigned;
                cmd.Parameters.Add("@ForStock", SqlDbType.Bit).Value = objEPR.ForStock;
                cmd.Parameters.Add("@ValuesCorrect", SqlDbType.Bit).Value = objEPR.ValuesCorrect;
                cmd.Parameters.Add("@Authorized", SqlDbType.VarChar).Value = objEPR.Authorized;
                cmd.Parameters.Add("@AuthorizedDate", SqlDbType.DateTime).Value = objEPR.AuthorizedDate;
                cmd.Parameters.Add("@ERAIMember", SqlDbType.Bit).Value = objEPR.ERAIMember;
                cmd.Parameters.Add("@ERAIReported", SqlDbType.Bit).Value = objEPR.ERAIReported;
                cmd.Parameters.Add("@DebitNotes", SqlDbType.Bit).Value = objEPR.DebitNotes;
                cmd.Parameters.Add("@APOpenOrders", SqlDbType.Bit).Value = objEPR.APOpenOrders;
                cmd.Parameters.Add("@ACTotalValue", SqlDbType.Decimal).Value = objEPR.ACTotalValue;
                cmd.Parameters.Add("@ACTotalValue1", SqlDbType.Decimal).Value = objEPR.ACTotalValue1;
                cmd.Parameters.Add("@SLComment", SqlDbType.NVarChar).Value = objEPR.SLComment;
                cmd.Parameters.Add("@SLTerms", SqlDbType.VarChar).Value = objEPR.SLTerms;
                cmd.Parameters.Add("@SLOverdue", SqlDbType.Bit).Value = objEPR.SLOverdue;
                cmd.Parameters.Add("@SLTotalValue", SqlDbType.Decimal).Value = objEPR.SLTotalValue;

                cmd.Parameters.Add("@PaymentAuthorizedBy", SqlDbType.VarChar).Value = objEPR.PaymentAuthorizedBy;
                cmd.Parameters.Add("@Countersigned", SqlDbType.VarChar).Value = objEPR.Countersigned;
                cmd.Parameters.Add("@PaymentAuthorizedDate", SqlDbType.DateTime).Value = objEPR.PaymentAuthorizedDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = objEPR.UpdatedBy;
                cmd.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objEPR.SupplierCode;
                cmd.Parameters.Add("@EPRCompletedByNo", SqlDbType.Int).Value = objEPR.EPRCompletedByNo;
                cmd.Parameters.Add("@ChangeLog", SqlDbType.VarChar).Value = objEPR.EPRChange;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update EPR", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<EPRDetails> GetEPRLog(System.Int32? eprId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_EPRLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@EPRId", SqlDbType.Int).Value = eprId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<EPRDetails> lst = new List<EPRDetails>();
                while (reader.Read())
                {
                    EPRDetails obj = new EPRDetails();
                    obj.EPRLogId = GetReaderValue_Int32(reader, "EPRLogId", 0);
                    obj.EPRId = GetReaderValue_Int32(reader, "EPRId", 0);
                    //obj.NPRNo = GetReaderValue_String(reader, "NPRNo", "");
                    obj.Details = GetReaderValue_String(reader, "Detail", "");
                    obj.UpdatedByName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.Now);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get EPR Log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

        }

        /// <summary>
        /// Insert EPR Email Log
        /// Call [usp_insert_Email_EPR_Log]
        /// </summary>
        /// <param name="nprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override Int32 InsertEmailEPRLog(System.Int32? eprId, System.String details, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Email_EPR_Log", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EPRNo", SqlDbType.Int).Value = eprId;
                cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = details;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@EPRIdLog", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NPRIdLog"].Value;

            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert EPR Email Log", sqlex);
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