USE BookStore;

--create store procedure for delete Cart by id
CREATE PROCEDURE spDeleteCartById
(
	@cart_id INT
)
AS BEGIN
	DELETE dbo.CartDetails WHERE (cart_id = @cart_id)
END

EXEC spDeleteCartById 7

SELECT * FROM dbo.CartDetails