//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
//[002]     Shashi Keshar    22/02/2016     BOM for Dash Board
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class BOMProvider : DataAccess {
		static private BOMProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public BOMProvider Instance {
			get {
				if (_instance == null) _instance = (BOMProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.BOM.ProviderType));
				return _instance;
			}
		}
        public BOMProvider()
        {
			this.ConnectionString = Globals.Settings.BOM.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_BOM_for_Client]
		/// </summary>
		public abstract Int32 CountForBOM(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_BOM]
		/// </summary>
        public abstract List<BOMDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String bomCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? isAssignToMe, int? assignedUser, System.Int32? intDivisionNo, System.Int32? salesPerson);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_BOM]
		/// </summary>
		public abstract bool Delete(System.Int32? bomId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_BOM_for_Client]
		/// </summary>
        public abstract List<BOMDetails> DropDownForClient(System.Int32? clientId, System.Int32? companyId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_BOM]
		/// </summary>
        public abstract Int32 Insert(System.Int32? clientId, System.String bomName, System.String notes, System.String bomCode, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Boolean? inactive, System.Int32? updateRequirement, System.Int32? status, System.Int32? currencyNo, System.String CurrentSupplier, System.DateTime? QuoteRequired, System.Boolean? AS9120, System.Int32? Contact2, System.Int32 AssignUserNo, out System.String ValidationMessage); //
		/// <summary>
		/// Get
        /// Calls [usp_select_BOM]
		/// </summary>
		public abstract BOMDetails Get(System.Int32? bomId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_BOM_for_Page]
		/// </summary>
		public abstract BOMDetails GetForPage(System.Int32? bomId);
		/// <summary>
		/// Update
		/// Calls [usp_update_BOM]
		/// </summary>
        public abstract bool Update(System.Int32? bomId, System.Int32? clientNo, System.String bomName, System.String notes, System.String bomCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? companyId, System.Int32? contactId, System.Int32? CurrencyNo, System.String CurrentSupplier, System.DateTime? QuoteRequired, System.Boolean? AS9120, System.Int32? contact2Id);
		/// <summary>
		/// UpdateDelete
		/// Calls [usp_update_BOM_Delete]
		/// </summary>
		public abstract bool UpdateDelete(System.Int32? bomId, System.Int32? updatedBy);

        /// <summary>
		/// Update
        /// Calls [usp_update_BOM_POHubQuote]
		/// </summary>
        public abstract bool UpdatePurchaseQuote(System.Int32? bomId, System.Int32? updatedBy, System.Int32? bomStatus, System.Int32 AssignUserNo, out System.String ValidateMessage);

        /// <summary>
        /// Calls [usp_update_BOMStatusToClosed]
        /// </summary>
        public abstract bool UpdateBOMStatusToClosed(System.Int32? bomId, System.Int32? updatedBy, System.Int32? bomStatus);  
		#endregion
				
		/// <summary>
		/// Returns a new BOMDetails instance filled with the DataReader's current record data
		/// </summary>        
        //protected virtual BOMDetails GetBOMFromReader(DbDataReader reader) {
        //    BOMDetails BOM = new BOMDetails();
        //    if (reader.HasRows) {
        //        BOM.BOMId = GetReaderValue_Int32(reader, "BOMId", 0); //From: [Table]
        //        BOM.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
        //        BOM.BOMName = GetReaderValue_String(reader, "BOMName", ""); //From: [usp_select_GoodsInLine]
        //        BOM.Cost = GetReaderValue_NullableDouble(reader, "Cost", null); //From: [usp_selectAll_Login_Top_Salespersons]
        //        BOM.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
        //        BOM.OnHold = GetReaderValue_Boolean(reader, "OnHold", false); //From: [Table]
        //        BOM.Consignment = GetReaderValue_Boolean(reader, "Consignment", false); //From: [Table]
        //        BOM.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
        //        BOM.BOMCode = GetReaderValue_String(reader, "BOMCode", ""); //From: [Table]
        //        BOM.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
        //        BOM.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
        //        BOM.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
        //        BOM.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
        //        BOM.StockCount = GetReaderValue_NullableInt32(reader, "StockCount", null); //From: [usp_datalistnugget_BOM]
        //        BOM.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
        //        BOM.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Client]
        //    }
        //    return BOM;
        //}
	
		/// <summary>
		/// Returns a collection of BOMDetails objects with the data read from the input DataReader
		/// </summary>                
        //protected virtual List<BOMDetails> GetBOMCollectionFromReader(DbDataReader reader) {
        //    List<BOMDetails> BOMs = new List<BOMDetails>();
        //    while (reader.Read()) BOMs.Add(GetBOMFromReader(reader));
        //    return BOMs;
        //}
        //[001] code start
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_BOM]
        /// </summary>
        public abstract List<Rebound.GlobalTrader.DAL.BOMDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);

        //[001] code end

        // [002] Code Start Here
        /// <summary>
        /// GetListReadyForClient
        /// Calls [usp_selectAll_BOM]
        /// </summary>
        public abstract List<BOMDetails> GetBomList(System.Int32? clientId, System.Boolean? isPoHUB, System.Int32? topToSelect, System.Int32? bomStatus, System.Int32? updatedBy);
        // [002] Code End here
        /// <summary>
        /// GetCSVListForBOM
        /// Calls [usp_selectAll_CSV_for_BOM]
        /// </summary>
        public abstract List<PDFDocumentDetails> GetCSVListForBOM(System.Int32? bomNo);

        /// <summary>
        /// UpdateBOMByPH
        /// Calls [usp_update_BOMByPH]
        /// </summary>
        public abstract bool UpdateBOMByPH(System.String BOMIdList, System.Int32? updatedBy);
        /// <summary>
        /// Delete
        /// Calls [usp_IpoBomCsvDelete]
        /// </summary>
        public abstract bool DeleteBomCsv(System.Int32? BomCSVId);


        /// <summary>
        /// DropDownForClient
        /// Calls [usp_GetUpdatedByListFromBOMIdList]
        /// </summary>
        public abstract BOMDetails GetUpdatedByListFromBOMIdList(System.String BOMIdList);

        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_BOM_ID_by_Name]
        /// </summary>
        public abstract BOMDetails GetIDByNumber(System.String bomName, System.Int32? clientNo);
        /// <summary>
        /// Get Image list for quote to client
        /// Calls [usp_selectAll_Image_for_QuoteToClient]
        /// </summary>
        /// <returns></returns>
        public abstract List<StockImageDetails> GetImageListForReq(System.Int32? sourcingResultNo, System.String fileType);
	}
}
