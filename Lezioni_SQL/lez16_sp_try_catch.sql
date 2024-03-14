-- DDL
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Salary DECIMAL(10, 2)				-- 123456769.11
);

-- DML
INSERT INTO Employees (EmployeeID, FirstName, LastName, Salary) VALUES
(1, 'John', 'Doe', 50000),
(2, 'Jane', 'Smith', 60000),
(3, 'Emily', 'Jones', 70000);

/*
	TRY
		Operazione 1
		Operazione 2
	CATCH
		LOG Errore
*/

DROP PROCEDURE IF EXISTS UpdateSalaryById;
-- Modifica il salario di una persona tramite una SP
CREATE PROCEDURE UpdateSalaryById
	@employeeId INT,
	@salaryValue DECIMAL(10, 2)
AS
BEGIN
	BEGIN TRY
		IF @salaryValue < 0
			THROW	50002, 'Salario negativo', 1

		UPDATE Employees SET
			Salary = @salaryValue
			WHERE EmployeeID = @employeeId

		IF @@ROWCOUNT = 0
			THROW	50001, 'Impiegato non trovato', 1				-- codice_errore, messaggio, classe

		PRINT 'Istruzione eseguita con successo'
	END TRY
	BEGIN CATCH
		-- Gestione dell'errore
		PRINT 'Ho riscontrato l''errore: ' + ERROR_MESSAGE() 
	END CATCH
END;

EXEC UpdateSalaryById @employeeId = 2, @salaryValue = -13560.12;

SELECT * FROM Employees;