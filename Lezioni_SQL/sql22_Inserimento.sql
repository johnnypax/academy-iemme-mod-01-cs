-- DDL
CREATE TABLE Categoria(
	categoriaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	codice VARCHAR(250) NOT NULL UNIQUE,
	quantita INT NOT NULL DEFAULT 0
);

CREATE TABLE Categoria_Prodotto(
	categoriaRIF INT NOT NULL,
	prodottoRIF INT NOT NULL,
	FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID) ON DELETE CASCADE,
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID) ON DELETE CASCADE,
	PRIMARY KEY (categoriaRIF, prodottoRIF)
);

INSERT INTO Categoria (nome) VALUES
('Mobili'),
('Illuminazione'),
('Elettrodomestici');

DROP PROCEDURE IF EXISTS InsertProdotto
CREATE PROCEDURE InsertProdotto
	@categoriaNome VARCHAR(250),
	@nomeProd VARCHAR(250),
	@codiceProd VARCHAR(250),
	@quantitaProd INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @categoriaID INT;
			DECLARE @prodottoID INT;

			SELECT @categoriaID = categoriaID FROM acc_lez22_ferramenta.dbo.Categoria WHERE nome = @categoriaNome; 
			-- PRINT @categoriaID;

			INSERT INTO Prodotto (nome, codice, quantita) VALUES
			(@nomeProd, @codiceProd, @quantitaProd);

			SELECT @prodottoID = @@IDENTITY;

			INSERT INTO Categoria_Prodotto(prodottoRIF, categoriaRIF) VALUES
			(@prodottoID,@categoriaID)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK

		PRINT 'Errore: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC InsertProdotto @categoriaNome = 'ehgitigurtr', @nomeProd = 'Lampadone', @codiceProd = 'LMPD1', @quantitaProd = 15;

SELECT * 
	FROM Prodotto
	JOIN Categoria_Prodotto ON Prodotto.prodottoID = Categoria_Prodotto.prodottoRIF
	JOIN Categoria ON Categoria_Prodotto.categoriaRIF = Categoria.categoriaID;

SELECT * FROM Categoria_Prodotto;