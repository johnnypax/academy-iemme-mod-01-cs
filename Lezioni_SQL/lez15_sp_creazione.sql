-- DDL

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    JobTitle NVARCHAR(50),
    Department NVARCHAR(50),
    StartDate DATE				-- 'YYYY-MM-DD'
);

-- DML
INSERT INTO Employees (FirstName, LastName, Email, JobTitle, Department, StartDate) VALUES 
('James', 'Smith', 'james.smith@example.com', 'Software Engineer', 'Engineering', '2019-03-01'),
('Maria', 'Garcia', 'maria.garcia@example.com', 'Project Manager', 'Marketing', '2018-06-15'),
('Robert', 'Johnson', 'robert.johnson@example.com', 'Database Administrator', 'IT', '2017-05-29'),
('Patricia', 'Miller', 'patricia.miller@example.com', 'Product Manager', 'Sales', '2020-02-17'),
('Michael', 'Davis', 'michael.davis@example.com', 'Web Developer', 'Engineering', '2021-08-23'),
('Linda', 'Martinez', 'linda.martinez@example.com', 'Graphic Designer', 'Design', '2016-04-11'),
('Elizabeth', 'Hernandez', 'elizabeth.hernandez@example.com', 'Sales Associate', 'Sales', '2019-07-19'),
('William', 'Brown', 'william.brown@example.com', 'Systems Analyst', 'IT', '2018-09-03'),
('Jennifer', 'Wilson', 'jennifer.wilson@example.com', 'Consultant', 'Customer Service', '2017-12-08'),
('David', 'Anderson', 'david.anderson@example.com', 'Quality Assurance', 'Engineering', '2020-05-01'),
('Susan', 'Thomas', 'susan.thomas@example.com', 'HR Specialist', 'Human Resources', '2018-03-23'),
('Joseph', 'Moore', 'joseph.moore@example.com', 'Finance Analyst', 'Finance', '2019-11-30'),
('Margaret', 'Taylor', 'margaret.taylor@example.com', 'Content Writer', 'Marketing', '2021-01-15'),
('Charles', 'Lee', 'charles.lee@example.com', 'UX Designer', 'Design', '2017-07-09'),
('Christopher', 'Harris', 'christopher.harris@example.com', 'Network Engineer', 'IT', '2018-08-21'),
('Jessica', 'Clark', 'jessica.clark@example.com', 'Social Media Manager', 'Marketing', '2020-06-05'),
('Daniel', 'Lewis', 'daniel.lewis@example.com', 'Business Analyst', 'Business Development', '2019-04-12'),
('Sarah', 'Walker', 'sarah.walker@example.com', 'Recruiter', 'Human Resources', '2021-09-20'),
('Thomas', 'Robinson', 'thomas.robinson@example.com', 'Technical Support', 'Customer Service', '2017-11-13'),
('Nancy', 'Rodriguez', 'nancy.rodriguez@example.com', 'Legal Advisor', 'Legal', '2018-01-29');

-- QL
SELECT * FROM Employees;

-- SP Creazione
CREATE PROCEDURE GetAllEmployees AS
BEGIN
	-- CORPO
	SELECT * FROM Employees;
END;

-- Esecuzione della SP
EXEC GetAllEmployees;

-- Eliminazione della SP
DROP PROCEDURE GetAllEmployees;

-- Istruzioni della SP
EXEC sp_helptext 'GetAllEmployees';

-- Modifica di una procedura esistente
ALTER PROCEDURE GetAllEmployees AS
BEGIN
	SELECT * FROM Employees WHERE Department = 'Legal'
END;

-- -----------------------
-- Voglio una procedure che prenda il parametro dipartimento in modo dinamico3
-- GetEmployeeByDepartment(nomeDipartimento string){ }

CREATE PROCEDURE GetEmployeeByDepartment
	@DepartmentName NVARCHAR(50)
AS
BEGIN
	SELECT * FROM Employees WHERE Department = @DepartmentName
END;

EXEC GetEmployeeByDepartment @DepartmentName = 'Engineering';

-- --------------------------------------------- IF
-- Se definito il parametro dipartimento, restituisci tutti gli impiegati afferenti, altrimenti tutti

CREATE PROCEDURE GetEmployeesByDepartmentOrAll
	@DepartmentValue NVARCHAR(50) = NULL
AS
BEGIN
	IF @DepartmentValue IS NULL 
		BEGIN
			SELECT * FROM Employees
		END
	ELSE
		BEGIN
			SELECT * FROM Employees WHERE Department = @DepartmentValue
		END
END;

EXEC GetEmployeesByDepartmentOrAll;
EXEC GetEmployeesByDepartmentOrAll @DepartmentValue = 'Engineering';

-- --------------------------------------------- IF 

-- Creare una SP che mi permetta di inserire un Employee, se non viene specificato il Department inserire "Stagista"
-- inoltre inserire la data (StartDate) a quella attuale

DROP PROCEDURE IF EXISTS InsertEmployeeFiltered;
CREATE PROCEDURE InsertEmployeeFiltered
	@firstNameValue NVARCHAR(50),
    @lastNameValue NVARCHAR(50),
    @emailValue NVARCHAR(100),
    @jobTitleValue NVARCHAR(50),
    @departmentValue NVARCHAR(50) = NULL,
    @startDateValue DATE = NULL
AS
BEGIN
	IF @departmentValue IS NULL AND @startDateValue IS NULL
		BEGIN
			INSERT INTO Employees(FirstName, LastName, Email, JobTitle, Department, StartDate) VALUES
			(@firstNameValue, @lastNameValue, @emailValue, @jobTitleValue, 'Stagista', CURRENT_TIMESTAMP)
		END
	ELSE
		BEGIN
			INSERT INTO Employees(FirstName, LastName, Email, JobTitle, Department, StartDate) VALUES
			(@firstNameValue, @lastNameValue, @emailValue, @jobTitleValue, @departmentValue, @startDateValue)
		END
END;

-- ------------------------------------------------ REFACTORING

CREATE PROCEDURE InsertEmployeeFilteredRefactored
	@firstNameValue NVARCHAR(50),
    @lastNameValue NVARCHAR(50),
    @emailValue NVARCHAR(100),
    @jobTitleValue NVARCHAR(50),
    @departmentValue NVARCHAR(50) = NULL,
    @startDateValue DATE = NULL
AS
BEGIN
	IF @departmentValue IS NULL AND @startDateValue IS NULL
		BEGIN
			SET @departmentValue = 'Stagista'
			SET @startDateValue = CURRENT_TIMESTAMP
		END
		
	INSERT INTO Employees(FirstName, LastName, Email, JobTitle, Department, StartDate) VALUES
	(@firstNameValue, @lastNameValue, @emailValue, @jobTitleValue, @departmentValue, @startDateValue)
END;

EXEC InsertEmployeeFilteredRefactored 
	@firstNameValue = 'Giovanni', 
	@lastNameValue = 'Pace',
	@jobTitleValue = 'Engineer',
	@emailValue = 'gio@pace.com';

EXEC GetEmployeesByDepartmentOrAll;