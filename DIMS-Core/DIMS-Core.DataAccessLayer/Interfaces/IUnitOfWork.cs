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
        IReadOnlyRepository<VUserProfile> VUserProfileRepository { get; }

        Task SaveChanges();
    }
}