CREATE DATABASE acc_lez29_libreria;
USE acc_lez29_libreria;

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
	titolo VARCHAR(250) NOT NULL,
	descrizione TEXT,
	autore VARCHAR(250),
	prezzo DECIMAL(10,2) NOT NULL CHECK (prezzo >= 0),
	quantita INTEGER DEFAULT 0 CHECK (quantita >= 0)
);

INSERT INTO Libro(titolo, descrizione, autore, prezzo, quantita) VALUES
('Il signore degli anelli', 'Molto lungo il testo', 'JRRT', 12.5, 78),
('Le due torri', 'Molto alte', 'JRRT', 13.5, 8),
('Il ritorno del re', 'In ritardo', 'JRRT', 14.5, 25);

SELECT * FROM Libro;