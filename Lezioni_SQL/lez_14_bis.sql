USE acc_lez14_alberghi;

/*
	Voglio una view che mi visualizzi il nome dell'albergo e la media delle valutazioni
*/

INSERT INTO Prenotazione (dataCheckIn, dataCheckOut, cameraRIF, clienteRIF)VALUES 
    ('2025-03-15', '2025-03-20', 4, 1),
    ('2025-04-10', '2025-04-15', 6, 2),

INSERT INTO Recensione(valutazione,descrizione,prenotazioneRIF) VALUES
	(5,'Camera Bella', 2),
	(1,'Camera brutta', 4),
	(3,'Camera Mediocre', 5);

DROP VIEW alberghiRecensioniPrenotazioni;
CREATE VIEW alberghiRecensioniPrenotazioni AS
	SELECT 
		albergoID,
		cameraID,
		prenotazioneID,
		recensioneID,
		clienteID,
		Albergo.nome AS nome_albergo,
		indirizzo,
		numero,
		tipo, 
		tariffaPerNotte,
		dataCheckIn,
		dataCheckOut,
		valutazione,
		descrizione,
		Cliente.nome AS nome_cliente,
		Cliente.cognome AS cognome_cliente,
		contatto
		FROM Albergo 
		JOIN Camera ON Albergo.albergoID = Camera.albergoRIF
		JOIN Prenotazione ON Camera.cameraID = Prenotazione.cameraRIF
		JOIN Recensione ON Prenotazione.prenotazioneID = Recensione.prenotazioneRIF
		JOIN Cliente ON Prenotazione.clienteRIF = Cliente.clienteID;

SELECT nome_albergo, AVG(valutazione) 
	FROM alberghiRecensioniPrenotazioni 
	GROUP BY nome_albergo;