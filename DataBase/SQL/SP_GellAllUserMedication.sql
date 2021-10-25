CREATE PROCEDURE [dbo].[SP_GellAllUserMedication]

AS
BEGIN

select a.ID as Userid, a.name, a.Email,a.ProvinceID , c.ProvinceName, b.MedicationID, d.Medication, a.IsActive  from users a 

		inner join UsersMedications b
		on a.ID=b.UserID
		inner join Provinces c
		on a.ProvinceID=c.ID
		inner join Medications d
		on b.MedicationID=d.ID

		order by a.ID asc

END

