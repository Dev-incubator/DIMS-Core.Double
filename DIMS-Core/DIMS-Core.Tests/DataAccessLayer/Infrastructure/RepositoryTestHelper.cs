using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure.Comparer;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Operators;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer.Infrastructure
{
    /// <summary>
    /// class to assist in testing repositories
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryTestHelper<TEntity> : IDisposable where TEntity : class
    {
        private readonly DIMSCoreContext _context;
        private readonly IRepository<TEntity> _repository;
        private readonly IEqualityComparer<TEntity> _comparer;
        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repository"></param>
        /// <param name="deconstruct">lambda expressions which deconstruct entity to ValueTuple</param>
        public RepositoryTestHelper(DIMSCoreContext context, IRepository<TEntity> repository, Func<TEntity, ITuple> deconstruct)
        {
            _context = context;
            _repository = repository;
            _comparer = new EqualityComparator<TEntity>(deconstruct);
        }

        public async Task GetAllEqualsSeedData(ICollection<TEntity> seedData)
        {
            await DbSet.AddRangeAsync(seedData);
            await _context.SaveChangesAsync();

            var repositoryData = _repository.GetAll();

            Assert.Equal(seedData, repositoryData, _comparer);
        }

        public async Task GetByIdEqualsSeedEntity(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            var repositoryEntity = await _repository.GetById(1);

            Assert.Equal(entity, repositoryEntity, _comparer);
        }

        public async Task CreatedEntityEqualsSeedEntity(TEntity entity)
        {
            await _repository.Create(entity);
            await _context.SaveChangesAsync();

            var repositoryEntity = await DbSet.FirstAsync();

            Assert.Equal(entity, repositoryEntity, _comparer);
        }

        public async Task IsEntityUpdated(TEntity startEntityState, Func<TEntity, TEntity> changeState)
        {
            //Arrange
            await DbSet.AddAsync(startEntityState);
            await _context.SaveChangesAsync();
            var changedEntity = changeState(startEntityState);

            //Act
            var updatedEntity = _repository.Update(changedEntity);

            //Assert
            Assert.Equal(changedEntity, updatedEntity);
        }

        public async Task HasEntityDeleted(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            await _repository.Delete(1);
            await _context.SaveChangesAsync();

            Assert.DoesNotContain(entity, DbSet);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
