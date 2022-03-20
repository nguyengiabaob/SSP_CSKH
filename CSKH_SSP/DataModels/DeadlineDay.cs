using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.DataModels
{
    public class DeadlineConfig
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }

        public Nullable<int> Hours
        {
            get; set;
        }
    }
}
