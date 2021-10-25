CREATE PROCEDURE [dbo].[SP_DeactivateUser]
	@UserId int

AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		update [users] set IsActive =0 where ID= @UserId
		
		COMMIT TRANSACTION;	
	SELECT 1
		END TRY
		BEGIN CATCH
			rollback transaction;
			SELECT 0
		END CATCH
END