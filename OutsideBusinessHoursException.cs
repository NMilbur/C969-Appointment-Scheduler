using System;

namespace Milburn_Software2
{
    public class OutsideBusinessHoursException : Exception
    {
        public OutsideBusinessHoursException() : base("Start and end time must be between 8 AM and 6 PM")
        {

        }

        public OutsideBusinessHoursException(string messageValue) : base(messageValue) 
        { 
     
        }
    }
}
