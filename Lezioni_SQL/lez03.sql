-- DDL
DROP TABLE IF EXISTS Contatto;
CREATE TABLE Contatto(
	contattoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	cod_fis CHAR(16) NOT NULL UNIQUE
);

INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Giovanni', 'Pace', 'gio@pace.com', 'PCAGNN'),
('Valeria', 'Verdi', 'val@verdi.com', 'VLRVRD'),
('Mario', 'Rossi', 'mar@rossi.com', 'MRRRSS');

INSERT INTO Contatto(nome, cognome, email, cod_fis) VALUES
('Marika', 'Mariko', 'mar@mar.com', 'MARMAR');

DELETE FROM Contatto WHERE contattoID = 3;
DELETE FROM Contatto WHERE cod_fis = 'MARMAR';

SELECT * FROM Contatto;