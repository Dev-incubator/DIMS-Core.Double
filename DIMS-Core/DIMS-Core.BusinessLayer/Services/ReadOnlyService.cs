using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class ReadOnlyService<TModel, TEntity, TRepository> : IReadOnlyService<TModel>
        where TModel : class
        where TEntity : class
        where TRepository : IReadOnlyRepository<TEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;

        protected ReadOnlyService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            var entities = _repository.GetAll();

            var mappedModels = _mapper.ProjectTo<TModel>(entities);

            return await mappedModels.ToListAsync();
        }

        #region Disposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ReadOnlyService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _repository.Dispose();

            _disposed = true;
        }
        #endregion
    }
}
