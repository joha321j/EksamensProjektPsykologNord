use B_DB19_2018

CREATE PROCEDURE SPInsertAppointment
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
@SocialSecurityNumber int,
@UserId int

AS
BEGIN
	INSERT INTO PN_Client(Id, MedicalReferral, Journalid, SocialSecurityNumber, UserId)
			VALUES(@ClientId, @MedicalRefferal, @JournalId, @SocialSecurityNumber, @UserId)
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
@InvoiceId int,
@DueDate datetime2(7),
@AppointmentId int

AS
BEGIN
	INSERT INTO PN_Invoice(Id, DueDate, AppointmentId)
			VALUES(@InvoiceId, @DueDate, @AppointmentId)
END
GO

CREATE PROCEDURE SPInsertUser
@UserId int,
@Name nvarchar(max),
@Address nvarchar(max),
@PhoneNumber nvarchar(12),
@Email nvarchar(max)

AS
BEGIN
	INSERT INTO PN_User(Id, Name, Address, PhoneNumber, Email)
			VALUES(@UserId, @Name, @Address, @PhoneNumber, @Email)
END
GO

CREATE PROCEDURE SPInsertJournal_Entry
@Journal_EntryId int,
@JournalId int,
@Text nvarchar(max)

AS
BEGIN
	INSERT INTO PN_Journal_Entry(Id,JournalId,Text)
			VALUES(@Journal_EntryId, @JournalId, @Text)
END
GO

CREATE PROCEDURE SPInsertPractitioner
@PractitonerId int,
@UserId int

AS
BEGIN
	INSERT INTO PN_Practitioner(Id, UserId)
			VALUES(@PractitonerId, @UserId)
END
GO

CREATE PROCEDURE SPInsertRoom
@RoomId int,
@DepartmentId int,
@Name nvarchar(max)

AS
BEGIN
	INSERT INTO PN_Room(Id,DepartmentId,Name)
			VALUES(@RoomId,@DepartmentId,@Name)
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

	SELECT PN_APPOINTMENT.DateAndTime, PN_Room.Id, PN_Room.Name, PN_Appointment.UserId, PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, 
	PN_AppointmentType.Duration, PN_AppointmentType.StandardPrice, PN_Appointment.Note, PN_User.Id  
	FROM PN_APPOINTMENT 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	join PN_Appointment.AppointmentTypeId = PN_AppointmentType.Id 
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
	WHERE Id = @AppointmentId
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
@DateAndTime datetime2(7),
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
			PractitionerId = @PractitionerId,
			Price = @Price,
			AppointmentTypeId = @AppointmentTTypeId,
			Note = @Note
	WHERE	Id = @AppointmentId
END
GO

CREATE PROCEDURE SPUpdateClient
@ClientId int,
@MedicalRefferal bit,
@JournalId int,
@SocialSecurityNumber int,
@UserId int

AS
BEGIN
	UPDATE PN_Client
	SET		MedicalReferral = @MedicalRefferal,
			Journalid = @JournalId,
			SocialSecurityNumber = @SocialSecurityNumber,
			UserId = @UserId
	WHERE	Id = @ClientId
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

CREATE PROCEDURE SPUpdatePractitioner
@PractitonerId int,
@UserId int

AS
BEGIN
	UPDATE PN_Practitioner
	SET		UserId = @UserId
	WHERE   Id = @PractitonerId
END
GO

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

	SELECT PN_APPOINTMENT.DateAndTime, PN_Room.Id, PN_Room.Name, PN_Appointment.UserId, PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, 
	PN_AppointmentType.Duration, PN_AppointmentType.StandardPrice, PN_Appointment.Note, PN_User.Id  
	FROM PN_APPOINTMENT 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	join PN_Appointment.AppointmentTypeId = PN_AppointmentType.Id 
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
END
GO