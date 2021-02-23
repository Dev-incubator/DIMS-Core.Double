CREATE TABLE [dbo].[TaskTracks]
(
    [TaskTrackId] INT NOT NULL IDENTITY, 
    [UserTaskId] INT NOT NULL, 
    [TrackDate] DATETIME NOT NULL, 
    [TrackNote] NVARCHAR(250) NULL,

    CONSTRAINT PK_TaskTrackId PRIMARY KEY (TaskTrackId),
    CONSTRAINT FK_TaskTrack_UserTask FOREIGN KEY (UserTaskId) REFERENCES UserTasks(UserTaskId) ON DELETE CASCADE ON UPDATE CASCADE 
)
