using System;
using System.Data;

namespace JobUa.Data.DAO.DataBase
{
    public class DBBase : DBManager, IBase
    {
        public DataTable GetAll(string dbName)
        {
            string query = @"Select * from " + dbName;
            return UpdateDBTableDataByQuery(query);
        }
        public DataTable GetObjByGuid(Guid guId, string idField, string dbName)
        {
            string query = @"Select * from " + dbName +  " where " +  idField  + " = '" + guId + @"'";
            return UpdateDBTableDataByQuery(query);
        }

        public string DeleteObjByGuid(Guid guid, string idField, string dbName)
        {
            try
            {
                string query = @"delete from " + dbName + " where " + idField + " = '" + guid + @"'";
                UpdateDBTableDataByQuery(query);
                return "Deleted object from " + dbName + " Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete object from " + dbName;
            }
        }
    }
}
