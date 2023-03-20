USE BookStore;

--create store procedure to add and update address
CREATE PROCEDURE spDeleteCustomerAddress
(
	@address_id INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.AddressDetails WHERE(address_id= @address_id))
		BEGIN
			DELETE dbo.AddressDetails WHERE(address_id= @address_id)
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spDeleteCustomerAddress 2

SELECT * FROM dbo.AddressDetails;
SELECT * FROM dbo.AddressType;