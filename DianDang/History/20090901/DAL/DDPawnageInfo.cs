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
	/// Strongly-typed collection for the DDPawnageInfo class.
	/// </summary>
    [Serializable]
	public partial class DDPawnageInfoCollection : ActiveList<DDPawnageInfo, DDPawnageInfoCollection>
	{	   
		public DDPawnageInfoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDPawnageInfoCollection</returns>
		public DDPawnageInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDPawnageInfo o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDPawnageInfo table.
	/// </summary>
	[Serializable]
	public partial class DDPawnageInfo : ActiveRecord<DDPawnageInfo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDPawnageInfo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDPawnageInfo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDPawnageInfo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDPawnageInfo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDPawnageInfo", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPawnageID = new TableSchema.TableColumn(schema);
				colvarPawnageID.ColumnName = "PawnageID";
				colvarPawnageID.DataType = DbType.Int32;
				colvarPawnageID.MaxLength = 0;
				colvarPawnageID.AutoIncrement = true;
				colvarPawnageID.IsNullable = false;
				colvarPawnageID.IsPrimaryKey = true;
				colvarPawnageID.IsForeignKey = false;
				colvarPawnageID.IsReadOnly = false;
				colvarPawnageID.DefaultSetting = @"";
				colvarPawnageID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPawnageID);
				
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
				
				TableSchema.TableColumn colvarCountNumber = new TableSchema.TableColumn(schema);
				colvarCountNumber.ColumnName = "CountNumber";
				colvarCountNumber.DataType = DbType.AnsiString;
				colvarCountNumber.MaxLength = 50;
				colvarCountNumber.AutoIncrement = false;
				colvarCountNumber.IsNullable = true;
				colvarCountNumber.IsPrimaryKey = false;
				colvarCountNumber.IsForeignKey = false;
				colvarCountNumber.IsReadOnly = false;
				colvarCountNumber.DefaultSetting = @"";
				colvarCountNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountNumber);
				
				TableSchema.TableColumn colvarPrice = new TableSchema.TableColumn(schema);
				colvarPrice.ColumnName = "Price";
				colvarPrice.DataType = DbType.AnsiString;
				colvarPrice.MaxLength = 50;
				colvarPrice.AutoIncrement = false;
				colvarPrice.IsNullable = true;
				colvarPrice.IsPrimaryKey = false;
				colvarPrice.IsForeignKey = false;
				colvarPrice.IsReadOnly = false;
				colvarPrice.DefaultSetting = @"";
				colvarPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrice);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "Amount";
				colvarAmount.DataType = DbType.AnsiString;
				colvarAmount.MaxLength = 50;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = true;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				colvarAmount.DefaultSetting = @"";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
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
				
				TableSchema.TableColumn colvarTicketID = new TableSchema.TableColumn(schema);
				colvarTicketID.ColumnName = "TicketID";
				colvarTicketID.DataType = DbType.Int32;
				colvarTicketID.MaxLength = 0;
				colvarTicketID.AutoIncrement = false;
				colvarTicketID.IsNullable = true;
				colvarTicketID.IsPrimaryKey = false;
				colvarTicketID.IsForeignKey = false;
				colvarTicketID.IsReadOnly = false;
				colvarTicketID.DefaultSetting = @"";
				colvarTicketID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTicketID);
				
				TableSchema.TableColumn colvarIsReif = new TableSchema.TableColumn(schema);
				colvarIsReif.ColumnName = "IsReif";
				colvarIsReif.DataType = DbType.Int32;
				colvarIsReif.MaxLength = 0;
				colvarIsReif.AutoIncrement = false;
				colvarIsReif.IsNullable = true;
				colvarIsReif.IsPrimaryKey = false;
				colvarIsReif.IsForeignKey = false;
				colvarIsReif.IsReadOnly = false;
				colvarIsReif.DefaultSetting = @"";
				colvarIsReif.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsReif);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDPawnageInfo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PawnageID")]
		[Bindable(true)]
		public int PawnageID 
		{
			get { return GetColumnValue<int>(Columns.PawnageID); }
			set { SetColumnValue(Columns.PawnageID, value); }
		}
		  
		[XmlAttribute("ClassID")]
		[Bindable(true)]
		public int? ClassID 
		{
			get { return GetColumnValue<int?>(Columns.ClassID); }
			set { SetColumnValue(Columns.ClassID, value); }
		}
		  
		[XmlAttribute("CountNumber")]
		[Bindable(true)]
		public string CountNumber 
		{
			get { return GetColumnValue<string>(Columns.CountNumber); }
			set { SetColumnValue(Columns.CountNumber, value); }
		}
		  
		[XmlAttribute("Price")]
		[Bindable(true)]
		public string Price 
		{
			get { return GetColumnValue<string>(Columns.Price); }
			set { SetColumnValue(Columns.Price, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public string Amount 
		{
			get { return GetColumnValue<string>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("TicketID")]
		[Bindable(true)]
		public int? TicketID 
		{
			get { return GetColumnValue<int?>(Columns.TicketID); }
			set { SetColumnValue(Columns.TicketID, value); }
		}
		  
		[XmlAttribute("IsReif")]
		[Bindable(true)]
		public int? IsReif 
		{
			get { return GetColumnValue<int?>(Columns.IsReif); }
			set { SetColumnValue(Columns.IsReif, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varClassID,string varCountNumber,string varPrice,string varAmount,string varDescription,int? varTicketID,int? varIsReif)
		{
			DDPawnageInfo item = new DDPawnageInfo();
			
			item.ClassID = varClassID;
			
			item.CountNumber = varCountNumber;
			
			item.Price = varPrice;
			
			item.Amount = varAmount;
			
			item.Description = varDescription;
			
			item.TicketID = varTicketID;
			
			item.IsReif = varIsReif;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPawnageID,int? varClassID,string varCountNumber,string varPrice,string varAmount,string varDescription,int? varTicketID,int? varIsReif)
		{
			DDPawnageInfo item = new DDPawnageInfo();
			
				item.PawnageID = varPawnageID;
			
				item.ClassID = varClassID;
			
				item.CountNumber = varCountNumber;
			
				item.Price = varPrice;
			
				item.Amount = varAmount;
			
				item.Description = varDescription;
			
				item.TicketID = varTicketID;
			
				item.IsReif = varIsReif;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PawnageIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CountNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PriceColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TicketIDColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IsReifColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PawnageID = @"PawnageID";
			 public static string ClassID = @"ClassID";
			 public static string CountNumber = @"CountNumber";
			 public static string Price = @"Price";
			 public static string Amount = @"Amount";
			 public static string Description = @"Description";
			 public static string TicketID = @"TicketID";
			 public static string IsReif = @"IsReif";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
