create table [dbo].[UserTasks]
(
	[UserTaskId] INT NOT NULL PRIMARY KEY IDENTITY,
	[TaskId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[StateId] INT NOT NULL

	FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId) on update cascade on delete cascade,
	FOREIGN KEY (UserId) REFERENCES UserProfiles(UserId) on update cascade on delete cascade,
	FOREIGN KEY (StateId) REFERENCES TaskStates(StateId) on update cascade on delete cascade,
)