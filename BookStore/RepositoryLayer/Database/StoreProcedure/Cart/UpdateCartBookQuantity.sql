USE BookStore;

---create a store procedure for update cart
CREATE PROCEDURE spUpdateCartBookQuantity
(
	@cart_id INT,
	@book_quantity INT
)
AS BEGIN
	UPDATE dbo.CartDetails SET book_quantity = @book_quantity WHERE (cart_id = @cart_id)
END

EXEC spUpdateCartBookQuantity 1 , 5

SELECT * FROM  dbo.CartDetails