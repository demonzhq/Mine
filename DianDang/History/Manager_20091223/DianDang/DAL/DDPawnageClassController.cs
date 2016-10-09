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
    /// Controller class for DDPawnageClass
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDPawnageClassController
    {
        // Preload our schema..
        DDPawnageClass thisSchemaLoad = new DDPawnageClass();
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
        public DDPawnageClassCollection FetchAll()
        {
            DDPawnageClassCollection coll = new DDPawnageClassCollection();
            Query qry = new Query(DDPawnageClass.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDPawnageClassCollection FetchByID(object ClassID)
        {
            DDPawnageClassCollection coll = new DDPawnageClassCollection().Where("ClassID", ClassID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDPawnageClassCollection FetchByQuery(Query qry)
        {
            DDPawnageClassCollection coll = new DDPawnageClassCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ClassID)
        {
            return (DDPawnageClass.Delete(ClassID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ClassID)
        {
            return (DDPawnageClass.Destroy(ClassID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ClassName,int? ParentID,int? UnitID,string MonthFeeRate,string MaxFeeRate,string MinFeeRate,string InterestRate,string Description,int? IsRoot,int? StatisticClassID)
	    {
		    DDPawnageClass item = new DDPawnageClass();
		    
            item.ClassName = ClassName;
            
            item.ParentID = ParentID;
            
            item.UnitID = UnitID;
            
            item.MonthFeeRate = MonthFeeRate;
            
            item.MaxFeeRate = MaxFeeRate;
            
            item.MinFeeRate = MinFeeRate;
            
            item.InterestRate = InterestRate;
            
            item.Description = Description;
            
            item.IsRoot = IsRoot;
            
            item.StatisticClassID = StatisticClassID;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ClassID,string ClassName,int? ParentID,int? UnitID,string MonthFeeRate,string MaxFeeRate,string MinFeeRate,string InterestRate,string Description,int? IsRoot,int? StatisticClassID)
	    {
		    DDPawnageClass item = new DDPawnageClass();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ClassID = ClassID;
				
			item.ClassName = ClassName;
				
			item.ParentID = ParentID;
				
			item.UnitID = UnitID;
				
			item.MonthFeeRate = MonthFeeRate;
				
			item.MaxFeeRate = MaxFeeRate;
				
			item.MinFeeRate = MinFeeRate;
				
			item.InterestRate = InterestRate;
				
			item.Description = Description;
				
			item.IsRoot = IsRoot;
				
			item.StatisticClassID = StatisticClassID;
				
	        item.Save(UserName);
	    }
    }
}
