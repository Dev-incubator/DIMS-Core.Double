using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class TaskState
    {
        public TaskState()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
