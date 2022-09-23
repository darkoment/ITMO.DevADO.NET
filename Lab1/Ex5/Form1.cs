using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // у.1.5 п.2

// Упражнение 1.5. Работа с классами конфигурации

namespace DBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new System.Data.StateChangeEventHandler(this.connection_StateChange); // у.1.4 п.1
        }

        OleDbConnection connection = new OleDbConnection();

        private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e) // у.1.4 п.2
        {
            button1.Enabled = (e.CurrentState == ConnectionState.Closed); // долго думал пока додумался вставить кнопку
            button2.Enabled = (e.CurrentState == ConnectionState.Open);
        }

        // у.1.5. п.8 В коде формы закомментируйте инициализацию переменной соединения testConnect.

        // правильная строка, Домашний компьютер
        // ASUS-SERVER\SQLEXPRESS";

        // правильная строка, Рабочий ноутбук
        // UTOCHKA\SQLEXPRESS";

        // у.1.5. п.9 После конструктора формы добавьте статический метод, возвращающий значение строки соединения по ее имени:
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        // у.1.5. п.10 10.	После метода объявите переменную testConnect...
        string testConnect = GetConnectionStringByName("DBConnect.NorthwindConnectionString");

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

            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message,
                    "SQL Error code " + se.NativeError,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void списокПодключенийToolStripMenuItem_Click(object sender, EventArgs e) // у.1.5 п.4
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    MessageBox.Show("name = " + cs.Name);
                    MessageBox.Show("providerName = " + cs.ProviderName);
                    MessageBox.Show("connectionString = " + cs.ConnectionString);
                }
            }
        }
    }
}
