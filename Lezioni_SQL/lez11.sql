-- DDL
CREATE TABLE Museo(
	museoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	indirizzo VARCHAR(250) NOT NULL,
	citta VARCHAR(250) NOT NULL,
	direttore VARCHAR(250) NOT NULL
);

CREATE TABLE Artista(
	artistaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	nazionalita VARCHAR(250) NOT NULL,
	data_nascita DATE NOT NULL,
	data_morte DATE
);

CREATE TABLE Dipinto(
	dipintoID INT PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	codice VARCHAR(250) NOT NULL UNIQUE,
	data_crea DATE NOT NULL,
	dimensioni VARCHAR(250) NOT NULL,
	tipo_pitt VARCHAR(250) NOT NULL,
	museoRIF INT,					-- Potrebbe essere in ristrutturazione e quindi in nessun museo
	FOREIGN KEY (museoRIF) REFERENCES Museo(museoID) ON DELETE SET NULL
);

CREATE TABLE Artista_Dipinto(
	artistaRIF INT NOT NULL,
	dipintoRIF INT NOT NULL,
	FOREIGN KEY (artistaRIF) REFERENCES Artista(artistaID) ON DELETE CASCADE,
	FOREIGN KEY (dipintoRIF) REFERENCES Dipinto(dipintoID) ON DELETE CASCADE,
	PRIMARY KEY (artistaRIF, dipintoRIF)
);

CREATE TABLE Personaggio(
	personaggioID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL
);

CREATE TABLE Personaggio_Dipinto(
	personaggioRIF INT NOT NULL,
	dipintoRIF INT NOT NULL,
	FOREIGN KEY (personaggioRIF) REFERENCES Personaggio(personaggioID) ON DELETE CASCADE,
	FOREIGN KEY (dipintoRIF) REFERENCES Dipinto(dipintoID) ON DELETE CASCADE,
	PRIMARY KEY (personaggioRIF, dipintoRIF)
);


