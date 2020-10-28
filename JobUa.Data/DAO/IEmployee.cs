using JobUa.Data.DAO.DataBase;
using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO
{
    public interface IEmployee : IBase
    {
        Employee getEmpObjByGuid(Guid guid);
        string saveEmployee(Employee emp);
        string updateEmployee(Employee emp);
    }
}
