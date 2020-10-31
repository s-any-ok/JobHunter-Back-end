using JobUa.Data.Models;
using System;
using System.Data;

namespace JobUa.Data.DAO.DataBase
{
    public class DBUser : DBBase, IUser
    {
        public string SaveUser(User user) {
            try
            {
                string query = @"insert into dbo.Users      (ChildID,
                                                            isCompany,
                                                            UserName,
                                                            UserLogin,
                                                            UserPassword,
                                                            SecretWord,
                                                            RegistrationData) 
                                                            Values 
                                                            ('" + user.ChildID + @"',
                                                             '" + user.isCompany + @"',
                                                             '" + user.UserName + @"',
                                                             '" + user.Login + @"',
                                                             '" + user.Password + @"',
                                                             '" + user.SecretWord + @"',
                                                             '" + user.RegistrationData + @"')";

                UpdateDBTableDataByQuery(query);
                return "You registered Successfully";
            }
            catch (Exception)
            {
                return "Failed to register";
            }
        }
        public DataTable LoginUser(string Login, string Password) {

            string query = @"Select UserID, ChildID, IsCompany from dbo.Users where UserLogin = '" + Login + @"' and UserPassword = '" + Password + @"'";
            return UpdateDBTableDataByQuery(query);
        }
    }
}
