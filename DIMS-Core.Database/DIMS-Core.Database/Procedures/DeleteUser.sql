create procedure DeleteUser
	@UserId int
as
delete from [UserProfiles] where UserId = @UserId