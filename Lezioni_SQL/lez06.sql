-- DDL
CREATE TABLE Prodotto(
	prodottoID INT IDENTITY(1,1),
	nome VARCHAR(150) NOT NULL,
	descrizione TEXT,
	categoria VARCHAR(50) DEFAULT 'Non definito',
	codice VARCHAR(10) NOT NULL,
	prezzo DECIMAL(5,2),	-- CHECK (prezzo >= 0),
	data_scadenza DATE,		-- CHECK (data_scadenza BETWEEN '1970-01-01' AND '2100-01-01'),										-- 'YYYY-MM-DD'
	data_inserimento DATETIME DEFAULT CURRENT_TIMESTAMP,		-- 'YYYY-MM-DD HH:mm:ss'
	PRIMARY KEY(prodottoID),
	UNIQUE(codice),
	CONSTRAINT CHK_prezzo CHECK (prezzo >= 0),
	CONSTRAINT CHK_scadenza CHECK (data_scadenza BETWEEN '1970-01-01' AND '2100-01-01')
);

-- Rimozione ed inserimento constraint
ALTER TABLE Prodotto DROP CONSTRAINT CHK_scadenza;
ALTER TABLE Prodotto ADD CONSTRAINT CHK_scadenza CHECK (data_scadenza BETWEEN '1970-01-01' AND '2100-01-01');
ALTER TABLE Prodotto ADD CONSTRAINT CHK_categoria CHECK(categoria IN ('alimento', 'illuminazione', 'mobilio'));

-- DML
INSERT INTO Prodotto (nome, descrizione, codice, prezzo, data_scadenza) VALUES
('Biscotti', 'Molto buoni', 'BIS123', 12.5, '2050-01-01');
INSERT INTO Prodotto (nome, descrizione, codice, prezzo, data_scadenza, categoria) VALUES
('Nutella', 'Caloooooorica', 'NUT213', 5.5, '2028-01-01', 'alimento'),
('Lampada', 'luminosa', 'LUM876', 75.5, null, 'illuminazione'),
('Divano', 'Comodo', 'DIV123', 895.5, null, 'mobilio');

-- QL
SELECT * FROM Prodotto;