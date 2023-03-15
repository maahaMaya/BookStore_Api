USE BookStore;

--Create Table for the Address Type
CREATE TABLE AdminDetails
(
	admin_id INT PRIMARY KEY IDENTITY NOT NULL, 
	fullname VARCHAR(50) NOT NULL, 
	email_id VARCHAR(50) NOT NULL, 
	passwords VARCHAR(50) NOT NULL,
	phone_number INT NOT NULL,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP
)