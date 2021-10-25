ALTER PROCEDURE [dbo].[SP_UpdateUser]
	@Name	varchar(255),
	@Email	varchar(255),
	@ProvinceID	tinyint,
	@IsActive	bit,
	@UserId int,
	@UserMedicationData UsersMedicationType READONLY 

AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		update  [users] set
		[Name]= @Name,
		Email=@Email,
		ProvinceID=@ProvinceID,
		IsActive=@IsActive
		where ID=@UserId

		COMMIT TRANSACTION;	

		BEGIN TRANSACTION
		delete from UsersMedications where UserID=@UserId
		insert into UsersMedications(UserID,MedicationID)
		select MedicationID,UserID from  @UserMedicationData 
		COMMIT TRANSACTION;	

	SELECT 1
		END TRY
		BEGIN CATCH
			rollback transaction;
			SELECT 0
		END CATCH
END