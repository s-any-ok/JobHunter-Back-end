using System;
using System.Data;

namespace JobUa.Data.DAO.DataBase
{
    public interface IBase
    {
        DataTable getAll(string dbName);
        DataTable getObjByGuid(Guid guId, string idField, string dbName);
        string deleteObjByGuid(Guid guid, string idField, string dbName);
    }
}
