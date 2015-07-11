using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DateTimeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DateTimeService.svc or DateTimeService.svc.cs at the Solution Explorer and start debugging.
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
