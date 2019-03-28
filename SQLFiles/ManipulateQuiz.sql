INSERT INTO TP2.UserQuizzes (UserId, QuizId, QuizMaxScore, QuizActualScore, QuizDate) VALUES
	(5, 1, 10, 6, GETDATE());

INSERT INTO TP2.UserQuizzes (UserId, QuizId, QuizMaxScore, QuizActualScore, QuizDate) VALUES
	(5, 2, 10, 8, GETDATE());

SELECT * FROM TP2.Quiz
SELECT * FROM TP2.QuizQuestions
SELECT * FROM TP2.UserQuizzes

SELECT *
FROM TP2.Questions AS q
WHERE q.QCategory = 'QC'

-- insert new quizzes. Don't forget to include questions to those quizzes
-- sample medium quiz
INSERT INTO TP2.Quiz(QuizMaxScore, QuizDifficulty, QuizCategory) VALUES
	(10, 2, 'QC');

-- sample medium quiz
INSERT INTO TP2.QuizQuestions(QuizId, QId) VALUES
	(3, 58),
	(3, 59),
	(3, 60),
	(3, 61),
	(3, 62),
	(3, 63),
	(3, 65),
	(3, 67),
	(3, 68),
	(3, 69);

-- sample easy quiz
INSERT INTO TP2.Quiz(QuizMaxScore, QuizDifficulty, QuizCategory) VALUES
	(10, 1, 'QC');

-- sample easy quiz
INSERT INTO TP2.QuizQuestions(QuizId, QId) VALUES
	(2, 51),
	(2, 52),
	(2, 53),
	(2, 55),
	(2, 58),
	(2, 59),
	(2, 60),
	(2, 61),
	(2, 62),
	(2, 63);

-- sample hard quiz
INSERT INTO TP2.Quiz(QuizMaxScore, QuizDifficulty, QuizCategory) VALUES
	(10, 3, 'QC');

-- sample medium quiz
INSERT INTO TP2.QuizQuestions(QuizId, QId) VALUES
	(4, 62),
	(4, 63),
	(4, 64),
	(4, 66),
	(4, 67),
	(4, 68),
	(4, 69),
	(4, 72),
	(4, 73),
	(4, 74);

--INSERT INTO TP2.Questions (QCategory, QType, QRating, QString) VALUES
--	('Movie', 'Multiple', 1, 'Who is Disney''s mascot?'),
