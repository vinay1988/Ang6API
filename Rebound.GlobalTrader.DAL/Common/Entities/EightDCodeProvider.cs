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

namespace Rebound.GlobalTrader.DAL
{
    public abstract class EightDCodeProvider : DataAccess
    {
        static private EightDCodeProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the 
        /// file
        /// </summary>       
        static public EightDCodeProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (EightDCodeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.EightDCodes.ProviderType));
                return _instance;
            }
        }
        public EightDCodeProvider()
        {
            this.ConnectionString = Globals.Settings.EightDCodes.ConnectionString;
        }

        /// <summary>
        /// Get For Analysis 8D Category
        /// Calls [USP_Select8DSubCat]
        /// </summary>
        public abstract List<EightDCodeDetails> GetListOfCategory();

        /// <summary>
        /// Get specific Category according to prifix
        /// call [USP_Select8DCategory]
        /// </summary>
        /// <param name="prifix"></param>
        /// <returns></returns>
        public abstract List<EightDCodeDetails> GetListSubCategory(System.Int32? id);

        /// <summary>
        /// Slelect active 8D Category
        /// USP_Select8DCategory
        /// </summary>
        /// <returns></returns>
        public abstract List<EightDCodeDetails> SelectListCategory();

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Analysis8DCategory]
        /// </summary>
        public abstract Int32 Insert(System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Analysis8DSubCategory]
        /// </summary>
        public abstract Int32 Insert(System.Int32 prefixNo,System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy);


        /// <summary>
        /// Slelect active 8D Category
        /// usp_select_Analysis8DCategory
        /// </summary>
        /// <returns></returns>
        public abstract EightDCodeDetails Get(System.Int32? Id);

        /// <summary>
        /// Slelect active 8D Category
        /// usp_select_Analysis8DSubCategory
        /// </summary>
        /// <returns></returns>
        public abstract EightDCodeDetails GetSubCat(System.Int32? Id);

        
        /// <summary>
        /// Calls [usp_update_Analysis8DCategory]
        /// </summary>
        public abstract bool Update(System.Int32? analysis8DCategory, System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy);

        /// <summary>
        /// Calls [usp_update_Analysis8DSubCategory]
        /// </summary>
        public abstract bool Update(System.Int32 analysis8SubDCategory,System.Int32 prefixNo, System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy);

        /// <summary>
        /// Returns a new StockDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual EightDCodeDetails Get8DCodeFromReader(DbDataReader reader)
        {
            EightDCodeDetails D8Code = new EightDCodeDetails();
            if (reader.HasRows)
            {
                D8Code.Analysis8DCategoryID = GetReaderValue_Int32(reader, "Analysis8DCategoryID", 0); //From: [Table]
                D8Code.Analysis8DSubCategoryID = GetReaderValue_Int32(reader, "Analysis8DSubCategoryID", 0); //From: [Table]
                D8Code.Prefix = GetReaderValue_String(reader, "Prefix", ""); //From: [Table]
                D8Code.PrefixDescription = GetReaderValue_String(reader, "Prefix", ""); //From: [Table]
                D8Code.Code = GetReaderValue_String(reader, "Code", ""); //From: [Table]
                D8Code.CodeDescription = GetReaderValue_String(reader, "CodeDescription", ""); //From: [Table]
                D8Code.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
                D8Code.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                D8Code.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                
            }
            return D8Code;
        }

        /// <summary>
        /// Returns a collection of StockDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<EightDCodeDetails> Get8DCollectionFromReader(DbDataReader reader)
        {
            List<EightDCodeDetails> D8Code = new List<EightDCodeDetails>();
            while (reader.Read()) D8Code.Add(Get8DCodeFromReader(reader));
            return D8Code;
        }
		

    }
}
