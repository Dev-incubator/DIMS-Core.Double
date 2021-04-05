using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Models
{
    public class TaskStateModel
    {
        public TaskStateModel()
        {
            UserTasks = new HashSet<UserTaskModel>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public ICollection<UserTaskModel> UserTasks { get; set; }
    }
}
