USE BookStore;

--CREATE TABLE CustomerDetails
CREATE TABLE CustomerDetails
(
	customer_id INT PRIMARY KEY IDENTITY NOT NULL, 
	fullname VARCHAR(50) NOT NULL, 
	email_id VARCHAR(50) NOT NULL, 
	passwords VARCHAR(50) NOT NULL,
	phone_number INT NOT NULL,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
	updated_at DATETIME
)

ALTER TABLE CustomerDetails ALTER COLUMN phone_number BIGINT;

--INSERT INTO UserDetails(fullname, email_id, passwords, phone_number) VALUES ('sourav kumar', 'sourav@gmail.com', 'Sourav@12345sa', 1234567890)
--UPDATE UserDetails SET passwords = 'Sourav@12345', updated_at = GETDATE() WHERE email_id = 'sourav@gmail.com'
--SELECT * FROM UserDetails;
--DROP TABLE UserDetails;