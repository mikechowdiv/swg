USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='CarDealerX')
DROP DATABASE CarDealerX
GO

CREATE DATABASE CarDealerX
GO