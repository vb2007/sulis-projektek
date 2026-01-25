-- AnimalShelter.dbo.Animals definition

-- Drop table

-- DROP TABLE AnimalShelter.dbo.Animals;

CREATE TABLE AnimalShelter.dbo.Animals (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Description nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT NULL NULL,
	ImageURL varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SpeciesId int NOT NULL,
	BreedId int NOT NULL,
	CreatedOn datetime2 DEFAULT getdate() NOT NULL,
	CreatedBy uniqueidentifier NOT NULL,
	ModifiedOn datetime2 NULL,
	ModifiedBy uniqueidentifier NULL,
	CONSTRAINT Animals_PK PRIMARY KEY (Id),
	CONSTRAINT Animals_Animals_Breeds_FK FOREIGN KEY (BreedId) REFERENCES AnimalShelter.dbo.[Animals.Breeds](Id),
	CONSTRAINT Animals_Animals_Species_FK FOREIGN KEY (SpeciesId) REFERENCES AnimalShelter.dbo.[Animals.Species](Id),
	CONSTRAINT Animals_Users_FK FOREIGN KEY (CreatedBy) REFERENCES AnimalShelter.dbo.Users(Id),
	CONSTRAINT Animals_Users_FK_1 FOREIGN KEY (ModifiedBy) REFERENCES AnimalShelter.dbo.Users(Id)
);
