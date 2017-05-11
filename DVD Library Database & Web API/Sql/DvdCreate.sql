use master
go

IF EXISTS(SELECT * FROM sys.databases WHERE name='dvd1')
DROP DATABASE Dvd1
GO

create database dvd1
go

use dvd1
go


if exists(select * from sys.tables where name = 'Dvds')
drop table Dvds
Go


if exists(select * from sys.tables where name = 'Ratings')
drop table Ratings
Go

create table Ratings(
	rating varchar(5) not null primary key,
)
go

create table Dvds(
	dvdId int identity(1,1) primary key,
	title varchar(50) not null,
	releaseYear char(4) not null,
	director varchar(50) not null,
	rating varchar(5) not null foreign key references Ratings(rating), 
	notes varchar(250)
)
go






