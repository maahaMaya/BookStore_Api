USE BookStore;
--Get all the Customer Details
CREATE PROCEDURE spGetAllCustomer              
AS BEGIN   
	SELECT * FROM CustomerDetails
END 

EXEC spGetALlCustomer;

DROP PROCEDURE spGetAllCustomer