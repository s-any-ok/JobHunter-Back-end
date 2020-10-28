using JobUa.Data.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JobUa.Data.DAO.DataBase
{
    public class DBEmployee : IEmployee
    {
        public DataTable getAll() {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Employees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }

        public DataTable getEmpByGuid(Guid guid) {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Employees where EmployeeID = '" + guid + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;
        }

        public Employee getEmpObjByGuid(Guid guid)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Employees where EmployeeID = '" + guid + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
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

        public string saveEmployee(Employee emp) {
            try
            {
                DataTable table = new DataTable();
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
                                                            Birthday) 
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
                                                             '" + emp.Birthday + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Employee Successfully";

            }
            catch (Exception)
            {
                return "Failed to add Employee";
            }
        }

        public string updateEmployee(Employee emp) {
            try
            {
                DataTable table = new DataTable();
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

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Employee";
            }
        }
        public string deleteEmpByGuid(Guid guid) {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Employees where EmployeeID = '" + guid + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Employee Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete Employee";
            }
        }
    }
}
