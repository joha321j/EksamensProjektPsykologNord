use B_DB19_2018

DROP PROC IF EXISTS SPInsertAppointmentForUser
DROP PROC IF EXISTS SPInsertAppointmentOutId
DROP PROC IF EXISTS SPInsertClient
DROP PROC IF EXISTS SPInsertDepartment
DROP PROC IF EXISTS SPInsertInvoice
DROP PROC IF EXISTS SPInsertUserOutId
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
DROP PROC IF EXISTS SPUpdateDepartment
DROP PROC IF EXISTS SPUpdateInvoice
DROP PROC IF EXISTS SPUpdateJournal_Entry
DROP PROC IF EXISTS SPUpdatePractitioner
DROP PROC IF EXISTS SPUpdateRoom
DROP PROC IF EXISTS SPUpdateAppointmentType
DROP PROC IF EXISTS SPUdateUser
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
DROP PROC IF EXISTS SPGetAllClients
DROP PROC IF EXISTS SPGetAllPractitioners
DROP PROC IF EXISTS SPGetAllDepartments
DROP PROC IF EXISTS SPGetRoomsFromDepartment
DROP PROC IF EXISTS SPGetPractitionersFromDepartment
DROP PROC IF EXISTS SPGetAppointmentTypeByPractitionerId
DROP PROC IF EXISTS SPGetUsersFromAppointmentId
DROP PROC IF EXISTS SPGetAppointmentsById
DROP PROC IF EXISTS SPDeleteAppointment
DROP PROC IF EXISTS SPGetAppointmentById
DROP PROC IF EXISTS SPUpdateAppointment
DROP PROC IF EXISTS SPInsertUserOutId

GO

CREATE PROC SPDeleteUser @UserId int
AS
BEGIN
DELETE FROM PN_User
WHERE PN_User.Id = @UserId
END
GO

CREATE PROC SPInsertClient
@ClientId int,
@MedicalRefferal bit,
@JournalId int,
@Note NVARCHAR(MAX),
@SocialSecurityNumber NVARCHAR(MAX)
AS
BEGIN
INSERT INTO PN_Client(Id, MedicalReferral, Journalid, Note, SocialSecurityNumber)
VALUES(@ClientId, @MedicalRefferal, @JournalId, @Note, @SocialSecurityNumber)
END
GO

CREATE PROC SPInsertUserOutId
@Name NVARCHAR(MAX),
@Address NVARCHAR(MAX),
@PhoneNumber NVARCHAR(MAX),
@Email NVARCHAR(MAX)
AS
BEGIN
INSERT INTO PN_User(Name, Address, PhoneNumber, Email)
OUTPUT inserted.Id
VALUES (@Name, @Address, @PhoneNumber, @Email)
END
GO

CREATE PROC SPUpdateAppointment
@AppointmentId int,
@DateAndTime datetime2,
@Note nvarchar(max),
@EmailNotification bit,
@SMSNotification bit,
@NotificationTime int

AS
BEGIN
	UPDATE PN_Appointment
	SET 
	DateAndTime = @DateAndTime,
	Note = @Note,
    Notificationtime = @NotificationTime,
    SMSNotification = @SMSNotification,
    EmailNotification = @EmailNotification
	WHERE PN_Appointment.Id = @AppointmentId
END
GO


CREATE PROC SPDeleteAppointment
@AppointmentId int
AS
BEGIN
	DELETE FROM PN_User_Appointment
	WHERE PN_User_Appointment.AppointmentId IN
	(
		SELECT PN_User_Appointment.AppointmentId
		FROM PN_User_Appointment
		WHERE PN_User_Appointment.AppointmentId = @AppointmentId
	)
	DELETE FROM PN_Invoice WHERE PN_Invoice.AppointmentId = @AppointmentId
	DELETE FROM PN_Appointment WHERE PN_Appointment.Id = @AppointmentId
END
GO

CREATE PROC SPInsertAppointmentForUser
@UserId int,
@AppointmentId int
AS
BEGIN
	INSERT INTO PN_User_Appointment(UserId, AppointmentId)
	VALUES(@UserId, @AppointmentId)
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
@DueDate datetime2,
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

CREATE PROCEDURE SPDeleteClient
@ClientId int

AS
BEGIN
	DELETE from PN_Client
	WHERE	Id = @ClientId
END
GO


CREATE PROC SPInsertAppointmentOutId
@DateAndTime datetime2,
@RoomId int,
@Price float,
@AppointmentTypeId int,
@Note nvarchar(max),
@NotificationTime int,
@EmailNotification bit,
@SMSNotification bit

