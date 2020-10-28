using JobUa.Data.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JobUa.Data.DAO.DataBase
{
    public class DBCompany : DBBase, ICompany
    {
        public Company getCmpObjByGuid(Guid guId)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Companies where CompanyID = '" + guId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            Company comp = new Company();

            comp.TIN = (string)table.Rows[0]["TIN"];
            comp.Name = (string)table.Rows[0]["Name"];
            comp.Information = (string)table.Rows[0]["Information"];
            comp.BusinessType = (BusinessType)Enum.Parse(typeof(Gender), table.Rows[0]["Employment"].ToString());
            comp.IsVip = (bool)table.Rows[0]["IsVip"];
            comp.Link = (string)table.Rows[0]["Link"];
            comp.ImageData = table.Rows[0]["ContactPhoneNumber"] != System.DBNull.Value ? (byte[])table.Rows[0]["ContactPhoneNumber"] : null;
            return comp;
        }

        public Company getCmpObjByVacGuid(Guid guId)
        {
            DataTable table = new DataTable();
            string query = @"Select * from dbo.Companies where VacancyID = '" + guId + @"'";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            Company comp = new Company();

            comp.TIN = (string)table.Rows[0]["TIN"];
            comp.Name = (string)table.Rows[0]["Name"];
            comp.Information = (string)table.Rows[0]["Information"];
            comp.BusinessType = (BusinessType)Enum.Parse(typeof(Gender), table.Rows[0]["Employment"].ToString());
            comp.IsVip = (bool)table.Rows[0]["IsVip"];
            comp.Link = (string)table.Rows[0]["Link"];
            comp.ImageData = table.Rows[0]["ContactPhoneNumber"] != System.DBNull.Value ? (byte[])table.Rows[0]["ContactPhoneNumber"] : null;
            return comp;
        }

        public string saveCompany(Company comp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Companies (CompanyID,
                                                            TIN,
                                                            CompName,
                                                            Information,
                                                            isVip,
                                                            Link,
                                                            BusinessType)  
                                                            Values 
                                                            ('" + comp.CompanyID + @"',
                                                             '" + comp.TIN + @"',
                                                             '" + comp.Name + @"',
                                                             '" + comp.Information + @"',
                                                             '" + comp.IsVip + @"',
                                                             '" + comp.Link + @"',
                                                             '" + comp.BusinessType + @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to add Company";
            }
        }

        public string updateCompany(Company comp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Companies set 
                                                            CompName =      '" + comp.Name + @"',
                                                            Information =   '" + comp.Information + @"',
                                                            Link =          '" + comp.Link + @"',
                                                            BusinessType =  '" + comp.BusinessType + @"',
                                                            ImageData =     '" + comp.ImageData + @"'
                                                            where
                                                            CompanyID =     '" + comp.CompanyID + @"'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JobSearchAppDB"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Company";
            }
        }
    }
}
