USE BookStore;

--Create a store procedure for delete book in Customer wishlist
CREATE PROCEDURE spDeleteBookInCustomerWishlist
(
	@wishlist_id INT

)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.WishDetails WHERE (wishlist_id = @wishlist_id))
		BEGIN
			DELETE dbo.WishDetails WHERE  (wishlist_id = @wishlist_id)
		END
		ELSE
			THROW 51002, 'Not Exist @wishlist_id ', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spDeleteBookInCustomerWishlist 5

SELECT * FROM dbo.WishDetails;