using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    public static class ExceptionHelper
    {
        public static void ThrowIdException(string paramName, int value)
        {
            throw new InvalidIdException($"Invalid entity id = {value}", paramName, value);
        }

        public static void ThrowNotExistException(string methodName)
        {
            throw new EntityNotExistException(methodName, $"Can't find entity in database");
        }

    }
}
