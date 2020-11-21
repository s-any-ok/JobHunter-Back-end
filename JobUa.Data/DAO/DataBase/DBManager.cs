using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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

                //XML
                XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
                using (FileStream fs = new FileStream(@"E:\data.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, table);
                }

                //JSON
                File.WriteAllText(@"E:\data.json", JsonConvert.SerializeObject(table));
            }
            return table;
        }
    }
}
