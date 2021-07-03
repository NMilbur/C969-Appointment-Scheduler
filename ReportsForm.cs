using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Milburn_Software2
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();

            reportDataGridView.DataSource = null;

            Stored.checkReminder();
        }

        public void initReportTable(string reportType)
        {
            string column1Title = "";
            string column2Title = "";
            string column3Title = "";
            string column4Title = "";

            if (reportType == "types_per_month")
            {
                column1Title = (Stored.RegionName == "es-ES") ? SpanishText.NumberOfTypesTitle : "Number of Types";
                column2Title = (Stored.RegionName == "es-ES") ? SpanishText.MonthText : "Month";

            }
            else if (reportType == "appointments_per_user")
            {
                column1Title = (Stored.RegionName == "es-ES") ? SpanishText.ConsultantTitle : "Consultant";
                column2Title = (Stored.RegionName == "es-ES") ? SpanishText.CustomerLabel : "Customer";
                column3Title = (Stored.RegionName == "es-ES") ? SpanishText.StartDateLabel : "Start";
                column4Title = (Stored.RegionName == "es-ES") ? SpanishText.EndDateLabel : "End";

            }
            else if (reportType == "customers_per_month") {
                column1Title = (Stored.RegionName == "es-ES") ? SpanishText.NumberOfClientsTitle : "Number of Customers";
                column2Title = (Stored.RegionName == "es-ES") ? SpanishText.MonthText : "Month";
            }

            reportDataGridView.DataSource = null;
            reportDataGridView.DataSource = getReport(reportType);
            reportDataGridView.AutoGenerateColumns = false;

            reportDataGridView.Columns["Column1"].HeaderText = column1Title;
            reportDataGridView.Columns["Column1"].DisplayIndex = 0;
            reportDataGridView.Columns["Column1"].Width = 130;

            reportDataGridView.Columns["Column2"].HeaderText = column2Title;
            reportDataGridView.Columns["Column2"].DisplayIndex = 1;
            reportDataGridView.Columns["Column2"].Width = 130;

            if (reportType == "appointments_per_user")
            {
                reportDataGridView.Columns["Column3"].HeaderText = column3Title;
                reportDataGridView.Columns["Column3"].DisplayIndex = 2;
                reportDataGridView.Columns["Column3"].Width = 130;
                reportDataGridView.Columns["Column3"].Visible = true;

                reportDataGridView.Columns["Column4"].HeaderText = column4Title;
                reportDataGridView.Columns["Column4"].DisplayIndex = 3;
                reportDataGridView.Columns["Column4"].Width = 130;
                reportDataGridView.Columns["Column4"].Visible = true;

            } else
            {
                reportDataGridView.Columns["Column3"].Visible = false;
                reportDataGridView.Columns["Column4"].Visible = false;
            } 
        }

        public List<Report> getReport(string reportType)
        {
            List<Report> rows = new List<Report>();
            MySqlConnection connection = new MySqlConnection(Stored.connection_string);
            connection.Open();

            string sql = "";

            if (reportType == "types_per_month")
            {
                sql = $"SELECT COUNT(DISTINCT type),  DATE_FORMAT(CONVERT_TZ(start, '+00:00', \"{Stored.Timezone}\"), '%m/%Y'), start AS month_year FROM appointment GROUP BY month_year ORDER BY month_year";
            
            } else if (reportType == "appointments_per_user")
            {
                sql = $"SELECT user.userName, customer.customerName, CONVERT_TZ(appointment.start, '+00:00', \"{Stored.Timezone}\"), " +
                    $"CONVERT_TZ(appointment.end, '+00:00', \"{Stored.Timezone}\") FROM appointment " +
                    "JOIN customer ON (appointment.customerId = customer.customerId) " +
                    "JOIN user ON (appointment.userId = user.userId) " +
                    "ORDER BY user.userName ASC, appointment.start ASC";
            
            } else if (reportType == "customers_per_month")
            {
                sql = $"SELECT COUNT(DISTINCT appointment.customerId), DATE_FORMAT(CONVERT_TZ(start, '+00:00', \"{Stored.Timezone}\"), '%m/%Y') AS month_year FROM appointment GROUP BY month_year ORDER BY month_year";
            }

            MySqlCommand command = new MySqlCommand(sql, connection);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reportType == "appointments_per_user")
                    {
                        rows.Add(new Report(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                    } else
                    {
                        rows.Add(new Report(reader[0].ToString(), reader[1].ToString()));
                    }
                }
            }

            reader.Close();
            connection.Close();

            return rows;
        }

        private void numApptTypeRpt_Click(object sender, EventArgs e)
        {
            initReportTable("types_per_month");
        }

        private void schedulePerConsultRpt_Click(object sender, EventArgs e)
        {
            initReportTable("appointments_per_user");
        }

        private void numCustomersPerMonthRpt_Click(object sender, EventArgs e)
        {
            initReportTable("customers_per_month");
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
