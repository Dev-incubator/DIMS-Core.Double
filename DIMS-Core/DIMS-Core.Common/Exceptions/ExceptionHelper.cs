using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    public static class ExceptionHelper
    {
        public static void ThrowIfIntLessOrEqualZero(int id, string paramName = "id")
        {
            if (id <= 0)
            {
                throw new InvalidIdException($"Invalid entity id = {id}", paramName, id);
            }
        }

        public static void ThrowNotExistException(string methodName)
        {
            throw new EntityNotExistException(methodName, $"Can't find entity in database");
        }
    }
}
