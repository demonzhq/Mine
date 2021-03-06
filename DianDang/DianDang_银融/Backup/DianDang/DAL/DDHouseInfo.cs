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
	/// Strongly-typed collection for the DDHouseInfo class.
	/// </summary>
    [Serializable]
	public partial class DDHouseInfoCollection : ActiveList<DDHouseInfo, DDHouseInfoCollection>
	{	   
		public DDHouseInfoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDHouseInfoCollection</returns>
		public DDHouseInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDHouseInfo o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDHouseInfo table.
	/// </summary>
	[Serializable]
	public partial class DDHouseInfo : ActiveRecord<DDHouseInfo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDHouseInfo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDHouseInfo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDHouseInfo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDHouseInfo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDHouseInfo", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarHouseID = new TableSchema.TableColumn(schema);
				colvarHouseID.ColumnName = "HouseID";
				colvarHouseID.DataType = DbType.Int32;
				colvarHouseID.MaxLength = 0;
				colvarHouseID.AutoIncrement = true;
				colvarHouseID.IsNullable = false;
				colvarHouseID.IsPrimaryKey = true;
				colvarHouseID.IsForeignKey = false;
				colvarHouseID.IsReadOnly = false;
				colvarHouseID.DefaultSetting = @"";
				colvarHouseID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHouseID);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.AnsiString;
				colvarAddress.MaxLength = 50;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarCompactNumber = new TableSchema.TableColumn(schema);
				colvarCompactNumber.ColumnName = "CompactNumber";
				colvarCompactNumber.DataType = DbType.AnsiString;
				colvarCompactNumber.MaxLength = 50;
				colvarCompactNumber.AutoIncrement = false;
				colvarCompactNumber.IsNullable = true;
				colvarCompactNumber.IsPrimaryKey = false;
				colvarCompactNumber.IsForeignKey = false;
				colvarCompactNumber.IsReadOnly = false;
				colvarCompactNumber.DefaultSetting = @"";
				colvarCompactNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompactNumber);
				
				TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
				colvarArea.ColumnName = "Area";
				colvarArea.DataType = DbType.AnsiString;
				colvarArea.MaxLength = 50;
				colvarArea.AutoIncrement = false;
				colvarArea.IsNullable = true;
				colvarArea.IsPrimaryKey = false;
				colvarArea.IsForeignKey = false;
				colvarArea.IsReadOnly = false;
				colvarArea.DefaultSetting = @"";
				colvarArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArea);
				
				TableSchema.TableColumn colvarRegisterDate = new TableSchema.TableColumn(schema);
				colvarRegisterDate.ColumnName = "RegisterDate";
				colvarRegisterDate.DataType = DbType.AnsiString;
				colvarRegisterDate.MaxLength = 50;
				colvarRegisterDate.AutoIncrement = false;
				colvarRegisterDate.IsNullable = true;
				colvarRegisterDate.IsPrimaryKey = false;
				colvarRegisterDate.IsForeignKey = false;
				colvarRegisterDate.IsReadOnly = false;
				colvarRegisterDate.DefaultSetting = @"";
				colvarRegisterDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegisterDate);
				
				TableSchema.TableColumn colvarInsuranceDate = new TableSchema.TableColumn(schema);
				colvarInsuranceDate.ColumnName = "InsuranceDate";
				colvarInsuranceDate.DataType = DbType.AnsiString;
				colvarInsuranceDate.MaxLength = 50;
				colvarInsuranceDate.AutoIncrement = false;
				colvarInsuranceDate.IsNullable = true;
				colvarInsuranceDate.IsPrimaryKey = false;
				colvarInsuranceDate.IsForeignKey = false;
				colvarInsuranceDate.IsReadOnly = false;
				colvarInsuranceDate.DefaultSetting = @"";
				colvarInsuranceDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsuranceDate);
				
				TableSchema.TableColumn colvarNotarizationDate = new TableSchema.TableColumn(schema);
				colvarNotarizationDate.ColumnName = "NotarizationDate";
				colvarNotarizationDate.DataType = DbType.AnsiString;
				colvarNotarizationDate.MaxLength = 50;
				colvarNotarizationDate.AutoIncrement = false;
				colvarNotarizationDate.IsNullable = true;
				colvarNotarizationDate.IsPrimaryKey = false;
				colvarNotarizationDate.IsForeignKey = false;
				colvarNotarizationDate.IsReadOnly = false;
				colvarNotarizationDate.DefaultSetting = @"";
				colvarNotarizationDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotarizationDate);
				
				TableSchema.TableColumn colvarPawnageID = new TableSchema.TableColumn(schema);
				colvarPawnageID.ColumnName = "PawnageID";
				colvarPawnageID.DataType = DbType.Int32;
				colvarPawnageID.MaxLength = 0;
				colvarPawnageID.AutoIncrement = false;
				colvarPawnageID.IsNullable = true;
				colvarPawnageID.IsPrimaryKey = false;
				colvarPawnageID.IsForeignKey = false;
				colvarPawnageID.IsReadOnly = false;
				colvarPawnageID.DefaultSetting = @"";
				colvarPawnageID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPawnageID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDHouseInfo",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("HouseID")]
		[Bindable(true)]
		public int HouseID 
		{
			get { return GetColumnValue<int>(Columns.HouseID); }
			set { SetColumnValue(Columns.HouseID, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("CompactNumber")]
		[Bindable(true)]
		public string CompactNumber 
		{
			get { return GetColumnValue<string>(Columns.CompactNumber); }
			set { SetColumnValue(Columns.CompactNumber, value); }
		}
		  
		[XmlAttribute("Area")]
		[Bindable(true)]
		public string Area 
		{
			get { return GetColumnValue<string>(Columns.Area); }
			set { SetColumnValue(Columns.Area, value); }
		}
		  
		[XmlAttribute("RegisterDate")]
		[Bindable(true)]
		public string RegisterDate 
		{
			get { return GetColumnValue<string>(Columns.RegisterDate); }
			set { SetColumnValue(Columns.RegisterDate, value); }
		}
		  
		[XmlAttribute("InsuranceDate")]
		[Bindable(true)]
		public string InsuranceDate 
		{
			get { return GetColumnValue<string>(Columns.InsuranceDate); }
			set { SetColumnValue(Columns.InsuranceDate, value); }
		}
		  
		[XmlAttribute("NotarizationDate")]
		[Bindable(true)]
		public string NotarizationDate 
		{
			get { return GetColumnValue<string>(Columns.NotarizationDate); }
			set { SetColumnValue(Columns.NotarizationDate, value); }
		}
		  
		[XmlAttribute("PawnageID")]
		[Bindable(true)]
		public int? PawnageID 
		{
			get { return GetColumnValue<int?>(Columns.PawnageID); }
			set { SetColumnValue(Columns.PawnageID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varAddress,string varCompactNumber,string varArea,string varRegisterDate,string varInsuranceDate,string varNotarizationDate,int? varPawnageID)
		{
			DDHouseInfo item = new DDHouseInfo();
			
			item.Address = varAddress;
			
			item.CompactNumber = varCompactNumber;
			
			item.Area = varArea;
			
			item.RegisterDate = varRegisterDate;
			
			item.InsuranceDate = varInsuranceDate;
			
			item.NotarizationDate = varNotarizationDate;
			
			item.PawnageID = varPawnageID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHouseID,string varAddress,string varCompactNumber,string varArea,string varRegisterDate,string varInsuranceDate,string varNotarizationDate,int? varPawnageID)
		{
			DDHouseInfo item = new DDHouseInfo();
			
				item.HouseID = varHouseID;
			
				item.Address = varAddress;
			
				item.CompactNumber = varCompactNumber;
			
				item.Area = varArea;
			
				item.RegisterDate = varRegisterDate;
			
				item.InsuranceDate = varInsuranceDate;
			
				item.NotarizationDate = varNotarizationDate;
			
				item.PawnageID = varPawnageID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HouseIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CompactNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn RegisterDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn InsuranceDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NotarizationDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PawnageIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string HouseID = @"HouseID";
			 public static string Address = @"Address";
			 public static string CompactNumber = @"CompactNumber";
			 public static string Area = @"Area";
			 public static string RegisterDate = @"RegisterDate";
			 public static string InsuranceDate = @"InsuranceDate";
			 public static string NotarizationDate = @"NotarizationDate";
			 public static string PawnageID = @"PawnageID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
