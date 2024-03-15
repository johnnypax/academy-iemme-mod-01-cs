CREATE TABLE Albergo (
	albergoID INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    indirizzo VARCHAR(255) NOT NULL,
	UNIQUE(nome, indirizzo)
);

CREATE TABLE Camera (
	cameraID INT PRIMARY KEY IDENTITY(1,1),
    numero INT NOT NULL,
    tipo VARCHAR (50) NOT NULL,
    capacitaMassima INT NOT NULL CHECK (capacitaMassima >= 0),
    tariffaPerNotte DECIMAL(10, 2) NOT NULL,
    albergoRIF INT NOT NULL,
    FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
	UNIQUE(numero, albergoRIF)
);

CREATE TABLE Cliente (
    clienteID INT PRIMARY KEY IDENTITY(1,1),
    nome NVARCHAR(100) NOT NULL,
    cognome NVARCHAR(100) NOT NULL ,
    contatto NVARCHAR(100) NOT NULL,
	-- Possibilit� di aggiungere un Codice Fiscale
);

CREATE TABLE Prenotazione (
    prenotazioneID INT PRIMARY KEY IDENTITY (1,1),
    dataCheckIn DATE NOT NULL,
    dataCheckOut DATE NOT NULL,
    cameraRIF INT NOT NULL,
    clienteRIF INT,
    FOREIGN KEY (cameraRIF) REFERENCES Camera(cameraID) ON DELETE CASCADE,
    FOREIGN KEY (clienteRIF) REFERENCES Cliente(clienteID) ON DELETE SET NULL,
	-- DA FINIRE...
);

CREATE TABLE Dipendente (
    dipendenteID INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    cognome VARCHAR(100) NOT NULL,
    posizione VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    albergoRIF INT NOT NULL,
    FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
);

CREATE TABLE Facility (
	facilityID INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    descrizione VARCHAR(255) NOT NULL,
    orariApertura TEXT NOT NULL,
    albergoRIF INT NOT NULL,
    FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
);

CREATE TABLE Recensione(
	recensioneID INT PRIMARY KEY IDENTITY(1,1),
	valutazione INT CHECK (valutazione BETWEEN 1 AND 5),
	descrizione TEXT,
	prenotazioneRIF INT NOT NULL,
	FOREIGN KEY (prenotazioneRIF) REFERENCES Prenotazione(prenotazioneID) ON DELETE CASCADE
	-- Verificare se la recensione puo essere inserita a fine del soggiorno (checkout riempito)
);



INSERT INTO Albergo (nome, indirizzo)VALUES
	('Hotel Bella Vista', 'Via Roma 123, Roma'),
    ('Grand Hotel Paradiso', 'Corso Italia 456, Milano'),
    ('Hotel Mare Blu', 'Lungomare 789, Napoli');

INSERT INTO Camera (numero, tipo, capacitaMassima, tariffaPerNotte, albergoRIF)VALUES 
    (101, 'Singola', 1, 100.00, 1),
    (202, 'Doppia', 2, 150.00, 1),
    (303, 'Suite', 4, 250.00, 2),
    (404, 'Matrimoniale', 2, 180.00, 2),
    (505, 'Tripla', 3, 200.00, 3);
INSERT INTO Camera (numero, tipo, capacitaMassima, tariffaPerNotte, albergoRIF)VALUES 
    (101, 'Doppia', 1, 100.00, 2);

INSERT INTO Cliente (Nome, cognome, contatto)VALUES 
	('Mario', 'Rossi', 'mario.rossi@example.com'),
    ('Laura', 'Bianchi', 'laura.bianchi@example.com'),
    ('Marco', 'Verdi', 'marco.verdi@example.com'),
    ('Francesca', 'Neri', 'francesca.neri@example.com'),
    ('Giovanni', 'Gialli', 'giovanni.gialli@example.com');

INSERT INTO Prenotazione (dataCheckIn, dataCheckOut, cameraRIF, clienteRIF)VALUES 
    ('2024-03-15', '2024-03-20', 1, 1),
    ('2024-04-10', '2024-04-15', 3, 2),
    ('2024-05-01', '2024-05-05', 5, 3);


INSERT INTO Dipendente (nome, cognome, posizione, email, albergoRIF)VALUES 
    ('Paolo', 'Bianchi', 'Receptionist', 'paolo.bianchi@example.com', 1),
    ('Anna', 'Verdi', 'Manager', 'anna.verdi@example.com', 2),
    ('Luca', 'Rossi', 'Pulizie', 'luca.rossi@example.com', 3),
    ('Maria', 'Gialli', 'Receptionist', 'maria.gialli@example.com', 1);


