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
	/// Strongly-typed collection for the DDUser class.
	/// </summary>
    [Serializable]
	public partial class DDUserCollection : ActiveList<DDUser, DDUserCollection>
	{	   
		public DDUserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDUserCollection</returns>
		public DDUserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDUser o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the DDUsers table.
	/// </summary>
	[Serializable]
	public partial class DDUser : ActiveRecord<DDUser>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDUser()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDUser(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDUser(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDUser(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("DDUsers", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = true;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = true;
				colvarUserID.IsForeignKey = false;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				colvarUserID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.AnsiString;
				colvarUserName.MaxLength = 50;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = true;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarUserPassword = new TableSchema.TableColumn(schema);
				colvarUserPassword.ColumnName = "UserPassword";
				colvarUserPassword.DataType = DbType.AnsiString;
				colvarUserPassword.MaxLength = 50;
				colvarUserPassword.AutoIncrement = false;
				colvarUserPassword.IsNullable = true;
				colvarUserPassword.IsPrimaryKey = false;
				colvarUserPassword.IsForeignKey = false;
				colvarUserPassword.IsReadOnly = false;
				colvarUserPassword.DefaultSetting = @"";
				colvarUserPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserPassword);
				
				TableSchema.TableColumn colvarRoleID = new TableSchema.TableColumn(schema);
				colvarRoleID.ColumnName = "RoleID";
				colvarRoleID.DataType = DbType.Int32;
				colvarRoleID.MaxLength = 0;
				colvarRoleID.AutoIncrement = false;
				colvarRoleID.IsNullable = true;
				colvarRoleID.IsPrimaryKey = false;
				colvarRoleID.IsForeignKey = false;
				colvarRoleID.IsReadOnly = false;
				colvarRoleID.DefaultSetting = @"";
				colvarRoleID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRoleID);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 50;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarPhoneNumber = new TableSchema.TableColumn(schema);
				colvarPhoneNumber.ColumnName = "PhoneNumber";
				colvarPhoneNumber.DataType = DbType.AnsiString;
				colvarPhoneNumber.MaxLength = 50;
				colvarPhoneNumber.AutoIncrement = false;
				colvarPhoneNumber.IsNullable = true;
				colvarPhoneNumber.IsPrimaryKey = false;
				colvarPhoneNumber.IsForeignKey = false;
				colvarPhoneNumber.IsReadOnly = false;
				colvarPhoneNumber.DefaultSetting = @"";
				colvarPhoneNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhoneNumber);
				
				TableSchema.TableColumn colvarCertNumber = new TableSchema.TableColumn(schema);
				colvarCertNumber.ColumnName = "CertNumber";
				colvarCertNumber.DataType = DbType.AnsiString;
				colvarCertNumber.MaxLength = 50;
				colvarCertNumber.AutoIncrement = false;
				colvarCertNumber.IsNullable = true;
				colvarCertNumber.IsPrimaryKey = false;
				colvarCertNumber.IsForeignKey = false;
				colvarCertNumber.IsReadOnly = false;
				colvarCertNumber.DefaultSetting = @"";
				colvarCertNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCertNumber);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDUsers",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		  
		[XmlAttribute("UserName")]
		[Bindable(true)]
		public string UserName 
		{
			get { return GetColumnValue<string>(Columns.UserName); }
			set { SetColumnValue(Columns.UserName, value); }
		}
		  
		[XmlAttribute("UserPassword")]
		[Bindable(true)]
		public string UserPassword 
		{
			get { return GetColumnValue<string>(Columns.UserPassword); }
			set { SetColumnValue(Columns.UserPassword, value); }
		}
		  
		[XmlAttribute("RoleID")]
		[Bindable(true)]
		public int? RoleID 
		{
			get { return GetColumnValue<int?>(Columns.RoleID); }
			set { SetColumnValue(Columns.RoleID, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("PhoneNumber")]
		[Bindable(true)]
		public string PhoneNumber 
		{
			get { return GetColumnValue<string>(Columns.PhoneNumber); }
			set { SetColumnValue(Columns.PhoneNumber, value); }
		}
		  
		[XmlAttribute("CertNumber")]
		[Bindable(true)]
		public string CertNumber 
		{
			get { return GetColumnValue<string>(Columns.CertNumber); }
			set { SetColumnValue(Columns.CertNumber, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUserName,string varUserPassword,int? varRoleID,string varEmail,string varPhoneNumber,string varCertNumber)
		{
			DDUser item = new DDUser();
			
			item.UserName = varUserName;
			
			item.UserPassword = varUserPassword;
			
			item.RoleID = varRoleID;
			
			item.Email = varEmail;
			
			item.PhoneNumber = varPhoneNumber;
			
			item.CertNumber = varCertNumber;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserID,string varUserName,string varUserPassword,int? varRoleID,string varEmail,string varPhoneNumber,string varCertNumber)
		{
			DDUser item = new DDUser();
			
				item.UserID = varUserID;
			
				item.UserName = varUserName;
			
				item.UserPassword = varUserPassword;
			
				item.RoleID = varRoleID;
			
				item.Email = varEmail;
			
				item.PhoneNumber = varPhoneNumber;
			
				item.CertNumber = varCertNumber;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UserPasswordColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RoleIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PhoneNumberColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CertNumberColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserID = @"UserID";
			 public static string UserName = @"UserName";
			 public static string UserPassword = @"UserPassword";
			 public static string RoleID = @"RoleID";
			 public static string Email = @"Email";
			 public static string PhoneNumber = @"PhoneNumber";
			 public static string CertNumber = @"CertNumber";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
