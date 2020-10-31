using JobUa.Data.Models;
using System;

namespace JobUa.Data.DAO.DataBase
{
    public class DBEmployee : DBBase, IEmployee
    {
        public Employee GetEmpObjByGuid(Guid guid)
        {
            string query = @"Select * from dbo.Employees where EmployeeID = '" + guid + @"'";
            var table = UpdateDBTableDataByQuery(query);

            Employee emp = new Employee();
            emp.EmployeeID = (Guid)table.Rows[0]["EmployeeID"];
            emp.FirstName = (string)table.Rows[0]["FirstName"];
            emp.MiddleName = (string)table.Rows[0]["MiddleName"];
            emp.LastName = (string)table.Rows[0]["LastName"];
            emp.Gender = (Gender)Enum.Parse(typeof(Gender), table.Rows[0]["Gender"].ToString());
            emp.Education = (string)table.Rows[0]["Education"];
            emp.AdditionalEducation = (string)table.Rows[0]["AdditionalEducation"];
            emp.Objective = (string)table.Rows[0]["Objective"];
            emp.Experience = (string)table.Rows[0]["Experience"];
            emp.Skills = (string)table.Rows[0]["Skills"];
            emp.Adress = (string)table.Rows[0]["Adress"];
            emp.PhotoData = table.Rows[0]["PhotoData"] != System.DBNull.Value ? (byte[])table.Rows[0]["PhotoData"] : null;
            emp.Birthday = (DateTime)table.Rows[0]["Birthday"];
            return emp;
        }

        public string SaveEmployee(Employee emp) {
            try
            {
                string query = @"insert into  dbo.Employees (EmployeeID,
                                                            FirstName,
                                                            MiddleName,
                                                            LastName,
                                                            Education,
                                                            AdditionalEducation,
                                                            Gender,
                                                            Objective,
                                                            Experience,
                                                            Skills,
                                                            Adress,
                                                            Birthday,
                                                            Email,
                                                            ContactPhoneNumber)
                                                            Values 
                                                            ('" + emp.EmployeeID + @"',
                                                             '" + emp.FirstName + @"',
                                                             '" + emp.MiddleName + @"',
                                                             '" + emp.LastName + @"',
                                                             '" + emp.Education + @"',
                                                             '" + emp.AdditionalEducation + @"',
                                                             '" + emp.Gender + @"',
                                                             '" + emp.Objective + @"',
                                                             '" + emp.Experience + @"',
                                                             '" + emp.Skills + @"',
                                                             '" + emp.Adress + @"',
                                                             '" + emp.Birthday + @"',
                                                             '" + emp.Email + @"',
                                                             '" + emp.ContactPhoneNumber + @"')";

                UpdateDBTableDataByQuery(query);
                return "Added Employee Successfully";

            }
            catch (Exception)
            {
                return "Failed to add Employee";
            }
        }

        public string UpdateEmployee(Employee emp) {
            try
            {
                string query = @"update  dbo.Employees set 
                                                            FirstName =                 '" + emp.FirstName + @"',
                                                            MiddleName =                '" + emp.MiddleName + @"',
                                                            LastName =                  '" + emp.LastName + @"',
                                                            Education =                 '" + emp.Education + @"',
                                                            AdditionalEducation =       '" + emp.AdditionalEducation + @"',
                                                            Objective =                 '" + emp.Objective + @"',
                                                            Experience =                '" + emp.Experience + @"',
                                                            Skills =                    '" + emp.Skills + @"',
                                                            Adress =                    '" + emp.Adress + @"',
                                                            PhotoData =                 '" + emp.PhotoData + @"'
                                                            where
                                                            EmployeeID =                '" + emp.EmployeeID + @"'";

                UpdateDBTableDataByQuery(query);
                return "Updated Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Employee";
            }
        }
    }
}
