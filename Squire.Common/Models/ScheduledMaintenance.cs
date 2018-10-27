using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.Common.Models
{
    public class ScheduledMaintenance
    {
        public DateTimeOffset PlannedStart { get; set; }

        public DateTimeOffset PlannedEnd { get; set; }

        public string Reason { get; set; }
    }
}
