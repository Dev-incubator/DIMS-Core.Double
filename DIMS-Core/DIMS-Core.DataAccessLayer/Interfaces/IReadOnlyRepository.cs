using System.Linq;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class 
    {
        IQueryable<T> GetAll();
    }
}
