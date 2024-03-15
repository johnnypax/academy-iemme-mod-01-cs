DECLARE @variabile VARCHAR(150) = 'CIAO';

-- PRINT @variabile;
SELECT @variabile

--------------------------------------
DECLARE @variabileUno VARCHAR(150);
DECLARE @variabileDue INT;
DECLARE @variabileTre INT;

SET @variabileUno = 'Giovanni'
SET @variabileDue = 2
SET @variabileTre = 8

-- PRINT @variabile;
SELECT CAST(@variabileDue AS VARCHAR) + CAST(@variabileTre AS VARCHAR) + @variabileUno;