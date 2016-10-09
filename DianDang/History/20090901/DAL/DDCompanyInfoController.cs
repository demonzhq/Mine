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
    /// Controller class for DDCompanyInfo
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DDCompanyInfoController
    {
        // Preload our schema..
        DDCompanyInfo thisSchemaLoad = new DDCompanyInfo();
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
        public DDCompanyInfoCollection FetchAll()
        {
            DDCompanyInfoCollection coll = new DDCompanyInfoCollection();
            Query qry = new Query(DDCompanyInfo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDCompanyInfoCollection FetchByID(object CompanyID)
        {
            DDCompanyInfoCollection coll = new DDCompanyInfoCollection().Where("CompanyID", CompanyID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DDCompanyInfoCollection FetchByQuery(Query qry)
        {
            DDCompanyInfoCollection coll = new DDCompanyInfoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CompanyID)
        {
            return (DDCompanyInfo.Delete(CompanyID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CompanyID)
        {
            return (DDCompanyInfo.Destroy(CompanyID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CompanyName,string PhoneNumber,string LicenseCode,string Address,string SubCompanyNumber,string SubCompanyName,string Postalcode,string ShopHours,string Remark)
	    {
		    DDCompanyInfo item = new DDCompanyInfo();
		    
            item.CompanyName = CompanyName;
            
            item.PhoneNumber = PhoneNumber;
            
            item.LicenseCode = LicenseCode;
            
            item.Address = Address;
            
            item.SubCompanyNumber = SubCompanyNumber;
            
            item.SubCompanyName = SubCompanyName;
            
            item.Postalcode = Postalcode;
            
            item.ShopHours = ShopHours;
            
            item.Remark = Remark;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CompanyID,string CompanyName,string PhoneNumber,string LicenseCode,string Address,string SubCompanyNumber,string SubCompanyName,string Postalcode,string ShopHours,string Remark)
	    {
		    DDCompanyInfo item = new DDCompanyInfo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CompanyID = CompanyID;
				
			item.CompanyName = CompanyName;
				
			item.PhoneNumber = PhoneNumber;
				
			item.LicenseCode = LicenseCode;
				
			item.Address = Address;
				
			item.SubCompanyNumber = SubCompanyNumber;
				
			item.SubCompanyName = SubCompanyName;
				
			item.Postalcode = Postalcode;
				
			item.ShopHours = ShopHours;
				
			item.Remark = Remark;
				
	        item.Save(UserName);
	    }
    }
}
