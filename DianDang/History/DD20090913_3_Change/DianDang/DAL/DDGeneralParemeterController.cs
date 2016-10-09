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
    /// Controller class for DDGeneralParemeters
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDGeneralParemeterController
    {
        // Preload our schema..
        DDGeneralParemeter thisSchemaLoad = new DDGeneralParemeter();
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
        public DDGeneralParemeterCollection FetchAll()
        {
            DDGeneralParemeterCollection coll = new DDGeneralParemeterCollection();
            Query qry = new Query(DDGeneralParemeter.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDGeneralParemeterCollection FetchByID(object ParamID)
        {
            DDGeneralParemeterCollection coll = new DDGeneralParemeterCollection().Where("ParamID", ParamID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDGeneralParemeterCollection FetchByQuery(Query qry)
        {
            DDGeneralParemeterCollection coll = new DDGeneralParemeterCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ParamID)
        {
            return (DDGeneralParemeter.Delete(ParamID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ParamID)
        {
            return (DDGeneralParemeter.Destroy(ParamID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ParamName,string ParamValue)
	    {
		    DDGeneralParemeter item = new DDGeneralParemeter();
		    
            item.ParamName = ParamName;
            
            item.ParamValue = ParamValue;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ParamID,string ParamName,string ParamValue)
	    {
		    DDGeneralParemeter item = new DDGeneralParemeter();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ParamID = ParamID;
				
			item.ParamName = ParamName;
				
			item.ParamValue = ParamValue;
				
	        item.Save(UserName);
	    }
    }
}
