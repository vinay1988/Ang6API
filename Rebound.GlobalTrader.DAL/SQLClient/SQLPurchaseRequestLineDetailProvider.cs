using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Rebound.GlobalTrader.DAL.Common.Entities;

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlPurchaseRequestLineDetailProvider : PurchaseRequestLineDetailProvider
    {        		
		
		/// <summary>
        /// Calls [usp_delete_PurchaseRequestLineDetail]
		/// </summary>
        public override bool Delete(System.Int32? purchaseRequestLineDetailId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_PurchaseRequestLineDetail", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestLineDetailId", SqlDbType.Int).Value = purchaseRequestLineDetailId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
                throw new Exception("Failed to delete Price Request line detail", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
        /// Calls [usp_insert_PurchaseRequestLineDetail]
		/// </summary>
        public override Int32 Insert(int? purchaseRequestLineNo, int? supplier, double? price, string spq, string leadTime, string rohs, string factorySealed, string msl, string manufacturerName, string dateCode, string packageType, string productType, string mOQ, string totalQSA, string lTB, string notes, int? updatedBy, System.Int32? currencyNo,System.Int32? mslLevelNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_PurchaseRequestLineDetail", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestLineNo", SqlDbType.Int).Value = purchaseRequestLineNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.NVarChar).Value = supplier;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price??0;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = spq;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohs;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = msl;

                cmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar).Value = manufacturerName;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageType", SqlDbType.NVarChar).Value = packageType;
                cmd.Parameters.Add("@ProductType", SqlDbType.NVarChar).Value = productType;
                cmd.Parameters.Add("@MOQ", SqlDbType.NVarChar).Value = mOQ;
                cmd.Parameters.Add("@TotalQSA", SqlDbType.NVarChar).Value = totalQSA;
                cmd.Parameters.Add("@LTB", SqlDbType.NVarChar).Value = lTB;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;

                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@PurchaseRequestLineDetailId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@PurchaseRequestLineDetailId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
                throw new Exception("Failed to insert Price Request line detail", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}					
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_PurchaseRequestLineDetail]
        /// </summary>
        public override PurchaseRequestLineDetailDetails Get(System.Int32? purchaseRequestLineDetailId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PurchaseRequestLineDetail", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseRequestLineDetailId", SqlDbType.Int).Value = purchaseRequestLineDetailId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
                    PurchaseRequestLineDetailDetails obj = new PurchaseRequestLineDetailDetails();
                    //obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
                    //obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
                    //obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    //obj.Part = GetReaderValue_String(reader, "Part", "");
                    //obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    //obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    //obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);			
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
                throw new Exception("Failed to get Price Request line detail", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
		/// Calls [usp_selectAll_PurchaseRequestLineDetail]
        /// </summary>
        public override List<PurchaseRequestLineDetailDetails> GetListLines(System.Int32? purchaseRequirementLineNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PurchaseRequestLineDetail", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@purchaseRequirementLineNo", SqlDbType.Int).Value = purchaseRequirementLineNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseRequestLineDetailDetails> lst = new List<PurchaseRequestLineDetailDetails>();
				while (reader.Read()) {
                    PurchaseRequestLineDetailDetails obj = new PurchaseRequestLineDetailDetails();
                    obj.PurchaseRequestLineDetailId = GetReaderValue_NullableInt32(reader, "PurchaseRequestLineDetailId", 0);
                    obj.PurchaseRequestLineNo = GetReaderValue_NullableInt32(reader, "PurchaseRequestLineNo", 0);
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", null);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.RoHSStatus = GetReaderValue_String(reader, "RoHSStatus", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageType = GetReaderValue_String(reader, "PackageType", "");
                    obj.ProductType = GetReaderValue_String(reader, "ProductType", "");
                    obj.MOQ = GetReaderValue_String(reader, "MOQ", "");
                    obj.TotalQSA = GetReaderValue_String(reader, "TotalQSA", "");
                    obj.LTB = GetReaderValue_String(reader, "LTB", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");    
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", 0);
                    obj.GlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "GlobalCurrencyNo", 0);
                    obj.MSLLevelNo = GetReaderValue_NullableInt32(reader, "MSLLevelNo", 0);
                    lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
                throw new Exception("Failed to get Price Request line detail", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_update_PurchaseRequestLineDetail]
        /// </summary>
        public override bool Update(System.Int32? purchaseRequestLineDetailId, int? purchaseRequestLineNo, int? companyNo, double? price, string spq, string leadTime, string rohs, string factorySealed, string msl, string manufacturerName, string dateCode, string packageType, string productType, string mOQ, string totalQSA, string lTB, string notes, int? updatedBy, System.Int32? currencyNo, System.Int32? mslLevelNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseRequestLineDetail", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestLineDetailId", SqlDbType.Int).Value = purchaseRequestLineDetailId;
                cmd.Parameters.Add("@PurchaseRequestLineNo", SqlDbType.Int).Value = purchaseRequestLineNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = spq;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@ROHS", SqlDbType.NVarChar).Value = rohs;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = msl;

                cmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar).Value = manufacturerName;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageType", SqlDbType.NVarChar).Value = packageType;
                cmd.Parameters.Add("@ProductType", SqlDbType.NVarChar).Value = productType;
                cmd.Parameters.Add("@MOQ", SqlDbType.NVarChar).Value = mOQ;
                cmd.Parameters.Add("@TotalQSA", SqlDbType.NVarChar).Value = totalQSA;
                cmd.Parameters.Add("@LTB", SqlDbType.NVarChar).Value = lTB;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;

                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
                throw new Exception("Failed to update Price Request line detail", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}				        
	}
}
