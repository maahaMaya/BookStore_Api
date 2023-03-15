USE BookStore;
--create table for the Feedback

CREATE TABLE FeedbackDetails
(	
	feedback_id INT PRIMARY KEY IDENTITY NOT NULL,
	customer_id INT FOREIGN KEY (customer_id) REFERENCES CustomerDetails(customer_id),
	book_id INT FOREIGN KEY  (book_id) REFERENCES BookDetails(book_id),
	feedback_rating FLOAT,
	feedback_comment VARCHAR(max)
);

SELECT * FROM FeedbackDetails;