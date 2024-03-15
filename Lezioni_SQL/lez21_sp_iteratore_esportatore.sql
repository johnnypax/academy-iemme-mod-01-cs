---- DDL
--CREATE TABLE Employees (
--    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
--    FirstName NVARCHAR(50),
--    LastName NVARCHAR(50),
--    Salary DECIMAL(10, 2)
--);

---- DML
--INSERT INTO Employees(FirstName, LastName, Salary) VALUES
--('Giovanni', 'Pace', 100000),
--('Valeria', 'Verdi', 120000),
--('Mario', 'Rossi', 90000);

--SELECT * FROM Employees;

---- SP che analizza ogni riga e può manipolarla

--DECLARE EmployeeCursor CURSOR FOR
--SELECT FirstName + ' ' + LastName, Salary FROM Employees

---- Apri il cursore
--OPEN EmployeeCursor

--DECLARE @nominativo VARCHAR(250);
--DECLARE @salario DECIMAL(10,2);

---- Recupero della prima riga
--FETCH NEXT FROM EmployeeCursor INTO @nominativo, @salario;

--WHILE @@FETCH_STATUS = 0
--BEGIN
--	PRINT @nominativo + ' ' + CAST(@salario AS VARCHAR); 

--	FETCH NEXT FROM EmployeeCursor INTO @nominativo, @salario;
--END

--CLOSE EmployeeCursor

--------------------------------------------------------------------------------------

-- DDL
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Salary DECIMAL(10, 2)
);

CREATE TABLE Dipendenti(
	dipendenteID INT PRIMARY KEY IDENTITY(1,1),
	nominativo NVARCHAR(250),
	salario DECIMAL(10, 2),
	dipartimento VARCHAR(250) DEFAULT 'Non assegnato'
);

-- DML
INSERT INTO Employees(FirstName, LastName, Salary) VALUES
('Giovanni', 'Pace', 100000),
('Valeria', 'Verdi', 120000),
('Mario', 'Rossi', 90000);

SELECT * FROM Employees;

-- SP che analizza ogni riga e può manipolarla
CREATE PROCEDURE ExportToOtherTable AS
BEGIN
	DECLARE EmployeeCursor CURSOR FOR
	SELECT FirstName + ' ' + LastName, Salary FROM Employees

	-- Apri il cursore
	OPEN EmployeeCursor

	DECLARE @nominativo VARCHAR(250);
	DECLARE @salario DECIMAL(10,2);

	-- Recupero della prima riga
	FETCH NEXT FROM EmployeeCursor INTO @nominativo, @salario;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		BEGIN TRY
			INSERT INTO Dipendenti(nominativo, salario) VALUES
			(@nominativo, @salario);

			PRINT 'Inserito valore: ' + @nominativo + ' ' + CAST(@salario AS VARCHAR); 
		END TRY
		BEGIN CATCH
			PRINT 'Non sono riuscito ad inserire' + @nominativo
		END CATCH

		FETCH NEXT FROM EmployeeCursor INTO @nominativo, @salario;
	END

	CLOSE EmployeeCursor
END

EXEC ExportToOtherTable;
SELECT * FROM Dipendenti;