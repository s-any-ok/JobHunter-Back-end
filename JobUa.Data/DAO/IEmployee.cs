using JobUa.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
