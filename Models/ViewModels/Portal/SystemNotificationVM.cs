using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class SystemNotificationVM
  {
        public int? UserNotificationId { get; set; }
        public string Title { get; set; }
        public string Body{ get; set; }
        public int SystemStatusId { get; set; }
        public string SystemStatusName { get; set; }
           public DateTime MessageDate { get; set; }
    

    }
}
