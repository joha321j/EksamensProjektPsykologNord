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

CREATE PROCEDURE SPUpdateDepartMent
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

