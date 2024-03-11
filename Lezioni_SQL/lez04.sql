-- DDL
DROP TABLE IF EXISTS Contatto;
CREATE TABLE Contatto(
	contattoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	cod_fis CHAR(16) NOT NULL UNIQUE
);


--INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
--('Giovanni', 'Pace', 'gio@pace.com', 'PCAGNN'),
--('Valeria', 'Verdi', 'val@verdi.com', 'VLRVRD'),
--('Mario', 'Rossi', 'mar@rossi.com', 'PCAGNN'),
--('Marika', 'Mariko', 'mar@mar.com', 'MARMAR');

INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Giovanni', 'Pace', 'gio@pace.com', 'PCAGNN');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Valeria', 'Verdi', 'val@verdi.com', 'VLRVRD');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Mario', 'Rossi', 'mar@rossi.com', 'MARRSS');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Marika', 'Mariko', 'mar@mar.com', 'MARMAR');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Mario', 'Mariottide', 'mar@td.com', 'MARMTD');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Maria', 'Mariani', 'mar@mrn.com', 'MARMRN');
INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Mariolino', 'Mariottide', 'mar@ted.com', 'MIOMTD');

-- QL
SELECT * FROM Contatto;
SELECT contattoID, nome, cognome, email, cod_fis FROM Contatto;

SELECT nome, cognome, email FROM Contatto;

-- Alias
SELECT nome AS 'First Name', cognome AS 'Last Name', email AS Email FROM Contatto;

-- RICERCA
SELECT * FROM Contatto WHERE nome = 'Mario';

SELECT * FROM Contatto WHERE nome = 'Mario' AND cognome = 'Rossi';

SELECT * FROM Contatto WHERE nome = 'Mario' OR nome = 'Giovanni' OR nome = 'Marika';
SELECT * FROM Contatto WHERE nome IN ('Mario', 'Giovanni', 'Marika');

SELECT * FROM Contatto WHERE nome <> 'Mario';

-- LIKE
-- Tutto ciò che inizia per Ma...
SELECT * FROM Contatto WHERE nome LIKE 'Ma%';

-- Tutto ciò che finisce per ...io
SELECT * FROM Contatto WHERE nome LIKE '%io';

-- Tutto ciò che contiene almeno una volta ...io...
SELECT * FROM Contatto WHERE nome LIKE '%io%';

-- Ricerca puntuale
SELECT * FROM Contatto WHERE nome LIKE '_a_i_____';

/*
Creare una tabella di libri caratterizzata da Titolo, l'autore ed il codice ISBN.
- Inserire almeno 6 libri
- Ricercare tutti i libri di un autore
- Ricercare tutti i libri che hanno la sequenza "an" al loro interno
- Ricerca per ISBN
*/