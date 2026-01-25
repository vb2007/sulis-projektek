-- AnimalShelter.dbo.Users definition

-- Drop table

-- DROP TABLE AnimalShelter.dbo.Users;

CREATE TABLE AnimalShelter.dbo.Users (
    Id uniqueidentifier DEFAULT newid() NOT NULL,
    Username nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    Email nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    PasswordHash nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    FirstName nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    LastName nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    ProfilePictureURL varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CreatedOn datetime2 DEFAULT getdate() NOT NULL,
    ModifiedOn datetime2 DEFAULT NULL NULL,
    IsAdmin bit DEFAULT 0 NOT NULL,
    CONSTRAINT Users_PK PRIMARY KEY (Id),
    CONSTRAINT Users_UNIQUE UNIQUE (Username)
);
