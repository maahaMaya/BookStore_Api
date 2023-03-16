USE BookStore;

--create update Book store procedure
CREATE PROCEDURE spDeletBook
(
	@book_id INT
)
AS BEGIN 
	DELETE FROM BookDetails WHERE (book_id = @book_id)
END 

EXEC spDeletBook  2 
SELECT * FROM BookDetails;

