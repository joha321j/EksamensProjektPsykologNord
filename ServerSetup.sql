use B_DB19_2018

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
	DepartmentName int NOT NULL FOREIGN KEY REFERENCES PN_Department(Id),
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

CREATE TABLE dbo.PN_AppointmentType
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
	RoomId int NOT NULL FOREIGN KEY REFERENCES PN_Room(Id),
	--UserId int NOT NULL FOREIGN KEY REFERENCES PN_User(Id),
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