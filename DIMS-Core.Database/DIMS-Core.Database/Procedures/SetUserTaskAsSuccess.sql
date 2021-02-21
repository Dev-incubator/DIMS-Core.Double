CREATE PROCEDURE [dbo].[SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS
    UPDATE UserTasks SET StateId = 2 /* Success */
    WHERE UserId = @UserId AND TaskId = @TaskId
