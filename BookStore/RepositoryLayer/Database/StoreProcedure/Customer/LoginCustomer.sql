USE BookStore;

CREATE PROCEDURE spLoginCustomer    
(                 
    @email_id VARCHAR(50),        
    @passwords VARCHAR(50)
)        
AS BEGIN
	SELECT TOP 1  percent customer_id, email_id FROM UserDetails WHERE (email_id = @email_id AND passwords = @passwords)       
END 

EXEC spLoginCustomer 'string' , 'string'

Drop Procedure dbo.spLoginCustomer