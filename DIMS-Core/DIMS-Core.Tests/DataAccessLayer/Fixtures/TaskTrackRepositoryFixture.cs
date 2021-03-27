using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class TaskTrackRepositoryFixture : BaseRepositoryFixture<TaskTrackRepository>
    {
        public int UpdateTaskTrackId { get; set; }
        public int DeleteTaskTrackId { get; set; }
        public int AddTaskTrackId { get; set; }

        protected override TaskTrackRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateTaskTrackId = (await Context.TaskTracks.AddAsync(new TaskTrack
            {
                TrackDate = DateTime.Now.AddDays(1).Date,
                TrackNote = "UpdateNote",
                UserTaskId = 1
            })).Entity.TaskTrackId;

            DeleteTaskTrackId = (await Context.TaskTracks.AddAsync(new TaskTrack
            {
                TrackDate = DateTime.Now.AddDays(2).Date,
                TrackNote = "DeleteNote",
                UserTaskId = 2
            })).Entity.TaskTrackId;

            AddTaskTrackId = (await Context.TaskTracks.AddAsync(new TaskTrack
            {
                TrackDate = DateTime.Now.AddDays(3).Date,
                TrackNote = "AddNote",
                UserTaskId = 3
            })).Entity.TaskTrackId;

            await Context.SaveChangesAsync();
        }
    }
}
