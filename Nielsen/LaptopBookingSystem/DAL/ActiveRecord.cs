


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace LaptopBookingSystem
{
    
    
    /// <summary>
    /// A class which represents the NProjectSuperviserInfo table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NProjectSuperviserInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NProjectSuperviserInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NProjectSuperviserInfo>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NProjectSuperviserInfo> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NProjectSuperviserInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NProjectSuperviserInfo item=new NProjectSuperviserInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NProjectSuperviserInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NProjectSuperviserInfo(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NProjectSuperviserInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectSuperviserInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NProjectSuperviserInfo(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NProjectSuperviserInfo(Expression<Func<NProjectSuperviserInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NProjectSuperviserInfo> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NProjectSuperviserInfo> _repo;
            
            if(db.TestMode){
                NProjectSuperviserInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectSuperviserInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NProjectSuperviserInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static NProjectSuperviserInfo SingleOrDefault(Expression<Func<NProjectSuperviserInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NProjectSuperviserInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NProjectSuperviserInfo SingleOrDefault(Expression<Func<NProjectSuperviserInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NProjectSuperviserInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NProjectSuperviserInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NProjectSuperviserInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NProjectSuperviserInfo> Find(Expression<Func<NProjectSuperviserInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NProjectSuperviserInfo> Find(Expression<Func<NProjectSuperviserInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NProjectSuperviserInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NProjectSuperviserInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NProjectSuperviserInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NProjectSuperviserInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NProjectSuperviserInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NProjectSuperviserInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NProjectSuperviserInfo)){
                NProjectSuperviserInfo compare=(NProjectSuperviserInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                if(_Mobile!=value){
                    _Mobile=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Mobile");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MailAddress;
        public string MailAddress
        {
            get { return _MailAddress; }
            set
            {
                if(_MailAddress!=value){
                    _MailAddress=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MailAddress");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NProjectSuperviserInfo, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NProjectSuperviserInfo> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NProjectSuperviserInfo, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NParameterCity table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NParameterCity: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NParameterCity> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NParameterCity>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NParameterCity> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NParameterCity item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NParameterCity item=new NParameterCity();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NParameterCity> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NParameterCity(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NParameterCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NParameterCity>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NParameterCity(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NParameterCity(Expression<Func<NParameterCity, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NParameterCity> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NParameterCity> _repo;
            
            if(db.TestMode){
                NParameterCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NParameterCity>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NParameterCity> GetRepo(){
            return GetRepo("","");
        }
        
        public static NParameterCity SingleOrDefault(Expression<Func<NParameterCity, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NParameterCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NParameterCity SingleOrDefault(Expression<Func<NParameterCity, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NParameterCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NParameterCity, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NParameterCity, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NParameterCity> Find(Expression<Func<NParameterCity, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NParameterCity> Find(Expression<Func<NParameterCity, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NParameterCity> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NParameterCity> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NParameterCity> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NParameterCity> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NParameterCity> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NParameterCity> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.City.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NParameterCity)){
                NParameterCity compare=(NParameterCity)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.City.ToString();
                    }

        public string DescriptorColumn() {
            return "City";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "City";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if(_City!=value){
                    _City=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="City");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _isDeleted;
        public bool isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NParameterCity, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NParameterCity> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NParameterCity, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NProjectInfo table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NProjectInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NProjectInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NProjectInfo>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NProjectInfo> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NProjectInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NProjectInfo item=new NProjectInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NProjectInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NProjectInfo(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NProjectInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NProjectInfo(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NProjectInfo(Expression<Func<NProjectInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NProjectInfo> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NProjectInfo> _repo;
            
            if(db.TestMode){
                NProjectInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NProjectInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static NProjectInfo SingleOrDefault(Expression<Func<NProjectInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NProjectInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NProjectInfo SingleOrDefault(Expression<Func<NProjectInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NProjectInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NProjectInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NProjectInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NProjectInfo> Find(Expression<Func<NProjectInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NProjectInfo> Find(Expression<Func<NProjectInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NProjectInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NProjectInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NProjectInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NProjectInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NProjectInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NProjectInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ProjectNumber.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NProjectInfo)){
                NProjectInfo compare=(NProjectInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.ProjectNumber.ToString();
                    }

        public string DescriptorColumn() {
            return "ProjectNumber";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "ProjectNumber";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ProjectNumber;
        public string ProjectNumber
        {
            get { return _ProjectNumber; }
            set
            {
                if(_ProjectNumber!=value){
                    _ProjectNumber=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProjectNumber");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ProjectSuperviserInfoSid;
        public int? ProjectSuperviserInfoSid
        {
            get { return _ProjectSuperviserInfoSid; }
            set
            {
                if(_ProjectSuperviserInfoSid!=value){
                    _ProjectSuperviserInfoSid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProjectSuperviserInfoSid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ProjectTypeSid;
        public int? ProjectTypeSid
        {
            get { return _ProjectTypeSid; }
            set
            {
                if(_ProjectTypeSid!=value){
                    _ProjectTypeSid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProjectTypeSid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _LaunchDate;
        public DateTime? LaunchDate
        {
            get { return _LaunchDate; }
            set
            {
                if(_LaunchDate!=value){
                    _LaunchDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LaunchDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CloseDate;
        public DateTime? CloseDate
        {
            get { return _CloseDate; }
            set
            {
                if(_CloseDate!=value){
                    _CloseDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CloseDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NProjectInfo, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NProjectInfo> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NProjectInfo, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NParameterProjectType table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NParameterProjectType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NParameterProjectType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NParameterProjectType>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NParameterProjectType> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NParameterProjectType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NParameterProjectType item=new NParameterProjectType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NParameterProjectType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NParameterProjectType(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NParameterProjectType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NParameterProjectType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NParameterProjectType(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NParameterProjectType(Expression<Func<NParameterProjectType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NParameterProjectType> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NParameterProjectType> _repo;
            
            if(db.TestMode){
                NParameterProjectType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NParameterProjectType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NParameterProjectType> GetRepo(){
            return GetRepo("","");
        }
        
        public static NParameterProjectType SingleOrDefault(Expression<Func<NParameterProjectType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NParameterProjectType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NParameterProjectType SingleOrDefault(Expression<Func<NParameterProjectType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NParameterProjectType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NParameterProjectType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NParameterProjectType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NParameterProjectType> Find(Expression<Func<NParameterProjectType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NParameterProjectType> Find(Expression<Func<NParameterProjectType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NParameterProjectType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NParameterProjectType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NParameterProjectType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NParameterProjectType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NParameterProjectType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NParameterProjectType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ProjectType.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NParameterProjectType)){
                NParameterProjectType compare=(NParameterProjectType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.ProjectType.ToString();
                    }

        public string DescriptorColumn() {
            return "ProjectType";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "ProjectType";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ProjectType;
        public string ProjectType
        {
            get { return _ProjectType; }
            set
            {
                if(_ProjectType!=value){
                    _ProjectType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProjectType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NParameterProjectType, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NParameterProjectType> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NParameterProjectType, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NCompanyInfo table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NCompanyInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NCompanyInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NCompanyInfo>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NCompanyInfo> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NCompanyInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NCompanyInfo item=new NCompanyInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NCompanyInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NCompanyInfo(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NCompanyInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NCompanyInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NCompanyInfo(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NCompanyInfo(Expression<Func<NCompanyInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NCompanyInfo> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NCompanyInfo> _repo;
            
            if(db.TestMode){
                NCompanyInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NCompanyInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NCompanyInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static NCompanyInfo SingleOrDefault(Expression<Func<NCompanyInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NCompanyInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NCompanyInfo SingleOrDefault(Expression<Func<NCompanyInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NCompanyInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NCompanyInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NCompanyInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NCompanyInfo> Find(Expression<Func<NCompanyInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NCompanyInfo> Find(Expression<Func<NCompanyInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NCompanyInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NCompanyInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NCompanyInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NCompanyInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NCompanyInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NCompanyInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Code.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NCompanyInfo)){
                NCompanyInfo compare=(NCompanyInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.Code.ToString();
                    }

        public string DescriptorColumn() {
            return "Code";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "Code";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Code;
        public string Code
        {
            get { return _Code; }
            set
            {
                if(_Code!=value){
                    _Code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ParameterCitySid;
        public int? ParameterCitySid
        {
            get { return _ParameterCitySid; }
            set
            {
                if(_ParameterCitySid!=value){
                    _ParameterCitySid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParameterCitySid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isVender;
        public bool? isVender
        {
            get { return _isVender; }
            set
            {
                if(_isVender!=value){
                    _isVender=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isVender");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NCompanyInfo, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NCompanyInfo> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NCompanyInfo, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NLaptopType table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NLaptopType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NLaptopType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NLaptopType>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NLaptopType> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NLaptopType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NLaptopType item=new NLaptopType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NLaptopType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NLaptopType(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NLaptopType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NLaptopType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NLaptopType(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NLaptopType(Expression<Func<NLaptopType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NLaptopType> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NLaptopType> _repo;
            
            if(db.TestMode){
                NLaptopType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NLaptopType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NLaptopType> GetRepo(){
            return GetRepo("","");
        }
        
        public static NLaptopType SingleOrDefault(Expression<Func<NLaptopType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NLaptopType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NLaptopType SingleOrDefault(Expression<Func<NLaptopType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NLaptopType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NLaptopType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NLaptopType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NLaptopType> Find(Expression<Func<NLaptopType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NLaptopType> Find(Expression<Func<NLaptopType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NLaptopType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NLaptopType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NLaptopType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NLaptopType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NLaptopType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NLaptopType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Brand.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NLaptopType)){
                NLaptopType compare=(NLaptopType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.Brand.ToString();
                    }

        public string DescriptorColumn() {
            return "Brand";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "Brand";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Brand;
        public string Brand
        {
            get { return _Brand; }
            set
            {
                if(_Brand!=value){
                    _Brand=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Brand");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Model;
        public string Model
        {
            get { return _Model; }
            set
            {
                if(_Model!=value){
                    _Model=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Model");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte[] _Image;
        public byte[] Image
        {
            get { return _Image; }
            set
            {
                if(_Image!=value){
                    _Image=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Image");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isTouchScreen;
        public bool? isTouchScreen
        {
            get { return _isTouchScreen; }
            set
            {
                if(_isTouchScreen!=value){
                    _isTouchScreen=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isTouchScreen");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _BatteryCapacity;
        public int? BatteryCapacity
        {
            get { return _BatteryCapacity; }
            set
            {
                if(_BatteryCapacity!=value){
                    _BatteryCapacity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BatteryCapacity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NLaptopType, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NLaptopType> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NLaptopType, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NLaptopInfo table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NLaptopInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NLaptopInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NLaptopInfo>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NLaptopInfo> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NLaptopInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NLaptopInfo item=new NLaptopInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NLaptopInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NLaptopInfo(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NLaptopInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NLaptopInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NLaptopInfo(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NLaptopInfo(Expression<Func<NLaptopInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NLaptopInfo> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NLaptopInfo> _repo;
            
            if(db.TestMode){
                NLaptopInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NLaptopInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NLaptopInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static NLaptopInfo SingleOrDefault(Expression<Func<NLaptopInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NLaptopInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NLaptopInfo SingleOrDefault(Expression<Func<NLaptopInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NLaptopInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NLaptopInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NLaptopInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NLaptopInfo> Find(Expression<Func<NLaptopInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NLaptopInfo> Find(Expression<Func<NLaptopInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NLaptopInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NLaptopInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NLaptopInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NLaptopInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NLaptopInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NLaptopInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.NielsenAssetsNumber.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NLaptopInfo)){
                NLaptopInfo compare=(NLaptopInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.NielsenAssetsNumber.ToString();
                    }

        public string DescriptorColumn() {
            return "NielsenAssetsNumber";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "NielsenAssetsNumber";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _LaptopTypeSid;
        public int? LaptopTypeSid
        {
            get { return _LaptopTypeSid; }
            set
            {
                if(_LaptopTypeSid!=value){
                    _LaptopTypeSid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LaptopTypeSid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NielsenAssetsNumber;
        public string NielsenAssetsNumber
        {
            get { return _NielsenAssetsNumber; }
            set
            {
                if(_NielsenAssetsNumber!=value){
                    _NielsenAssetsNumber=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NielsenAssetsNumber");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LaptopSerial;
        public string LaptopSerial
        {
            get { return _LaptopSerial; }
            set
            {
                if(_LaptopSerial!=value){
                    _LaptopSerial=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LaptopSerial");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Price;
        public int? Price
        {
            get { return _Price; }
            set
            {
                if(_Price!=value){
                    _Price=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Price");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isComplete;
        public bool? isComplete
        {
            get { return _isComplete; }
            set
            {
                if(_isComplete!=value){
                    _isComplete=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isComplete");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _PurchaseDate;
        public DateTime? PurchaseDate
        {
            get { return _PurchaseDate; }
            set
            {
                if(_PurchaseDate!=value){
                    _PurchaseDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PurchaseDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PurchaseCompanySid;
        public int? PurchaseCompanySid
        {
            get { return _PurchaseCompanySid; }
            set
            {
                if(_PurchaseCompanySid!=value){
                    _PurchaseCompanySid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PurchaseCompanySid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NLaptopInfo, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NLaptopInfo> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NLaptopInfo, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the NProjectAssignment table in the NielsenLaptopBookingSystem Database.
    /// </summary>
    public partial class NProjectAssignment: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<NProjectAssignment> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<NProjectAssignment>(new LaptopBookingSystem.NielsenLaptopBookingSystemDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<NProjectAssignment> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(NProjectAssignment item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                NProjectAssignment item=new NProjectAssignment();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<NProjectAssignment> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LaptopBookingSystem.NielsenLaptopBookingSystemDB _db;
        public NProjectAssignment(string connectionString, string providerName) {

            _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                NProjectAssignment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectAssignment>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public NProjectAssignment(){
             _db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public NProjectAssignment(Expression<Func<NProjectAssignment, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<NProjectAssignment> GetRepo(string connectionString, string providerName){
            LaptopBookingSystem.NielsenLaptopBookingSystemDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB();
            }else{
                db=new LaptopBookingSystem.NielsenLaptopBookingSystemDB(connectionString, providerName);
            }
            IRepository<NProjectAssignment> _repo;
            
            if(db.TestMode){
                NProjectAssignment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<NProjectAssignment>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<NProjectAssignment> GetRepo(){
            return GetRepo("","");
        }
        
        public static NProjectAssignment SingleOrDefault(Expression<Func<NProjectAssignment, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            NProjectAssignment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static NProjectAssignment SingleOrDefault(Expression<Func<NProjectAssignment, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            NProjectAssignment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<NProjectAssignment, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<NProjectAssignment, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<NProjectAssignment> Find(Expression<Func<NProjectAssignment, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<NProjectAssignment> Find(Expression<Func<NProjectAssignment, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<NProjectAssignment> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<NProjectAssignment> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<NProjectAssignment> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<NProjectAssignment> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<NProjectAssignment> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<NProjectAssignment> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Sid";
        }

        public object KeyValue()
        {
            return this.Sid;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.isDeleted.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(NProjectAssignment)){
                NProjectAssignment compare=(NProjectAssignment)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Sid;
        }
        
        public string DescriptorValue()
        {
                            return this.isDeleted.ToString();
                    }

        public string DescriptorColumn() {
            return "isDeleted";
        }
        public static string GetKeyColumn()
        {
            return "Sid";
        }        
        public static string GetDescriptorColumn()
        {
            return "isDeleted";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Sid;
        public int Sid
        {
            get { return _Sid; }
            set
            {
                if(_Sid!=value){
                    _Sid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _isDeleted;
        public bool? isDeleted
        {
            get { return _isDeleted; }
            set
            {
                if(_isDeleted!=value){
                    _isDeleted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeleted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                         
             this.isDeleted=true;
            _repo.Update(this,provider);
                
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<NProjectAssignment, bool>> expression) {
            var repo = GetRepo();
            
            
            List<NProjectAssignment> items=repo.GetAll().Where(expression).ToList();
            items.ForEach(x=>x.isDeleted=true);
            repo.Update(items);
            
        }

                
        public static void Destroy(Func<NProjectAssignment, bool> expression) {
            var repo = GetRepo();
            repo.Delete(expression);
        }
        
        public static void Destroy(object key) {
            var repo = GetRepo();
            repo.Delete(key);
        }
        
        public static void Destroy(object key, IDataProvider provider) {
        
            var repo = GetRepo();
            repo.Delete(key,provider);
            
        }        
        
        public void Destroy() {
            _repo.Delete(KeyValue());
        }        
        public void Destroy(IDataProvider provider) {
            _repo.Delete(KeyValue(), provider);
        }         
        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
