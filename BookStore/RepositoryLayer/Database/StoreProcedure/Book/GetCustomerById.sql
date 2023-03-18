USE BookStore;

-----create store procedure to get customer by Id
CREATE PROCEDURE spGetCustomerById
(
	@customer_id INT
)
AS BEGIN
	SELECT * FROM dbo.CustomerDetails WHERE (customer_id = @customer_id)
END

SELECT * FROM dbo.CustomerDetails
EXEC spGetCustomerById 1