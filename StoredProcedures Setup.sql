use B_DB19_2018

DROP PROC IF EXISTS SPInsertAppointment
DROP PROC IF EXISTS SPInsertClient
DROP PROC IF EXISTS SPInsertDepartment
DROP PROC IF EXISTS SPInsertInvoice
DROP PROC IF EXISTS SPInsertUser
DROP PROC IF EXISTS SPInsertJournal_Entry
DROP PROC IF EXISTS SPInsertPractitioner
DROP PROC IF EXISTS SPInsertRoom
DROP PROC IF EXISTS SPInsertAppointmentType
DROP PROC IF EXISTS SPSelectAppointment
DROP PROC IF EXISTS SPSelectClient
DROP PROC IF EXISTS SPSelectDepartment
DROP PROC IF EXISTS SPSelectInvoice
DROP PROC IF EXISTS SPSelectJournal_Entry
DROP PROC IF EXISTS SPSelectPractitioner
DROP PROC IF EXISTS SPSelectRoom
DROP PROC IF EXISTS SPSelectAppointmentType
DROP PROC IF EXISTS SPSelectUser
DROP PROC IF EXISTS SPUpdateClient
DROP PROC IF EXISTS SPUpdateAppointment
DROP PROC IF EXISTS SPUpdateDepartment
DROP PROC IF EXISTS SPUpdateInvoice
DROP PROC IF EXISTS SPUpdateJournal_Entry
DROP PROC IF EXISTS SPUpdatePractitioner
DROP PROC IF EXISTS SPUpdateRoom
DROP PROC IF EXISTS SPUpdateAppointmentType
DROP PROC IF EXISTS SPUdateUser
DROP PROC IF EXISTS SPDeleteAppointment
DROP PROC IF EXISTS SPDeleteClient
DROP PROC IF EXISTS SPDeleteAppointment
DROP PROC IF EXISTS SPDeleteDepartment
DROP PROC IF EXISTS SPDeleteInvoice
DROP PROC IF EXISTS SPDeleteJournal_Entry
DROP PROC IF EXISTS SPDeletePractitioner
DROP PROC IF EXISTS SPDeleteRoom
DROP PROC IF EXISTS SPDeleteAppointmentType
DROP PROC IF EXISTS SPDeleteUser
DROP PROC IF EXISTS SPGetAllAppointments

GO



CREATE PROC SPInsertAppointment
@DateAndTime datetime2,
@RoomId int,
@Price float,
@AppointmentTypeId int,
@Note nvarchar(max)

AS
BEGIN

	INSERT INTO PN_Appointment(DateAndTime, RoomId, Price, AppointmentTypeId, Note)
			VALUES(@DateAndTime, @RoomId, @Price, @AppointmentTypeId, @Note)

END
GO

CREATE PROCEDURE SPInsertClient
@ClientId int,
@MedicalRefferal bit,
@JournalId int,
@SocialSecurityNumber int

AS
BEGIN
	INSERT INTO PN_Client(Id, MedicalReferral, Journalid, SocialSecurityNumber)
			VALUES(@ClientId, @MedicalRefferal, @JournalId, @SocialSecurityNumber)
END
GO

CREATE PROCEDURE SPInsertDepartment
@DepartmentId int,
@Address nvarchar(max),
@Name nvarchar(max)

AS
BEGIN
	INSERT INTO PN_Department(Id, Address, Name)
			VALUES(@DepartmentId, @Address, @Name)
END
GO

CREATE PROCEDURE SPInsertInvoice
@DueDate datetime2(7),
@AppointmentId int

AS
BEGIN
	INSERT INTO PN_Invoice(DueDate, AppointmentId)
			VALUES(@DueDate, @AppointmentId)
END
GO

CREATE PROCEDURE SPInsertUser
@Name nvarchar(max),
@Address nvarchar(max),
@PhoneNumber nvarchar(12),
@Email nvarchar(max)

AS
BEGIN
	INSERT INTO PN_User(Name, Address, PhoneNumber, Email)
			VALUES(@Name, @Address, @PhoneNumber, @Email)
END
GO

CREATE PROCEDURE SPInsertJournal_Entry
@JournalId int,
@Text nvarchar(max)

AS
BEGIN
	INSERT INTO PN_Journal_Entry(JournalId,Text)
			VALUES(@JournalId, @Text)
