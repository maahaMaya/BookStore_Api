USE BookStore;

--create a store procedure to add customer fedback
CREATE PROCEDURE spAddCustomerFeedback
(
	@customer_id INT,
	@book_id INT,
	@feedback_rating FLOAT,
	@feedback_comment VARCHAR(max)
)
AS BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT * FROM dbo.FeedbackDetails WHERE (customer_id = @customer_id AND book_id = @book_id))
		BEGIN
			INSERT INTO dbo.FeedbackDetails (customer_id, book_id , feedback_rating,  feedback_comment) VALUES (@customer_id, @book_id, @feedback_rating, @feedback_comment)
		END
		ELSE
			UPDATE dbo.FeedbackDetails SET feedback_rating = @feedback_rating , feedback_comment= @feedback_comment WHERE (customer_id = @customer_id AND book_id = @book_id)
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END

EXEC spAddCustomerFeedback 1, 1, 4.7, 'this is a nice book'

SELECT * FROM dbo.FeedbackDetails