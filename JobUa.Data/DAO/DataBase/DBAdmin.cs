using System.Data;

namespace JobUa.Data.DAO.DataBase
{
    public class DBAdmin : DBBase, IAdmin
    {
        public DataTable LoginAdmin(string login, string password) {

            string query = @"Select * from dbo.Admins where AdminLogin = '" + login + @"' and AdminPassword = '" + password + @"'";
            return UpdateDBTableDataByQuery(query);
        }
    }
}
