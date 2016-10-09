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
    /// Controller class for DDTaking
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDTakingController
    {
        // Preload our schema..
        DDTaking thisSchemaLoad = new DDTaking();
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
        public DDTakingCollection FetchAll()
        {
            DDTakingCollection coll = new DDTakingCollection();
            Query qry = new Query(DDTaking.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDTakingCollection FetchByID(object TakingID)
        {
            DDTakingCollection coll = new DDTakingCollection().Where("TakingID", TakingID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDTakingCollection FetchByQuery(Query qry)
        {
            DDTakingCollection coll = new DDTakingCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TakingID)
        {
            return (DDTaking.Delete(TakingID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TakingID)
        {
            return (DDTaking.Destroy(TakingID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? PawnageID,int? ClassID,int? StatisticClassID,string ServiceFee,string InterestFee,string ReturnFee,string OverdueFee,string OperationDate)
	    {
		    DDTaking item = new DDTaking();
		    
            item.PawnageID = PawnageID;
            
            item.ClassID = ClassID;
            
            item.StatisticClassID = StatisticClassID;
            
            item.ServiceFee = ServiceFee;
            
            item.InterestFee = InterestFee;
            
            item.ReturnFee = ReturnFee;
            
            item.OverdueFee = OverdueFee;
            
            item.OperationDate = OperationDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TakingID,int? PawnageID,int? ClassID,int? StatisticClassID,string ServiceFee,string InterestFee,string ReturnFee,string OverdueFee,string OperationDate)
	    {
		    DDTaking item = new DDTaking();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TakingID = TakingID;
				
			item.PawnageID = PawnageID;
				
			item.ClassID = ClassID;
				
			item.StatisticClassID = StatisticClassID;
				
			item.ServiceFee = ServiceFee;
				
			item.InterestFee = InterestFee;
				
			item.ReturnFee = ReturnFee;
				
			item.OverdueFee = OverdueFee;
				
			item.OperationDate = OperationDate;
				
	        item.Save(UserName);
	    }
    }
}
