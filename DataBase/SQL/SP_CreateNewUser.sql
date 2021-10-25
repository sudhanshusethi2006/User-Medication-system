CREATE PROCEDURE [dbo].[SP_CreateNewUser]
	@Name	varchar(255),
	@Email	varchar(255),
	@ProvinceID	tinyint,
	@IsActive	bit,
	@UserMedicationData MedicationType READONLY 

AS
BEGIN
declare @id_identity int
	BEGIN TRY
		BEGIN TRANSACTION

		insert into [users]
		values
		(
		@Name,
		@Email,
		@ProvinceID,
		@IsActive
		)
		set @id_identity= @@IDENTITY
		COMMIT TRANSACTION;	

		BEGIN TRANSACTION
		insert into UsersMedications 
		select @id_identity, MedicationID from @UserMedicationData
		COMMIT TRANSACTION;	

	SELECT 1
		END TRY
		BEGIN CATCH
			rollback transaction;
			SELECT 0
		END CATCH
END