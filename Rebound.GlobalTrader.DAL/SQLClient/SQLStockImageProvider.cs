//Marker     Changed by      Date         Remarks
//[001]      Vinay           06/3/2014     CR:- Image Utility 
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
	public class SqlStockImageProvider : StockImageProvider {
		/// <summary>
		/// Count StockImage
		/// Calls [usp_count_StockImage_ForStock]
		/// </summary>
		public override Int32 CountForStock(System.Int32? stockNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_StockImage_ForStock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete StockImage
		/// Calls [usp_delete_StockImage]
		/// </summary>
		public override bool Delete(System.Int32? stockImageNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_delete_StockImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockImageNo", SqlDbType.Int).Value = stockImageNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Delete StockImage
        /// Calls [usp_delete_StockImage]
        /// </summary>
        public override bool DeleteSAN(System.Int32? stockImageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Globals.Settings.StockImages.ConnectionString);
                cmd = new SqlCommand("usp_delete_StockImage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockImageNo", SqlDbType.Int).Value = stockImageNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete StockImage", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		/// <summary>
		/// Delete StockImage
		/// Calls [usp_delete_StockImage_for_Stock]
		/// </summary>
		public override bool DeleteForStock(System.Int32? stockNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_delete_StockImage_for_Stock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_StockImage]
		/// </summary>
		public override Int32 Insert(System.Int32? stockNo, System.String caption, System.String thumbnailImageContentType, System.String mediumImageContentType, System.Byte[] fullsizeImage, System.String fullsizeImageContentType, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_insert_StockImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = caption;
				cmd.Parameters.Add("@ThumbnailImage", SqlDbType.VarBinary).Value = DBNull.Value;
				cmd.Parameters.Add("@ThumbnailImageContentType", SqlDbType.NVarChar).Value = thumbnailImageContentType;
                cmd.Parameters.Add("@MediumImage", SqlDbType.VarBinary).Value = DBNull.Value;
				cmd.Parameters.Add("@MediumImageContentType", SqlDbType.NVarChar).Value = mediumImageContentType;
				cmd.Parameters.Add("@FullsizeImage", SqlDbType.VarBinary).Value = fullsizeImage;
				cmd.Parameters.Add("@FullsizeImageContentType", SqlDbType.NVarChar).Value = fullsizeImageContentType;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_StockImageForSAN]
        /// </summary>
        public override Int32 Insert(System.Int32? stockNo, System.String caption, System.String stockImageName, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Globals.Settings.StockImages.ConnectionString);
                cmd = new SqlCommand("usp_insert_StockImageForSAN", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = caption;
                cmd.Parameters.Add("@ImageName", SqlDbType.NVarChar).Value = stockImageName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert StockImage", sqlex);
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
		/// Calls [usp_insert_StockImage_CopyFromStockToStock]
		/// </summary>
		public override Int32 InsertCopyFromStockToStock(System.Int32? oldStockNo, System.Int32? newStockNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_insert_StockImage_CopyFromStockToStock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OldStockNo", SqlDbType.Int).Value = oldStockNo;
				cmd.Parameters.Add("@NewStockNo", SqlDbType.Int).Value = newStockNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return string.IsNullOrEmpty(cmd.Parameters["@NewId"].Value.ToString()) ? 0 : (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_StockImage]
        /// </summary>
		public override StockImageDetails Get(System.Int32? stockImageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_StockImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockImageId", SqlDbType.Int).Value = stockImageId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockImageFromReader(reader);
					StockImageDetails obj = new StockImageDetails();
					obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.Caption = GetReaderValue_String(reader, "Caption", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetFullSizeImage 
		/// Calls [usp_select_StockImage_FullSizeImage]
        /// </summary>
		public override StockImageDetails GetFullSizeImage(System.Int32? stockImageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_select_StockImage_FullSizeImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockImageId", SqlDbType.Int).Value = stockImageId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockImageFromReader(reader);
					StockImageDetails obj = new StockImageDetails();
					obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.FullsizeImage = GetReaderValue_ByteArray(reader, "FullsizeImage", null);
					obj.FullsizeImageContentType = GetReaderValue_String(reader, "FullsizeImageContentType", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetMediumImage 
		/// Calls [usp_select_StockImage_MediumImage]
        /// </summary>
		public override StockImageDetails GetMediumImage(System.Int32? stockImageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_select_StockImage_MediumImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockImageId", SqlDbType.Int).Value = stockImageId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockImageFromReader(reader);
					StockImageDetails obj = new StockImageDetails();
					obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.MediumImage = GetReaderValue_ByteArray(reader, "MediumImage", null);
					obj.MediumImageContentType = GetReaderValue_String(reader, "MediumImageContentType", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetThumbnailImage 
		/// Calls [usp_select_StockImage_ThumbnailImage]
        /// </summary>
		public override StockImageDetails GetThumbnailImage(System.Int32? stockImageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_select_StockImage_ThumbnailImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockImageId", SqlDbType.Int).Value = stockImageId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetStockImageFromReader(reader);
					StockImageDetails obj = new StockImageDetails();
					obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.ThumbnailImage = GetReaderValue_ByteArray(reader, "ThumbnailImage", null);
					obj.ThumbnailImageContentType = GetReaderValue_String(reader, "ThumbnailImageContentType", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForStock 
		/// Calls [usp_selectAll_StockImage_for_Stock]
        /// </summary>
		public override List<StockImageDetails> GetListForStock(System.Int32? stockId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
                cn = new SqlConnection(Globals.Settings.StockImages.MediaConnectionString);
				cmd = new SqlCommand("usp_selectAll_StockImage_for_Stock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<StockImageDetails> lst = new List<StockImageDetails>();
				while (reader.Read()) {
					StockImageDetails obj = new StockImageDetails();
					obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
					obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
					obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.ImageName = "";
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get StockImages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        //[001] code start
        /// <summary>
        /// GetListForStock 
        /// Calls [usp_selectAll_StockImage_for_Stock]
        /// </summary>
        public override List<StockImageDetails> GetListForStockSAN(System.Int32? stockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Globals.Settings.StockImages.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_StockImage_for_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockImageDetails> lst = new List<StockImageDetails>();
                while (reader.Read())
                {
                    StockImageDetails obj = new StockImageDetails();
                    obj.StockImageId = GetReaderValue_Int32(reader, "StockImageId", 0);
                    obj.StockNo = GetReaderValue_Int32(reader, "StockNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.ImageName = GetReaderValue_String(reader, "ImageName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get StockImages", sqlex);
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
        /// Update StockImage
		/// Calls [usp_update_StockImage]
        /// </summary>
		public override bool Update(System.Int32? stockImageId, System.Int32? stockNo, System.String caption, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_StockImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockImageId", SqlDbType.Int).Value = stockImageId;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = caption;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update StockImage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_SourcingImage]
        /// </summary>
        public override Int32 InsertSourcing(System.Int32? sourcingNo, System.String caption, System.String stockImageName, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Globals.Settings.StockImages.ConnectionString);
                cmd = new SqlCommand("usp_insert_SourcingImage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SourcingNo", SqlDbType.Int).Value = sourcingNo;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = caption;
                cmd.Parameters.Add("@ImageName", SqlDbType.NVarChar).Value = stockImageName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Sourcing Image", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Sourcing Image
        /// Calls [usp_delete_SourcingImage]
        /// </summary>
        public override bool DeleteSourcing(System.Int32? sourcingImageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(Globals.Settings.StockImages.ConnectionString);
                cmd = new SqlCommand("usp_delete_SourcingImage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SourcingImageNo", SqlDbType.Int).Value = sourcingImageNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Sourcing Image", sqlex);
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