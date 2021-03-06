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
	/// Strongly-typed collection for the DDPawnTicket class.
	/// </summary>
    [Serializable]
	public partial class DDPawnTicketCollection : ActiveList<DDPawnTicket, DDPawnTicketCollection>
	{	   
		public DDPawnTicketCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDPawnTicketCollection</returns>
		public DDPawnTicketCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDPawnTicket o = this[i];
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
	/// This is an ActiveRecord class which wraps the DDPawnTicket table.
	/// </summary>
	[Serializable]
	public partial class DDPawnTicket : ActiveRecord<DDPawnTicket>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDPawnTicket()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDPawnTicket(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDPawnTicket(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDPawnTicket(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DDPawnTicket", TableType.Table, DataService.GetInstance("DianDang"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTicketID = new TableSchema.TableColumn(schema);
				colvarTicketID.ColumnName = "TicketID";
				colvarTicketID.DataType = DbType.Int32;
				colvarTicketID.MaxLength = 0;
				colvarTicketID.AutoIncrement = true;
				colvarTicketID.IsNullable = false;
				colvarTicketID.IsPrimaryKey = true;
				colvarTicketID.IsForeignKey = false;
				colvarTicketID.IsReadOnly = false;
				colvarTicketID.DefaultSetting = @"";
				colvarTicketID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTicketID);
				
				TableSchema.TableColumn colvarCompanyID = new TableSchema.TableColumn(schema);
				colvarCompanyID.ColumnName = "CompanyID";
				colvarCompanyID.DataType = DbType.Int32;
				colvarCompanyID.MaxLength = 0;
				colvarCompanyID.AutoIncrement = false;
				colvarCompanyID.IsNullable = true;
				colvarCompanyID.IsPrimaryKey = false;
				colvarCompanyID.IsForeignKey = false;
				colvarCompanyID.IsReadOnly = false;
				colvarCompanyID.DefaultSetting = @"";
				colvarCompanyID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCompanyID);
				
				TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
				colvarCustomerID.ColumnName = "CustomerID";
				colvarCustomerID.DataType = DbType.Int32;
				colvarCustomerID.MaxLength = 0;
				colvarCustomerID.AutoIncrement = false;
				colvarCustomerID.IsNullable = true;
				colvarCustomerID.IsPrimaryKey = false;
				colvarCustomerID.IsForeignKey = false;
				colvarCustomerID.IsReadOnly = false;
				colvarCustomerID.DefaultSetting = @"";
				colvarCustomerID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomerID);
				
				TableSchema.TableColumn colvarStatusID = new TableSchema.TableColumn(schema);
				colvarStatusID.ColumnName = "StatusID";
				colvarStatusID.DataType = DbType.Int32;
				colvarStatusID.MaxLength = 0;
				colvarStatusID.AutoIncrement = false;
				colvarStatusID.IsNullable = true;
				colvarStatusID.IsPrimaryKey = false;
				colvarStatusID.IsForeignKey = false;
				colvarStatusID.IsReadOnly = false;
				colvarStatusID.DefaultSetting = @"";
				colvarStatusID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatusID);
				
				TableSchema.TableColumn colvarTicketNumber = new TableSchema.TableColumn(schema);
				colvarTicketNumber.ColumnName = "TicketNumber";
				colvarTicketNumber.DataType = DbType.AnsiString;
				colvarTicketNumber.MaxLength = 50;
				colvarTicketNumber.AutoIncrement = false;
				colvarTicketNumber.IsNullable = true;
				colvarTicketNumber.IsPrimaryKey = false;
				colvarTicketNumber.IsForeignKey = false;
				colvarTicketNumber.IsReadOnly = false;
				colvarTicketNumber.DefaultSetting = @"";
				colvarTicketNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTicketNumber);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.AnsiString;
				colvarStartDate.MaxLength = 50;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = true;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
				colvarEndDate.ColumnName = "EndDate";
				colvarEndDate.DataType = DbType.AnsiString;
				colvarEndDate.MaxLength = 50;
				colvarEndDate.AutoIncrement = false;
				colvarEndDate.IsNullable = true;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarOperateDate = new TableSchema.TableColumn(schema);
				colvarOperateDate.ColumnName = "OperateDate";
				colvarOperateDate.DataType = DbType.AnsiString;
				colvarOperateDate.MaxLength = 50;
				colvarOperateDate.AutoIncrement = false;
				colvarOperateDate.IsNullable = true;
				colvarOperateDate.IsPrimaryKey = false;
				colvarOperateDate.IsForeignKey = false;
				colvarOperateDate.IsReadOnly = false;
				colvarOperateDate.DefaultSetting = @"";
				colvarOperateDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOperateDate);
				
				TableSchema.TableColumn colvarRemark = new TableSchema.TableColumn(schema);
				colvarRemark.ColumnName = "Remark";
				colvarRemark.DataType = DbType.AnsiString;
				colvarRemark.MaxLength = 50;
				colvarRemark.AutoIncrement = false;
				colvarRemark.IsNullable = true;
				colvarRemark.IsPrimaryKey = false;
				colvarRemark.IsForeignKey = false;
				colvarRemark.IsReadOnly = false;
				colvarRemark.DefaultSetting = @"";
				colvarRemark.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRemark);
				
				TableSchema.TableColumn colvarOperatorID = new TableSchema.TableColumn(schema);
				colvarOperatorID.ColumnName = "OperatorID";
				colvarOperatorID.DataType = DbType.Int32;
				colvarOperatorID.MaxLength = 0;
				colvarOperatorID.AutoIncrement = false;
				colvarOperatorID.IsNullable = true;
				colvarOperatorID.IsPrimaryKey = false;
				colvarOperatorID.IsForeignKey = false;
				colvarOperatorID.IsReadOnly = false;
				colvarOperatorID.DefaultSetting = @"";
				colvarOperatorID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOperatorID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DianDang"].AddSchema("DDPawnTicket",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TicketID")]
		[Bindable(true)]
		public int TicketID 
		{
			get { return GetColumnValue<int>(Columns.TicketID); }
			set { SetColumnValue(Columns.TicketID, value); }
		}
		  
		[XmlAttribute("CompanyID")]
		[Bindable(true)]
		public int? CompanyID 
		{
			get { return GetColumnValue<int?>(Columns.CompanyID); }
			set { SetColumnValue(Columns.CompanyID, value); }
		}
		  
		[XmlAttribute("CustomerID")]
		[Bindable(true)]
		public int? CustomerID 
		{
			get { return GetColumnValue<int?>(Columns.CustomerID); }
			set { SetColumnValue(Columns.CustomerID, value); }
		}
		  
		[XmlAttribute("StatusID")]
		[Bindable(true)]
		public int? StatusID 
		{
			get { return GetColumnValue<int?>(Columns.StatusID); }
			set { SetColumnValue(Columns.StatusID, value); }
		}
		  
		[XmlAttribute("TicketNumber")]
		[Bindable(true)]
		public string TicketNumber 
		{
			get { return GetColumnValue<string>(Columns.TicketNumber); }
			set { SetColumnValue(Columns.TicketNumber, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public string StartDate 
		{
			get { return GetColumnValue<string>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("EndDate")]
		[Bindable(true)]
		public string EndDate 
		{
			get { return GetColumnValue<string>(Columns.EndDate); }
			set { SetColumnValue(Columns.EndDate, value); }
		}
		  
		[XmlAttribute("OperateDate")]
		[Bindable(true)]
		public string OperateDate 
		{
			get { return GetColumnValue<string>(Columns.OperateDate); }
			set { SetColumnValue(Columns.OperateDate, value); }
		}
		  
		[XmlAttribute("Remark")]
		[Bindable(true)]
		public string Remark 
		{
			get { return GetColumnValue<string>(Columns.Remark); }
			set { SetColumnValue(Columns.Remark, value); }
		}
		  
		[XmlAttribute("OperatorID")]
		[Bindable(true)]
		public int? OperatorID 
		{
			get { return GetColumnValue<int?>(Columns.OperatorID); }
			set { SetColumnValue(Columns.OperatorID, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCompanyID,int? varCustomerID,int? varStatusID,string varTicketNumber,string varStartDate,string varEndDate,string varOperateDate,string varRemark,int? varOperatorID)
		{
			DDPawnTicket item = new DDPawnTicket();
			
			item.CompanyID = varCompanyID;
			
			item.CustomerID = varCustomerID;
			
			item.StatusID = varStatusID;
			
			item.TicketNumber = varTicketNumber;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.OperateDate = varOperateDate;
			
			item.Remark = varRemark;
			
			item.OperatorID = varOperatorID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTicketID,int? varCompanyID,int? varCustomerID,int? varStatusID,string varTicketNumber,string varStartDate,string varEndDate,string varOperateDate,string varRemark,int? varOperatorID)
		{
			DDPawnTicket item = new DDPawnTicket();
			
				item.TicketID = varTicketID;
			
				item.CompanyID = varCompanyID;
			
				item.CustomerID = varCustomerID;
			
				item.StatusID = varStatusID;
			
				item.TicketNumber = varTicketNumber;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.OperateDate = varOperateDate;
			
				item.Remark = varRemark;
			
				item.OperatorID = varOperatorID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TicketIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CompanyIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CustomerIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TicketNumberColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn OperateDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RemarkColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn OperatorIDColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TicketID = @"TicketID";
			 public static string CompanyID = @"CompanyID";
			 public static string CustomerID = @"CustomerID";
			 public static string StatusID = @"StatusID";
			 public static string TicketNumber = @"TicketNumber";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string OperateDate = @"OperateDate";
			 public static string Remark = @"Remark";
			 public static string OperatorID = @"OperatorID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