INSERT INTO Facility (Nome, descrizione, orariApertura, albergoRIF)VALUES
    ('Palestra', 'Palestra attrezzata con macchinari moderni', '06:00 - 22:00', 1),
    ('Piscina', 'Piscina con vista panoramica', '09:00 - 20:00', 2),
    ('Spa', 'Spa con trattamenti benessere e massaggi', '10:00 - 21:00', 3);
INSERT INTO Facility (Nome, descrizione, orariApertura, albergoRIF)VALUES
    ('Piscina', 'Piscinotta', '09:00 - 20:00', 1),
    ('Spa', 'Spaotta', '10:00 - 21:00', 1);

SELECT * 
	FROM Albergo
	JOIN Camera ON Albergo.albergoID = Camera.albergoRIF
	JOIN Prenotazione ON Camera.cameraID = Prenotazione.cameraRIF;


--DECLARE @data_inizio DATE = '2024-03-01'
--DECLARE @data_fine DATE = '2024-03-03'
--DECLARE @cameraRIF INT = 1
--DECLARE @contatore INT = 0

--SELECT @contatore = COUNT(*) FROM Prenotazione
--                WHERE cameraRIF = @cameraRIF
--                AND @data_inizio BETWEEN dataCheckIn AND dataCheckOut
--                OR @data_fine BETWEEN dataCheckIn AND dataCheckOut
--                OR dataCheckIn BETWEEN @data_inizio AND @data_fine
--                OR dataCheckOut BETWEEN @data_inizio AND @data_fine

--IF @contatore > 0
--	BEGIN
--		PRINT 'Non possibile inserimento (disse il robot)'
--	END
--ELSE
--	BEGIN
--		PRINT 'Inserimento effettuato'
--	END

-------------------------------------------------------------------

--DECLARE @data_inizio DATE = '2024-03-01'
--DECLARE @data_fine DATE = '2024-03-20'
--DECLARE @cameraRIF INT = 1

--SELECT * FROM Prenotazione
--                WHERE cameraRIF = @cameraRIF
--                AND @data_inizio BETWEEN dataCheckIn AND dataCheckOut
--                OR @data_fine BETWEEN dataCheckIn AND dataCheckOut
--                OR dataCheckIn BETWEEN @data_inizio AND @data_fine
--                OR dataCheckOut BETWEEN @data_inizio AND @data_fine

--IF @@ROWCOUNT > 0
--	BEGIN
--		PRINT 'Non possibile inserimento (disse il robot)'
--	END
--ELSE
--	BEGIN
--		PRINT 'Inserimento effettuato'
--	END

-----------------------------------------------------------

DROP PROCEDURE IF EXISTS InsertReservation;
CREATE PROCEDURE InsertReservation
	@data_inizio DATE,
	@data_fine DATE,
	@idCamera INT,
	@idCliente INT
AS 
BEGIN
	DECLARE @contatore INT = 0;

	SELECT @contatore = COUNT(*) FROM Prenotazione
					WHERE cameraRIF = @idCamera
					AND @data_inizio BETWEEN dataCheckIn AND dataCheckOut
					OR @data_fine BETWEEN dataCheckIn AND dataCheckOut
					OR dataCheckIn BETWEEN @data_inizio AND @data_fine
					OR dataCheckOut BETWEEN @data_inizio AND @data_fine

	IF @contatore > 0
		BEGIN
			SELECT 'ERROR' AS STATUS
			PRINT 'Non possibile inserimento (disse il robot)'
		END
	ELSE
		BEGIN
			BEGIN TRY
				INSERT INTO Prenotazione(dataCheckIn, dataCheckOut, clienteRIF, cameraRIF) VALUES
				(@data_inizio, @data_fine, @idCliente, @idCamera);
					
				SELECT 'SUCCESS' AS STATUS
				PRINT 'Inserimento effettuato'
			END TRY
			BEGIN CATCH
				SELECT 'ERROR' AS STATUS
				PRINT 'Errore' + ERROR_MESSAGE()
			END CATCH
		END
END;

EXEC InsertReservation @data_inizio = '2024-03-10', @data_fine = '2024-03-12', @idCamera = 1, @idCliente = 1;