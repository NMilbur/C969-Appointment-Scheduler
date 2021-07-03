namespace Milburn_Software2
{
    class SpanishText
    {
        public static string RequiredText = "Este campo es obligatorio";

        // Login
        public static string UsernameText = "Nombre de usuario";
        public static string PasswordText = "Contraseña";
        public static string LoginBtnText = "Iniciar sesión";
        public static string CancelBtnText = "Cancelar";

        public static string NoLoginText = "La combinación de nombre de usuario y contraseña proporcionada no existe en el sistema. Inténtalo de nuevo.";
        public static string EmptyLoginText = "Es necesario completar tanto el nombre de usuario como la contraseña.";

        // Appointment Manager
        public static string AddApptText = "Agregar cita";
        public static string EditApptText = "Editar cita";
        public static string DeleteApptText = "Eliminar cita";
        public static string LogOutText = "Cerrar sesión";
        public static string MonthText = "Mes";
        public static string WeekText = "Semana";
        public static string ManageCustomerText = "Administrar clientes";
        public static string ReportsText = "Informes";
        public static string StartDateLabel = "Hora de inicio";
        public static string EndDateLabel = "Hora de finalización";
        public static string CustomerLabel = "Cliente";
        public static string ApptTypeLabel = "Tipo";
        public static string DeleteConfirmationText = "¿Estás seguro de que quieres eliminar esto?";
        public static string DeleteConfirmationTitle = "Confirmar la eliminación";

        // Appointment Add/Edit Form
        public static string ApptFormTypeLabel = "Tipo de cita";
        public static string ApptDateLabel = "Día de la cita";
        public static string ApptStartLabel = "Hora de inicio";
        public static string ApptEndLabel = "Hora de finalización";
        public static string SaveBtn = "Guardar";

        // Customer Manager
        public static string AddBtn = "Agregar";
        public static string EditBtn = "Editar";
        public static string DeleteBtn = "Eliminar";
        public static string GoBackBtn = "Regresa";
        public static string PhoneLabel = "Número de teléfono";

        // Customer Add/Edit Form
        public static string NameLabel = "Nombre";
        public static string AddressLabel = "Dirección";
        public static string Address2Label = "Dirección 2";
        public static string CityLabel = "Ciudad";
        public static string PostalCodeLabel = "Código postal";
        public static string CountryLabel = "País";

        // Reports Form
        public static string NumberOfTypesTitle = "Numero de tipos";
        public static string ConsultantTitle = "Consultor";
        public static string NumberOfClientsTitle = "Numero de clientes";

        // Exception Text
        public static string OutsideBusinessHoursText = "La hora de inicio y finalización debe ser entre las 8 a. M. Y las 6 p. M.";
        public static string OverlappingHoursText = "Los nuevos nombramientos no deben caer en el marco de tiempo de los nombramientos existentes.";
        public static string IncorrectTime = "La hora de inicio debe ser anterior a la hora de finalización.";
    }
}
