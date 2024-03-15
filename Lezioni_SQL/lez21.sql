USE acc_lez15_sp_creazione

SELECT DISTINCT department FROM Employees;

SELECT TOP (1) * 
	FROM Employees 
	WHERE StartDate IS NOT NULL 
	ORDER BY StartDate;

SELECT * 
	FROM Employees 
	WHERE StartDate IS NOT NULL 
	ORDER BY EmployeeID
	OFFSET 1 ROWS
	FETCH NEXT 3 ROWS ONLY;