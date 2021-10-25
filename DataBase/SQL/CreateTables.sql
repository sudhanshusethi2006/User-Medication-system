CREATE DATABASE UserMedicationSystem;
use UserMedicationSystem
---------------------------------------------
create table Provinces(
ID tinyint primary key,
ProvinceName varchar(40)
)

insert into Provinces values
(1, 'Alberta'),
(2, 'British Columbia'),
(3, 'Manitoba'),
(4, 'New Brunswick'),
(5, 'Newfoundland and Labrador'),
(6, 'Northwest Territories'),
(7, 'Nova Scotia'),
(8, 'Nunavut'),
(9, 'Ontario'),
(10, 'Prince Edward Island'),
(11, 'Quebec'),
(12, 'Saskatchewan'),
(13, 'Yukon')
-----------------------------------------------------
create table Medications
(
ID smallint primary key,
Medication varchar(20)
)

insert into Medications values
(1,'diabetes T1'),
(2,'diabetes T2'),
(3,'migraine'),
(4,'obesity'),
(5,'depression')
------------------------------------------------------------

create table Users
(
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) NOT NULL,
Email varchar (255),
ProvinceID tinyint,
IsActive bit,
constraint fk_province foreign key(ProvinceId) references Provinces(ID),
constraint uc_email UNIQUE(Email)
)

--------------------------------
create table UsersMedications
(
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserID int,
MedicationID smallint,
constraint fk_Usermedication foreign key(MedicationID) references Medications(ID),
constraint fk_UserID foreign key(UserID) references users(ID)
)




-----------------------------
CREATE TYPE UsersType as Table
(
Name varchar(255) NOT NULL,
Email varchar (255),
ProvinceID tinyint,
IsActive bit
)

----------------------------
CREATE TYPE UsersMedicationType as Table
(
	
	MedicationID smallint,
	UserID int
)

--------------------------------------------
CREATE TYPE MedicationType as Table
(
		MedicationID smallint 
)
----------------------------------


