using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    public static class ExceptionHelper
    {
        public static InvalidIdException CreateIdException(string paramName, int value)
        {
            return new InvalidIdException($"Invalid entity id = {value}", paramName, value);
        }

        public static EntityNotExistException CreateNotExistException(string methodName)
        {
            return new EntityNotExistException(methodName, $"Can't find entity in database");
        }

    }
}
