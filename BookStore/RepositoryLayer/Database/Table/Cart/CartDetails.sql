USE BookStore;
--Create Table for the Cart  

CREATE TABLE CartDetails
(	cart_id INT PRIMARY KEY IDENTITY NOT NULL,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES CustomerDetails(customer_id),
	book_id INT FOREIGN KEY  (book_id) REFERENCES BookDetails(book_id),
	book_quantity INT DEFAULT 1
)

SELECT * FROM CartDetails;