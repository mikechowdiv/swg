use dvd1
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DBReset')
	drop procedure DBReset
GO

Create procedure DBReset as
begin
	delete from Dvds;
	delete from Ratings

	DBCC CHECKIDENT (Dvds, reseed,0)

	insert into Ratings (rating)
	Values
	('G'),
	('PG'),
	('PG-13'),
	('R'),
	('X');

	insert into Dvds (title, releaseYear, director, rating, notes)
	values
	('HelloWorld1','2009', 'FP Kopasd', 'G', 'Testing'),
	('HelloWorld2','2008', 'Jon Hasd', 'X', 'Testing'),
	('HelloWorld3','2007', 'Ioa', 'PG-13', 'Testing'),
	('HelloWorld4','2012', 'Oasd Rfgas', 'R', 'Testing');

	end
	go
