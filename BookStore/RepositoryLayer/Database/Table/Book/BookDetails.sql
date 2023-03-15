USE BookStore;

CREATE TABLE BookDetails
(
	book_id INT PRIMARY KEY IDENTITY NOT NULL,
	book_title VARCHAR(100) NOT NULL,
	book_author VARCHAR(100) NOT NULL,
	book_rating FLOAT,
	book_total_rating INT,
	book_actual_price INT NOT NULL,
	book_discount_price INT NOT NULL,
	book_description VARCHAR(MAX) NOT NULL,
	book_stock INT NOT NULL,
	book_image VARCHAR(MAX) NOT NULL
)