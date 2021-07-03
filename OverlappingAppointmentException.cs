using System;

namespace Milburn_Software2
{
    public class OverlappingAppointmentException : Exception
    {
        public OverlappingAppointmentException() : base("New appointments must not fall in the timeframe of existing appointments.")
        {

        }

        public OverlappingAppointmentException(string message) : base(message)
        {

        }
    }
}
