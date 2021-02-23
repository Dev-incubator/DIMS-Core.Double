using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DirectionId { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? StartDate { get; set; }
        public double UniversityAverageScore { get; set; }
        public double MathScore { get; set; }
        public byte Sex { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }

        public virtual Direction Direction { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
