USE BookStore;

--Store Procedure for Login Admin
CREATE PROCEDURE spLoginAdmin
(
	@email_id VARCHAR(50),
	@passwords VARCHAR(50)
)
AS BEGIN
	SELECT TOP 1 PERCENT admin_id, email_id FROM AdminDetails WHERE (email_id = @email_id AND passwords = @passwords)
END

EXEC spLoginAdmin 'adminOne@gmail.com', 'adminOne@12345'