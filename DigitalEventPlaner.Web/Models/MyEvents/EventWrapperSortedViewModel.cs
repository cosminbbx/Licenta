using System;
using System.Collections.Generic;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class EventWrappersSortedViewModel
    {
        public List<EventWrapperViewModel> NeedsApproval { get; set; }
        public List<EventWrapperViewModel> ToBeDone { get; set; }
        public List<EventWrapperViewModel> Done { get; set; }
        public List<EventWrapperViewModel> Canceled { get; set; }
    }
}
