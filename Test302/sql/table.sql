USE CarDealer1
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
	DROP TABLE Contacts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Features')
	DROP TABLE Features
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Listings')
	DROP TABLE Listings
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO

CREATE TABLE States (
	StateId char(2) not null primary key,
	StateName varchar(15) not null
)

CREATE TABLE Makes (
	MakesId int identity(1,1) not null primary key,
	MakesName varchar(15) not null
)

CREATE TABLE Listings (
	ListingId int identity(1,1) not null primary key,
	UserId nvarchar(128) not null,
	StateId char(2) not null foreign key references States(StateId),
	MakesId int null foreign key references Makes(MakesId),
	[Year] int not null,
	City nvarchar(50) not null,
	Rate decimal(7,2) not null,
	Mileage decimal(7,2) not null,
	isNew bit not null,
	isManual bit not null,
	ListingDescription varchar(500) null,
	ImageFileName varchar(50),
	CreatedDate datetime2 not null default(getdate())
)

CREATE TABLE Contacts (
	ListingId int not null foreign key references Listings(ListingId),
	UserId nvarchar(128) not null,
	primary key (ListingId, UserId)
)

CREATE TABLE Features (
	ListingId int not null foreign key references Listings(ListingId),
	UserId nvarchar(128) not null,
	primary key (ListingId, UserId)
)
