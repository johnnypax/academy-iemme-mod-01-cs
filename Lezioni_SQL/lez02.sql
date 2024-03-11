-- DDL
CREATE TABLE Persona(
	nome VARCHAR(50) NOT NULL, 
	cognome VARCHAR(50) NOT NULL, 
	telefono VARCHAR(50), 
	cod_fis CHAR(16) NOT NULL UNIQUE
);

-- DML
-- INSERIMENTO
INSERT INTO Persona(nome, cognome, telefono, cod_fis) VALUES
('Giovanni', 'Pace', '+39123456', 'PCAGNN'),
('Valeria', 'Verdi', '+3954321', 'VLRVRD'),
('Mario', 'Rossi', '+3954333', 'MRRRSS');

-- ELIMINAZIONE
--DELETE FROM Persona; -- MOLTO PERICOLOSO
DELETE FROM Persona WHERE cod_fis = 'MRRRSS';

-- MODIFICA
UPDATE Persona SET 
	nome = 'Giovannino', 
	telefono = '+11111111' 
		WHERE cod_fis = 'PCAGNN';

-- QL
SELECT * FROM Persona;