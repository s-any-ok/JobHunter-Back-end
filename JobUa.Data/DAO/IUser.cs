using JobUa.Data.DAO.DataBase;
using JobUa.Data.Models;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface IUser : IBase
    {
        string SaveUser(User user);
        DataTable LoginUser(string Login, string Password);
    }
}
