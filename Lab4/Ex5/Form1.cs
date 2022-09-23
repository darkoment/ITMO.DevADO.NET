using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // у.4.5. п.2

namespace WorkingDataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // у.4.5. п.9 обаботчик события LOAD формы
        private void Form1_Load(object sender, EventArgs e)
        {
            CustomersDataGridView.DataSource = northwindDataSet1.Customers;
            CustomersDataGridView.MultiSelect = false;
            CustomersDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            CustomersDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        // у.4.5. п.10
        private void FillTableButton_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);
        }
        // у.4.5. п.11
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            // у.4.5. п.12a
            NorthwindDataSet.CustomersRow NewRow = (NorthwindDataSet.CustomersRow)northwindDataSet1.Customers.NewRow();
            // у.4.5. п.12b
            NewRow.CustomerID = "WINGT";
            NewRow.CompanyName = "Wingtip Toys";
            NewRow.ContactName = "Steve Lasker";
            NewRow.ContactTitle = "CEO";
            NewRow.Address = "1234 Main Street";
            NewRow.City = "Buffalo";
            NewRow.Region = "NY";
            NewRow.PostalCode = "98052";
            NewRow.Country = "USA";
            NewRow.Phone = "206-555-0111";
            NewRow.Fax = "206-555-0112";
            // у.4.5. п.12c
            try
            {
                northwindDataSet1.Customers.Rows.Add(NewRow);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Row Failed");
            }
        }
        // у.4.5. п.13
        private NorthwindDataSet.CustomersRow GetSelectedRow()
        {
            String SelectedCustomerID = CustomersDataGridView.CurrentRow.Cells["CustomerID"].Value.ToString();
            NorthwindDataSet.CustomersRow SelectedRow = northwindDataSet1.Customers.FindByCustomerID(SelectedCustomerID);
            return SelectedRow;
        }
        // у.4.5. п.15
        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().Delete(); // // у.4.5. п.15
        }
        // у.4.5. п.18
        private void UpdateRowVersionDisplay()
        {
            // у.4.5. п.19
            try
            {
                CurrentDRVTextBox.Text = GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name, DataRowVersion.Current].ToString();
            }
            catch (Exception ex)
            {
                CurrentDRVTextBox.Text = ex.Message;
            }
            try
            {
                OriginalDRVTextBox.Text = GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name, DataRowVersion.Original].ToString();
            }
            catch (Exception ex)
            {
                OriginalDRVTextBox.Text = ex.Message;
            }
            // у.4.5. п.20
            RowStateTextBox.Text = GetSelectedRow().RowState.ToString();
        }
        // у.4.5. п.21
        private void UpdateValueButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow()[CustomersDataGridView.CurrentCell.OwningColumn.Name] = CellValueTextBox.Text;
            UpdateRowVersionDisplay();
        }

        // у.4.5. п.22 - КЛИК ПО ТЕКСТОВОМУ ПОЛЮ!!!
        private void CustomersDataGridView_Click(object sender, EventArgs e)
        {
            CellValueTextBox.Text = CustomersDataGridView.CurrentCell.Value.ToString();
            UpdateRowVersionDisplay();
        }

        // у.4.5. п.23
        private void AcceptChangesButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().AcceptChanges();
            UpdateRowVersionDisplay();
        }
        // у.4.5. п.24
        private void RejectChangesButton_Click(object sender, EventArgs e)
        {
            GetSelectedRow().RejectChanges();
            UpdateRowVersionDisplay();
        }
    }
}
