-- DDL
CREATE TABLE Studente(
	studenteID INT PRIMARY KEY IDENTITY(1,1),
	nominativo VARCHAR(250) NOT NULL,
	matricola VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Esame(
	esameID INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	data_esame DATE NOT NULL,
	crediti INT CHECK (crediti >= 0) NOT NULL
);

CREATE TABLE Studente_Esame(
	studenteRIF INT NOT NULL ,
	esameRIF INT NOT NULL,
	FOREIGN KEY (studenteRIF) REFERENCES Studente(studenteID) ON DELETE CASCADE,
	FOREIGN KEY (esameRIF) REFERENCES Esame(esameID) ON DELETE CASCADE,
	PRIMARY KEY (studenteRIF, esameRIF)
);

INSERT INTO Studente(nominativo, matricola) VALUES
('Giovanni Pace', 'AB1234'),
('Mario Rossi', 'AB1235'),
('Valeria Verdi', 'AB1236');

INSERT INTO Esame(titolo, data_esame, crediti) VALUES
('Analisi I', '2020-01-01', 6),
('Analisi I', '2020-02-02', 6),
('Fisica I', '2020-01-01', 6),
('Fisica I', '2020-02-02', 6),
('Basi di Dati', '2020-03-03', 9);

INSERT INTO Studente_Esame(studenteRIF, esameRIF) VALUES
(1,	2),
(1,	5),
(2,	2),
(2,	4),
(2,	5);

-- Voglio tutti gli esami a cui è iscritto Giovanni Pace
SELECT * 
	FROM Studente
	JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
	JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID
	WHERE matricola = 'AB1234';

-- Voglio tutti gli studenti iscritti ad uno specifico esame
SELECT *
	FROM Esame
	JOIN Studente_Esame ON Esame.esameID = Studente_Esame.esameRIF
	JOIN Studente ON Studente_Esame.studenteRIF = Studente.studenteID
	WHERE titolo = 'Analisi I' AND data_esame = '2020-02-02';
	
-- Tutti gli studenti iscritti a tutti gli esami e studenti non iscritti
SELECT * 
	FROM Studente
	LEFT JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
	LEFT JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID;

-- Tutti gli esami che hanno iscritti e quelli che non
SELECT * 
	FROM Studente
	RIGHT JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
	RIGHT JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID;

-- VOGLIO TUTTI
SELECT * 
	FROM Studente
	FULL JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
	FULL JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID;

-- VOGLIO TUTTI
SELECT * 
	FROM Studente
	LEFT JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
	LEFT JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID
UNION
	SELECT * 
		FROM Studente
		RIGHT JOIN Studente_Esame ON Studente.studenteID = Studente_Esame.studenteRIF
		RIGHT JOIN Esame ON Studente_Esame.esameRIF = Esame.esameID;