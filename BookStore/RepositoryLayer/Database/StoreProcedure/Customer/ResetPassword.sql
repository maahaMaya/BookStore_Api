USE BookStore;
--create strore procedure fot reset password
CREATE PROCEDURE spResetPassword
(	
	@email_id VARCHAR(50),
	@passwords VARCHAR(50)
)
AS BEGIN
	UPDATE CustomerDetails SET passwords = @passwords WHERE (email_id = @email_id)
END

EXEC spGetALlCustomer;
