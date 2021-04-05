using System;
namespace DIMS_Core.BusinessLayer.Models
{
    public class DirectionModel
    {
        public int DirectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public static bool operator ==(DirectionModel left, DirectionModel right)
        {
            return left.Name == right.Name;
        }

        public static bool operator !=(DirectionModel left, DirectionModel right)
        {
            return left.Name != right.Name;
        }
    }
}
