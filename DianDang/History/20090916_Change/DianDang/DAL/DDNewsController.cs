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
    /// Controller class for DDNews
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDNewsController
    {
        // Preload our schema..
        DDNews thisSchemaLoad = new DDNews();
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
        public DDNewsCollection FetchAll()
        {
            DDNewsCollection coll = new DDNewsCollection();
            Query qry = new Query(DDNews.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDNewsCollection FetchByID(object NewsID)
        {
            DDNewsCollection coll = new DDNewsCollection().Where("NewsID", NewsID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDNewsCollection FetchByQuery(Query qry)
        {
            DDNewsCollection coll = new DDNewsCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object NewsID)
        {
            return (DDNews.Delete(NewsID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object NewsID)
        {
            return (DDNews.Destroy(NewsID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? ClassID,string Title,string Content,DateTime? PublishDate,string OperaterName,string Source)
	    {
		    DDNews item = new DDNews();
		    
            item.ClassID = ClassID;
            
            item.Title = Title;
            
            item.Content = Content;
            
            item.PublishDate = PublishDate;
            
            item.OperaterName = OperaterName;
            
            item.Source = Source;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int NewsID,int? ClassID,string Title,string Content,DateTime? PublishDate,string OperaterName,string Source)
	    {
		    DDNews item = new DDNews();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.NewsID = NewsID;
				
			item.ClassID = ClassID;
				
			item.Title = Title;
				
			item.Content = Content;
				
			item.PublishDate = PublishDate;
				
			item.OperaterName = OperaterName;
				
			item.Source = Source;
				
	        item.Save(UserName);
	    }
    }
}
