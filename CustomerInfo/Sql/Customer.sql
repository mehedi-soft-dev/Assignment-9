CREATE DATABASE CustomerInformation

USE CustomerInformation

CREATE TABLE Districts
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(15)
)

SELECT * FROM Districts

INSERT INTO Districts (Name) VALUES('Rangpur')
INSERT INTO Districts (Name) VALUES('Dhaka')
INSERT INTO Districts (Name) VALUES('Dinajpur')
INSERT INTO Districts (Name) VALUES('Gaibandha')
INSERT INTO Districts (Name) VALUES('Bogura')

CREATE TABLE Customers
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Code VARCHAR(4),
	Name VARCHAR(20),
	Contact VARCHAR(11),
	Address VARCHAR(20),
	DistrictId INT REFERENCES Districts ("ID")		
)

SELECT * FROM Customers

DROP TABLE Customers

CREATE VIEW CustomerDetailsView
AS
SELECT c.ID, c.Code, c.Name, c.Contact, c.Address, c.DistrictId, d.Name AS District FROM Customers AS c
LEFT JOIN Districts AS d ON d.ID = c.DistrictId

SELECT * FROM CustomerDetailsView

DROP VIEW CustomerDetailsView
