using JobUa.Data.Models.Relations;
using System;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface ISaveVacancy
    {
        DataTable getAll();
        DataTable getByEmpGuid(Guid guid);
        string saveNewVacancy(Guid VacancyID, Guid EmployeeID, DateTime SaveData);
        string deleteSaveVacBySaveGuid(Guid? guid);
    }
}
