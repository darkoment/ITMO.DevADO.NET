using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient; // у.1.1.
using System.Data.OleDb; // у.1.1.
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Упражнение 1.3. Обработка ошибок

namespace DBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection();

        // правильная строка
        //string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=ASUS-SERVER\SQLEXPRESS";
        
        // для ошибка имени Провайдера
        string testConnect = @"Provider=SQLXXXDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=ASUS-SERVER\SQLEXPRESS";
        
        // для ошибка имени Базы данных
        //string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NorthXXXd;Data Source=ASUS-SERVER\SQLEXPRESS";
        
        // для ошибка имени Сервера
        // string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=ASUS-SURVER\SQLEXPRESS";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }

            catch (OleDbException XcpSQL) // у.1.3, п.2 (блок catch)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message,
                    "SQL Error code " + se.NativeError,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            catch (Exception Xcp) // у.1.3, п.3 (блок catch)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //catch // у.1.3, п.3 (блок catch без параметров закомментирован)
            //{
            //    MessageBox.Show("Ошибка соединения с базой данных");
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
