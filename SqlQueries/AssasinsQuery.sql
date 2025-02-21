CREATE TABLE dbo.Assassins (
    AssassinId INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,  -- Enum ContinentalAgeRange (stored as int)
    Height NVARCHAR(10) NOT NULL,
    RegisteredDate DATETIME NOT NULL,
    State INT NOT NULL,  -- Enum AllFiftyStates (stored as int)
    MartialArt INT NOT NULL,  -- Enum MartialArts (stored as int)
    Weapon INT NOT NULL  -- Enum Weapons (stored as int)
);

-- Insert data from the screenshot
INSERT INTO dbo.Assassins (AssassinId, FirstName, LastName, Age, Height, RegisteredDate, State, MartialArt, Weapon)
VALUES 
(1, 'Ezio', 'Lorenzo', 23, '5''10"', '2024-01-10', 32, 3, 1);