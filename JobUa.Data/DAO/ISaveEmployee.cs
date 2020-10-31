using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.DAO
{
    public interface ISaveEmployee : IBase
    {
        string SaveNewEmployee(Guid CompanyID, Guid EmployeeID, DateTime SaveData);
    }
}
