using DIMS_Core.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IDirectionService : IService<DirectionModel>
    {
        public bool Equal(DirectionModel directionModel1, DirectionModel directionModel2);
        public bool NotEqual(DirectionModel directionModel1, DirectionModel directionModel2);
    }
}
