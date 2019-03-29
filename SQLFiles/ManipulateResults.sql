SELECT * FROM TP2.TUsers
SELECT * FROM TP2.UserQuizzes
SELECT * FROM TP2.Quiz
SELECT * FROM TP2.QuizQuestions
SELECT * FROM TP2.Questions
SELECT * FROM TP2.Answers
SELECT * FROM TP2.Reviews
SELECT * FROM TP2.Results

-- INSERT INTO TP2.Reviews(QId, QuizId, UserId, RRatings) VALUES
	--(null, 2, 5, 9)

INSERT INTO TP2.Results(UserQuizId, QId, UserAnswer, Correct) VALUES
  (1, 51, 'A version control tool', 1),
  (1, 52, 'True', 1),
  (1, 53, 'The class selector in CSS uses a', 1),
  (1, 54, 'Communicates only to the view', 0),
  (1, 56, 'git checkout -nb <newBranch>', 0),
  (1, 57, 'an open source platform that performs static analysis of code to determine code quality.', 1),
  (1, 58, 'True', 0),
  (1, 59, 'iterative', 1),
  (1, 60, 'agile', 0),
  (1, 61, 'A partial view.', 0);

-- 2nd test
INSERT INTO TP2.Results(UserQuizId, QId, UserAnswer, Correct) VALUES
  (2, 51, 'A version control tool', 1),
  (2, 52, 'True', 1),
  (2, 53, 'The class selector in CSS uses a', 1),
  (2, 54, 'Communicates only to the view', 0),
  (2, 56, 'git checkout -b <newBranch> ', 1),
  (2, 57, 'an open source platform that performs static analysis of code to determine code quality.', 1),
  (2, 58, 'true', 1),
  (2, 59, 'iterative', 1),
  (2, 60, 'kanban', 1),
  (2, 61, 'A partial view.', 0);
