using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.Models
{
    public class RoutineDetail
    {
        public int RoutineId { get; set; }
        public string RoutineTitle { get; set; }
        public DateTime RoutineScheduledFor { get; set; }
        public string RoutineScheduleTime { get; set; }

    }
}
