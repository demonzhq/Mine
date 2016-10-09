using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace DianDang
{
    /// <summary>
    /// Controller class for DDPrintParam
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDPrintParamController
    {
        // Preload our schema..
        DDPrintParam thisSchemaLoad = new DDPrintParam();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DDPrintParamCollection FetchAll()
        {
            DDPrintParamCollection coll = new DDPrintParamCollection();
            Query qry = new Query(DDPrintParam.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDPrintParamCollection FetchByID(object PrintOption)
        {
            DDPrintParamCollection coll = new DDPrintParamCollection().Where("PrintOption", PrintOption).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDPrintParamCollection FetchByQuery(Query qry)
        {
            DDPrintParamCollection coll = new DDPrintParamCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PrintOption)
        {
            return (DDPrintParam.Delete(PrintOption) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PrintOption)
        {
            return (DDPrintParam.Destroy(PrintOption) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string OptionName,int? OptionValue)
	    {
		    DDPrintParam item = new DDPrintParam();
		    
            item.OptionName = OptionName;
            
            item.OptionValue = OptionValue;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PrintOption,string OptionName,int? OptionValue)
	    {
		    DDPrintParam item = new DDPrintParam();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PrintOption = PrintOption;
				
			item.OptionName = OptionName;
				
			item.OptionValue = OptionValue;
				
	        item.Save(UserName);
	    }
    }
}
