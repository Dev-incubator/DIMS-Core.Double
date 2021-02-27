using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Tests.DataAccessLayer.Infrastructure
{
    class TaskStateEqualityComparer : IEqualityComparer<TaskState>
    {
        public bool Equals(TaskState x, TaskState y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.StateId == y.StateId && x.StateName == y.StateName;
        }

        public int GetHashCode(TaskState obj)
        {
            return HashCode.Combine(obj.StateId, obj.StateName, obj.UserTasks);
        }
    }
}
