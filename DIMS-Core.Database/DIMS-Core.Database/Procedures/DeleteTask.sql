create procedure DeleteTask
	@TaskId int
as
delete from [Tasks] where TaskId = @TaskId