END
GO

CREATE PROCEDURE SPInsertPractitioner
@UserId int

AS
BEGIN
	INSERT INTO PN_Practitioner(Id)
			VALUES(@UserId)
END
GO

CREATE PROCEDURE SPInsertRoom
@DepartmentId int,
@Name nvarchar(max)

AS
BEGIN
	INSERT INTO PN_Room(DepartmentId,Name)
			VALUES(@DepartmentId,@Name)
END
GO

CREATE PROCEDURE SPInsertAppointmentType
@Name nvarchar(max),
@Duration datetime2(7),
@StandardPrice float

AS
BEGIN
	INSERT INTO PN_AppointmentType(Name, Duration, StandardPrice)
			VALUES(@Name, @Duration, @StandardPrice)
END
GO

CREATE PROCEDURE SPSelectAppointment
@AppointmentId int

AS
BEGIN

	SELECT PN_APPOINTMENT.DateAndTime, PN_Room.Id, PN_Room.Name, PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, 
	PN_AppointmentType.Duration, PN_AppointmentType.StandardPrice, PN_Appointment.Note 
	FROM PN_APPOINTMENT 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	JOIN PN_AppointmentType ON PN_AppointmentType.Id = PN_Appointment.AppointmentTypeId
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
	WHERE PN_Appointment.Id = @AppointmentId
END
GO

CREATE PROCEDURE SPSelectClient
@ClientId int

AS
BEGIN

	SELECT * FROM PN_Client
	WHERE Id like '%'+@ClientId+'%'
END
GO

CREATE PROCEDURE SPSelectDepartment
@DepartmentId int

AS
BEGIN

	SELECT * FROM PN_Department
	WHERE Id like '%'+@DepartmentId+'%'
END
GO

CREATE PROCEDURE SPSelectInvoice
@InvoiceId int

AS
BEGIN

	SELECT * FROM PN_Invoice
	WHERE Id like '%'+@InvoiceId+'%'
END
GO

CREATE PROCEDURE SPSelectJournal_Entry
@Journal_EntryId int

AS
BEGIN

	SELECT * FROM PN_Journal_Entry
	WHERE Id like '%'+@Journal_EntryId+'%'
END
GO

CREATE PROCEDURE SPSelectPractitioner
@PractitionerId int

AS
BEGIN

	SELECT * FROM PN_Practitioner
	WHERE Id like '%'+@PractitionerId+'%'
END
GO
CREATE PROCEDURE SPSelectRoom
@RoomId int

AS
BEGIN

	SELECT * FROM PN_Room
	WHERE Id like '%'+@RoomId+'%'
END
GO

CREATE PROCEDURE SPSelectAppointmentType
@AppointmentTypeId int

AS
BEGIN

	SELECT * FROM PN_AppointmentType
	WHERE Id like '%'+@AppointmentTypeId+'%'
END
GO

CREATE PROCEDURE SPSelectUser
@UserId int

AS
BEGIN

	SELECT * FROM PN_User
	WHERE Id like '%'+@UserId+'%'
END
GO

CREATE PROCEDURE SPUpdateAppointment
@AppointmentId int,
@DateAndTime datetime2,
@RoomId int,
@PractitionerId int,
@Price float,
@AppointmentTypeId int,
@Note nvarchar(max)

AS
BEGIN
	UPDATE PN_Appointment
	SET		DateAndTime	= @DateAndTime,
			RoomId = @RoomId,			
			Price = @Price,
			AppointmentTypeId = @AppointmentTypeId,
			Note = @Note
	WHERE	Id = @AppointmentId
END
GO

CREATE PROCEDURE SPUpdateClient
@MedicalRefferal bit,
@JournalId int,
@SocialSecurityNumber int,
@ClintId int

AS
BEGIN
	UPDATE PN_Client
	SET		MedicalReferral = @MedicalRefferal,
			Journalid = @JournalId,
			SocialSecurityNumber = @SocialSecurityNumber
	WHERE	Id = @ClintId
END
GO

CREATE PROCEDURE SPUpdateDepartment
@DepartmentId int,
@Address nvarchar(max),
@Name nvarchar(max)

AS
BEGIN
	UPDATE PN_Department
	SET		Address = @Address,
			Name = @Name
	WHERE	Id = @DepartmentId
