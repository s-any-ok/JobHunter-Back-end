using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO.DataBase
{
    public interface ICompany : IBase
    {
        Company GetCmpObjByGuid(Guid guid);
        Company GetCmpObjByVacGuid(Guid guid);
        string SaveCompany(Company comp);
        string UpdateCompany(Company comp);
    }
}
