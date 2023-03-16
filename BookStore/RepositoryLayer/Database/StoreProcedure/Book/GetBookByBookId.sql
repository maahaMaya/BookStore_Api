USE BookStore;

--create add new Book store procedure
CREATE PROCEDURE spGetBookByBookId
(
	@book_id INT
)
AS BEGIN 
	SELECT * FROM BookDetails WHERE (book_id = @book_id)
END

EXEC spGetBookByBookId 2