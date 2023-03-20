USE BookStore;

--Create a store procedure for get book in Customer wishlist
CREATE PROCEDURE spGetBookInCustomerWishlist
(
	@customer_id INT

)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.WishDetails WHERE (customer_id = @customer_id))
		BEGIN
			--SELECT w.wishlist_id, w.book_id, w.customer_id, b.book_title
			SELECT * FROM dbo.WishDetails w FULL JOIN dbo.BookDetails b ON w.book_id = b.book_id
			WHERE (w.customer_id = @customer_id)
		END
		ELSE
			THROW 51002, 'Not Exist @wishlist_id ', 1
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spGetBookInCustomerWishlist 1


DROP PROCEDURE spGetBookInCustomerWishlist
SELECT * FROM dbo.WishDetails;

IF EXISTS(SELECT * FROM dbo.WishDetails, dbo.BookDetails WHERE (dbo.WishDetails.customer_id = 1 AND dbo.BookDetails.book_id = 5))
BEGIN
	PRINT('HELlo')
END