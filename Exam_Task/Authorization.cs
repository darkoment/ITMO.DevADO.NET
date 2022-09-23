using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ITMO.ADO_Course.Exam_Task
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private int parsedCustomerID;

        SQLhelp sql = new SQLhelp();
        DataTable data;
        private void Form1_Load(object sender, EventArgs e)
        {
            data = sql.GetTable("select * from Sales.Customer");
        }

        private bool IsCustomerNameAndPassValid()
        {
            if (txtCustomerName.Text == "")
            {
                if (txtCustomerPassword.Text == "") 
                {
                    MessageBox.Show("Please enter a password.");
                    return false;
                }
                MessageBox.Show("Please enter a name.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            if (IsCustomerNameAndPassValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspLoginCustomer", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerPass", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerPass"].Value = txtCustomerPassword.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();

                            this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

                            Form frm = new FillOrCancel();
                            frm.Show();
                        }
                        catch
                        {
                            MessageBox.Show("Customer ID was not returned. Account could not be authorized.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}
