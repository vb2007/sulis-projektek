-- AnimalShelter.dbo.Appointments definition

-- Drop table

-- DROP TABLE AnimalShelter.dbo.Appointments;

CREATE TABLE AnimalShelter.dbo.Appointments (
    Id uniqueidentifier DEFAULT newid() NOT NULL,
	AppointmentAt datetime2 NOT NULL,
	ReservedTo int NOT NULL,
	ReservedBy uniqueidentifier NOT NULL,
	CreatedOn datetime2 DEFAULT getdate() NOT NULL,
	CONSTRAINT Appointments_PK PRIMARY KEY (Id),
	CONSTRAINT Appointments_Animals_FK FOREIGN KEY (ReservedTo) REFERENCES AnimalShelter.dbo.Animals(Id) ON DELETE CASCADE,
	CONSTRAINT Appointments_Users_FK FOREIGN KEY (ReservedBy) REFERENCES AnimalShelter.dbo.Users(Id) ON DELETE CASCADE
);
