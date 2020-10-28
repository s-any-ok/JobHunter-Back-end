using JobUa.Data.Models.Relations;
using System;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface ISaveEmployee
    {
        DataTable getAll();
        DataTable getByCmpGuid(Guid guid);
        string saveNewEmployee(Guid CompanyID, Guid EmployeeID, DateTime SaveData);
        string deleteSaveEmpBySaveGuid(Guid? guid);
    }
}
