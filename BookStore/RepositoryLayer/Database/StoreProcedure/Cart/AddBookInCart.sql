USE BookStore;

CREATE PROCEDURE spAddBookInCart
(
	@customer_id INT,
	@book_id INT,
	@book_quantity INT
)
AS BEGIN
 INSERT INTO CartDetails 
	(customer_id, book_id, book_quantity ) 
 VALUES 
	(@customer_id, @book_id, @book_quantity)
END;

EXEC spAddBookInCart 1, 1, 3