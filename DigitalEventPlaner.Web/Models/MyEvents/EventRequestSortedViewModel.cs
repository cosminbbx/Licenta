using System;
using System.Collections.Generic;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class EventRequestSortedViewModel
    {
        public List<EventRequestViewModel> NeedsApproval { get; set; }
        public List<EventRequestViewModel> Accepted { get; set; }
        public List<EventRequestViewModel> Canceled { get; set; }
    }
}
