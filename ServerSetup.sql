use B_DB19_2018

IF OBJECT_ID('dbo.PN_Client_Apppointment', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Invoice;

IF OBJECT_ID('dbo.PN_Appointment', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Appointment;

IF OBJECT_ID('dbo.PN_Room', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Room;

IF OBJECT_ID('dbo.PN_Department', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Department;

IF OBJECT_ID('dbo.PN_Journal', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Journal;

IF OBJECT_ID('dbo.PN_Journal_Entry', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Journal_Entry;

IF OBJECT_ID('dbo.PN_User', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_User;

IF OBJECT_ID('dbo.PN_Client', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Cliént;

IF OBJECT_ID('dbo.PN_Practitioner', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Practitioner;
  
IF OBJECT_ID('dbo.PN_TreatmentType', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_TreatmentType;

IF OBJECT_ID('dbo.PN_Invoice', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Invoice;

IF OBJECT_ID('dbo.PN_Practitioner_TreatmentType', 'U') IS NOT NULL 
  DROP TABLE dbo.PN_Invoice;

CREATE TABLE dbo.PN_Department
(
	Name nvarchar(120) NOT NULL PRIMARY KEY,
	Address	nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_Room
(
	Name nvarchar(120) NOT NULL,
	DepartmentName nvarchar(120) NOT NULL FOREIGN KEY REFERENCES PN_Department(Name),
	PRIMARY KEY(Name, DepartmentName)
);

CREATE TABLE dbo.PN_Journal
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
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
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MedicalReferral bit NOT NULL,
	Journalid int NOT NULL FOREIGN KEY REFERENCES PN_Journal(Id),
	SocialSecurityNumber int NOT NULL,
	UserId int NOT NULL FOREIGN KEY REFERENCES PN_User(Id)
);

CREATE TABLE dbo.PN_Practitioner
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId int NOT NULL FOREIGN KEY REFERENCES PN_User(Id),
);

CREATE TABLE dbo.PN_TreatmentType
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name nvarchar(max) NOT NULL,
	Duration DateTime2 NOT NULL,
	StandardPrice float NOT NULL,
);

CREATE TABLE dbo.PN_Appointment
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DateAndTime DateTime2 NOT NULL,
	DepartmentName nvarchar(120) NOT NULL,
	RoomName nvarchar(120) NOT NULL FOREIGN KEY (RoomName, DepartmentName) REFERENCES PN_Room(Name,DepartmentName),
	PractitionerId int NOT NULL FOREIGN KEY REFERENCES PN_Practitioner(Id),
	Price float NOT NULL,
	TreatmentTypeId int NOT NULL FOREIGN KEY REFERENCES PN_TreatmentType(Id),
	Note nvarchar(max) NOT NULL,
);

CREATE TABLE dbo.PN_Invoice
(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DueDate DateTime2 NOT NULL,
	AppointmentId int NOT NULL FOREIGN KEY REFERENCES PN_Appointment(Id),
);

CREATE TABLE dbo.PN_Client_Appointment
(
	ClientId int NOT NULL FOREIGN KEY REFERENCES PN_Client(Id),
	AppointmentId int NOT NULL FOREIGN KEY REFERENCES PN_Appointment(Id),
	PRIMARY KEY(ClientId, AppointmentId),
);

CREATE TABLE dbo.PN_Practitioner_TreatmentType
(
	PractitionerId int NOT NULL FOREIGN KEY REFERENCES PN_Practitioner(Id),
	TreatmentTypeId int NOT NULL FOREIGN KEY REFERENCES PN_TreatmentType(Id),
	PRIMARY KEY(PractitionerId, TreatmentTypeId),
);