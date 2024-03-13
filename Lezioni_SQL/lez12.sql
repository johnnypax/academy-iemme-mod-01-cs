/*
Creare un sistema di gestione ospedale.
L'obiettivo è tracciare le informazioni relative ai pazienti, i ricoveri ed il reparto di riferimento.
Ad ogni reparto afferiscono più medici, di ogni medico dobbiamo tener traccia delle informazioni di base
compreso il numero identificativo univoco. Possiamo asserire che un medico appartiene ad un solo reparto.
Ogni giorno un paziente ricoverato riceve una o più visite, una visita è caratterizzata solo dalla data e dalle
note.
Inoltre, vi viene chiesto di tener traccia degli esami di laboratorio. Un paziente potrebbe venire in struttura
anche solo per effettuare un esame delle urine.
*/

CREATE TABLE Reparto(
	repartoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL UNIQUE,
	num_letti INT NOT NULL CHECK (num_letti > 0)
);

CREATE TABLE Paziente(
	pazienteID INT PRIMARY KEY IDENTITY(1,1),
	nominativo VARCHAR(250) NOT NULL,
	codice_fiscale CHAR(16) NOT NULL UNIQUE,
	telefono VARCHAR(250) NOT NULL,
	email VARCHAR(250)
);

CREATE TABLE Esame(
	esameID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(50) NOT NULL CHECK (tipo IN ('urine', 'sangue', 'midollo')),
	data_esame DATETIME DEFAULT CURRENT_TIMESTAMP,
	esito TEXT,
	pazienteRIF INT NOT NULL,
	FOREIGN KEY (pazienteRIF) REFERENCES Paziente(pazienteID) ON DELETE CASCADE
);

CREATE TABLE Medico(
	medicoID INT PRIMARY KEY IDENTITY(1,1),
	codice_identificativo CHAR(10) NOT NULL UNIQUE,
	nominativo VARCHAR(250) NOT NULL,
	isPrimario TINYINT NOT NULL CHECK (isPrimario IN (0,1)) DEFAULT 0,
	repartoRIF INT NOT NULL,
	FOREIGN KEY (repartoRIF) REFERENCES Reparto(repartoID) -- Sono obbligato a togliere prima i medici prima di eliminare il reparto
);

CREATE TABLE Ricovero(
	ricoveroID INT PRIMARY KEY IDENTITY(1,1),
	data_ingresso DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	data_uscita DATETIME,
	lettino VARCHAR(50) NOT NULL DEFAULT 'N.D.',
	pazienteRIF INT NOT NULL,
	repartoRIF INT NOT NULL,
	FOREIGN KEY (pazienteRIF) REFERENCES Paziente(pazienteID) ON DELETE CASCADE,
	FOREIGN KEY (repartoRIF) REFERENCES Reparto(repartoID) ON DELETE CASCADE,
);

ALTER TABLE Ricovero ADD CONSTRAINT CHK_data_uscita CHECK(data_uscita >= data_ingresso);

CREATE TABLE Visita(
	visitaID INT PRIMARY KEY IDENTITY(1,1),
	data_visita DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	note TEXT,
	medicoRIF INT NOT NULL,
	ricoveroRIF INT NOT NULL,
	FOREIGN KEY (medicoRIF) REFERENCES Medico(medicoID) ON DELETE CASCADE,
	FOREIGN KEY (ricoveroRIF) REFERENCES Ricovero(ricoveroID) ON DELETE CASCADE,
);

INSERT INTO Reparto(nome, num_letti) VALUES
('Cardiologia', 250),
('Gastroenterologia', 100),
('Neurologia', 60);

INSERT INTO Paziente(nominativo, codice_fiscale, telefono, email) VALUES
('Giovanni Pace', 'PCAGNN', '+3012345', 'gio@pace.com'),
('Valeria Verdi', 'VLRVRD', '+3012346', 'val@ver.com'),
('Mario Rossi', 'MRRRSS', '+3012347', 'mar@rossi.com');

INSERT INTO Esame(tipo, esito, pazienteRIF) VALUES
('urine', 'Stappoooooo', 1),
('urine', 'Stappoooooo', 2),
('urine', 'Stappoooooo', 3),
('sangue', 'Tutto okappa', 1);

INSERT INTO Medico(codice_identificativo, nominativo, isPrimario, repartoRIF) VALUES
('AA1234', 'Marina Massironi', 1, 1),
('AA1235', 'Billi Ballo', 0, 1),
('AA1236', 'Herbert Ballerina', 0, 1),
('AA1237', 'Ivo Avido', 1, 2),
('AA1238', 'Rupert Sciamenna', 0, 2);

INSERT INTO Ricovero(data_uscita, lettino, pazienteRIF, repartoRIF) VALUES
(null, '3F', 1, 1),
('2024-05-05', '5T', 2, 2),
('2024-05-06', '5F', 2, 3);
INSERT INTO Ricovero(data_uscita, lettino, pazienteRIF, repartoRIF) VALUES
('2024-05-05', '4F', 3, 2);

INSERT INTO Visita(note, medicoRIF, ricoveroRIF) VALUES
('Tutto bene!', 1, 1);

SELECT * FROM Reparto;
SELECT * FROM Paziente;
SELECT * FROM Esame;
SELECT * FROM Medico;
SELECT * FROM Ricovero;
SELECT * FROM Visita;

SELECT Paziente.nominativo AS 'Nome paziente', nome AS 'Nome reparto', Medico.nominativo AS 'Nome medico'
	FROM Paziente
	JOIN Ricovero ON Paziente.pazienteID = Ricovero.pazienteRIF
	JOIN Reparto ON Ricovero.repartoRIF = Reparto.repartoID
	JOIN Medico ON Reparto.repartoID = Medico.repartoRIF
	WHERE codice_fiscale = 'VLRVRD';
