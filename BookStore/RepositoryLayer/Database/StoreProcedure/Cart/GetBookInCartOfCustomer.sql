USE BookStore;

--create store procedure to get cart of customer
CREATE PROCEDURE spGetBookInCartOfCustomer
(
	@customer_id INT
)
AS BEGIN

	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.CartDetails WHERE customer_id = @customer_id )
		BEGIN
			SELECT * FROM CartDetails WHERE (customer_id = @customer_id) 
		END
		ELSE
			THROW 51002, 'Not a Valid customer_id', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END;

EXEC spGetBookInCartOfCustomer 2
DROP PROCEDURE spGetBookInCartOfCustomer
SELECT * FROM dbo.CartDetails