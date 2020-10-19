CREATE TABLE Users(
    Id int PRIMARY KEY IDENTITY,
    FirstName varchar(100),
    LastName varchar(100),
    UserName varchar(100) not null,
    [Password] varchar(100) not null,
    UserType int not null,
    Phone varchar(15),
    Email varchar(100),
    [Address] varchar(150),
    DateCreated date not null,
    IsDeleted bit not null
);

CREATE TABLE Events(
    Id int PRIMARY KEY IDENTITY,
    UserId INT not null,
    EventType INT not null,
    Participants INT not null,
    NumberOfServices INT not null,
    [Status] int not null,
    EventDate date not null,
    BugetNeeded int not null,
    IsDeleted bit not null,
    CONSTRAINT FK_Users_Events FOREIGN KEY (UserId)
        REFERENCES Users (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Services(
    Id int PRIMARY KEY IDENTITY,
    UserId int not null,
    ServiceType int not null,
    [Name] VARCHAR(150) not null,
    [Description] varchar(500),
    EventsPerDay int not null,
    SmartRate float not null,
    IsDeleted bit not null,
    CONSTRAINT FK_Users_Services FOREIGN KEY (UserId)
        REFERENCES Users (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE ServicePackages(
    Id int PRIMARY Key IDENTITY,
    ServiceID INT NOT NULL,
    PricePerParticipant int not null,
    [Description] varchar(500),
    MaxCapacity int not NULL,
    isDeleted bit not null,
    CONSTRAINT FK_Service_ServicePackages FOREIGN KEY (ServiceID)
        REFERENCES Services (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE EventServices(
    Id int PRIMARY KEY IDENTITY,
    EventId int not null,
    ServiceId int not null,
    ServicePackageId int not null,
    [Status] int not null,
    CONSTRAINT FK_Event_EventServices FOREIGN KEY (EventId)
        REFERENCES Events (Id),
    CONSTRAINT FK_Services_EventServices FOREIGN KEY (ServiceId)
        REFERENCES Services (Id),
    CONSTRAINT FK_ServicePackage_EventServices FOREIGN KEY (ServicePackageId)
        REFERENCES ServicePackages (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)

CREATE TABLE Resources(
    Id int PRIMARY KEY IDENTITY,
    ResourceArea VARCHAR(30) not null,
    ResourceKey VARCHAR(30) not null,
    ResourceValue VARCHAR(300) not null
);

CREATE TABLE ContainerNames(
    Id int PRIMARY KEY IDENTITY,
    UserId int not null,
    [Name] varchar(50) not null,
    ContainerType int not null,
    CONSTRAINT FK_Users_ImageContainer FOREIGN KEY (UserId)
        REFERENCES Users (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

Drop table Users;

Drop table Services;

Drop table ServicePackages;
Drop table Events;
Drop table EventServices;
Drop table ContainerNames;