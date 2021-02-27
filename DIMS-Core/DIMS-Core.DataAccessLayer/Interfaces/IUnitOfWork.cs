using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<Direction> DirectionRepository { get; }
        IRepository<UserTask> UserTaskRepository { get; }
        IRepository<Models.Task> TaskRepository { get; }
        IReadOnlyRepository<VUserProfile> VUserProfileRepository { get; }
        IReadOnlyRepository<VUserTask> VUserTaskRepository { get; }
        IReadOnlyRepository<VTask> VTaskRepository { get; }

        Task SaveChanges();
    }
}