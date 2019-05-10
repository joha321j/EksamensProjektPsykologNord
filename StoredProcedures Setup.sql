CREATE PROCEDURE SPUpdateAppointment
@AppointmentId int,
@DateAndTime datetime2(7),
@RoomId int,
@PractitionerId int,
@Price float,
@TreatmentTypeId int,
@Note nvarchar(max)

AS
BEGIN
	UPDATE PN_Appointment
	SET		DateAndTime	= @DateAndTime,
			RoomId = @RoomId,
			PractitionerId = @PractitionerId,
			Price = @Price,
			TreatmentTypeId = @TreatmentTypeId,
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

CREATE PROCEDURE SPUpdateTreatmentType
@TreatmentTypeId int,
@Name nvarchar(max),
@Duration datetime2(7),
@StandardPrice float

AS
BEGIN
	UPDATE	PN_TreatmentType
	SET		Name = @Name,
			Duration = @Duration,
			StandardPrice = @StandardPrice
	WHERE	Id = @TreatmentTypeId
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

CREATE PROCEDURE SPDeleteTreatmentType
@TreatmentTypeId int

AS
BEGIN
	DELETE from PN_TreatmentType
	WHERE Id = @TreatmentTypeId
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