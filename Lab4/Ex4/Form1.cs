using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // у.4.4 п.3

// Упражнение 4.4 Программное создание объекта DataAdapter

namespace DataAdapterProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // у.4.4 п.4 добавил @ чтобы обойти обратный слэш в адресе сервера
        private SqlConnection NorthwindConnection = new SqlConnection(@"Data Source=ASUS-SERVER\SQLEXPRESS;" +
            "Initial Catalog=Northwind;Integrated Security=True");

        private SqlDataAdapter SqlDataAdapter1; // у.4.4 п.5

        // у.4.4 п.6
        private DataSet NorthwindDataset = new DataSet("Northwind");
        private DataTable CustomersTable = new DataTable("Customers");

        // у.4.4 п.7
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Customers", NorthwindConnection);
            NorthwindDataset.Tables.Add(CustomersTable);
            SqlDataAdapter1.Fill(NorthwindDataset.Tables["Customers"]);
            dataGridView1.DataSource = NorthwindDataset.Tables["Customers"];

            SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1); // у.4.4 п.8
        }

        // у.4.4 п.10 сохранение изменений в базе данных
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }
    }
}
