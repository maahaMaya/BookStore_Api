USE BookStore;

--create add new Book store procedure
CREATE PROCEDURE spUpdateBookImage
(
	@book_id INT,
	@book_image VARCHAR(MAX) 
)
AS BEGIN 
	UPDATE BookDetails SET book_image = @book_image WHERE (book_id = @book_id)
END

EXEC spUpdateBookImage 1, 'imageUrls'
EXEC spGetAllBook