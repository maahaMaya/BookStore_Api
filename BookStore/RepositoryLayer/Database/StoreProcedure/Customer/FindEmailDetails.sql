USE BookStore;

CREATE PROCEDURE spFindEmailDetails
(
	@email_id VARCHAR(50)
)
AS BEGIN
	SELECT TOP 1 PERCENT customer_id, email_id FROM CustomerDetails WHERE (email_id = @email_id) 
END

EXEC spFindEmailDetails 'Hari@gmail.com'