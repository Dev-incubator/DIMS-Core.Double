CREATE PROCEDURE [dbo].[SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
    UPDATE UserTasks SET StateId = 3 /* Fail */
    WHERE UserId = @UserId AND TaskId = @TaskId
