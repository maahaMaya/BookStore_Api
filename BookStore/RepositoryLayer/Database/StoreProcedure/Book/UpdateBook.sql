USE BookStore;

--create update Book store procedure
CREATE PROCEDURE spUpdateBook
(
	@book_id INT,
	@book_title VARCHAR(100),
	@book_author VARCHAR(100),
	@book_rating FLOAT,
	@book_total_rating INT,
	@book_actual_price INT,
	@book_discount_price INT,
	@book_description VARCHAR(MAX),
	@book_stock INT,
	@book_image VARCHAR(MAX) 
)
AS BEGIN 
	UPDATE BookDetails SET 
	book_title = @book_title, 
	book_author = @book_rating,
	book_rating = @book_rating,
	book_total_rating = @book_total_rating, 
	book_actual_price = @book_actual_price, 
	book_discount_price = @book_discount_price, 
	book_description = @book_description,
	book_stock = @book_stock, 
	book_image = @book_image
	WHERE (book_id = @book_id)
END 

EXEC spUpdateBook  2 , 'india' , 'bharat' , 4.91 , 1, 100, 50, 'Hello this is the about india history', 25 , 'imagssssssssse'

SELECT * FROM BookDetails;

DROP PROCEDURE spUpdateBook;