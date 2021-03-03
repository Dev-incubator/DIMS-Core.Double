using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DIMS_Core.Common.Exceptions;


namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    /// TODO: Task #1
    /// Implement all methods
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set.AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            ExceptionHelper.ThrowIfInvalidId(id);

            var objectFromDb = await _set.FindAsync(id);

            ExceptionHelper.ThrowIfEntityIsNull(objectFromDb, nameof(GetById));

            return objectFromDb;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
           var create = await _set.AddAsync(entity);
           return create.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var update = _set.Update(entity);
            return update.Entity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _set.FindAsync(id);
            _set.Remove(entity);
        }

        protected DatabaseFacade GetDatabaseFacade()
        {
            return _context.Database;
        }

        #region Disposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _context.Dispose();

            _disposed = true;
        }

        ~Repository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}
