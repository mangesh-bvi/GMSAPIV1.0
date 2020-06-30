using System;
using System.Collections.Generic;
using System.Text;

namespace GMS_System.Model
{
   public class StatusMaster
    {
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
