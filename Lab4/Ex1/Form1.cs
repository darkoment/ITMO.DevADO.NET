using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatasetDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Упражнение 4.1. Использование DataSet Designer для создания DataSet
        
        // у.4.1. п.7
        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet NorthwindDataset1 = new NorthwindDataSet(); // у.4.1. п.7a

            NorthwindDataSetTableAdapters.CustomersTableAdapter CustomersTableAdapter1 = 
                new NorthwindDataSetTableAdapters.CustomersTableAdapter(); // у.4.1. п.7b

            CustomersTableAdapter1.Fill(NorthwindDataset1.Customers); // у.4.1. п.7c

            foreach (NorthwindDataSet.CustomersRow NWCustomer in NorthwindDataset1.Customers.Rows)
            {
                CustomersListBox.Items.Add(NWCustomer.CompanyName); // выбор столбца CompanyName из таблицы
                // CustomersListBox.Items.Add(NWCustomer.ContactName); // просто для проверки 
            }
        }
    }
}
