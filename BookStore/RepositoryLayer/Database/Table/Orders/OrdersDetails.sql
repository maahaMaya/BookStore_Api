USE BookStore;
--create table for the Order

CREATE TABLE OrdersDetails
(	order_id INT PRIMARY KEY IDENTITY NOT NULL,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES CustomerDetails(customer_id),
	book_id INT FOREIGN KEY (book_id) REFERENCES BookDetails(book_id),
	address_id INT FOREIGN KEY (address_id) REFERENCES AddressDetails(address_id),
	order_quantity INT ,
	order_total_price INT,
	order_discount_price INT,
	order_placed_time DATETIME DEFAULT CURRENT_TIMESTAMP
);

SELECT * FROM OrdersDetails;