END
GO

CREATE PROCEDURE SPUpdateInvoice
@InvoiceId int,
@DueDate datetime2(7),
@AppointmentId int

AS
BEGIN
	UPDATE PN_Invoice
	SET		DueDate = @DueDate,
			AppointmentId = @AppointmentId
	WHERE	Id = @InvoiceId
END
GO

CREATE PROCEDURE SPUpdateJournal_Entry
@Journal_EntryId int,
@JournalId int,
@Text nvarchar(max)

AS
BEGIN
	UPDATE PN_Journal_Entry
	SET		JournalId = @JournalId,
			Text = @Text
	WHERE	Id = @Journal_EntryId
END
GO

--CREATE PROCEDURE SPUpdatePractitioner
--@PractitonerId int,
--@UserId int

--AS
--BEGIN
--	UPDATE PN_Practitioner
	--SET		UserId = @UserId
	--WHERE   Id = @PractitonerId
--END
--GO

CREATE PROCEDURE SPUpdateRoom
@RoomId int,
@DepartmentId int,
@Name nvarchar(max)

AS
BEGIN
	UPDATE PN_ROOM
	SET		DepartmentId = @DepartmentId,
			Name = @Name
	WHERE	Id = @RoomId
END
GO

CREATE PROCEDURE SPUpdateAppointmentType
@AppointmentTypeId int,
@Name nvarchar(max),
@Duration datetime2(7),
@StandardPrice float

AS
BEGIN
	UPDATE	PN_AppointmentType
	SET		Name = @Name,
			Duration = @Duration,
			StandardPrice = @StandardPrice
	WHERE	Id = @AppointmentTypeId
END
GO

CREATE PROCEDURE SPUdateUser
@UserId int,
@Name nvarchar(max),
@Address nvarchar(max),
@PhoneNumber nvarchar(12),
@Email nvarchar(max)

AS
BEGIN
	UPDATE PN_User
	SET		name = @Name,
			Address = @Address,
			PhoneNumber = @PhoneNumber,
			Email = @Email
	WHERE	Id = @UserId
END
GO

CREATE PROCEDURE SPDeleteAppointment
@AppointmentId int

AS
BEGIN
	DELETE from PN_Appointment
	WHERE	Id = @AppointmentId
END
GO

CREATE PROCEDURE SPDeleteClient
@ClientId int

AS
BEGIN
	DELETE from PN_Client
	WHERE	Id = @ClientId
END
GO

CREATE PROCEDURE SPDeleteDepartment
@DepartmentId int

AS
BEGIN
	DELETE from PN_Department
	WHERE	Id = @DepartmentId
END
GO

CREATE PROCEDURE SPDeleteInvoice
@InvoiceId int

AS
BEGIN
	DELETE from PN_Invoice
	WHERE Id = @InvoiceId
END
GO

CREATE PROCEDURE SPDeleteJournal_Entry
@Journal_EntryId int

AS
BEGIN
	DELETE from PN_Journal_Entry
	WHERE Id = @Journal_EntryId
END
GO

CREATE PROCEDURE SPDeletePractitioner
@PractitionerId int

AS
BEGIN
	DELETE from PN_Practitioner
	WHERE Id = @PractitionerId
END
GO

CREATE PROCEDURE SPDeleteRoom
@RoomId int

AS
BEGIN
	DELETE from PN_Room
	WHERE id = @RoomId
END
GO

CREATE PROCEDURE SPDeleteAppointmentType
@AppointmentTypeId int

AS
BEGIN
	DELETE from PN_AppointmentType
	WHERE Id = @AppointmentTypeId
END
GO

CREATE PROCEDURE SPDeleteUser
@UserId int

AS
BEGIN
	DELETE from PN_User
	WHERE Id = @UserId
END
GO

CREATE PROCEDURE SPGetAllAppointments

AS
BEGIN

	SELECT PN_APPOINTMENT.DateAndTime, PN_Room.Id, PN_Room.Name, PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, 
	PN_AppointmentType.Duration, PN_AppointmentType.StandardPrice, PN_Appointment.Note
	FROM PN_APPOINTMENT 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	JOIN PN_AppointmentType ON PN_AppointmentType.Id = PN_Appointment.AppointmentTypeId
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
END
GO