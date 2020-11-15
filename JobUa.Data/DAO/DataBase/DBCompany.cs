using JobUa.Data.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JobUa.Data.DAO.DataBase
{
    public class DBCompany : DBBase, ICompany
    {
        public Company GetCmpObjByGuid(Guid guId)
        {
            string query = @"Select * from dbo.Companies where CompanyID = '" + guId + @"'";
            var table = UpdateDBTableDataByQuery(query);

            Company comp = new Company();

            comp.TIN = (string)table.Rows[0]["TIN"];
            comp.CompName = (string)table.Rows[0]["Name"];
            comp.Information = (string)table.Rows[0]["Information"];
            comp.BusinessType = (BusinessType)Enum.Parse(typeof(Gender), table.Rows[0]["Employment"].ToString());
            comp.IsVip = (bool)table.Rows[0]["IsVip"];
            comp.Link = (string)table.Rows[0]["Link"];
            comp.ImageData = table.Rows[0]["ContactPhoneNumber"] != System.DBNull.Value ? (byte[])table.Rows[0]["ContactPhoneNumber"] : null;
            return comp;
        }

        public Company GetCmpObjByVacGuid(Guid guId)
        {
            string query = @"Select * from dbo.Companies where VacancyID = '" + guId + @"'";
            var table = UpdateDBTableDataByQuery(query);

            Company comp = new Company();

            comp.TIN = (string)table.Rows[0]["TIN"];
            comp.CompName = (string)table.Rows[0]["Name"];
            comp.Information = (string)table.Rows[0]["Information"];
            comp.BusinessType = (BusinessType)Enum.Parse(typeof(Gender), table.Rows[0]["Employment"].ToString());
            comp.IsVip = (bool)table.Rows[0]["IsVip"];
            comp.Link = (string)table.Rows[0]["Link"];
            comp.ImageData = table.Rows[0]["ContactPhoneNumber"] != System.DBNull.Value ? (byte[])table.Rows[0]["ContactPhoneNumber"] : null;
            return comp;
        }

        public string SaveCompany(Company comp)
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
                                                            BusinessType,
                                                            Email,
                                                            ContactPhoneNumber)  
                                                            Values 
                                                            ('" + comp.CompanyID + @"',
                                                             '" + comp.TIN + @"',
                                                             '" + comp.CompName + @"',
                                                             '" + comp.Information + @"',
                                                             '" + comp.IsVip + @"',
                                                             '" + comp.Link + @"',
                                                             '" + comp.BusinessType + @"',
                                                             '" + comp.Email + @"',
                                                             '" + comp.ContactPhoneNumber + @"')";

                UpdateDBTableDataByQuery(query);
                return "Added Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to add Company";
            }
        }

        public string UpdateCompany(Company comp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Companies set 
                                                            CompName =      '" + comp.CompName + @"',
                                                            Information =   '" + comp.Information + @"',
                                                            Link =          '" + comp.Link + @"',
                                                            BusinessType =  '" + comp.BusinessType + @"',
                                                            ImageData =     '" + comp.ImageData + @"'
                                                            where
                                                            CompanyID =     '" + comp.CompanyID + @"'";

                UpdateDBTableDataByQuery(query);
                return "Updated Company Successfully";
            }
            catch (Exception)
            {
                return "Failed to update Company";
            }
        }
    }
}
