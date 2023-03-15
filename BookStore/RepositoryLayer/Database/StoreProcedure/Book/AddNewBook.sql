USE BookStore;

--create add new Book store procedure
CREATE PROCEDURE spAddNewBook
(
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
	INSERT INTO BookDetails 
	(book_title, book_author, book_rating, book_total_rating, book_actual_price, book_discount_price, book_description, book_stock, book_image)
	VALUES 
	(@book_title, @book_author, @book_rating, @book_total_rating, @book_actual_price, @book_discount_price, @book_description, @book_stock, @book_image)
END 

EXEC spAddNewBook 'india' , 'bharat' , 4.9 , 1, 100, 50, 'Hello this is the about india history', 25 , 'image'

SELECT * FROM BookDetails;