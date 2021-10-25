ALTER PROCEDURE [dbo].[SP_SaveUsersData]
	@UsersData UsersType READONLY,
	@UserMedicationData UsersMedicationType READONLY

AS
BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
			BEGIN
			MERGE [dbo].[users] as A
			USING @UsersData as B
			on A.Email=B.Email

			when MATCHED THEN
			UPDATE SET
			A.[Name]=B.[Name],
			A.Email=B.Email,
			A.ProvinceID=B.ProvinceID,
			A.IsActive=B.IsActive


			WHEN NOT MATCHED BY TARGET THEN
			INSERT
			(
			[Name],
			Email,
			ProvinceID,
			IsActive
			)
			Values
			(
			B.[Name],
			B.Email,
			B.ProvinceID,
			B.IsActive
			);

			END


		COMMIT TRANSACTION;

			declare @UserMedicationCount int
		 select @UserMedicationCount= count(*) from UsersMedications
		 print @UserMedicationCount
		 if(@UserMedicationCount = 0)
			Begin 
		 
				BEGIN TRANSACTION
				BEGIN
	
					insert into UsersMedications (MedicationID, UserID)
					select MedicationID, UserID from @UserMedicationData order by UserID 

				END


				COMMIT TRANSACTION;
			End
		SELECT 1
		END TRY
		BEGIN CATCH
			rollback transaction;
			SELECT 0
		END CATCH
END



