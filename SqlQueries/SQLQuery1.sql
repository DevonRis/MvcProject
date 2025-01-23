USE SkillsShowcase;

CREATE TABLE dbo.GuitarManufactureDetails (
    GuitarManufacturerId INT PRIMARY KEY,
    ManufacturerName NVARCHAR(50) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    ContactNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Website NVARCHAR(100) NOT NULL,
    DateEstablished DATE
);

INSERT INTO GuitarManufactureDetails (GuitarManufacturerId, ManufacturerName, Location, ContactNumber, Email, Website, DateEstablished)
VALUES 
(1, 'Fender', 'Los Angeles, CA', '718-536-9997', 'service@fender.com', 'www.fender.com', '1946-01-10'),
(2, 'Gibson', 'Nashville, TN', '1-800-444-2766', 'service@gibson.com', 'www.gibson.com', '1902-06-10'),
(3, 'PaulReedSmith', 'Stevensville, MD', '410-643-9970', 'info@prsguitars.com', 'www.prsguitars.com', '1985-04-13'),
(4, 'Ibanez', 'Nagoya, Japan', '81-52-211-9611', 'contact@ibanez.com', 'www.ibanez.com', '1957-02-15');