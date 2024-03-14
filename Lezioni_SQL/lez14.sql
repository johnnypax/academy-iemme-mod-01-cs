DROP TABLE IF EXISTS Recensione;
DROP TABLE IF EXISTS Facility;
DROP TABLE IF EXISTS Dipendente;
DROP TABLE IF EXISTS Prenotazione;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Camera;
DROP TABLE IF EXISTS Albergo;

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
	-- Possibilità di aggiungere un Codice Fiscale
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
	-- Verificare se la recensione può essere inserita a fine del soggiorno (checkout riempito)
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


-- VIEWS
CREATE VIEW albergoConRelativiClienti AS
	SELECT al.nome AS 'Albergo', cl.nome + ' ' + cl.cognome AS 'Nominativo' 
		FROM Albergo AS al
		JOIN Camera ca ON al.albergoID = ca.albergoRIF
		JOIN Prenotazione pr ON ca.cameraID = pr.cameraRIF
		JOIN Cliente cl ON pr.clienteRIF = cl.clienteID;

SELECT * FROM albergoConRelativiClienti;

-----------------------------------
DROP VIEW IF EXISTS albergoGeneraleConClienti;
CREATE VIEW albergoGeneraleConClienti AS
	SELECT albergoID, al.nome AS nome_albergo, indirizzo, cl.nome + ' ' + cl.cognome AS 'Nominativo' --al.*
		FROM Albergo AS al
		JOIN Camera ca ON al.albergoID = ca.albergoRIF
		JOIN Prenotazione pr ON ca.cameraID = pr.cameraRIF
		JOIN Cliente cl ON pr.clienteRIF = cl.clienteID;

CREATE VIEW dettaglioGeneraleAlberghiFacility AS
	SELECT nome_albergo, indirizzo, nominativo, nome, descrizione, orariApertura
		FROM albergoGeneraleConClienti
		JOIN Facility f ON albergoGeneraleConClienti.albergoID = f.albergoRIF;

SELECT * 
	FROM dettaglioGeneraleAlberghiFacility 
	ORDER BY nome_albergo;

-- Conta tutti i clienti per un albergo
SELECT COUNT(*) AS 'Numero clienti' FROM albergoGeneraleConClienti WHERE nome_albergo = 'Hotel Bella Vista';