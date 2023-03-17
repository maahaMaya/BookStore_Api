USE BookStore;

--create store procedure to add new cart
CREATE PROCEDURE spGetBookInCartOfCustomer
(
	@customer_id INT
)
AS BEGIN
SELECT * FROM CartDetails WHERE (customer_id = @customer_id) 
END;

EXEC spGetBookInCartOfCustomer 1

SELECT * FROM dbo.CartDetails