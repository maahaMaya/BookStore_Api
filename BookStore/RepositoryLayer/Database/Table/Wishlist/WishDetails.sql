USE BookStore;
--Create table for the Wishlist

CREATE TABLE WishDetails
(	wishlist_id INT PRIMARY KEY IDENTITY NOT NULL,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES CustomerDetails(customer_id),
	book_id INT FOREIGN KEY  (book_id) REFERENCES BookDetails(book_id),
)

SELECT * FROM WishDetails;