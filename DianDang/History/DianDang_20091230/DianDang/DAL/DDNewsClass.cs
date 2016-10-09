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
	/// Strongly-typed collection for the DDNewsClass class.
	/// </summary>
    [Serializable]
	public partial class DDNewsClassCollection : ActiveList<DDNewsClass, DDNewsClassCollection>
	{	   
		public DDNewsClassCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDNewsClassCollection</returns>
		public DDNewsClassCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDNewsClass o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDNewsClass table.
	/// </summary>
	[Serializable]
	public partial class DDNewsClass : ActiveRecord<DDNewsClass>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDNewsClass()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDNewsClass(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDNewsClass(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDNewsClass(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDNewsClass", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarClassID = new TableSchema.TableColumn(schema);
				colvarClassID.ColumnName = "ClassID";
				colvarClassID.DataType = DbType.Int32;
				colvarClassID.MaxLength = 0;
				colvarClassID.AutoIncrement = true;
				colvarClassID.IsNullable = false;
				colvarClassID.IsPrimaryKey = true;
				colvarClassID.IsForeignKey = false;
				colvarClassID.IsReadOnly = false;
				colvarClassID.DefaultSetting = @"";
				colvarClassID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassID);
				
				TableSchema.TableColumn colvarClassName = new TableSchema.TableColumn(schema);
				colvarClassName.ColumnName = "ClassName";
				colvarClassName.DataType = DbType.AnsiString;
				colvarClassName.MaxLength = 50;
				colvarClassName.AutoIncrement = false;
				colvarClassName.IsNullable = true;
				colvarClassName.IsPrimaryKey = false;
				colvarClassName.IsForeignKey = false;
				colvarClassName.IsReadOnly = false;
				colvarClassName.DefaultSetting = @"";
				colvarClassName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 50;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDNewsClass",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int ClassID 
		{
			get { return GetColumnValue<int>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("ClassName")]
		[Bindable(true)]
		public string ClassName 
		{
			get { return GetColumnValue<string>(Columns.ClassName); }
			set { SetColumnValue(Columns.ClassName, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varClassName,string varDescription)
		{
			DDNewsClass item = new DDNewsClass();
			
			item.ClassName = varClassName;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varClassID,string varClassName,string varDescription)
		{
			DDNewsClass item = new DDNewsClass();
			
				item.ClassID = varClassID;
			
				item.ClassName = varClassName;
			
				item.Description = varDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ClassID = @"ClassID";
			 public static string ClassName = @"ClassName";
			 public static string Description = @"Description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
