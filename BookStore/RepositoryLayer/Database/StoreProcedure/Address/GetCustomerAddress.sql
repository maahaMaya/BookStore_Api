USE BookStore;

--create store procedure to add and update address
CREATE PROCEDURE spGetCustomerAddress
(
	@customer_id INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.AddressDetails WHERE(customer_id= @customer_id))
		BEGIN
			SELECT c.fullname, c.phone_number, a.address_id, a.address_type_id, a.customer_id, a.customer_address, a.customer_city, a.customer_state  FROM dbo.AddressDetails a FULL JOIN dbo.CustomerDetails c ON a.customer_id = c.customer_id 
			WHERE(a.customer_id = @customer_id )
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spGetCustomerAddress 1

SELECT * FROM dbo.AddressDetails