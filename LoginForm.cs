using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace Milburn_Software2
{
    public partial class LoginForm : Form
    {
        private string no_login_message = "The username and password combination provided does not exist in the system. Please try again.";
        private string empty_field_message = "Both the username and password need to be filled out.";

        public LoginForm()
        {
            InitializeComponent();

            //CultureInfo.CurrentUICulture = new CultureInfo("es-ES", false);
            //Console.WriteLine(CultureInfo.CurrentUICulture.Name);

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            Stored.RegionName = cultureInfo.Name;
            Stored.RequiredMessage = "This field is required";

            if (Stored.RegionName == "es-ES") {
                usernameLabel.Text = SpanishText.UsernameText;
                passwordLabel.Text = SpanishText.PasswordText;
                loginBtn.Text = SpanishText.LoginBtnText;
                cancelBtn.Text = SpanishText.CancelBtnText;

                no_login_message = SpanishText.NoLoginText;
                empty_field_message = SpanishText.EmptyLoginText;
                Stored.RequiredMessage = SpanishText.RequiredText;
            }

        }

        private void loginBtn_Click(object sender, EventArgs e) 
        {
            if (usernameInput.Text == "" || passwordInput.Text == "") 
            {
                MessageBox.Show(empty_field_message);

            } else 
            {
                MySqlConnection connection = new MySqlConnection(Stored.connection_string);
                connection.Open();

                MySqlCommand command = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{usernameInput.Text}' AND password = '{passwordInput.Text}'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Stored.UserID = 0;

                if (reader.HasRows)
                {
                    reader.Read();
                    Stored.UserID = Convert.ToInt32(reader[0]);
                }

                reader.Close();
                connection.Close();

                if (Stored.UserID != 0)
                {
                    DateTime currentDate = DateTime.Now;
                    Stored.UserName = usernameInput.Text;
                    //string tzOffset = TimeZone.CurrentTimeZone.GetUtcOffset(currentDate).ToString();
                    //string[] tzArr = tzOffset.Split(":");
                    Stored.Timezone = TimeZone.CurrentTimeZone.GetUtcOffset(currentDate).ToString().Substring(0, 6);

                    usernameInput.Text = "";
                    passwordInput.Text = "";

                    File.AppendAllText("login_log.txt", $"[{currentDate.ToString("yyyy-MM-dd HH:mm:ss")}] User \"{Stored.UserName}\" logged in\n");

                    Stored.checkReminder();

                    this.Hide();
                    AppointmentForm appointmentForm = new AppointmentForm();
                    appointmentForm.ShowDialog();
                    this.Show();

                } else
                {
                    MessageBox.Show(no_login_message);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
