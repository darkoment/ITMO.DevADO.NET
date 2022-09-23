using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingDataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable CustomersTable = new DataTable("Customers"); // у.4.2. п.4

        // у.4.2. п.5 Создание таблицы в обработчике события Click специальной кнопкой
        private void AddTableButton_Click(object sender, EventArgs e) 
        {
            try // этот обработчик добавлен в инициативном порядке (по обр. у.1.3.)
            {
                TableGrid.DataSource = CustomersTable; // у.4.2. п.6a

                // у.4.2. п.6b Добавить столбцы в таблицу
                CustomersTable.Columns.Add("CustomerID", Type.GetType("System.String"));
                CustomersTable.Columns.Add("CompanyName", Type.GetType("System.String"));
                CustomersTable.Columns.Add("ContactName", Type.GetType("System.String"));
                CustomersTable.Columns.Add("ContactTitle", Type.GetType("System.String"));
                CustomersTable.Columns.Add("Address", Type.GetType("System.String"));
                CustomersTable.Columns.Add("City", Type.GetType("System.String"));
                CustomersTable.Columns.Add("Country", Type.GetType("System.String"));
                CustomersTable.Columns.Add("Phone", Type.GetType("System.String"));

                // у.4.2. п.6c Указать столбец CustomerID как первичный ключ:
                // Если закомментировать, то можно добавлять в таблицу одинаковые данные :)
                DataColumn[] KeyColumns = new DataColumn[1];
                KeyColumns[0] = CustomersTable.Columns["CustomerID"];
                CustomersTable.PrimaryKey = KeyColumns;

                // у.4.2. п.6d Запретить для столбцов CustomerID и CompanyName значения Null:
                CustomersTable.Columns["CustomerID"].AllowDBNull = false;
                CustomersTable.Columns["CompanyName"].AllowDBNull = false;
            }

            catch (Exception Xcp) // этот обработчик добавлен в инициативном порядке (по обр. у.1.3.)
            {
                MessageBox.Show(Xcp.Message, "Неожиданное исключение",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // этот обработчик добавлен в инициативном порядке
        }

        private void AddRowButton_Click(object sender, EventArgs e) // у.4.2. п.7a Создание записи
        {
            try // у.4.2. п.8 Реализация обработчика исключений
            {
                // новые записи можно добавлять в коде
                DataRow CustRow = CustomersTable.NewRow();

                // Неточности в методичке - массив данных больше, чем к-во столбцов таблицы
                //Object[] CustRecord =  {"ALFKI", "Alfreds Futterkiste", "Maria Anders",
                //    "Sales Representative", "Obere Str. 57", "Berlin",
                //      null, "12209", "Germany", "030-0074321","030-0076545"};

                // Откорректированные данные
                Object[] CustRecord =  {"ALFKI", "Alfreds Futterkiste", "Maria Anders",
                "Sales Representative", "Obere Str. 57", "Berlin",
                  "Germany", "030-0076545"};

                CustRow.ItemArray = CustRecord;

                CustomersTable.Rows.Add(CustRow); // у.4.2. п.7b Добавление записи в таблицу
            }

            catch (Exception Xcp) // у.4.2. п.8 Реализация обработчика исключений (по обр. у.1.3.)
            {
                MessageBox.Show(Xcp.Message, "Неожиданное исключение",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
