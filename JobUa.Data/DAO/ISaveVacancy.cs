using JobUa.Data.DAO.DataBase;
using System;

namespace JobUa.Data.DAO
{
    public interface ISaveVacancy : IBase
    {
        string SaveNewVacancy(Guid VacancyID, Guid EmployeeID, DateTime SaveData);
    }
}
