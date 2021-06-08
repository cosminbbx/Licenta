Drop table EventServices;
Drop table ServicePackages;

Drop table Services;

CREATE TABLE Services(
    Id int PRIMARY KEY IDENTITY,
    UserId int not null,
    ServiceType int not null,
    [Name] VARCHAR(150) not null,
    [Description] varchar(500),
    EventsPerDay int not null,
    SmartRate real not null,
    NumberOfRatings int not null,
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
    IsDeleted bit not null,
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

insert into Services (UserId,ServiceType,[Name],[Description],EventsPerDay,SmartRate,NumberOfRatings,IsDeleted)
values (1,1,'Service1','Description1',1,0,0,1)

insert into Services (UserId,ServiceType,[Name],[Description],EventsPerDay,SmartRate,NumberOfRatings,IsDeleted)
values (1,2,'Service2','Description2',1,0,0,1)

insert into Services (UserId,ServiceType,[Name],[Description],EventsPerDay,SmartRate,NumberOfRatings,IsDeleted)
values (1,3,'Service3','Description3',1,0,0,1)

insert into Services (UserId,ServiceType,[Name],[Description],EventsPerDay,SmartRate,NumberOfRatings,IsDeleted)
values (1,4,'Service4','Description4',1,0,0,1)

insert into Services (UserId,ServiceType,[Name],[Description],EventsPerDay,SmartRate,NumberOfRatings,IsDeleted)
values (1,5,'Service5','Description5',1,0,0,1)


insert into ServicePackages (ServiceID,PricePerParticipant,[Description],MaxCapacity,IsDeleted)
values (1,100,'Description1',300,1)

insert into ServicePackages (ServiceID,PricePerParticipant,[Description],MaxCapacity,IsDeleted)
values (2,150,'Description2',300,1)

insert into ServicePackages (ServiceID,PricePerParticipant,[Description],MaxCapacity,IsDeleted)
values (3,200,'Description3',300,1)

insert into ServicePackages (ServiceID,PricePerParticipant,[Description],MaxCapacity,IsDeleted)
values (4,250,'Description4',300,1)

insert into ServicePackages (ServiceID,PricePerParticipant,[Description],MaxCapacity,IsDeleted)
values (5,300,'Description5',300,1)