AS
	IF NOT EXISTS
	 (SELECT PN_Appointment.DateAndTime, PN_Appointment.RoomId FROM PN_Appointment
		WHERE PN_Appointment.DateAndTime = @DateAndTime AND
		PN_Appointment.RoomId = @RoomId
	 )
	BEGIN
	INSERT INTO PN_Appointment(DateAndTime, RoomId, Price, AppointmentTypeId, Note, Notificationtime, EmailNotification, SMSNotification)
	OUTPUT inserted.Id
	VALUES(@DateAndTime, @RoomId, @Price, @AppointmentTypeId, @Note, @NotificationTime, @EmailNotification, @SMSNotification)
END

GO
CREATE PROCEDURE SPGetAllAppointments

AS
BEGIN
	SELECT DISTINCT PN_User_Appointment.AppointmentId, PN_APPOINTMENT.DateAndTime, PN_Room.Id, PN_Room.Name,
	PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, PN_AppointmentType.Duration,
	PN_AppointmentType.StandardPrice, PN_Appointment.Note, PN_Appointment.Price, PN_Appointment.NotificationTime,
	PN_Appointment.EmailNotification, PN_Appointment.SMSNotification
	FROM PN_Appointment 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	JOIN PN_AppointmentType ON PN_AppointmentType.Id = PN_Appointment.AppointmentTypeId
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
	ORDER BY  PN_User_Appointment.AppointmentId
END
GO

CREATE PROCEDURE SPGetUsersFromAppointmentId @AppointmentId INT
AS
BEGIN
SELECT PN_User_Appointment.UserId
FROM PN_User_Appointment
WHERE PN_User_Appointment.AppointmentId = @AppointmentId
END
GO


CREATE PROC SPGetAllClients
AS
BEGIN
	SELECT PN_User.Id, PN_User.Name, PN_User.Email, PN_User.PhoneNumber, PN_User.Address, PN_Client.SocialSecurityNumber, 
	PN_Client.Note, PN_Client.Journalid, PN_Client.MedicalReferral
	FROM PN_User
	JOIN PN_Client ON PN_User.Id = PN_Client.Id
END
GO

CREATE PROC SPGetAllPractitioners
AS
BEGIN
	SELECT PN_User.Id, PN_User.Name, PN_User.Email, PN_User.PhoneNumber, PN_User.Address, PN_Practitioner.StartTime, PN_Practitioner.DayLength
	FROM PN_User
	JOIN PN_Practitioner ON PN_User.Id = PN_Practitioner.Id
END
GO

CREATE PROC SPGetAllDepartments
AS
BEGIN
	SELECT PN_Department.Id, PN_Department.Name, PN_Department.Address
	FROM PN_Department
END
GO

CREATE PROC SPGetRoomsFromDepartment @DepartmentId int
AS
BEGIN
	SELECT PN_Room.Id, PN_Room.Name
	FROM PN_Room
	WHERE PN_Room.DepartmentId = @DepartmentId
END
GO

CREATE PROC SPGetPractitionersFromDepartment @DepartmentId int
AS
BEGIN
	SELECT PN_Department_Practitioner.PractitionerId
	FROM PN_Department_Practitioner
	WHERE PN_Department_Practitioner.DepartmentId = @DepartmentId
END
GO

CREATE PROC SPGetAppointmentTypeByPractitionerId @PractitionerId int
AS
BEGIN
    SELECT PN_AppointmentType.Name, PN_AppointmentType.StandardPrice, PN_AppointmentType.Duration, PN_AppointmentType.Id
    FROM
    PN_AppointmentType
    JOIN PN_Practitioner_AppointmentType ON PN_AppointmentType.Id = PN_Practitioner_AppointmentType.AppointmentTypeId
    WHERE
    PN_Practitioner_AppointmentType.PractitionerId = @PractitionerId
END
GO

CREATE PROC SPGetAppointmentById @AppointmentId int
AS
BEGIN
SELECT DISTINCT PN_User_Appointment.AppointmentId, PN_Appointment.DateAndTime, PN_Room.Id, PN_Room.Name, PN_Appointment.AppointmentTypeId, PN_AppointmentType.Name, 
	PN_AppointmentType.Duration, PN_AppointmentType.StandardPrice, PN_Appointment.Note, PN_Appointment.Price, PN_Appointment.NotificationTime, PN_Appointment.EmailNotification, 
	PN_Appointment.SMSNotification, PN_Department.Name
	FROM PN_APPOINTMENT 
	JOIN PN_Room ON PN_Appointment.RoomId=PN_Room.Id
	JOIN PN_AppointmentType ON PN_AppointmentType.Id = PN_Appointment.AppointmentTypeId
	JOIN PN_User_Appointment ON PN_Appointment.Id = PN_User_Appointment.AppointmentId
	JOIN PN_Department on PN_Department.Id = PN_Room.DepartmentId
	WHERE PN_Appointment.Id = @AppointmentId
END
GO
    

