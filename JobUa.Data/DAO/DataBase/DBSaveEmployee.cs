using System;

namespace JobUa.Data.DAO.DataBase
{
    public class DBSaveEmployee : DBBase, ISaveEmployee
    {
        public string SaveNewEmployee(Guid CompanyID, Guid EmployeeID, DateTime SaveData) {
            try
            {
                string query = @"insert into dbo.SaveEmployees (
                                                                CompanyID,
                                                                EmployeeID,
                                                                SaveData
                                                                ) 
                                                                Values 
                                                                ('" + CompanyID + @"',
                                                                 '" + EmployeeID + @"',
                                                                 '" + SaveData + @"')";
                UpdateDBTableDataByQuery(query);
                return "Save Employee to saved Employees Successfully";
            }
            catch (Exception)
            {
                return "Failed to save Employee to saved Employees";
            }
        }
    }
}
