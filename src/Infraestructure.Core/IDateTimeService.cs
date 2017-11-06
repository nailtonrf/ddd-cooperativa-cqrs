using System;

namespace Infraestructure.Core
{
    public interface IDateTimeService
    {
        DateTime CurrentDateTime();
        DateTime CurrentDate();
        DateTime MinValue();
    }
}