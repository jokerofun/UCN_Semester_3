create table Ticket(

Id int NOT null    primary key identity (1,1),
TicketName         varchar(35)      NOT NULL,
TicketDescription  varchar(150),
Price              decimal(9,2)     NOT NULL,
MaxTickets         int            NOT NULL,
Active             Bit            DEFAULT 1, 
TripId           int         NOT NULL,
    CONSTRAINT fk_Ticket_Trip FOREIGN KEY (TripId) REFERENCES Trip(ID)
);