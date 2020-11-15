using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobUa.Data.DAO.DataBase
{
    public abstract class DBManager
    {
        private string connString = "JobSearchAppDB";
        public DataTable UpdateDBTableDataByQuery(string query) {
            DataTable table = new DataTable() { TableName = "MyTable" };

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[connString].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
                DataSet dataSet = new DataSet();

                dataSet.Tables.Add(table);
                // Save to disk
                dataSet.WriteXml(@"E:\MyDataset.xml");
                // Read from disk
                //dataSet.ReadXml(@"E:\MyDataset.xml");
            }
            return table;
        }
    }
}
