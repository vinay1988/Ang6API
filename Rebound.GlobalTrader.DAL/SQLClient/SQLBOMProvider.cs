//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
//[002]    Shashi Keshar     22/02/2016     BOM for Dash Board
//[003]      Umendra Gupta  30/08/2018      Add ClientCode,ReceivedBy and SalesPerson field
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
	public class SqlBOMProvider : BOMProvider {
		/// <summary>
		/// Count BOM
        /// Calls [usp_count_BOM]
		/// </summary>
        public override Int32 CountForBOM(System.Int32? clientId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_BOM", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count BOM", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		/// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_BOM]
        /// </summary>
        public override List<BOMDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String bomCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? IsAssignToMe, int? assignedUser, System.Int32? intDivision, System.Int32? salesPerson)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                if (isPOHub == true )
                {
                    if (IsAssignToMe == 0)
                    {
                        cmd = new SqlCommand("usp_datalistnugget_PHBOM", cn);
                    }
                    if (IsAssignToMe == 1)
                    {
                        pageSize = 1000;//Set the max page size dynamically.
                        cmd = new SqlCommand("usp_datalistnugget_PHBOMAssign", cn);
                    }
                }
                
                else
                {
                    cmd = new SqlCommand("usp_datalistnugget_BOM", cn);
                }
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
                cmd.Parameters.Add("@BOMCode", SqlDbType.NVarChar).Value = bomCode;
                //cmd.Parameters.Add("@CodeHi", SqlDbType.NVarChar).Value = CodeHi;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = isPOHub;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = selectedClientNo;
                cmd.Parameters.Add("@BomStatus", SqlDbType.Int).Value = bomStatus;
                cmd.Parameters.Add("@SalesPerson", SqlDbType.NVarChar).Value = salesPerson;//[003]

                if (assignedUser > 0)
                {
                    cmd.Parameters.Add("@AssignedUser", SqlDbType.Int).Value = assignedUser;
                }
                cmd.Parameters.Add("@ClientDivisionNo", SqlDbType.Int).Value = intDivision;    
                cn.Open();


                DbDataReader reader = ExecuteReader(cmd);
                List<BOMDetails> lst = new List<BOMDetails>();
                while (reader.Read())
                {
                    BOMDetails obj = new BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.BOMStatus = GetReaderValue_String(reader, "Status", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyId", 0);
                    obj.TotalBomLinePrice = GetReaderValue_Double(reader, "TotalBomLinePrice", 0.00);
                    obj.POCurrencyNo = GetReaderValue_Int32(reader, "POCurrencyNo", 0);
                    obj.DateRequestToPOHub = GetReaderValue_NullableDateTime(reader, "DateRequestToPOHub", null);
                    obj.AssignedUser = GetReaderValue_String(reader, "AssignedUser", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.Requestedby = GetReaderValue_String(reader, "Requestedby", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		/// <summary>
		/// Delete BOM
		/// Calls [usp_delete_BOM]
		/// </summary>
		public override bool Delete(System.Int32? bomId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_BOM", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete BOM", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
				
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_BOM_for_Client]
        /// </summary>
        public override List<BOMDetails> DropDownForClient(System.Int32? clientId, System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_BOM_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<BOMDetails> lst = new List<BOMDetails>();
                while (reader.Read())
                {
                    BOMDetails obj = new BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get BOMs", sqlex);
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
        /// Calls [usp_insert_BOM]
		/// </summary>
        //public override Int32 Insert(System.Int32? clientId, System.String bomName, System.String notes, System.String bomCode, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Boolean? inactive, System.Int32? UpdateRequirement, System.Int32? Status, System.Int32? CurrencyNo, System.String currentSupplier, System.DateTime? quoteRequired, System.Boolean? AS9120, System.Int32 AssignUserNo,out System.String ValidationMessage)
        public override Int32 Insert(System.Int32? clientId, System.String bomName, System.String notes, System.String bomCode, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Boolean? inactive, System.Int32? UpdateRequirement, System.Int32? Status, System.Int32? CurrencyNo, System.String currentSupplier, System.DateTime? quoteRequired, System.Boolean? AS9120, System.Int32? Contact2, System.Int32 AssignUserNo, out System.String ValidationMessage)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_BOM", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;				
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@BOMCode", SqlDbType.NVarChar).Value = bomCode;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactId;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdateRequirementId", SqlDbType.Int).Value = UpdateRequirement;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = CurrencyNo;
                cmd.Parameters.Add("@CurrentSupplier", SqlDbType.VarChar).Value = currentSupplier;
                cmd.Parameters.Add("@QuoteRequired", SqlDbType.DateTime).Value = quoteRequired;
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = AS9120;
                cmd.Parameters.Add("@Contact2", SqlDbType.Int).Value = Contact2;
                cmd.Parameters.Add("@AssignUserNo", SqlDbType.Int).Value = AssignUserNo;
				cmd.Parameters.Add("@BOMId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ValidationMessage", SqlDbType.VarChar,200).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                ValidationMessage = null;
                if (ret == -1)
                {
                    ValidationMessage = (String)(cmd.Parameters["@ValidationMessage"].Value == null ? string.Empty : cmd.Parameters["@ValidationMessage"].Value); ;
                    return ret;
                }             
				return (Int32)cmd.Parameters["@BOMId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert BOM", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_BOM]
        /// </summary>
		public override BOMDetails Get(System.Int32? BOMId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_BOM", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = BOMId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetBOMFromReader(reader);
                    Rebound.GlobalTrader.DAL.BOMDetails obj = new Rebound.GlobalTrader.DAL.BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");					
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "companyId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactNo = GetReaderValue_Int32(reader, "contactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "contactName", "");
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", null);
                    obj.DateRequestToPOHub = GetReaderValue_NullableDateTime(reader, "DateRequestToPOHub", null);
                    obj.ReleaseBy = GetReaderValue_NullableInt32(reader, "ReleaseBy", null);
                    obj.DateRelease = GetReaderValue_NullableDateTime(reader, "DateRelease", null);
                    obj.BomCount = GetReaderValue_Int32(reader, "BomCount", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);                 
                    obj.BOMStatus = GetReaderValue_String(reader, "Status", "");
                    obj.StatusValue = GetReaderValue_NullableInt32(reader, "StatusValue", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyId", null);
                    obj.Currency_Code = GetReaderValue_String(reader, "Currency_Code", "");
                    obj.CurrentSupplier = GetReaderValue_String(reader, "CurrentSupplier", "");
                    obj.QuoteRequired = GetReaderValue_DateTime(reader, "QuoteRequired", DateTime.MinValue);
                    obj.AllItemHasSourcing = GetReaderValue_NullableInt32(reader, "AllHasSourcing", 0);
                    obj.AS9120 = GetReaderValue_Boolean(reader, "AS9120", false);
                    obj.Requestedby = GetReaderValue_String(reader, "Requestedby", "");
                    obj.Releasedby = GetReaderValue_String(reader, "Releasedby", "");
                    obj.NoBidCount = GetReaderValue_Int32(reader, "NoBidCount", 0);
                    obj.UpdateByPH = GetReaderValue_Int32(reader, "UpdateByPH", 0);
                    obj.AssignedUser = GetReaderValue_String(reader, "AssignTo", "");

                    obj.Contact2Id = GetReaderValue_Int32(reader, "Contact2Id", 0);
                    obj.Contact2Name = GetReaderValue_String(reader, "Contact2Name", "");
                    obj.ValidationMessage = GetReaderValue_String(reader, "ValidateMessage", "");
                    obj.IsReqInValid = GetReaderValue_Int32(reader, "IsReqInValid", 0) > 0 ? true : false;

					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get BOM", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_BOM_for_Page]
        /// </summary>
		public override BOMDetails GetForPage(System.Int32? bomId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_BOM_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetBOMFromReader(reader);
                    BOMDetails obj = new BOMDetails();
					obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.BOMStatus = GetReaderValue_String(reader, "Status", "");
                    obj.RequestToPOHubBy = GetReaderValue_Int32(reader, "RequestToPOHubBy", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get BOM", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}		
		
        /// <summary>
        /// Update BOM
		/// Calls [usp_update_BOM]
        /// </summary>
        public override bool Update(System.Int32? bomId, System.Int32? clientNo, System.String bomName, System.String notes, System.String bomCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Int32? currencyNo, System.String currentSupplier, System.DateTime? quoteRequired, System.Boolean? AS9120, System.Int32? contact2Id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;                
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@BOMCode", SqlDbType.NVarChar).Value = bomCode;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactId;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@CurrentSupplier", SqlDbType.VarChar).Value = currentSupplier;
                cmd.Parameters.Add("@QuoteRequired", SqlDbType.DateTime).Value = quoteRequired;
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = AS9120;
                cmd.Parameters.Add("@Contact2Id", SqlDbType.Int).Value = contact2Id;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }		
		
        /// <summary>
        /// Update BOM
		/// Calls [usp_update_BOM_Delete]
        /// </summary>
        public override bool UpdateDelete(System.Int32? bomId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOM_Delete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code start
        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_BOM]
        /// </summary>
        public override List<Rebound.GlobalTrader.DAL.BOMDetails> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<Rebound.GlobalTrader.DAL.BOMDetails> lst = new List<Rebound.GlobalTrader.DAL.BOMDetails>();
                while (reader.Read())
                {
                    Rebound.GlobalTrader.DAL.BOMDetails obj = new Rebound.GlobalTrader.DAL.BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end		

        /// <summary>
        /// Update BOM
        /// Calls [usp_update_BOM_POHubQuote]
        /// </summary>
        public override bool UpdatePurchaseQuote(System.Int32? bomId, System.Int32? updatedBy, System.Int32? bomStatus, System.Int32 AssignUserNo,out System.String ValidateMessage)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOM_POHubQuote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@BOMStatus", SqlDbType.Int).Value = bomStatus;
                cmd.Parameters.Add("@AssignUserNo", SqlDbType.Int).Value = AssignUserNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ValidateMessage", SqlDbType.VarChar,250).Direction = ParameterDirection.Output;
                cn.Open();
                //int ret = ExecuteNonQuery(cmd);
               // ExecuteNonQuery(cmd);
                ExecuteScalar(cmd);
                int ret = (int)(cmd.Parameters["@RowsAffected"].Value == null ? 0 : cmd.Parameters["@RowsAffected"].Value);
                ValidateMessage = (String)(cmd.Parameters["@ValidateMessage"].Value == null ? null : cmd.Parameters["@ValidateMessage"].Value);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[002] code start here
        /// <summary>
        /// GetListReadyForClient 
        /// Calls [usp_selectAll_BOM]
        /// </summary>
        public override List<BOMDetails> GetBomList(System.Int32? clientId, System.Boolean? isPoHUB, System.Int32? topToSelect, System.Int32? bomStatus, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 50;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cmd.Parameters.Add("@IsPoHUB", SqlDbType.Bit).Value = isPoHUB;
                cmd.Parameters.Add("@BomStatus", SqlDbType.Int).Value = bomStatus;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<BOMDetails> lst = new List<BOMDetails>();
                while (reader.Read())
                {
                    BOMDetails obj = new BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.StatusValue = GetReaderValue_Int32(reader, "StatusValue", 0);
                    obj.RequestToPOHubBy = GetReaderValue_Int32(reader, "RequestToPOHubBy", 0);
                    obj.UpdatedBy = GetReaderValue_Int32(reader, "UpdatedBy", 0);
                    obj.QuoteRequired = GetReaderValue_NullableDateTime(reader, "QuoteRequired", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //[002] code end

        /// <summary>
        /// GetCSVListForBOM
        /// Calls [usp_selectAll_CSV_for_BOM]
        /// </summary>
        public override List<PDFDocumentDetails> GetCSVListForBOM(System.Int32? bomNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CSV_for_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = bomNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "BOMCSVId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "BOMNo", 0);
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
                throw new Exception("Failed to get CSV list for BOM", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update BOM By PH
        /// Calls [usp_update_BOMByPH]
        /// </summary>
        public override bool UpdateBOMByPH(System.String bOMIdList, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOMByPH", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMIdList", SqlDbType.VarChar).Value = bOMIdList;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update BOM", sqlex);
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
        /// Calls [usp_IpoBomCsvDelete]
        /// </summary>
        public override bool DeleteBomCsv(System.Int32? BomCSVId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_IpoBomCsvDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BomCSVId", SqlDbType.Int).Value = BomCSVId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete HUBRFQ csv", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DropDownForClient 
        /// Calls [usp_GetUpdatedByListFromBOMIdList]
        /// </summary>
        public override BOMDetails GetUpdatedByListFromBOMIdList(System.String BOMIdList)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetUpdatedByListFromBOMIdList", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMIdList", SqlDbType.VarChar).Value = BOMIdList;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
                    BOMDetails obj = new BOMDetails();
                    obj.UpdatedByList = GetReaderValue_String(reader, "UserIds", "");
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
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
                throw new Exception("Failed to get BOMs emails", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update BOM Status to Close
        /// Calls [usp_update_BOMStatusToClosed]
        /// </summary>
        public override bool UpdateBOMStatusToClosed(System.Int32? bomId, System.Int32? updatedBy, System.Int32? bomStatus)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOMStatusToClosed", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@BOMStatus", SqlDbType.Int).Value = bomStatus;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update BOM Status", sqlex);
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
        /// Calls [usp_select_BOM_ID_by_Name]
        /// </summary>GetIDByNumber
        public override BOMDetails GetIDByNumber(System.String bomName, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_BOM_ID_by_Name", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BomName", SqlDbType.NVarChar).Value = bomName;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                   
                    BOMDetails obj = new BOMDetails();
                    obj.BOMId = GetReaderValue_Int32(reader, "BOMId", 0);
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
                throw new Exception("Failed to get HUBRFQ", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        // [001] code start
        /// <summary>
        /// Get Stock Image
        /// Calls [usp_selectAll_Image_for_QuoteToClient]
        /// </summary>
        public override List<StockImageDetails> GetImageListForReq(System.Int32? sourcingResultNo, System.String fileType)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Image_for_QuoteToClient", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockImageDetails> lstPDF = new List<StockImageDetails>();
                while (reader.Read())
                {
                    StockImageDetails obj = new StockImageDetails();
                    obj.StockImageId = GetReaderValue_Int32(reader, "SourcingImageId", 0);
                    obj.ImageDocumentRefNo = GetReaderValue_Int32(reader, "SourcingResultNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.ImageName = GetReaderValue_String(reader, "ImageName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    obj.UpdatedByName = GetReaderValue_String(reader, "ImageName", "");
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Image list", sqlex);
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
