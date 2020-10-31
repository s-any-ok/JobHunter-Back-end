using System;
using System.Data;

namespace JobUa.Data.DAO.DataBase
{
    public interface IBase
    {
        DataTable GetAll(string dbName);
        DataTable GetObjByGuid(Guid guId, string idField, string dbName);
        string DeleteObjByGuid(Guid guid, string idField, string dbName);
    }
}
