USE B_DB19_2018

--TEST SETUP

INSERT INTO PN_Department(Address, Name)
VALUES 
('Seebladsgame 1, 5000 Odense C', 'UCL'),
('Niels Bohrs Alle 1, 5230 Odense M', 'UCL 1'),
('FrederiksGade 50, 4000 TestCity', 'Awesome')
GO

INSERT INTO PN_Room(Name, DepartmentId)
VALUES
('A', 1),
('B', 1),
('A', 2),
('B', 2),
('C', 2),
('One and Only', 3)
GO

INSERT INTO PN_Journal(Name)
VALUES
('Journal'),('Journal'),('Journal')
GO

INSERT INTO PN_Journal_Entry(JournalId, Text)
VALUES
(1, 'Brækket fod'),
(1, 'Syg i hovedet'),
(1, 'Okay nu'),
(2, 'Først Prøve'),
(3, 'Hun ser godt ud'),
(3, 'Hun har det ikke særligt godt med sin kæreste')
GO

INSERT INTO PN_User(Name, Address, PhoneNumber, Email)
VALUES
('Henrik Thomsen', 'Hans Jørgens Gade 3, 5000 Odense C', '004561275627', 'ht@gmail.com'),
('Line Andersen', 'Vibevænget 23, 5492 Vissenbjerg', '004564472954', 'mail@mail.dk'),
('Karl Karlsen', 'KarlsensVej 15, 9000 Aalborg', '004570192740', 'Karl@karlsen.dk'),
('Anders Andersen', 'Andersenvej 60, 8000 Århus', '004569102748', 'anders@andersen.dk'),
('Tester test', 'testvej 200, 6700 Hillerød', '004567102948', 'test@test.dk')
GO

INSERT INTO PN_Client(Id, MedicalReferral, Note, Journalid, SocialSecurityNumber)
VALUES
(1, 0, 'Idiot', 1, '2507790491'),
(2, 1, '', 2, '2802991040'),
(5, 0, 'test', 3, '2001782099')
GO

INSERT INTO PN_Practitioner(Id, StartTime, DayLength)
VALUES
(3, '2019-05-08 10:00:00', '10:00'),
(4, '2019-05-08 09:00:00', '10:00')
GO

INSERT INTO PN_AppointmentType(Name, Duration, StandardPrice)
VALUES
('Normal', '01:00', 1499.00),
('Billig', '01:00', 999.00),
('Par', '02:00', 2499.00)

INSERT INTO PN_Appointment(DateAndTime, RoomId, Price, AppointmentTypeId, Note, NotificationTime, EmailNotification, SMSNotification)
VALUES
('2019-05-16 12:00:00', 1, 0.00, 1, 'test note', 5, 0, 0),
('2019-05-20 12:00:00', 3, 0.00, 2, 'note', 24, 1, 0),
('2019-05-15 12:00:00', 2, 0.00, 1, 'test note', 5, 1, 1),
('2019-05-16 14:00:00', 5, 0.00, 3, 'note', 24, 0, 1),
('2019-05-18 15:00:00', 1, 0.00, 1, 'test note', 24, 1, 1),
('2019-05-23 10:00:00', 1, 2000.00, 2, 'note', 24, 1, 1),
('2019-06-16 10:00:00', 2, 0.00, 1, 'test note', 24, 0, 0),
('2019-06-16 12:00:00', 5, 0.00, 2, 'note', 24, 0, 0)
GO

INSERT INTO PN_Invoice(AppointmentId, DueDate)
VALUES
(1, '2019-05-20 12:00:00'),
(2, '2019-05-21 12:00:00'),
(3, '2019-06-01 12:00:00'),
(4, '2019-05-20 12:00:00'),
(5, '2019-05-20 12:00:00'),
(6, '2019-05-20 12:00:00'),
(7, '2019-05-20 12:00:00')

INSERT INTO PN_User_Appointment(UserId, AppointmentId)
VALUES
(1,1),
(2,4),
(5,4),
(4,4),
(3,2),
(2,2),
(3,3),
(1,3),
(4,5),
(5,5),
(1,6),
(4,6),
(5,7),
(3,7),
(5,8),
(3,8),
(3,1)

INSERT INTO PN_Practitioner_AppointmentType(PractitionerId,AppointmentTypeId)
VALUES
(3,1),
(3,2),
(4,1),
(4,2),
(4,3)

INSERT INTO PN_Department_Practitioner(DepartmentId, PractitionerId)
VALUES
(1,3),
(2,3),
(1,4),
(3,4)
