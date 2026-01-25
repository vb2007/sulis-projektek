-- AnimalShelter.dbo.[Animals.Breeds] definition

-- Drop table

-- DROP TABLE AnimalShelter.dbo.[Animals.Breeds];

CREATE TABLE AnimalShelter.dbo.[Animals.Breeds] (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedOn datetime2 DEFAULT getdate() NOT NULL,
	CreatedBy uniqueidentifier NOT NULL,
	ModifiedOn datetime2 DEFAULT NULL NULL,
	ModifiedBy uniqueidentifier DEFAULT NULL NULL,
	CONSTRAINT Animals_Breeds_PK PRIMARY KEY (Id),
	CONSTRAINT Animals_Breeds_UNIQUE UNIQUE (Name),
	CONSTRAINT Animals_Breeds_Users_FK FOREIGN KEY (CreatedBy) REFERENCES AnimalShelter.dbo.Users(Id),
	CONSTRAINT Animals_Breeds_Users_FK_1 FOREIGN KEY (ModifiedBy) REFERENCES AnimalShelter.dbo.Users(Id)
);
