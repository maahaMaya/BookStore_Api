USE BookStore;

--Create Table for the Address Type
CREATE TABLE AddressType 
( 
	address_type_id INT PRIMARY KEY IDENTITY NOT NULL, 
	address_type VARCHAR(50)
)
INSERT INTO AddressType VALUES ('WORK'),('Home');
SELECT * FROM AddressType;

--Create Table for the Address
CREATE TABLE AddressDetails
(	address_id INT PRIMARY KEY IDENTITY NOT NULL,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES CustomerDetails(customer_id),
	address_type_id INT FOREIGN KEY (address_type_id) REFERENCES AddressType(address_type_id),
	customer_address VARCHAR(MAX),
	customer_city VARCHAR(100),
	customer_state VARCHAR(100)
);

SELECT * FROM AddressDetails;