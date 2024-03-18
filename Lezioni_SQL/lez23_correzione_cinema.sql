CREATE TABLE Cinema (
	CinemaID INT PRIMARY KEY,
	Nome VARCHAR (100) NOT NULL,
	Indirizzo VARCHAR (255) NOT NULL,
	Phone VARCHAR (20)
);
 
CREATE TABLE Theater (
	TheaterID INT PRIMARY KEY,
	CinemaID INT NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Capacity INT NOT NULL,
	ScreenType VARCHAR(50),
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
); 

CREATE TABLE Movie (
	MovieID INT PRIMARY KEY,
	Title VARCHAR(255) NOT NULL,
	Director VARCHAR(100),
	ReleaseDate DATE,
	DurationMinutes INT,
	Rating VARCHAR(5)
); 

--DROP TABLE ShowTime;
CREATE TABLE Showtime (
	ShowtimeID INT PRIMARY KEY IDENTITY(1,1),
	MovieID INT NOT NULL,
	TheaterID INT NOT NULL,
	ShowDateTime DATETIME NOT NULL,
	Price DECIMAL(5,2) NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
); 

CREATE TABLE Customer (
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100),
	PhoneNumber VARCHAR(20)
); 

--DROP TABLE Ticket;
CREATE TABLE Ticket (
	TicketID INT PRIMARY KEY IDENTITY(1,1),
	ShowtimeID INT NOT NULL,
	SeatNumber VARCHAR(10) NOT NULL,
	PurchasedDateTime DATETIME NOT NULL,
	CustomerID INT NOT NULL,
	FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
); 

--DROP TABLE Review;
CREATE TABLE Review (
	ReviewID INT PRIMARY KEY IDENTITY(1,1),
	MovieID INT NOT NULL,
	CustomerID INT NOT NULL,
	ReviewText TEXT,
	Rating INT CHECK (Rating >= 1 AND Rating <= 5),
	ReviewDate DATETIME NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
); 

CREATE TABLE Employee (
	EmployeeID INT PRIMARY KEY,
	CinemaID INT NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Position VARCHAR(50),
	HireDate DATE,
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
)

INSERT INTO Cinema (CinemaID, Nome, Indirizzo, Phone)
VALUES
(1, 'Cinema City', 'Via Roma 123, Città', '+39 1234567890'),
(2, 'Cineplex', 'Via Milano 456, Città', '+39 0987654321');

INSERT INTO Theater (TheaterID, CinemaID, Nome, Capacity, ScreenType)
VALUES
(1, 1, 'Sala 1', 100, '2D'),
(2, 1, 'Sala 2', 80, '3D'),
(3, 2, 'Sala A', 120, '2D');

INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
VALUES
(1, 'Il Signore degli Anelli', 'Peter Jackson', '2001-12-19', 178, 'PG-13'),
(2, 'La La Land', 'Damien Chazelle', '2016-12-09', 128, 'PG-13');

INSERT INTO Showtime (MovieID, TheaterID, ShowDateTime, Price)
VALUES
(1, 2, '2024-15-03 20:30:00', 12.50), --SIG ANELLI
(2, 3, '2024-16-03 15:00:00', 9.00);  -- LA LA

INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber)
VALUES
('Mario', 'Rossi', 'mario.rossi@example.com', '+39 123456789'),
('Giulia', 'Bianchi', 'giulia.bianchi@example.com', '+39 987654321');

