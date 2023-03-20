USE BookStore;

--create store procedure to add and update address
CREATE PROCEDURE spAddUpdateCustomerAddress
(
	@customer_id INT,
	@address_type_id INT,
	@customer_address VARCHAR(MAX),
	@customer_city	VARCHAR(100),
	@customer_state VARCHAR(100)
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.AddressDetails WHERE(customer_id= @customer_id AND address_type_id = @address_type_id))
		BEGIN
			UPDATE dbo.AddressDetails SET customer_address = @customer_address, customer_city = @customer_city , customer_state = @customer_state  
			WHERE(customer_id= @customer_id AND address_type_id = @address_type_id)
		END
		ELSE
		BEGIN
			INSERT INTO dbo.AddressDetails (customer_id , address_type_id , customer_address , customer_city , customer_state ) 
			VALUES (@customer_id, @address_type_id, @customer_address, @customer_city, @customer_state )
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spAddUpdateCustomerAddress 1, 1 , 'Jamshedpur', 'jsrs' , 'jharkhand'

SELECT * FROM dbo.AddressDetails;
SELECT * FROM dbo.AddressType;