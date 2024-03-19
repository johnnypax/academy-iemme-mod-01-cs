USE acc_lez24_citta;

CREATE TABLE Citta(
	cittaID INTEGER PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL ,
	prov VARCHAR(3) NOT NULL
);

ALTER TABLE Citta ADD CONSTRAINT CHK_nome UNIQUE(nome);

INSERT INTO Citta(nome, prov) VALUES
('Pescara', 'PE'),
('L''Aquila', 'AQ');

INSERT INTO Citta(nome, prov) VALUES
('Chieti', 'CH');

SELECT cittaID, nome, prov FROM Citta;

CREATE TABLE Utenti(
	userID INT PRIMARY KEY IDENTITY(1,1),
	usern VARCHAR(250) NOT NULL UNIQUE,
	passw VARCHAR(250) NOT NULL
);

INSERT INTO Utenti(usern, passw) VALUES
('ciccio', 'pasticcio'),
('bo', 'passwordo'),
('ceppa', 'blu');

CREATE PROCEDURE CheckUserPass
	@userValue VARCHAR(250),
	@passValue VARCHAR(250)
AS
BEGIN
  --SELECT * FROM Utenti WHERE usern = 'bo' AND passw = 'passwodo'
	SELECT * FROM Utenti WHERE usern = @userValue AND passw = @passValue
END;

EXEC CheckUserPass @userValue = ' '' OR 1=1; ', @passValue = 'passwodo';
SELECT userID, usern, passw FROM Utenti WHERE usern = '' OR 1=1 OR '' = '' AND passw = 'passwrdo'