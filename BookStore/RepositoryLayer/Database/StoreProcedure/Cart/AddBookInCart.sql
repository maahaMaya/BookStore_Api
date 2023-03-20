USE BookStore;

--create store procedure to add new cart
CREATE PROCEDURE spAddBookInCart
(
	@customer_id INT,
	@book_id INT,
	@book_quantity INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.CartDetails WHERE customer_id = @customer_id AND book_id= @book_id)
		BEGIN
			DECLARE @BookQuant INT
			SELECT @BookQuant = book_quantity FROM dbo.CartDetails WHERE customer_id = @customer_id AND book_id= @book_id
			SET @BookQuant = @BookQuant +  @book_quantity;
			UPDATE CartDetails SET book_quantity = @BookQuant WHERE (customer_id = @customer_id AND book_id= @book_id)
		END
		ELSE IF EXISTS(SELECT * FROM CustomerDetails, BookDetails WHERE customer_id = @customer_id AND book_id = @book_id)
		BEGIN
			INSERT INTO dbo.CartDetails (customer_id, book_id, book_quantity ) VALUES (@customer_id, @book_id, @book_quantity)
		END
		ELSE
			THROW 51002, 'Not a Valid Department', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END;

	


EXEC spAddBookInCart 1, 4 ,1

DROP PROCEDURE spAddBookInCart



