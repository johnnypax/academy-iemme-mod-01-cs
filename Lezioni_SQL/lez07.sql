-- DDL
DROP TABLE IF EXISTS Carta;
DROP TABLE IF EXISTS Persona;

CREATE TABLE Persona(
	personaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Carta(
	cartaID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(10) NOT NULL UNIQUE,
	negozio VARCHAR(50) NOT NULL,
	personaRIF INT NOT NULL,
	FOREIGN KEY (personaRIF) REFERENCES Persona(personaID) ON DELETE CASCADE		-- CASCADE/SET NULL
);

INSERT INTO Persona(nome, cognome, email) VALUES
('Giovanni', 'Pace', 'gio@pace.com'),
('Valeria', 'Verdi', 'val@ver.com'),
('Mario', 'Rossi', 'mar@rossi.com'),
('Marika', 'Mariko', 'mar@ko.com');

INSERT INTO Carta(codice, negozio, personaRIF) VALUES
('AB123', 'Coop',	1),
('AB124', 'Coop',	2),
('AB125', 'Coop',	3),
('CC123', 'Conad',	3),
('CC124', 'Conad',	1),
('CC125', 'Conad',	2),
('TT123', 'Tigotà',	1);

-- DELETE FROM Persona WHERE personaID = 1;	-- Permessa grazie a ON DELETE CASCADE

SELECT * FROM Persona;
SELECT * FROM Carta;

-- Cerco tutte le carte di Giovanni Pace
SELECT * 
	FROM Persona 
	JOIN Carta ON Persona.personaID = Carta.personaRIF
	WHERE personaID = 1;

SELECT nome, cognome, email, codice, negozio
	FROM Persona 
	JOIN Carta ON Persona.personaID = Carta.personaRIF
	WHERE personaID = 1;

-- VOglio sapere a chi appartiene la CC125
SELECT *
	FROM Carta
	JOIN Persona ON Carta.personaRIF = Persona.personaID
	WHERE codice = 'CC125';

-- VOglio vedere tutte le persone e le relative carte di fedelta
SELECT * 
	FROM Persona 
	RIGHT JOIN Carta ON Persona.personaID = Carta.personaRIF;