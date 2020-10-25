using JobUa.Data.Models.Relations;
using System;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface ISaveEmployee
    {
        DataTable getAll();
        DataTable getByCmpGuid(Guid guid);
        string saveNewEmployee(SaveEmployee semp);
        string deleteSaveEmpBySaveGuid(Guid? guid);
    }
}
