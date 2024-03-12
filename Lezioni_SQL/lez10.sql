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

CREATE TABLE Iscrizione(
	studenteRIF INT NOT NULL ,
	esameRIF INT NOT NULL,
	data_iscr DATETIME DEFAULT CURRENT_TIMESTAMP,
	note TEXT,
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

INSERT INTO Iscrizione(studenteRIF, esameRIF) VALUES
(1,	2),
(1,	5),
(2,	2),
(2,	4),
(2,	5);

SELECT *
	FROM Studente
	JOIN Iscrizione ON Studente.studenteID = Iscrizione.studenteRIF
	JOIN Esame ON Iscrizione.esameRIF = Esame.esameID;