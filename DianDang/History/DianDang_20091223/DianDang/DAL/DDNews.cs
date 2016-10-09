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
	/// Strongly-typed collection for the DDNews class.
	/// </summary>
    [Serializable]
	public partial class DDNewsCollection : ActiveList<DDNews, DDNewsCollection>
	{	   
		public DDNewsCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDNewsCollection</returns>
		public DDNewsCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDNews o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDNews table.
	/// </summary>
	[Serializable]
	public partial class DDNews : ActiveRecord<DDNews>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDNews()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDNews(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDNews(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDNews(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDNews", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarNewsID = new TableSchema.TableColumn(schema);
				colvarNewsID.ColumnName = "NewsID";
				colvarNewsID.DataType = DbType.Int32;
				colvarNewsID.MaxLength = 0;
				colvarNewsID.AutoIncrement = true;
				colvarNewsID.IsNullable = false;
				colvarNewsID.IsPrimaryKey = true;
				colvarNewsID.IsForeignKey = false;
				colvarNewsID.IsReadOnly = false;
				colvarNewsID.DefaultSetting = @"";
				colvarNewsID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNewsID);
				
				TableSchema.TableColumn colvarClassID = new TableSchema.TableColumn(schema);
				colvarClassID.ColumnName = "ClassID";
				colvarClassID.DataType = DbType.Int32;
				colvarClassID.MaxLength = 0;
				colvarClassID.AutoIncrement = false;
				colvarClassID.IsNullable = true;
				colvarClassID.IsPrimaryKey = false;
				colvarClassID.IsForeignKey = false;
				colvarClassID.IsReadOnly = false;
				colvarClassID.DefaultSetting = @"";
				colvarClassID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassID);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.AnsiString;
				colvarTitle.MaxLength = 50;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = true;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarContent = new TableSchema.TableColumn(schema);
				colvarContent.ColumnName = "Content";
				colvarContent.DataType = DbType.AnsiString;
				colvarContent.MaxLength = 2147483647;
				colvarContent.AutoIncrement = false;
				colvarContent.IsNullable = true;
				colvarContent.IsPrimaryKey = false;
				colvarContent.IsForeignKey = false;
				colvarContent.IsReadOnly = false;
				colvarContent.DefaultSetting = @"";
				colvarContent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContent);
				
				TableSchema.TableColumn colvarPublishDate = new TableSchema.TableColumn(schema);
				colvarPublishDate.ColumnName = "PublishDate";
				colvarPublishDate.DataType = DbType.DateTime;
				colvarPublishDate.MaxLength = 0;
				colvarPublishDate.AutoIncrement = false;
				colvarPublishDate.IsNullable = true;
				colvarPublishDate.IsPrimaryKey = false;
				colvarPublishDate.IsForeignKey = false;
				colvarPublishDate.IsReadOnly = false;
				colvarPublishDate.DefaultSetting = @"";
				colvarPublishDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPublishDate);
				
				TableSchema.TableColumn colvarOperaterName = new TableSchema.TableColumn(schema);
				colvarOperaterName.ColumnName = "OperaterName";
				colvarOperaterName.DataType = DbType.AnsiString;
				colvarOperaterName.MaxLength = 50;
				colvarOperaterName.AutoIncrement = false;
				colvarOperaterName.IsNullable = true;
				colvarOperaterName.IsPrimaryKey = false;
				colvarOperaterName.IsForeignKey = false;
				colvarOperaterName.IsReadOnly = false;
				colvarOperaterName.DefaultSetting = @"";
				colvarOperaterName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOperaterName);
				
				TableSchema.TableColumn colvarSource = new TableSchema.TableColumn(schema);
				colvarSource.ColumnName = "Source";
				colvarSource.DataType = DbType.AnsiString;
				colvarSource.MaxLength = 50;
				colvarSource.AutoIncrement = false;
				colvarSource.IsNullable = true;
				colvarSource.IsPrimaryKey = false;
				colvarSource.IsForeignKey = false;
				colvarSource.IsReadOnly = false;
				colvarSource.DefaultSetting = @"";
				colvarSource.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSource);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDNews",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("NewsID")]
		[Bindable(true)]
		public int NewsID 
		{
			get { return GetColumnValue<int>(Columns.NewsID); }
			set { SetColumnValue(Columns.NewsID, value); }
		}
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int? ClassID 
		{
			get { return GetColumnValue<int?>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("Title")]
		[Bindable(true)]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }
			set { SetColumnValue(Columns.Title, value); }
		}
		  
		[XmlAttribute("Content")]
		[Bindable(true)]
		public string Content 
		{
			get { return GetColumnValue<string>(Columns.Content); }
			set { SetColumnValue(Columns.Content, value); }
		}
		  
		[XmlAttribute("PublishDate")]
		[Bindable(true)]
		public DateTime? PublishDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.PublishDate); }
			set { SetColumnValue(Columns.PublishDate, value); }
		}
		  
		[XmlAttribute("OperaterName")]
		[Bindable(true)]
		public string OperaterName 
		{
			get { return GetColumnValue<string>(Columns.OperaterName); }
			set { SetColumnValue(Columns.OperaterName, value); }
		}
		  
		[XmlAttribute("Source")]
		[Bindable(true)]
		public string Source 
		{
			get { return GetColumnValue<string>(Columns.Source); }
			set { SetColumnValue(Columns.Source, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varClassID,string varTitle,string varContent,DateTime? varPublishDate,string varOperaterName,string varSource)
		{
			DDNews item = new DDNews();
			
			item.ClassID = varClassID;
			
			item.Title = varTitle;
			
			item.Content = varContent;
			
			item.PublishDate = varPublishDate;
			
			item.OperaterName = varOperaterName;
			
			item.Source = varSource;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varNewsID,int? varClassID,string varTitle,string varContent,DateTime? varPublishDate,string varOperaterName,string varSource)
		{
			DDNews item = new DDNews();
			
				item.NewsID = varNewsID;
			
				item.ClassID = varClassID;
			
				item.Title = varTitle;
			
				item.Content = varContent;
			
				item.PublishDate = varPublishDate;
			
				item.OperaterName = varOperaterName;
			
				item.Source = varSource;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn NewsIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ContentColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PublishDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn OperaterNameColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SourceColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string NewsID = @"NewsID";
			 public static string ClassID = @"ClassID";
			 public static string Title = @"Title";
			 public static string Content = @"Content";
			 public static string PublishDate = @"PublishDate";
			 public static string OperaterName = @"OperaterName";
			 public static string Source = @"Source";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}