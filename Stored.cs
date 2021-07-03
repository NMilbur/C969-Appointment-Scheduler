using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Milburn_Software2
{
    public class Stored
    {
        public static string connection_string = @"server=wgudb.ucertify.com;userid=U08N7j;password=53689336285;database=U08N7j";
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string Timezone { get; set; }
        public static string RegionName { get; set; }
        public static string RequiredMessage { get; set; }
        public static bool HasViewedReminder { get; set; }
        public static int ViewedReminderApptID { get; set; }

        public static void checkReminder() {
            MySqlConnection connection = new MySqlConnection(connection_string);
            connection.Open();

            string sql = $"SELECT customer.customerName, DATE_FORMAT(CONVERT_TZ(appointment.start, '+00:00', \"{Timezone}\"), '%l:%i %p'), appointment.appointmentId " +
                "FROM appointment " +
                "JOIN customer ON (appointment.customerId = customer.customerId) " +
                $"WHERE appointment.userId = {UserID} AND appointment.start BETWEEN UTC_TIMESTAMP() AND DATE_ADD(UTC_TIMESTAMP(), INTERVAL 15 MINUTE)";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if ((Convert.ToInt32(reader[2]) != ViewedReminderApptID && HasViewedReminder) || !HasViewedReminder)
                    {
                        string message = (RegionName == "es-ES") ?
                            $"Tienes una cita con {reader[0].ToString()} a las {reader[1].ToString()}" :
                            $"You have an appointment with {reader[0].ToString()} at {reader[1].ToString()}";

                        MessageBox.Show(message);

                        HasViewedReminder = true;
                        ViewedReminderApptID = Convert.ToInt32(reader[2]);
                    }
                }
            }

            reader.Close();
            connection.Close();
        }
    }
}
