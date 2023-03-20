USE BookStore;

--Create a store procedure for add book in wishlist
CREATE PROCEDURE spAddBookInWishlist
(
	@customer_id INT,
	@book_id INT
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT * FROM dbo.WishDetails WHERE (customer_id = @customer_id AND book_id = @book_id))
		BEGIN
			INSERT INTO dbo.WishDetails VALUES (@customer_id, @book_id)
		END
		ELSE
			THROW 51002, 'Exist customer_id book_id ', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spAddBookInWishlist 1 , 5

SELECT * FROM dbo.WishDetails;