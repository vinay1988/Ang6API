//Marker     Changed by      Date         Remarks
//[001]      Vinay           09/07/2012   This need for Rebound- Invoice bulk Emailer
//[002]      Vinay           04/10/2012   Degete Ref:#26#  - Add two more columns contact to identify Default Purchase ledger and Default Sales ledger
//[003]      Aashu Singh     13-Sep-2018  [REB-12820]:Provision to add Global Security on Contact Section
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
    public class SqlContactProvider : ContactProvider
    {
        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Contact]
        /// </summary>
        public override List<ContactDetails> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Contact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ContactDetails> lst = new List<ContactDetails>();
                while (reader.Read())
                {
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Contacts", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count Contact
        /// Calls [usp_count_Contact_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_Contact_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count Contact", sqlex);
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
        /// Calls [usp_datalistnugget_Contact]
        /// </summary>
        //[003] start
        public override List<ContactDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String firstNameSearch, System.String lastNameSearch, System.String companyNameSearch, System.Int32? salesmanSearch, System.String telNo, Boolean IsGlobalLogin, System.Int32? clientSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_Contact", cn);
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
                cmd.Parameters.Add("@FirstNameSearch", SqlDbType.NVarChar).Value = firstNameSearch;
                cmd.Parameters.Add("@LastNameSearch", SqlDbType.NVarChar).Value = lastNameSearch;
                cmd.Parameters.Add("@CompanyNameSearch", SqlDbType.NVarChar).Value = companyNameSearch;
                cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
                cmd.Parameters.Add("@TelNo", SqlDbType.NVarChar).Value = telNo;
                //[003] start
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                //[003] end
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ContactDetails> lst = new List<ContactDetails>();
                while (reader.Read())
                {
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Contacts", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Contact
        /// Calls [usp_delete_Contact]
        /// </summary>
        public override bool Delete(System.Int32? contactId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Contact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Contact", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DropDownForCompany 
        /// Calls [usp_dropdown_Contact_for_Company]
        /// </summary>
        public override List<ContactDetails> DropDownForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Contact_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ContactDetails> lst = new List<ContactDetails>();
                while (reader.Read())
                {
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Contacts", sqlex);
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
        /// Create a new row
        /// Calls [usp_insert_Contact]
        /// </summary>
        public override Int32 Insert(System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? FinanceContact)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Contact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = contactName;
                cmd.Parameters.Add("@Salutation", SqlDbType.NVarChar).Value = salutation;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
                cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = extension;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@HomeTelephone", SqlDbType.NVarChar).Value = homeTelephone;
                cmd.Parameters.Add("@MobileTelephone", SqlDbType.NVarChar).Value = mobileTelephone;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@TextOnlyEmail", SqlDbType.Bit).Value = textOnlyEmail;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@FinanceContact", SqlDbType.Bit).Value = FinanceContact;
                cmd.Parameters.Add("@ContactId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@ContactId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Contact", sqlex);
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
        /// Get 
        /// Calls [usp_select_Contact]
        /// </summary>
        public override ContactDetails Get(System.Int32? contactId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Contact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetContactFromReader(reader);
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.MobileTelephone = GetReaderValue_String(reader, "MobileTelephone", "");
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.ContactPositionNo = GetReaderValue_NullableInt32(reader, "ContactPositionNo", null);
                    obj.TextOnlyEmail = GetReaderValue_NullableBoolean(reader, "TextOnlyEmail", null);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
                    obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
                    obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.HasSupplementalData = GetReaderValue_Int32(reader, "HasSupplementalData", 0);
                    obj.HasUserDefinedData = GetReaderValue_Int32(reader, "HasUserDefinedData", 0);
                    //[001] code start
                    obj.FinanceContact = GetReaderValue_NullableBoolean(reader, "FinanceContact", null);
                    //[001] code end
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
                throw new Exception("Failed to get Contact", sqlex);
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
        /// Calls [usp_select_Contact_for_Page]
        /// </summary>
        public override ContactDetails GetForPage(System.Int32? contactId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Contact_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetContactFromReader(reader);
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
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
                throw new Exception("Failed to get Contact", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForCompany 
        /// Calls [usp_selectAll_Contact_for_Company]
        /// </summary>
        public override List<ContactDetails> GetListForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Contact_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ContactDetails> lst = new List<ContactDetails>();
                while (reader.Read())
                {
                    ContactDetails obj = new ContactDetails();
                    obj.ContactId = GetReaderValue_Int32(reader, "ContactId", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.MobileTelephone = GetReaderValue_String(reader, "MobileTelephone", "");
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.ContactPositionNo = GetReaderValue_NullableInt32(reader, "ContactPositionNo", null);
                    obj.TextOnlyEmail = GetReaderValue_NullableBoolean(reader, "TextOnlyEmail", null);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
                    obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
                    obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.HasSupplementalData = GetReaderValue_Int32(reader, "HasSupplementalData", 0);
                    obj.HasUserDefinedData = GetReaderValue_Int32(reader, "HasUserDefinedData", 0);
                    obj.DefaultPO = GetReaderValue_NullableBoolean(reader, "DefaultPO", null);
                    obj.DefaultSO = GetReaderValue_NullableBoolean(reader, "DefaultSO", null);
                    //[001] code start
                    obj.FinanceContact = GetReaderValue_NullableBoolean(reader, "FinanceContact", null);
                    //[001] code end
                    //[002] code start
                    obj.DefaultPOLedgerContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOLedgerContactNo", null);
                    obj.DefaultSOLedgerContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOLedgerContactNo", null);
                    obj.DefaultPOLedger = GetReaderValue_NullableBoolean(reader, "DefaultPOLedger", null);
                    obj.DefaultSOLedger = GetReaderValue_NullableBoolean(reader, "DefaultSOLedger", null);
                    //[002] code end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Contacts", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Contact
        /// Calls [usp_update_Contact]
        /// </summary>
        public override bool Update(System.Int32? contactId, System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? FinanceContact)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Contact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactId;
                cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = contactName;
                cmd.Parameters.Add("@Salutation", SqlDbType.NVarChar).Value = salutation;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
                cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = extension;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@HomeTelephone", SqlDbType.NVarChar).Value = homeTelephone;
                cmd.Parameters.Add("@MobileTelephone", SqlDbType.NVarChar).Value = mobileTelephone;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@TextOnlyEmail", SqlDbType.Bit).Value = textOnlyEmail;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@FinanceContact", SqlDbType.Bit).Value = FinanceContact;
                //[001] code end
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Contact", sqlex);
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