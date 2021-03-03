using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DIMSCoreContext _context;

        private IRepository<UserProfile> _userProfileRepository;

        private IRepository<Direction> _directionRepository;

        private IRepository<UserTask> _userTaskRepository;

        private IRepository<Models.Task> _taskRepository;

        private IReadOnlyRepository<VUserProfile> _vUserProfileRepository;

        private IReadOnlyRepository<VUserTask> _vUserTaskRepository;

        private IReadOnlyRepository<VTask> _vTaskRepository;
        public IRepository<UserProfile> UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_context);

        public IRepository<Direction> DirectionRepository => _directionRepository ??= new DirectionRepository(_context);

        public IRepository<UserTask> UserTaskRepository => _userTaskRepository ??= new UserTaskRepository(_context);

        public IRepository<Models.Task> TaskRepository => _taskRepository ??= new TaskRepository(_context);

        public IReadOnlyRepository<VUserProfile> VUserProfileRepository => _vUserProfileRepository ??= new VUserProfileRepository(_context);
        public IReadOnlyRepository<VUserTask> VUserTaskRepository => _vUserTaskRepository ??= new VUserTaskRepository(_context);
        public IReadOnlyRepository<VTask> VTaskRepository => _vTaskRepository ??= new VTaskRepository(_context);

        public UnitOfWork(DIMSCoreContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
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

        ~UnitOfWork()
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
