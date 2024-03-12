-- DDL
CREATE TABLE Libro(
	libroID INT PRIMARY KEY ID3ENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	autore VARCHAR(50) NOT NULL,
	isbn CHAR(17) NOT NULL UNIQUE,
	categoria VARCHAR(50) DEFAULT 'N.D.' 
);

-- DML
INSERT INTO Libro(isbn, titolo, autore) VALUES
('ab1234', 'Il signore degli anelli', 'JRRT'),
('ab1235', 'Le due torri', 'JRRT');

INSERT INTO Libro(isbn, titolo, autore, categoria) VALUES
('ab1236', 'Il ritorno del re', 'JRRT', 'Fantasy'),
('ab1237', 'Come miagolare', 'Il gatto di Valerio', null);

-- QL
SELECT * FROM Libro;


SELECT * FROM Libro WHERE categoria IS NULL;
SELECT * FROM Libro WHERE categoria IS NOT NULL;

SELECT * FROM Libro 
	WHERE titolo LIKE '%an%' 
		OR  autore LIKE '%an%' 
		OR  isbn LIKE '%an%';