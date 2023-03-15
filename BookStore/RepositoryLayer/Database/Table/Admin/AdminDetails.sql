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

INSERT INTO AdminDetails (fullname, email_id, passwords, phone_number) VALUES ('Admin One', 'adminOne@gmail.com', 'adminOne@12345', 1234567890), ('Admin Two', 'adminTwo@gmail.com', 'adminTwo@12345', 0987654321);

SELECT * FROM AdminDetails;