INSERT INTO Ticket (ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
VALUES
( 1, 'A1', '2024-15-03 15:30:00', 1),
( 2, 'B3', '2024-15-03 19:00:00', 2)

INSERT INTO Review (MovieID, CustomerID, ReviewText, Rating, ReviewDate)
VALUES
( 1, 1, 'Fantastico film, lo consiglio vivamente!', 5, '2024-16-03 10:00:00'),
( 2, 2, 'Bellissima storia e ottime interpretazioni.', 4, '2024-17-03 09:30:00');

INSERT INTO Employee (EmployeeID, CinemaID, FirstName, LastName, Position, HireDate)
VALUES
(1, 1, 'Luca', 'Verdi', 'Manager', '2020-01-15'),
(2, 2, 'Chiara', 'Neri', 'Cassiere', '2023-05-20');

--Creare una vista FilmsInProgrammation che mostri i titoli dei film, la data di inizio
--programmazione, la durata e la classificazione per rating. Questa vista aiuterà il personale e i clienti a
--vedere rapidamente quali film sono attualmente in programmazione.
CREATE VIEW FilmsInProgrammation AS
	SELECT Title,ReleaseDate,DurationMinutes,Rating,ShowDateTime
		FROM Movie
		JOIN Showtime ON Movie.MovieID = Showtime.MovieID;

SELECT * FROM FilmsInProgrammation;

/*Creare una vista AvailableSeatsForShow che, per ogni spettacolo, mostri il numero totale di
posti nella sala e quanti sono ancora disponibili. Questa vista � essenziale per il personale alla
biglietteria per gestire le vendite dei biglietti.*/


CREATE VIEW AvailableSeatsForShow AS
	SELECT Capacity - COUNT(*)  AS 'POSTI RIMANENTI',Movie.Title,Theater.Nome, Theater.Capacity
	FROM Showtime 
		JOIN Ticket ON Showtime.ShowtimeID=Ticket.ShowtimeID
		JOIN Movie ON Showtime.MovieID=Movie.MovieID
		JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
		GROUP BY Showtime.ShowtimeID,Movie.Title,Theater.Capacity,Theater.Nome;

	SELECT * FROM AvailableSeatsForShow;

----------------------------------------

CREATE VIEW	AvailableSeatsForShow AS
	SELECT Title, Capacity, Capacity - (SELECT COUNT(*) FROM Ticket JOIN Showtime ON Showtime.ShowtimeID = Ticket.ShowtimeID) AS Difference 
	FROM Theater
		JOIN Showtime ON Theater.TheaterID = Showtime.TheaterID
		JOIN Movie ON Showtime.MovieID = Movie.MovieID;

SELECT * FROM AvailableSeatsForShow;

/*Generare una vista TotalEarningsPerMovie che elenchi ogni film insieme agli incassi totali
generati. Questa informazione � cruciale per la direzione per valutare il successo commerciale dei
film.*/

CREATE VIEW TotalEarningsPerMovie AS
	SELECT SUM(Price) AS 'Incasso',Movie.Title
		FROM Showtime
		JOIN Movie ON Showtime.MovieID=Movie.MovieID
		JOIN Ticket ON Showtime.ShowtimeID = Ticket.ShowtimeID
		GROUP BY Movie.Title


	SELECT * FROM TotalEarningsPerMovie;

/*Creare una vista RecentReviews che mostri le ultime recensioni lasciate dai clienti, includendo il
titolo del film, la valutazione, il testo della recensione e la data. Questo permetter� al personale e
alla direzione di monitorare il feedback dei clienti in tempo reale.*/

SELECT Movie.Title,Review.Rating,Review.ReviewText,Review.ReviewDate
	FROM Review
	JOIN Movie ON Review.MovieID=Movie.MovieID;

---------------------------------------------------
/*Creare una stored procedure PurchaseTicket che permetta di acquistare un biglietto per uno
spettacolo, specificando l'ID dello spettacolo, il numero del posto e l'ID del cliente. La procedura
dovrebbe verificare la disponibilit� del posto e registrare l'acquisto.*/

DROP PROCEDURE IF EXISTS PurchaseTicket;
CREATE PROCEDURE PurchaseTicket
@inputShowID INT,
@inputCostumerID INT,
@inputSeatNumber VARCHAR(10)
AS
BEGIN
	DECLARE @IsOccupato INT;
	 BEGIN TRY		
			BEGIN TRANSACTION
				SELECT @IsOccupato=COUNT(*)
					FROM Ticket
					JOIN Showtime ON Ticket.ShowtimeID=Showtime.ShowtimeID
					JOIN Theater ON Showtime.TheaterID=Theater.TheaterID
					Where Showtime.ShowtimeID = @inputShowID AND Ticket.SeatNumber=@inputSeatNumber
					

					IF @IsOccupato  >0
							THROW 50001, 'POSTO NON DISPONIBILE', 1;

					INSERT INTO Ticket( CustomerID,SeatNumber,PurchasedDateTime,ShowtimeID) 
					VALUES( @inputCostumerID,@inputSeatNumber,CURRENT_TIMESTAMP,@inputShowID);
							
					PRINT'BIGLIETTO ACQUISTATO'
					COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
	END CATCH
END;
	
EXEC PurchaseTicket @inputShowID=1,
@inputCostumerID=2,
@inputSeatNumber="A2";

/*2. Procedura di Aggiornamento Programmazione Film
Implementare una stored procedure UpdateMovieSchedule che permetta di aggiornare gli orari
degli spettacoli per un determinato film. Questo include la possibilit� di aggiungere o rimuovere
spettacoli dall'agenda.*/

SELECT * FROM Showtime
WHERE ShowtimeID = 4 AND MovieID= 2 AND TheaterID= 2 AND ShowDateTime='2024-17-03 22:30:00.000';

DROP PROCEDURE IF EXISTS AddMovieSchedule
CREATE PROCEDURE AddMovieSchedule
@inputMovieId INT,
@inputTheaterID INT,
@inputShowDateTime DATETIME,
@inputPrice DECIMAL(5,2)
AS
BEGIN
	BEGIN TRY
		INSERT INTO Showtime(MovieID,TheaterID,ShowDateTime,Price) VALUES
		(@inputMovieId,@inputTheaterID,@inputShowDateTime,@inputPrice);
		END TRY
		BEGIN CATCH
			PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
		END CATCH
END;

EXEC AddMovieSchedule 
		@inputMovieId=2,
		@inputTheaterID=2,
		@inputShowDateTime='2024-17-03 22:30:00',
		@inputPrice= 11.00

SELECT * FROM Showtime;

CREATE PROCEDURE removeMovieSchedule
	@inputShowTimeID INT,
	@inputMovieID INT,
	@inputTheater INT,
	@inputShowDateTime DATETIME
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @contatore INT=0;
				SELECT @contatore=COUNT(*) FROM Showtime
					WHERE ShowtimeID = @inputShowTimeID AND MovieID=@inputMovieID AND TheaterID= @inputTheater AND ShowDateTime=@inputShowDateTime; 
					If @contatore = 1
						BEGIN
							DELETE FROM Showtime
								WHERE ShowtimeID = @inputShowTimeID AND MovieID=@inputMovieID AND TheaterID= @inputTheater AND ShowDateTime=@inputShowDateTime;
							PRINT 'Showtime eliminato'
						END
					ELSE
						BEGIN
							SELECT 'ERROR' AS STATUS
							PRINT 'Non � STATO POSSIBILE ELIMINARE sHOWTIME'
						END
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()
		END CATCH
	END;
SELECT * FROM Showtime;
EXEC removeMovieSchedule @inputShowTimeID=3,
	@inputMovieID= 2,
	@inputTheater= 2,
	@inputShowDateTime='2024-17-03 22:30:00'

--Implementare una stored procedure UpdateMovieSchedule che permetta di aggiornare gli orari
--degli spettacoli per un determinato film. Questo include la possibilit� di aggiungere o rimuovere
--spettacoli dall'agenda.
DROP PROCEDURE UpdateMovieSchedule
CREATE PROCEDURE UpdateMovieSchedule 
@showdatetimeValue DATE,
@showtimeIDValue INT = NULL,
@movieIDValue INT,
@showtimetheaterValue INT,
@showtimepriceValue DECIMAL,
@check BIT = 'true'
AS
	BEGIN
		
		BEGIN TRY
			BEGIN TRANSACTION 
			DECLARE @cont INT
			SELECT @cont = COUNT(*) FROM Showtime
			WHERE Showtime.ShowDateTime = @showdatetimeValue AND Showtime.MovieID = @movieIDValue AND Showtime.ShowtimeID = @showtimeIDValue
				IF @cont = 0 AND @showdatetimeValue > CURRENT_TIMESTAMP AND @showtimeIDValue IS NULL
				INSERT INTO Showtime(MovieID,TheaterID,ShowDateTime,Price)
				VALUES (@movieIDValue,@showtimetheaterValue,@showdatetimeValue,@showtimepriceValue)
				ELSE
				UPDATE Showtime SET 
				ShowDateTime = @showdatetimeValue
				WHERE Showtime.ShowtimeID = @showtimeIDValue  AND Showtime.MovieID = @movieIDValue 
				IF @check = 'false'
				DELETE FROM Showtime
				WHERE Showtime.ShowDateTime = @showdatetimeValue AND Showtime.MovieID = @movieIDValue AND Showtime.ShowtimeID = @showtimeIDValue
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT 'ERRORE'
			ROLLBACK
		END CATCH

	END
	EXEC UpdateMovieSchedule @showdatetimeValue =  '2025-01-20T23:00:00', @showtimeIDValue = 8,@showtimepriceValue = 10,@showtimetheaterValue = 1,@movieIDValue = 1,@check = 'false'
	SELECT * FROM Showtime

	--Sviluppare una stored procedure InsertNewMovie che consenta di inserire un nuovo film nel
--sistema, richiedendo tutti i dettagli pertinenti come titolo, regista, data di uscita, durata e
--classificazione.

CREATE PROCEDURE InsertNewMovie 
    @MovieID INT,
    @Title VARCHAR(255),
    @Director VARCHAR(100),
    @ReleaseDate DATE = NULL,
    @DurationMinutes INT,
    @Rating VARCHAR(5)
AS
BEGIN 
    --DECLARE @DefaultReleaseDate VARCHAR(255) = 'Il film deve essere ancora rilasciato';
 
    BEGIN TRY
        BEGIN TRANSACTION;
 
			IF @MovieID IS NULL
				THROW 50001,'Inserisci un MovieID',1;
			IF @Title IS NULL
				THROW 50002,'Inserisci un Titolo',1;
			IF @Director IS NULL
				THROW 50003,'Inserisci un Director',1;
			IF @ReleaseDate IS NULL
				SET @ReleaseDate = CURRENT_TIMESTAMP;

			INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
			VALUES (@MovieID, @Title, @Director, @ReleaseDate, @DurationMinutes, @Rating);
 
				PRINT 'Nuovo film inserito con successo.';
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Si è verificato un errore durante l''inserimento del nuovo film: ' + ERROR_MESSAGE();
    END CATCH
END;

DROP PROCEDURE IF EXISTS SubmitReview;
CREATE PROCEDURE SubmitReview
	@valutazione INT,
	@testo TEXT,
	@idFilm INT,
	@idCliente INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			DECLARE @cont INT;
			DECLARE @dataFilm DATETIME;
			DECLARE @ExistingReviews INT;

			SELECT @cont = COUNT(*), @dataFilm = ShowDateTime FROM Customer
				JOIN Ticket ON Customer.CustomerID = Ticket.CustomerID
				JOIN Showtime ON Ticket.ShowtimeID = Showtime.ShowtimeID
				JOIN Movie ON Showtime.MovieID = Movie.MovieID
				WHERE Customer.CustomerID = @idCliente 
					AND Movie.MovieID = @idFilm;

			 SELECT @ExistingReviews = COUNT(*)
				FROM Review
				WHERE MovieID = @idFilm
				AND CustomerID = @idCliente;

			IF @cont <> 0 AND @dataFilm >= CURRENT_TIMESTAMP AND @ExistingReviews = 0
			BEGIN
				INSERT INTO Review (MovieID, CustomerID, ReviewText, Rating, ReviewDate) VALUES
				(@idFilm, @idCliente, @testo, @valutazione, CURRENT_TIMESTAMP)
			END
				
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC SubmitReview @valutazione = 4, @testo = 'Decente', @idFilm = 4, @idCliente = 1;

SELECT * FROM Review;