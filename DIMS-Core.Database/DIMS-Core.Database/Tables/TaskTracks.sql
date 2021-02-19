CREATE TABLE [dbo].[TaskTracks]
(
    [TaskTrackId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserTaskId] INT NOT NULL, 
    [TrackDate] DATETIME NOT NULL, 
    [TrackNote] NVARCHAR(250) NULL,

    FOREIGN KEY (UserTaskId) REFERENCES UserTasks(UserTaskId)
)
