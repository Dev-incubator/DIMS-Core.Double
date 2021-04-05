using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IService<TModel> : IDisposable 
        where TModel : class
    {
        Task<TModel> Create(TModel model);
        Task<TModel> GetById(int id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> Update(TModel model);
        Task Delete(int id);
    }
}
