using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using MTFFAPI.Entity;

namespace MTFFAPI.Services
{
    public class SimpleDBClient
    {
        private const String connStr = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = databaseIP)(PORT = 1521))"
            + "(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = PDBORCL)))" + "Persist Security Info=True; User Id=DBTA; Password=password";
        SqlSugarClient db;
        public SimpleDBClient()
        {
            initConn();
        }
        public void initConn()
        {
            using (db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connStr,         //必填, 数据库连接字符串
                DbType = DbType.Oracle,         //必填, 数据库类型
                IsAutoCloseConnection = false,      //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                InitKeyType = InitKeyType.SystemTable    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
            })) { };
        }
        #region testGet
        public Supplier getSupplierByID(string id)
        {
            Supplier sup;

            var getAll = db.Queryable<Supplier>().Where(it => it.SupplierID == id).ToList();
            if (getAll.Any())
            {
                sup = getAll[0];
            }
            else
            {
                sup = new Supplier();
                sup.SupplierID = "-1";
            }
            return sup;
        }
        #endregion

        #region testAdd
        public void addSupplier(SupplierCreation newSup)
        {
            db.Insertable(newSup).ExecuteCommand();
        }
        #endregion

        #region testDel
        public int delSupplierByID(string id)
        {
            var t3 = db.Deleteable<Supplier>().In(id).ExecuteCommand();
            return t3;
        }
        #endregion

        #region testUpdate
        public int updateSupplier(SupplierModification supModify)
        {
            var t1 = db.Updateable(supModify).ExecuteCommand();
            return t1;
        }
        #endregion
    }
}
