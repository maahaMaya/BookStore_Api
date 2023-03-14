USE BookStore;
--Get all the Customer Details
CREATE PROCEDURE spGetAllCustomer              
AS BEGIN   
	SELECT * FROM UserDetails
END 

EXEC spGetALlCustomer;