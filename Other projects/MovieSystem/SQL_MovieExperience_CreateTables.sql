/* Database MovieExperience must be created */
use MovieExperience

CREATE TABLE Showing (
    ShowingId INT IDENTITY (1, 1) NOT NULL,
    Title     NVARCHAR (50) NOT NULL,
    Room      NVARCHAR (50) NOT NULL,
    showTime  DATETIME      NOT NULL,
    CONSTRAINT PKEY_Showing PRIMARY KEY (ShowingId)
);


 CREATE TABLE SeatReservation (
    id        INT      IDENTITY (1, 1) NOT NULL,
    seatRow    INT      NOT NULL,
    seatNo     INT      NOT NULL,
    reserved   BIT      NOT NULL,
    changeDate DATETIME NULL,
    showing_id INT      NOT NULL,
    CONSTRAINT pkSeatReservation PRIMARY KEY (id),
    CONSTRAINT FKEY_Showing FOREIGN KEY (showing_id) REFERENCES Showing(ShowingId)
);
