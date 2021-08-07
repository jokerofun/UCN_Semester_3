create table IntermediateDestination
(
    [Id]							    INT       IDENTITY (1, 1) NOT NULL,
    [IntermediateDestination]           NVARCHAR           (50)   NOT NULL,
    [DepartureDate]                     DATETIME                  NOT NULL,
    [ArrivalDate]                       DATETIME                  NOT NULL,
	CruiseId int,
    CONSTRAINT fk_t FOREIGN KEY (CruiseId) REFERENCES Trip(ID)
);