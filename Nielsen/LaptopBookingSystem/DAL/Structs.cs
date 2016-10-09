


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace LaptopBookingSystem {
	
        /// <summary>
        /// Table: NProjectSuperviserInfo
        /// Primary Key: Sid
        /// </summary>

        public class NProjectSuperviserInfoTable: DatabaseTable {
            
            public NProjectSuperviserInfoTable(IDataProvider provider):base("NProjectSuperviserInfo",provider){
                ClassName = "NProjectSuperviserInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Mobile", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("MailAddress", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn Mobile{
                get{
                    return this.GetColumn("Mobile");
                }
            }
				
   			public static string MobileColumn{
			      get{
        			return "Mobile";
      			}
		    }
            
            public IColumn MailAddress{
                get{
                    return this.GetColumn("MailAddress");
                }
            }
				
   			public static string MailAddressColumn{
			      get{
        			return "MailAddress";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NParameterCity
        /// Primary Key: Sid
        /// </summary>

        public class NParameterCityTable: DatabaseTable {
            
            public NParameterCityTable(IDataProvider provider):base("NParameterCity",provider){
                ClassName = "NParameterCity";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NProjectInfo
        /// Primary Key: Sid
        /// </summary>

        public class NProjectInfoTable: DatabaseTable {
            
            public NProjectInfoTable(IDataProvider provider):base("NProjectInfo",provider){
                ClassName = "NProjectInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProjectNumber", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("ProjectSuperviserInfoSid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProjectTypeSid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LaunchDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CloseDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn ProjectNumber{
                get{
                    return this.GetColumn("ProjectNumber");
                }
            }
				
   			public static string ProjectNumberColumn{
			      get{
        			return "ProjectNumber";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn ProjectSuperviserInfoSid{
                get{
                    return this.GetColumn("ProjectSuperviserInfoSid");
                }
            }
				
   			public static string ProjectSuperviserInfoSidColumn{
			      get{
        			return "ProjectSuperviserInfoSid";
      			}
		    }
            
            public IColumn ProjectTypeSid{
                get{
                    return this.GetColumn("ProjectTypeSid");
                }
            }
				
   			public static string ProjectTypeSidColumn{
			      get{
        			return "ProjectTypeSid";
      			}
		    }
            
            public IColumn LaunchDate{
                get{
                    return this.GetColumn("LaunchDate");
                }
            }
				
   			public static string LaunchDateColumn{
			      get{
        			return "LaunchDate";
      			}
		    }
            
            public IColumn CloseDate{
                get{
                    return this.GetColumn("CloseDate");
                }
            }
				
   			public static string CloseDateColumn{
			      get{
        			return "CloseDate";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NParameterProjectType
        /// Primary Key: Sid
        /// </summary>

        public class NParameterProjectTypeTable: DatabaseTable {
            
            public NParameterProjectTypeTable(IDataProvider provider):base("NParameterProjectType",provider){
                ClassName = "NParameterProjectType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProjectType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn ProjectType{
                get{
                    return this.GetColumn("ProjectType");
                }
            }
				
   			public static string ProjectTypeColumn{
			      get{
        			return "ProjectType";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NCompanyInfo
        /// Primary Key: Sid
        /// </summary>

        public class NCompanyInfoTable: DatabaseTable {
            
            public NCompanyInfoTable(IDataProvider provider):base("NCompanyInfo",provider){
                ClassName = "NCompanyInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("ParameterCitySid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isVender", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn Code{
                get{
                    return this.GetColumn("Code");
                }
            }
				
   			public static string CodeColumn{
			      get{
        			return "Code";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn ParameterCitySid{
                get{
                    return this.GetColumn("ParameterCitySid");
                }
            }
				
   			public static string ParameterCitySidColumn{
			      get{
        			return "ParameterCitySid";
      			}
		    }
            
            public IColumn isVender{
                get{
                    return this.GetColumn("isVender");
                }
            }
				
   			public static string isVenderColumn{
			      get{
        			return "isVender";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NLaptopType
        /// Primary Key: Sid
        /// </summary>

        public class NLaptopTypeTable: DatabaseTable {
            
            public NLaptopTypeTable(IDataProvider provider):base("NLaptopType",provider){
                ClassName = "NLaptopType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Brand", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Model", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Image", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Binary,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("isTouchScreen", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("BatteryCapacity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn Brand{
                get{
                    return this.GetColumn("Brand");
                }
            }
				
   			public static string BrandColumn{
			      get{
        			return "Brand";
      			}
		    }
            
            public IColumn Model{
                get{
                    return this.GetColumn("Model");
                }
            }
				
   			public static string ModelColumn{
			      get{
        			return "Model";
      			}
		    }
            
            public IColumn Image{
                get{
                    return this.GetColumn("Image");
                }
            }
				
   			public static string ImageColumn{
			      get{
        			return "Image";
      			}
		    }
            
            public IColumn isTouchScreen{
                get{
                    return this.GetColumn("isTouchScreen");
                }
            }
				
   			public static string isTouchScreenColumn{
			      get{
        			return "isTouchScreen";
      			}
		    }
            
            public IColumn BatteryCapacity{
                get{
                    return this.GetColumn("BatteryCapacity");
                }
            }
				
   			public static string BatteryCapacityColumn{
			      get{
        			return "BatteryCapacity";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NLaptopInfo
        /// Primary Key: Sid
        /// </summary>

        public class NLaptopInfoTable: DatabaseTable {
            
            public NLaptopInfoTable(IDataProvider provider):base("NLaptopInfo",provider){
                ClassName = "NLaptopInfo";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LaptopTypeSid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("NielsenAssetsNumber", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("LaptopSerial", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Price", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isComplete", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("PurchaseDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PurchaseCompanySid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn LaptopTypeSid{
                get{
                    return this.GetColumn("LaptopTypeSid");
                }
            }
				
   			public static string LaptopTypeSidColumn{
			      get{
        			return "LaptopTypeSid";
      			}
		    }
            
            public IColumn NielsenAssetsNumber{
                get{
                    return this.GetColumn("NielsenAssetsNumber");
                }
            }
				
   			public static string NielsenAssetsNumberColumn{
			      get{
        			return "NielsenAssetsNumber";
      			}
		    }
            
            public IColumn LaptopSerial{
                get{
                    return this.GetColumn("LaptopSerial");
                }
            }
				
   			public static string LaptopSerialColumn{
			      get{
        			return "LaptopSerial";
      			}
		    }
            
            public IColumn Price{
                get{
                    return this.GetColumn("Price");
                }
            }
				
   			public static string PriceColumn{
			      get{
        			return "Price";
      			}
		    }
            
            public IColumn isComplete{
                get{
                    return this.GetColumn("isComplete");
                }
            }
				
   			public static string isCompleteColumn{
			      get{
        			return "isComplete";
      			}
		    }
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
   			public static string RemarkColumn{
			      get{
        			return "Remark";
      			}
		    }
            
            public IColumn PurchaseDate{
                get{
                    return this.GetColumn("PurchaseDate");
                }
            }
				
   			public static string PurchaseDateColumn{
			      get{
        			return "PurchaseDate";
      			}
		    }
            
            public IColumn PurchaseCompanySid{
                get{
                    return this.GetColumn("PurchaseCompanySid");
                }
            }
				
   			public static string PurchaseCompanySidColumn{
			      get{
        			return "PurchaseCompanySid";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: NProjectAssignment
        /// Primary Key: Sid
        /// </summary>

        public class NProjectAssignmentTable: DatabaseTable {
            
            public NProjectAssignmentTable(IDataProvider provider):base("NProjectAssignment",provider){
                ClassName = "NProjectAssignment";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Sid", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isDeleted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn Sid{
                get{
                    return this.GetColumn("Sid");
                }
            }
				
   			public static string SidColumn{
			      get{
        			return "Sid";
      			}
		    }
            
            public IColumn isDeleted{
                get{
                    return this.GetColumn("isDeleted");
                }
            }
				
   			public static string isDeletedColumn{
			      get{
        			return "isDeleted";
      			}
		    }
            
                    
        }
        
}