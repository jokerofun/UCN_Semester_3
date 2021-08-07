create table UserTicket(
Id int NOT null    primary key identity (1,1),
FirstName      nvarchar(30) NOT NULL,
LastName       nvarchar(30) NOT NULL,
TicketId       int NOT NULL,
UserId         nvarchar(128) NOT NULL,
	CONSTRAINT fk_UserTicket_Ticket FOREIGN KEY (TicketId) REFERENCES Ticket(Id),
	CONSTRAINT fk_UserTicket_UserAccount FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);