USE BookStore;

--create a store procedure to add customer fedback
CREATE PROCEDURE spGetCustomerFeedback
(
	@book_id INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM dbo.FeedbackDetails WHERE (book_id = @book_id))
		BEGIN
			SELECT c.fullname, f.feedback_id, f.customer_id, f.book_id, f.feedback_rating, f.feedback_comment  FROM dbo.CustomerDetails c FULL JOIN dbo.FeedbackDetails f on c.customer_id = f.customer_id WHERE (book_id = @book_id)
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spGetCustomerFeedback 1

SELECT * FROM dbo.FeedbackDetails
