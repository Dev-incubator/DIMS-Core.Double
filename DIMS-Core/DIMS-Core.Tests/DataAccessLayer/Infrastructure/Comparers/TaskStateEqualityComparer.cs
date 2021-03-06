using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Tests.DataAccessLayer.Infrastructure.Comparers
{
    class TaskStateEqualityComparer : IEqualityComparer<TaskState>
    {
        public bool Equals(TaskState x, TaskState y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null)
            {
                return false;
            }

            if (y is null)
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.StateName == y.StateName;
        }

        public int GetHashCode(TaskState obj)
        {
            return HashCode.Combine(obj.StateId, obj.StateName, obj.UserTasks);
        }
    }
}
