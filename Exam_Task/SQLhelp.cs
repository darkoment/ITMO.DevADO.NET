using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITMO.ADO_Course.Exam_Task
{
    internal class SQLhelp
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            }
        }
        DataTable userTable;
        SqlDataAdapter adapter;
        public DataTable GetTable(string query)
        {
            adapter = new SqlDataAdapter(query, ConnectionString);
            userTable = new DataTable();
            adapter.Fill(userTable);
            return userTable;
        }
    }
}
