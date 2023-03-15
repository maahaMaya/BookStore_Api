USE BookStore;

--Add the Customer Details
CREATE PROCEDURE spRegisterNewCustomer
(        
    @fullname VARCHAR(50),         
    @email_id VARCHAR(50),        
    @passwords VARCHAR(50),
    @phone_number INT
) 
AS BEGIN  
	INSERT INTO CustomerDetails (fullname, email_id, passwords, phone_number) 
	VALUES (@fullname ,@email_id ,@passwords, @phone_number) 
END 

EXEC spRegisterNewCustomer 'Hari Om', 'Hari@gmail.com', 'Hari@12345', 0987654321
