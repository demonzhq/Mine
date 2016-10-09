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
namespace DianDang{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the dt_addtosourcecontrol Procedure
        /// </summary>
        public static StoredProcedure DtAddtosourcecontrol(string vchSourceSafeINI, string vchProjectName, string vchComment, string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_addtosourcecontrol", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchSourceSafeINI", vchSourceSafeINI, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchProjectName", vchProjectName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_addtosourcecontrol_u Procedure
        /// </summary>
        public static StoredProcedure DtAddtosourcecontrolU(string vchSourceSafeINI, string vchProjectName, string vchComment, string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_addtosourcecontrol_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchSourceSafeINI", vchSourceSafeINI, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchProjectName", vchProjectName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_adduserobject Procedure
        /// </summary>
        public static StoredProcedure DtAdduserobject()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_adduserobject", DataService.GetInstance("DianDang"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_adduserobject_vcs Procedure
        /// </summary>
        public static StoredProcedure DtAdduserobjectVcs(string vchProperty)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_adduserobject_vcs", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchProperty", vchProperty, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_checkinobject Procedure
        /// </summary>
        public static StoredProcedure DtCheckinobject(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, int? iVCSFlags, int? iActionFlag, string txStream1, string txStream2, string txStream3)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_checkinobject", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@iVCSFlags", iVCSFlags, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iActionFlag", iActionFlag, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@txStream1", txStream1, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@txStream2", txStream2, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@txStream3", txStream3, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_checkinobject_u Procedure
        /// </summary>
        public static StoredProcedure DtCheckinobjectU(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, int? iVCSFlags, int? iActionFlag, string txStream1, string txStream2, string txStream3)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_checkinobject_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@iVCSFlags", iVCSFlags, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iActionFlag", iActionFlag, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@txStream1", txStream1, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@txStream2", txStream2, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@txStream3", txStream3, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_checkoutobject Procedure
        /// </summary>
        public static StoredProcedure DtCheckoutobject(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, int? iVCSFlags, int? iActionFlag)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_checkoutobject", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@iVCSFlags", iVCSFlags, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iActionFlag", iActionFlag, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_checkoutobject_u Procedure
        /// </summary>
        public static StoredProcedure DtCheckoutobjectU(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, int? iVCSFlags, int? iActionFlag)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_checkoutobject_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchComment", vchComment, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@iVCSFlags", iVCSFlags, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iActionFlag", iActionFlag, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_displayoaerror Procedure
        /// </summary>
        public static StoredProcedure DtDisplayoaerror(int? iObject, int? iresult)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_displayoaerror", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@iObject", iObject, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iresult", iresult, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_displayoaerror_u Procedure
        /// </summary>
        public static StoredProcedure DtDisplayoaerrorU(int? iObject, int? iresult)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_displayoaerror_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@iObject", iObject, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@iresult", iresult, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_droppropertiesbyid Procedure
        /// </summary>
        public static StoredProcedure DtDroppropertiesbyid(int? id, string propertyX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_droppropertiesbyid", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_dropuserobjectbyid Procedure
        /// </summary>
        public static StoredProcedure DtDropuserobjectbyid(int? id)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_dropuserobjectbyid", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_generateansiname Procedure
        /// </summary>
        public static StoredProcedure DtGenerateansiname(string name)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_generateansiname", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddOutputParameter("@name", DbType.AnsiString, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getobjwithprop Procedure
        /// </summary>
        public static StoredProcedure DtGetobjwithprop(string propertyX, string valueX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getobjwithprop", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@value", valueX, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getobjwithprop_u Procedure
        /// </summary>
        public static StoredProcedure DtGetobjwithpropU(string propertyX, string uvalue)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getobjwithprop_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@uvalue", uvalue, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getpropertiesbyid Procedure
        /// </summary>
        public static StoredProcedure DtGetpropertiesbyid(int? id, string propertyX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getpropertiesbyid", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getpropertiesbyid_u Procedure
        /// </summary>
        public static StoredProcedure DtGetpropertiesbyidU(int? id, string propertyX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getpropertiesbyid_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getpropertiesbyid_vcs Procedure
        /// </summary>
        public static StoredProcedure DtGetpropertiesbyidVcs(int? id, string propertyX, string valueX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getpropertiesbyid_vcs", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddOutputParameter("@value", DbType.AnsiString, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_getpropertiesbyid_vcs_u Procedure
        /// </summary>
        public static StoredProcedure DtGetpropertiesbyidVcsU(int? id, string propertyX, string valueX)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_getpropertiesbyid_vcs_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddOutputParameter("@value", DbType.String, null, null);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_isundersourcecontrol Procedure
        /// </summary>
        public static StoredProcedure DtIsundersourcecontrol(string vchLoginName, string vchPassword, int? iWhoToo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_isundersourcecontrol", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@iWhoToo", iWhoToo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_isundersourcecontrol_u Procedure
        /// </summary>
        public static StoredProcedure DtIsundersourcecontrolU(string vchLoginName, string vchPassword, int? iWhoToo)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_isundersourcecontrol_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@iWhoToo", iWhoToo, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_removefromsourcecontrol Procedure
        /// </summary>
        public static StoredProcedure DtRemovefromsourcecontrol()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_removefromsourcecontrol", DataService.GetInstance("DianDang"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_setpropertybyid Procedure
        /// </summary>
        public static StoredProcedure DtSetpropertybyid(int? id, string propertyX, string valueX, byte[] lvalue)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_setpropertybyid", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@value", valueX, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@lvalue", lvalue, DbType.Binary, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_setpropertybyid_u Procedure
        /// </summary>
        public static StoredProcedure DtSetpropertybyidU(int? id, string propertyX, string uvalue, byte[] lvalue)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_setpropertybyid_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@id", id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@property", propertyX, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@uvalue", uvalue, DbType.String, null, null);
        	
            sp.Command.AddParameter("@lvalue", lvalue, DbType.Binary, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_validateloginparams Procedure
        /// </summary>
        public static StoredProcedure DtValidateloginparams(string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_validateloginparams", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_validateloginparams_u Procedure
        /// </summary>
        public static StoredProcedure DtValidateloginparamsU(string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_validateloginparams_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_vcsenabled Procedure
        /// </summary>
        public static StoredProcedure DtVcsenabled()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_vcsenabled", DataService.GetInstance("DianDang"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_verstamp006 Procedure
        /// </summary>
        public static StoredProcedure DtVerstamp006()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_verstamp006", DataService.GetInstance("DianDang"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_whocheckedout Procedure
        /// </summary>
        public static StoredProcedure DtWhocheckedout(string chObjectType, string vchObjectName, string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_whocheckedout", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.AnsiString, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.AnsiString, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the dt_whocheckedout_u Procedure
        /// </summary>
        public static StoredProcedure DtWhocheckedoutU(string chObjectType, string vchObjectName, string vchLoginName, string vchPassword)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("dt_whocheckedout_u", DataService.GetInstance("DianDang"), "dbo");
        	
            sp.Command.AddParameter("@chObjectType", chObjectType, DbType.AnsiStringFixedLength, null, null);
        	
            sp.Command.AddParameter("@vchObjectName", vchObjectName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchLoginName", vchLoginName, DbType.String, null, null);
        	
            sp.Command.AddParameter("@vchPassword", vchPassword, DbType.String, null, null);
        	
            return sp;
        }
        
    }
    
}
