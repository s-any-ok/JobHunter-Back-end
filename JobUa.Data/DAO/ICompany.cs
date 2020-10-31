using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO.DataBase
{
    public interface ICompany : IBase
    {
        Company getCmpObjByGuid(Guid guid);
        Company getCmpObjByVacGuid(Guid guid);
        string saveCompany(Company comp);
        string updateCompany(Company comp);
    }
}
