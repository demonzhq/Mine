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
	/// Strongly-typed collection for the DDModule class.
	/// </summary>
    [Serializable]
	public partial class DDModuleCollection : ActiveList<DDModule, DDModuleCollection>
	{	   
		public DDModuleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDModuleCollection</returns>
		public DDModuleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDModule o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDModules table.
	/// </summary>
	[Serializable]
	public partial class DDModule : ActiveRecord<DDModule>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDModule()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDModule(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDModule(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDModule(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDModules", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarModuleID = new TableSchema.TableColumn(schema);
				colvarModuleID.ColumnName = "ModuleID";
				colvarModuleID.DataType = DbType.Int32;
				colvarModuleID.MaxLength = 0;
				colvarModuleID.AutoIncrement = true;
				colvarModuleID.IsNullable = false;
				colvarModuleID.IsPrimaryKey = true;
				colvarModuleID.IsForeignKey = false;
				colvarModuleID.IsReadOnly = false;
				colvarModuleID.DefaultSetting = @"";
				colvarModuleID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModuleID);
				
				TableSchema.TableColumn colvarModuleName = new TableSchema.TableColumn(schema);
				colvarModuleName.ColumnName = "ModuleName";
				colvarModuleName.DataType = DbType.AnsiString;
				colvarModuleName.MaxLength = 50;
				colvarModuleName.AutoIncrement = false;
				colvarModuleName.IsNullable = true;
				colvarModuleName.IsPrimaryKey = false;
				colvarModuleName.IsForeignKey = false;
				colvarModuleName.IsReadOnly = false;
				colvarModuleName.DefaultSetting = @"";
				colvarModuleName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModuleName);
				
				TableSchema.TableColumn colvarParentID = new TableSchema.TableColumn(schema);
				colvarParentID.ColumnName = "ParentID";
				colvarParentID.DataType = DbType.Int32;
				colvarParentID.MaxLength = 0;
				colvarParentID.AutoIncrement = false;
				colvarParentID.IsNullable = true;
				colvarParentID.IsPrimaryKey = false;
				colvarParentID.IsForeignKey = false;
				colvarParentID.IsReadOnly = false;
				colvarParentID.DefaultSetting = @"";
				colvarParentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParentID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDModules",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ModuleID")]
		[Bindable(true)]
		public int ModuleID 
		{
			get { return GetColumnValue<int>(Columns.ModuleID); }
			set { SetColumnValue(Columns.ModuleID, value); }
		}
		  
		[XmlAttribute("ModuleName")]
		[Bindable(true)]
		public string ModuleName 
		{
			get { return GetColumnValue<string>(Columns.ModuleName); }
			set { SetColumnValue(Columns.ModuleName, value); }
		}
		  
		[XmlAttribute("ParentID")]
		[Bindable(true)]
		public int? ParentID 
		{
			get { return GetColumnValue<int?>(Columns.ParentID); }
			set { SetColumnValue(Columns.ParentID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varModuleName,int? varParentID)
		{
			DDModule item = new DDModule();
			
			item.ModuleName = varModuleName;
			
			item.ParentID = varParentID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varModuleID,string varModuleName,int? varParentID)
		{
			DDModule item = new DDModule();
			
				item.ModuleID = varModuleID;
			
				item.ModuleName = varModuleName;
			
				item.ParentID = varParentID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ModuleIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ModuleNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ParentIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ModuleID = @"ModuleID";
			 public static string ModuleName = @"ModuleName";
			 public static string ParentID = @"ParentID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
