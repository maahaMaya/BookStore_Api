USE BookStore;

--get all book
CREATE PROCEDURE spGetAllBook
AS BEGIN 
	SELECT * FROM BookDetails
END

EXEC spGetAllBook