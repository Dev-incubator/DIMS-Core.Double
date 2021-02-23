using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class VTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
