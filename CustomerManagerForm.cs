using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Milburn_Software2
{
    public partial class CustomerManagerForm : Form
    {
        public CustomerManagerForm()
        {
            InitializeComponent();
            initCustomerTable();

            if (Stored.RegionName == "es-ES")
            {
                addCustomerBtn.Text = SpanishText.AddBtn;
                editCustomerBtn.Text = SpanishText.EditBtn;
                deleteCustomerBtn.Text = SpanishText.DeleteBtn;
                goBackBtn.Text = SpanishText.GoBackBtn;
            }

            Stored.checkReminder();
        }

        public void initCustomerTable()
        {
            customerDataGridView.DataSource = null;
            customerDataGridView.DataSource = getCustomers();
            customerDataGridView.AutoGenerateColumns = false;

            customerDataGridView.Columns["CustomerId"].Visible = false;
            customerDataGridView.Columns["AddressId"].Visible = false;

            customerDataGridView.Columns["Name"].HeaderText = (Stored.RegionName == "es-ES") ? SpanishText.CustomerLabel : "Customer";
            customerDataGridView.Columns["Name"].DisplayIndex = 1;
            customerDataGridView.Columns["Name"].Width = 130;

            customerDataGridView.Columns["PhoneNumber"].HeaderText = (Stored.RegionName == "es-ES") ? SpanishText.PhoneLabel : "Phone";
            customerDataGridView.Columns["PhoneNumber"].DisplayIndex = 2;
            customerDataGridView.Columns["PhoneNumber"].Width = 130;
        }

        public List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();
            MySqlConnection connection = new MySqlConnection(Stored.connection_string);
            connection.Open();

            string sql = "SELECT customer.customerId, customer.customerName, address.phone, address.addressId " +
                "FROM customer " +
                "JOIN address ON (customer.addressId = address.addressId) " +
                "WHERE active = 1 " +
                "ORDER BY customer.customerName ASC";

            MySqlCommand command = new MySqlCommand(sql, connection);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    customers.Add(new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3])));
                }
            }

            reader.Close();
            connection.Close();

            return customers;
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
            this.Show();

            initCustomerTable();
        }

        private void editCustomerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = customerDataGridView.SelectedRows[0];
                CustomerForm customerEditForm = new CustomerForm(Convert.ToInt32(selectedRow.Cells["CustomerId"].Value), Convert.ToInt32(selectedRow.Cells["AddressId"].Value));

                //Console.WriteLine("ID: " + Convert.ToInt32(selectedRow.Cells["AppointmentId"].Value));

                customerEditForm.ShowDialog();
                this.Show();

                initCustomerTable();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a row.");
                return;

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a row.");
                return;
            }
        }

        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteText = (Stored.RegionName == "es-ES") ? SpanishText.DeleteConfirmationText : "Are you sure you want to delete this?";
                string deleteTitle = (Stored.RegionName == "es-ES") ? SpanishText.DeleteConfirmationTitle : "Confirm Deletion";

                var confirmation = MessageBox.Show(deleteText, deleteTitle, MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = customerDataGridView.SelectedRows[0];

                    MySqlConnection connection = new MySqlConnection(Stored.connection_string);
                    connection.Open();

                    MySqlCommand command = new MySqlCommand($"UPDATE customer SET active = 0 WHERE customerId = {Convert.ToInt32(selectedRow.Cells["CustomerId"].Value)}", connection);
                    command.ExecuteNonQuery();

                    connection.Close();

                    initCustomerTable();
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a row.");
                return;

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a row.");
                return;
            }
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
