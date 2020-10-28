using JobUa.Data.Models;
using System;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface IEmployee
    {
        DataTable getAll();
        DataTable getEmpByGuid(Guid guid);
        Employee getEmpObjByGuid(Guid guid);
        string saveEmployee(Employee emp);
        string updateEmployee(Employee emp);
        string deleteEmpByGuid(Guid guid);
    }
}
