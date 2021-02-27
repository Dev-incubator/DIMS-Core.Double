using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{

    public class InvalidIdException : BaseException
    {
        public int Id { get; set; }

        public InvalidIdException(string message, string paramName, int id) : base(message)
        {
            this.Id = id;
        }
    }

}
