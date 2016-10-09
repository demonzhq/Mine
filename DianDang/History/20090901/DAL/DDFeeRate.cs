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
	/// Strongly-typed collection for the DDFeeRate class.
	/// </summary>
    [Serializable]
	public partial class DDFeeRateCollection : ActiveList<DDFeeRate, DDFeeRateCollection>
	{	   
		public DDFeeRateCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDFeeRateCollection</returns>
		public DDFeeRateCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDFeeRate o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDFeeRate table.
	/// </summary>
	[Serializable]
	public partial class DDFeeRate : ActiveRecord<DDFeeRate>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDFeeRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDFeeRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDFeeRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDFeeRate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDFeeRate", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRateID = new TableSchema.TableColumn(schema);
				colvarRateID.ColumnName = "RateID";
				colvarRateID.DataType = DbType.Int32;
				colvarRateID.MaxLength = 0;
				colvarRateID.AutoIncrement = true;
				colvarRateID.IsNullable = false;
				colvarRateID.IsPrimaryKey = true;
				colvarRateID.IsForeignKey = false;
				colvarRateID.IsReadOnly = false;
				colvarRateID.DefaultSetting = @"";
				colvarRateID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRateID);
				
				TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
				colvarRate.ColumnName = "Rate";
				colvarRate.DataType = DbType.AnsiString;
				colvarRate.MaxLength = 50;
				colvarRate.AutoIncrement = false;
				colvarRate.IsNullable = true;
				colvarRate.IsPrimaryKey = false;
				colvarRate.IsForeignKey = false;
				colvarRate.IsReadOnly = false;
				colvarRate.DefaultSetting = @"";
				colvarRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRate);
				
				TableSchema.TableColumn colvarRateType = new TableSchema.TableColumn(schema);
				colvarRateType.ColumnName = "RateType";
				colvarRateType.DataType = DbType.Int32;
				colvarRateType.MaxLength = 0;
				colvarRateType.AutoIncrement = false;
				colvarRateType.IsNullable = true;
				colvarRateType.IsPrimaryKey = false;
				colvarRateType.IsForeignKey = false;
				colvarRateType.IsReadOnly = false;
				colvarRateType.DefaultSetting = @"";
				colvarRateType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRateType);
				
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
				DataService.Providers["DianDang"].AddSchema("DDFeeRate",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RateID")]
		[Bindable(true)]
		public int RateID 
		{
			get { return GetColumnValue<int>(Columns.RateID); }
			set { SetColumnValue(Columns.RateID, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public string Rate 
		{
			get { return GetColumnValue<string>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("RateType")]
		[Bindable(true)]
		public int? RateType 
		{
			get { return GetColumnValue<int?>(Columns.RateType); }
			set { SetColumnValue(Columns.RateType, value); }
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
		public static void Insert(string varRate,int? varRateType,string varDescription)
		{
			DDFeeRate item = new DDFeeRate();
			
			item.Rate = varRate;
			
			item.RateType = varRateType;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varRateID,string varRate,int? varRateType,string varDescription)
		{
			DDFeeRate item = new DDFeeRate();
			
				item.RateID = varRateID;
			
				item.Rate = varRate;
			
				item.RateType = varRateType;
			
				item.Description = varDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RateIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RateTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RateID = @"RateID";
			 public static string Rate = @"Rate";
			 public static string RateType = @"RateType";
			 public static string Description = @"Description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
