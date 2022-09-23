using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAdapterWizard
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }
        // Упражнение 4.3. Создание объектов DataAdapter

        // у.4.3. п.11. Создание обработчика события формы
        private void LoadForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = northwindDataSet1.Customers; // у.4.3. п.12a

            sqlDataAdapter1.Fill(northwindDataSet1.Customers); // у.4.3. п.12b Загрузка таблицы данными из базы!!!
        }

        // у.4.3. п.14. Сохранения изменений в базе данных
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(northwindDataSet1);
        }

        // Обработка событий DataAdapter

        // п.1. Создание обработчика события RowUpdating
        private void sqlDataAdapter1_RowUpdating(object sender, System.Data.SqlClient.SqlRowUpdatingEventArgs e)
        {
            NorthwindDataSet.CustomersRow CustRow = (NorthwindDataSet.CustomersRow)e.Row;
            DialogResult response = MessageBox.Show("Продолжить обновление " + CustRow.CustomerID.ToString() +
                "?", "Продолжить обновление?", MessageBoxButtons.YesNo);

            if (response == DialogResult.No)
            {
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        // п.2. Создание обработчика события RowUpdated
        private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {
            NorthwindDataSet.CustomersRow CustRow = (NorthwindDataSet.CustomersRow)e.Row;
            MessageBox.Show(CustRow.CustomerID.ToString() + " был обновлен");

            northwindDataSet1.Customers.Clear();
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);
        }

        // п.3. Создание обработчика события FillError
        private void sqlDataAdapter1_FillError(object sender, FillErrorEventArgs e)
        {
            DialogResult response = MessageBox.Show("При заполнении набора данных произошла следующая ошибка: " + e.Errors.Message.ToString() +
                " Продолжать попытки заполнить?", "Обнаружена ошибка заполнения", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                e.Continue = true;
            }
            else
            {
                e.Continue = false;
            }
        }
    }
}

