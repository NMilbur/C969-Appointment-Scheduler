using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Milburn_Software2
{
    public partial class CustomerForm : Form
    {
        public delegate bool TextFieldValidity(Control.ControlCollection controls);
        public CustomerForm()
        {
            InitializeComponent();
            initCountryDD();
            initLabels();

            addressIdInput.Text = "-1";
            customerIdInput.Text = "-1";
        }

        public CustomerForm(int customerId, int addressId)
        {
            InitializeComponent();
            initCountryDD();
            initLabels();

            customerIdInput.Text = customerId.ToString();
            addressIdInput.Text = addressId.ToString();

            MySqlConnection connection = new MySqlConnection(Stored.connection_string);
            connection.Open();

            string sql = "SELECT customer.customerName, address.address, address.address2, city.city, address.postalCode, city.countryId, address.phone " +
                "FROM customer " +
                "JOIN address ON (customer.addressId = address.addressId) " +
                "JOIN city ON (address.cityId = city.cityId) " +
                $"WHERE customer.customerId = {customerId}";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    customerNameInput.Text = reader[0].ToString();
                    addressInput1.Text = reader[1].ToString();
                    addressInput2.Text = reader[2].ToString();
                    cityInput.Text = reader[3].ToString();
                    postalCodeInput.Text = reader[4].ToString();
                    countryDD.SelectedValue = (int)reader[5];
                    phoneInput.Text = reader[6].ToString();
                }
            }

            reader.Close();
            connection.Close();
        }

        public void initLabels()
        {
            if (Stored.RegionName == "es-ES")
            {
                nameLabel.Text = SpanishText.NameLabel;
                addressLabel.Text = SpanishText.AddressLabel;
                address2Label.Text = SpanishText.Address2Label;
                cityLabel.Text = SpanishText.CityLabel;
                postalCodeLabel.Text = SpanishText.PostalCodeLabel;
                countryLabel.Text = SpanishText.CountryLabel;
                phoneLabel.Text = SpanishText.PhoneLabel;
                saveBtn.Text = SpanishText.SaveBtn;
                cancelBtn.Text = SpanishText.CancelBtnText;
            }
        }

        public void initCountryDD()
        {
            List<DropDown> datasource = new List<DropDown>();

            MySqlConnection connection = new MySqlConnection(Stored.connection_string);
            connection.Open();

            string sql = "SELECT country, countryId FROM country ORDER BY country";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            countryDD.DisplayMember = "Name";
            countryDD.ValueMember = "Value";

            datasource.Add(new DropDown("Select...", -1));

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    datasource.Add(new DropDown(reader[0].ToString(), Convert.ToInt32(reader[1])));
                }
            }

            reader.Close();
            connection.Close();

            countryDD.DataSource = datasource;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool allowSubmit = true;

            // using this lambda to check all fields for values and displaying errors if no value is found for the field
            // this replaced a large section of if statements and generalized the value checking.
            TextFieldValidity checkValidSubmit = (controls) =>
            {
                bool showError = false;

                foreach (Control option in controls)
                {
                    if (option is ComboBox)
                    {
                        if ((int)((ComboBox)option).SelectedValue == -1) {
                            showError = true;
                            allowSubmit = false;
                        }
                    }
                    else 
                    {
                        if (String.IsNullOrWhiteSpace(option.Text) && (string)option.Tag != "pass")
                        {
                            showError = true;
                            allowSubmit = false;
                        } 
                    }
                    
                    if (showError)
                    {
                        errorProvider1.SetError(option, Stored.RequiredMessage);
                        showError = false;
                    } else
                    {
                        errorProvider1.SetError(option, "");
                    }
                }

                return allowSubmit;
            };

            allowSubmit = checkValidSubmit(Controls);

            if (allowSubmit)
            {
                MySqlConnection connection = new MySqlConnection(Stored.connection_string);
                connection.Open();

                MySqlCommand command;
                int countryId = (int)countryDD.SelectedValue;
                int cityId = (countryId == -1) ? -1 : getCityId(connection, countryId);
                int addressId = Convert.ToInt32(addressIdInput.Text);
                int customerId = Convert.ToInt32(customerIdInput.Text);

                if (addressId != -1)
                {
                    string addressUpdate = "UPDATE address " +
                        $"SET address = \"{addressInput1.Text}\", address2 = \"{addressInput2.Text}\", cityId = {cityId}, " +
                        $"postalCode = \"{postalCodeInput.Text}\", phone = \"{phoneInput.Text}\", lastUpdate = UTC_TIMESTAMP, lastUpdateBy = \"{Stored.UserName}\" " +
                        $"WHERE addressId = {addressId}";

                    command = new MySqlCommand(addressUpdate, connection);
                    command.ExecuteNonQuery();

                }
                else
                {
                    addressId = getAddressId(connection, cityId);
                }

                if (customerId != -1)
                {
                    string customerUpdate = "UPDATE customer " +
                        $"SET customerName = \"{customerNameInput.Text}\", addressId = {addressId}, lastUpdate = UTC_TIMESTAMP(), lastUpdateBy = \"{Stored.UserName}\" " +
                        $"WHERE customerId = {customerId}";

                    command = new MySqlCommand(customerUpdate, connection);
                    command.ExecuteNonQuery();

                }
                else
                {
                    string customerInsertSql = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                        $"VALUES (\"{customerNameInput.Text}\", {addressId}, 1, UTC_TIMESTAMP(), \"{Stored.UserName}\", UTC_TIMESTAMP(), \"{Stored.UserName}\")";

                    command = new MySqlCommand(customerInsertSql, connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();

                this.Close();
            }
        }

        private int getCityId(MySqlConnection connection, int countryId) {
            int cityId = -1;

            MySqlCommand command = new MySqlCommand($"SELECT cityId FROM city WHERE LOWER(city) = LOWER(\"{cityInput.Text}\") AND countryId = {countryId}", connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cityId = Convert.ToInt32(reader[0]);
                }
            }

            reader.Close();

            if (cityId == -1)
            {
                string cityInsertSql = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES (\"{cityInput.Text}\", {countryId}, UTC_TIMESTAMP(), \"{Stored.UserName}\", UTC_TIMESTAMP(), \"{Stored.UserName}\")";

                command = new MySqlCommand(cityInsertSql, connection);
                command.ExecuteNonQuery();

                command = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cityId = Convert.ToInt32(reader[0]);
                    }
                }

                reader.Close();
            }
            
            return cityId;
        }

        private int getAddressId(MySqlConnection connection, int cityId) {
            int addressId = -1;
            int customerId = Convert.ToInt32(customerIdInput.Text);

            string addressInsert = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                $"VALUES (\"{addressInput1.Text}\", \"{addressInput2.Text}\", {cityId}, \"{postalCodeInput.Text}\", \"{phoneInput.Text}\", " +
                $"UTC_TIMESTAMP(), \"{Stored.UserName}\", UTC_TIMESTAMP(), \"{Stored.UserName}\")";

            MySqlCommand command = new MySqlCommand(addressInsert, connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    addressId = Convert.ToInt32(reader[0]);
                }
            }

            reader.Close();

            return addressId;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
