USE BookStore;

--create a store procedure to add order
CREATE PROCEDURE spCreateOrder
(
	@customer_id INT,
	@book_id INT,
	@address_id INT
)
AS BEGIN
 BEGIN TRY
	DECLARE @BookActualPrice INT;
	DECLARE @BookDiscountPrice INT; 
	DECLARE @BookTotalActualPrice INT;
	DECLARE @BookTotalDiscountPrice INT;
	DECLARE @BookOrderQuantity INT;
	IF EXISTS(SELECT * FROM dbo.BookDetails b,dbo.CartDetails c WHERE (b.book_stock >= c.book_quantity AND b.book_id = @book_id))
	BEGIN
		SET @BookActualPrice = (SELECT book_actual_price FROM dbo.BookDetails WHERE book_id = @book_id)
		SET @BookDiscountPrice = (SELECT book_discount_price FROM dbo.BookDetails WHERE book_id = @book_id)
		SET @BookOrderQuantity = (SELECT c.book_quantity FROM dbo.CartDetails c WHERE c.book_id = @book_id AND c.customer_id = @customer_id)
		SET @BookTotalActualPrice = @BookActualPrice * @BookOrderQuantity;
		SET @BookTotalDiscountPrice = @BookDiscountPrice * @BookOrderQuantity;

		INSERT INTO dbo.OrdersDetails (customer_id, book_id, address_id , order_quantity, order_total_price, order_discount_price) VALUES 
		(@customer_id, @book_id, @address_id, @BookOrderQuantity, @BookTotalActualPrice, @BookTotalDiscountPrice );

		UPDATE dbo.BookDetails  SET book_stock = book_stock - @BookOrderQuantity WHERE (book_id = @book_id);

		DELETE dbo.CartDetails  WHERE (customer_id = @customer_id AND book_id = @book_id)
	END
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ERROR
END CATCH
END

DROP PROC spCreateOrder
EXEC spCreateOrder	1, 1, 1


SELECT * FROM dbo.AddressDetails;
SELECT * FROM dbo.CartDetails;
SELECT * FROM dbo.BookDetails;
SELECT * FROM dbo.OrdersDetails;
DECLARE @BActualPrice INT
SET @BActualPrice = (SELECT book_actual_price FROM dbo.BookDetails WHERE book_id = 1);
PRINT(@BActualPrice)