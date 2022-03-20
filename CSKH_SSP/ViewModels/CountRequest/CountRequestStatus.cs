using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.ViewModels.CountRequest {
    public class CountRequestStatus {
        public int CountOpenStatus { get; set; }
        public int CountProcessingStatus { get; set; }
        public int CountClosedStatus { get; set; }
        public int CountDoneStatus { get; set; }
        public int CountRejectStatus { get; set; }
        public int CountMentionStatus { get; set; }
        public int CountPinnedRequest { get; set; }
    }
}
