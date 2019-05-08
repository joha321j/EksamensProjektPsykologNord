use B_DB19_2018

IF OBJECT_ID('dbo.PN_Practitioner_AppointmentType', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Practitioner_AppointmentType;

IF OBJECT_ID('dbo.PN_User_Appointment', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_User_Appointment; 

IF OBJECT_ID('dbo.PN_Invoice', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Invoice;

IF OBJECT_ID('dbo.PN_Appointment', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Appointment; 

IF OBJECT_ID('dbo.PN_AppointmentType', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_AppointmentType; 

IF OBJECT_ID('dbo.PN_Department_Practitioner', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Department_Practitioner; 

IF OBJECT_ID('dbo.PN_Practitioner', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Practitioner; 

IF OBJECT_ID('dbo.PN_Client', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Client; 

IF OBJECT_ID('dbo.PN_User', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_User; 

IF OBJECT_ID('dbo.PN_Journal_Entry', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Journal_Entry; 

IF OBJECT_ID('dbo.PN_Journal', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Journal; 

IF OBJECT_ID('dbo.PN_Room', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Room; 

IF OBJECT_ID('dbo.PN_Department', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Department; 


CREATE TABLE dbo.PN_Department
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Address	nvarchar(max) NOT NULL,
	Name nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_Room
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name nvarchar(max),
	DepartmentId int NOT NULL FOREIGN KEY REFERENCES PN_Department(Id),
);

CREATE TABLE dbo.PN_Journal
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(max) NOT NULL
);

CREATE TABLE dbo.PN_Journal_Entry
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	JournalId int NOT NULL FOREIGN KEY REFERENCES PN_Journal(Id),
	Text nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_User
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name nvarchar(max) NOT NULL,
	Address nvarchar(max) NOT NULL,
	PhoneNumber nvarchar(12) NOT NULL,
	Email nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_Client
(
	Id int NOT NULL FOREIGN KEY REFERENCES PN_User(Id) PRIMARY KEY,
	MedicalReferral bit NOT NULL,
	Note NVARCHAR(MAX),
	Journalid int NOT NULL FOREIGN KEY REFERENCES PN_Journal(Id),
	SocialSecurityNumber NVARCHAR(12) NOT NULL	
);

CREATE TABLE dbo.PN_Practitioner
(
	Id int NOT NULL FOREIGN KEY REFERENCES PN_User(Id) PRIMARY KEY,
	StartTime DATETIME2 NOT NULL,
	DayLength TIME NOT NULL
);



CREATE TABLE dbo.PN_AppointmentType
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name nvarchar(max) NOT NULL,
	Duration TIME NOT NULL,
	StandardPrice float NOT NULL,
);

CREATE TABLE dbo.PN_Appointment
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DateAndTime DateTime2 NOT NULL,
	RoomId int NOT NULL FOREIGN KEY REFERENCES PN_Room(Id),
	Price float NOT NULL,
	AppointmentTypeId int NOT NULL FOREIGN KEY REFERENCES PN_AppointmentType(Id),
	Note nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_Invoice
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DueDate DateTime2 NOT NULL,
	AppointmentId int NOT NULL FOREIGN KEY REFERENCES PN_Appointment(Id),
);

CREATE TABLE dbo.PN_User_Appointment
(
	UserId int NOT NULL FOREIGN KEY REFERENCES PN_User(Id),
	AppointmentId int NOT NULL FOREIGN KEY REFERENCES PN_Appointment(Id),
	PRIMARY KEY(UserId, AppointmentId),
);

CREATE TABLE dbo.PN_Practitioner_AppointmentType
(
	PractitionerId int NOT NULL FOREIGN KEY REFERENCES PN_Practitioner(Id),
	AppointmentTypeId int NOT NULL FOREIGN KEY REFERENCES PN_AppointmentType(Id),
	PRIMARY KEY(PractitionerId, AppointmentTypeId),
);

CREATE TABLE dbo.PN_Department_Practitioner
(
	DepartmentId int NOT NULL FOREIGN KEY REFERENCES PN_Department(Id),
	PractitionerId int NOT NULL FOREIGN KEY REFERENCES PN_Practitioner(Id),
	PRIMARY KEY(PractitionerId, DepartmentId),	
);