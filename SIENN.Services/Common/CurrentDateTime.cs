using System;

namespace SIENN.Services.Common
{
    public class CurrentDateTime : ICurrentDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}