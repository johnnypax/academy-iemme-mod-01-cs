CREATE TABLE Persona(
	personaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE CartaIdentita(
	cartaidentitaID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(10) NOT NULL UNIQUE,
	scadenza DATE NOT NULL,
	personaRIF INT NOT NULL UNIQUE,
	FOREIGN KEY (personaRIF) REFERENCES Persona(personaID) ON DELETE CASCADE		-- CASCADE/SET NULL
);

INSERT INTO Persona(nome, cognome, email) VALUES
('Giovanni', 'Pace', 'gio@pace.com'),
('Valeria', 'Verdi', 'val@ver.com'),
('Mario', 'Rossi', 'mar@rossi.com'),
('Marika', 'Mariko', 'mar@ko.com');

INSERT INTO CartaIdentita(codice, scadenza, personaRIF) VALUES
('AB123', '2020-01-01', 1),
('AB124', '2020-01-01', 2),
('AB125', '2020-01-01', 3);

-- Voglio consultare la carta di identità di Valeria
SELECT *
	FROM Persona
	JOIN CartaIdentita ON Persona.personaID = CartaIdentita.personaRIF
	WHERE nome = 'Valeria' AND cognome = 'Verdi';

SELECT * 
	FROM CartaIdentita
	JOIN Persona ON CartaIdentita.personaRIF = Persona.personaID
	WHERE codice = 'AB124';

SELECT * 
	FROM CartaIdentita
	RIGHT JOIN Persona ON CartaIdentita.personaRIF = Persona.personaID
	ORDER BY cognome ASC;		-- DESC