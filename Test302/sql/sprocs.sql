IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName
	FROM States
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakesSelectAll')
      DROP PROCEDURE MakesSelectAll
GO

CREATE PROCEDURE MakesSelectAll AS
BEGIN
	SELECT MakesId, MakesName
	FROM Makes
	ORDER BY MakesName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsInsert')
      DROP PROCEDURE ListingsInsert
GO

CREATE PROCEDURE ListingsInsert (
	@ListingId int output,
	@UserId nvarchar(128),
	@StateId char(2),
	@MakesId int,
	@Year int,
	@City nvarchar(50),
	@Rate decimal(7,2),
	@Mileage decimal(7,2),
	@isNew bit,
	@isManual bit,
	@ListingDescription varchar(500),
	@ImageFileName varchar(50)
) AS
BEGIN
	INSERT INTO Listings (UserId, StateId, MakesId, [Year], City, Rate, Mileage, isNew,
		isManual, ListingDescription, ImageFileName)
	VALUES (@UserId, @StateId, @MakesId, @Year, @City, @Rate, @Mileage, @isNew, @isManual, @ListingDescription, @ImageFileName);

	SET @ListingId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsUpdate')
      DROP PROCEDURE ListingsUpdate
GO

CREATE PROCEDURE ListingsUpdate (
	@ListingId int,
	@UserId nvarchar(128),
	@StateId char(2),
	@MakesId int,
	@Year int,
	@City nvarchar(50),
	@Rate decimal(7,2),
	@Mileage decimal(7,2),
	@isNew bit,
	@isManual bit,
	@ListingDescription varchar(500),
	@ImageFileName varchar(50)
) AS
BEGIN
	UPDATE Listings SET 
		UserId = @UserId, 
		StateId = @StateId, 
		MakesId = @MakesId, 
		[Year] = @Year, 
		City = @City, 
		Rate = @Rate, 
		Mileage = @Mileage, 
		isNew = @isNew,
		isManual = @isManual, 
		ListingDescription = @ListingDescription,
		ImageFileName = @ImageFileName
	WHERE ListingId = @ListingId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsDelete')
      DROP PROCEDURE ListingsDelete
GO

CREATE PROCEDURE ListingsDelete (
	@ListingId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contacts WHERE ListingId = @ListingId;
	DELETE FROM Features WHERE ListingId = @ListingId;
	DELETE FROM Listings WHERE ListingId = @ListingId;

	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelect')
      DROP PROCEDURE ListingsSelect
GO

CREATE PROCEDURE ListingsSelect (
	@ListingId int
) AS
BEGIN
	SELECT ListingId, UserId, StateId, MakesId, [Year], City, Rate, Mileage,
		isNew, isManual, ListingDescription, ImageFileName
	FROM Listings
	WHERE ListingId = @ListingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectRecent')
      DROP PROCEDURE ListingsSelectRecent
GO

CREATE PROCEDURE ListingsSelectRecent AS
BEGIN
	SELECT TOP 5 ListingId, UserId, Rate, City, StateId, ImageFileName
	FROM Listings
	ORDER BY CreatedDate DESC
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectFront')
      DROP PROCEDURE ListingsSelectFront
GO

CREATE PROCEDURE ListingsSelectFront as
BEGIN
	SELECT TOP 5 ListingId, UserId, Rate, City, [Year], ImageFileName
	FROM Listings
	ORDER BY CreatedDate DESC
END

GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectDetails')
      DROP PROCEDURE ListingsSelectDetails
GO

CREATE PROCEDURE ListingsSelectDetails (
	@ListingId int
) AS 
BEGIN
	SELECT ListingId, UserId, [Year], City, StateId, Rate, Mileage, 
		isNew, isManual, l.MakesId, MakesName, ImageFileName, l.ListingDescription
	FROM Listings l 
		INNER JOIN Makes b ON l.MakesId = b.MakesId
	WHERE ListingId = @ListingId
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectFeatures')
      DROP PROCEDURE ListingsSelectFeatures
GO

CREATE PROCEDURE ListingsSelectFeatures (
	@UserId nvarchar(128)
) AS 
BEGIN
	SELECT l.ListingId, l.City, l.StateId, l.Rate, l.Mileage, l.UserId,
	l.isNew, l.isManual, l.MakesId, b.MakesName
	FROM Features f
		INNER JOIN Listings l on f.ListingId = l.ListingId 
		INNER JOIN Makes b ON l.MakesId = b.MakesId
	WHERE f.UserId = @UserId;
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectContacts')
      DROP PROCEDURE ListingsSelectContacts
GO

CREATE PROCEDURE ListingsSelectContacts (
	@UserId nvarchar(128)
) AS 
BEGIN
	SELECT l.ListingId, u.Email, u.Id as UserId, l.[Year], l.City, l.StateId, l.Rate
	FROM Listings l 
		INNER JOIN Contacts c ON l.ListingId = c.ListingId
		INNER JOIN AspNetUsers u ON c.UserId = u.Id
	WHERE l.UserId = @UserId;
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ListingsSelectByUser')
      DROP PROCEDURE ListingsSelectByUser
GO

CREATE PROCEDURE ListingsSelectByUser (
	@UserId nvarchar(128)
) AS
BEGIN
	SELECT ListingId, UserId, [Year], City, StateId, Rate, Mileage, 
		isNew, isManual, l.MakesId, MakesName, ImageFileName
	FROM Listings l 
		INNER JOIN Makes b ON l.MakesId = b.MakesId
	WHERE UserId = @UserId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'FeaturesInsert')
      DROP PROCEDURE FeaturesInsert
GO

CREATE PROCEDURE FeaturesInsert (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	INSERT INTO Features(UserId, ListingId)
	VALUES (@UserId, @ListingId)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'FeaturesDelete')
      DROP PROCEDURE FeaturesDelete
GO

CREATE PROCEDURE FeaturesDelete (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	DELETE FROM Features
	WHERE UserId = @UserId AND ListingId = @ListingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsert')
      DROP PROCEDURE ContactsInsert
GO

CREATE PROCEDURE ContactsInsert (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	INSERT INTO Contacts(UserId, ListingId)
	VALUES (@UserId, @ListingId)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsDelete')
      DROP PROCEDURE ContactsDelete
GO

CREATE PROCEDURE ContactsDelete (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	DELETE FROM Contacts
	WHERE UserId = @UserId AND ListingId = @ListingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsSelect')
      DROP PROCEDURE ContactsSelect
GO

CREATE PROCEDURE ContactsSelect (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	SELECT UserId, ListingId 
	FROM Contacts
	WHERE UserId = @UserId AND ListingId = @ListingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'FeaturesSelect')
      DROP PROCEDURE FeaturesSelect
GO

CREATE PROCEDURE FeaturesSelect (
	@UserId nvarchar(128),
	@ListingId int
) AS
BEGIN
	SELECT UserId, ListingId 
	FROM Features
	WHERE UserId = @UserId AND ListingId = @ListingId
END
GO