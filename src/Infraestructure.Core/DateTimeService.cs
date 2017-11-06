using System;

namespace Infraestructure.Core
{
    public sealed class DateTimeService : IDateTimeService
    {
        public DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }

        public DateTime CurrentDate()
        {
            return DateTime.Now.Date;
        }

        public DateTime MinValue()
        {
            return DateTime.MinValue;
        }
    }
}