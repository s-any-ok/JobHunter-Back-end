using System;
using System.Data;


namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveVacancy : DBBase, ISaveVacancy
    {   
        public string SaveNewVacancy(Guid VacancyID, Guid EmployeeID, DateTime SaveData) {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.SaveVacancies (
                                                                VacancyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + VacancyID + @"',
                                                                 '" + EmployeeID + @"',
                                                                 '" + SaveData + @"')";

                UpdateDBTableDataByQuery(query);
                return "Saved Vacancy to saved Vacancies Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Vacancy to saved Vacancies";
            }
        }
    }
}
