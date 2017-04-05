IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Features;
	DELETE FROM Contacts;
	DELETE FROM Listings;
	DELETE FROM States;
	DELETE FROM Makes;
	DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');

	DBCC CHECKIDENT ('listings', RESEED, 1)


	-----------------------------------------STATES--------------------------------------------

	INSERT INTO States (StateId, StateName)
	VALUES ('OH', 'Ohio'),
	('KY', 'Kentucky'),
	('MN', 'Minnesota');

	-----------------------------------------MAKES--------------------------------------------

	SET IDENTITY_INSERT Makes ON;

	INSERT INTO Makes (MakesId, MakesName)
	VALUES (1, 'Ford'),
	(2, 'GM'),
	(3, 'BMW')

	SET IDENTITY_INSERT Makes OFF;

	

	-----------------------------------------USER--------------------------------------------

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email,  TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com',  0, 0, 0, 'test');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email,  TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com',  0, 0, 0, 'test2');


	-----------------------------------------LISTINGS--------------------------------------------

	SET IDENTITY_INSERT Listings ON;

	INSERT INTO Listings(ListingId, UserId, StateId, MakesId, [Year], City, Rate, Mileage, isNew,
		isManual, ImageFileName, ListingDescription)
	VALUES (1, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2001, 'Cleveland', 100, 400, 0, 1, 'placeholder.png', 'Description'),
	 (2, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2001, 'Cleveland', 110, 410, 0, 1, 'placeholder.png',null),
	 (3, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2003, 'Cleveland', 120, 420, 0, 1, 'placeholder.png',null),
	 (4, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2001, 'Cleveland', 130, 430, 0, 1, 'placeholder.png', 'Experience the chill of Cleveland winters in this leaky shack.  Poorly insulated and weather worn, you will truly appreciate returning home from your stay here.'),
	 (5, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2001, 'Columbus', 140, 440, 0, 1, 'placeholder.png',null),
	 (6, '00000000-0000-0000-0000-000000000000', 'OH', 3, 2001, 'Cleveland', 150, 450, 0, 1, 'placeholder.png',null);

	SET IDENTITY_INSERT Listings OFF;

	-----------------------------------------FEATURED--------------------------------------------

	INSERT INTO Features(ListingId, UserId)
	VALUES (1, '11111111-1111-1111-1111-111111111111'),
	(2, '11111111-1111-1111-1111-111111111111')

	-----------------------------------------CONTACTS--------------------------------------------

	INSERT INTO Contacts(ListingId, UserId)
	VALUES (1, '11111111-1111-1111-1111-111111111111'),
	(3, '11111111-1111-1111-1111-111111111111')






END