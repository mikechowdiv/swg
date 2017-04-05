USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='CarDealer2')
DROP DATABASE CarDealer2
GO

CREATE DATABASE CarDealer2
GO