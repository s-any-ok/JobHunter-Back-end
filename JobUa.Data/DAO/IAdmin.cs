using JobUa.Data.DAO.DataBase;
using System.Data;

namespace JobUa.Data.DAO
{
    public interface IAdmin : IBase
    {
        DataTable LoginAdmin(string login, string password);
    }
}
