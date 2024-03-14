DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Products;

-- DDL
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Quantity INT CHECK (Quantity >= 0)
);

CREATE TABLE OrderDetails (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    Quantity INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- DML
INSERT INTO Products (ProductName, Quantity) VALUES
('Tavolo', 10),
('Sedia', 20),
('Lampada', 30);

SELECT * FROM Products;

DROP PROCEDURE IF EXISTS CreateOrder;
CREATE PROCEDURE CreateOrder
	@idProductValue INT,
	@quantityValue INT
AS
BEGIN
	BEGIN TRY

		BEGIN TRANSACTION
			IF @quantityValue <= 0
				THROW 50001, 'Quantità non concessa', 1

			UPDATE Products 
			SET Quantity = Quantity - @quantityValue 
			WHERE ProductID = @idProductValue

			IF @@ROWCOUNT = 0
				THROW 50002, 'Oggetto non trovato o errore generico', 1

			INSERT INTO OrderDetails (ProductID, Quantity) VALUES
			(@idProductValue, @quantityValue);

			PRINT 'STAPPOOOOOOOOO'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()

	END CATCH
END;

EXEC CreateOrder @idProductValue = 2, @quantityValue = 4;			-- OK
EXEC CreateOrder @idProductValue = 2, @quantityValue = 40;


SELECT * FROM Products;
SELECT * FROM OrderDetails;