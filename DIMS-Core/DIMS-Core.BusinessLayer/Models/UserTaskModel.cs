using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Models
{
    public class UserTaskModel
    {
        public UserTaskModel()
        {
            TaskTracks = new HashSet<TaskTrackModel>();
        }

        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }

        public TaskStateModel State { get; set; }
        public Task Task { get; set; }
        public UserProfileModel User { get; set; }
        public ICollection<TaskTrackModel> TaskTracks { get; set; }
    }
}
