SELECT * FROM TP2.Quiz
SELECT * FROM TP2.TUsers
SELECT * FROM TP2.Reviews

SELECT *
FROM TP2.Questions AS q
WHERE q.QCategory = 'QC'

--INSERT INTO TP2.Questions (QCategory, QType, QRating, QString) VALUES
--	('Movie', 'Multiple', 1, 'Who is Disney''s mascot?');

-- inserting a couple reviews for the quizzes
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 2, 5, 9)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 2, 6, 6)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 2, 3, 2)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 2, 8, 3)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 3, 5, 8)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 3, 6, 7)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 3, 3, 5)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 3, 8, 7)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 4, 5, 4)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 4, 6, 6)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 4, 3, 1)
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(null, 4, 8, 8)

-- question reviews
INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	(51, null, 5, 8),