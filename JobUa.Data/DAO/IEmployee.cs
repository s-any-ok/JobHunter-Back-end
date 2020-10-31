using JobUa.Data.DAO.DataBase;
using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO
{
    public interface IEmployee : IBase
    {
        Employee GetEmpObjByGuid(Guid guid);
        string SaveEmployee(Employee emp);
        string UpdateEmployee(Employee emp);
    }
}
