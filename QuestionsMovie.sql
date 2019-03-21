-- SELECT Statements

SELECT *
FROM TP2.Questions

SELECT *
FROM TP2.Answers

SELECT q.QString, a.AAnswer, a.Correct
FROM TP2.Answers AS a
	INNER JOIN TP2.Questions AS q ON a.QId = q.QId
WHERE q.QCategory = 'Movie';

-- movie questions
INSERT INTO TP2.Questions (QCategory, QType, QRating, QString) VALUES
	('Movie', 'Multiple', 1, 'Which one of these Academy Awards did Gone With the Wind not win?'),
	('Movie', 'Multiple', 1, 'Clint Eastwood gave us the immortal line, "Go ahead... make my day", in what film?'),
	('Movie', 'Multiple', 1, 'In the Friday the 13th movies, what is the name of the masked killer?'),
	('Movie', 'Multiple', 1, 'What was the name of the island on which King Kong was discovered in the original 1933 movie?'),
	('Movie', 'Multiple', 1, 'Julie Andrews won the Academy Award for best actress in what film?'),

	('Movie', 'Multiple', 2, 'In the movie Who Framed Roger Rabbit, which pair of genetically similar characters perform a piano duet?'),
	('Movie', 'Multiple', 2, 'Which cult film contains the line - "If you wake up at a different time, in a different place, could you wake up as a different person?"'),
	('Movie', 'Multiple', 2, '"You take the red pill, you stay in wonderland, and I show you how deep the rabbit hole goes". Name the film.'),
	('Movie', 'Multiple', 2, '"Who died and made you king of the zombies?" is a line from which horror-comedy film?'),
	('Movie', 'Multiple', 2, '"Strange, isn''t it? Each man''s life touches so many other lives." Can you name the film?'),

	('Movie', 'Fill', 3, 'Fill in the blanks to this well-known film quote - "I''ll get you, my pretty, and your little ___ too"?'),
	('Movie', 'Fill', 3, 'Which movie did this quote come from? “I''m going to make him an offer he can''t refuse.”'),
	('Movie', 'Fill', 3, 'Which movie did this quote come from? “Made it, Ma! Top of the world!”'),
	('Movie', 'Fill', 3, 'Which movie did this quote come from? “Louis, I think this is the beginning of a beautiful friendship.”'),
	('Movie', 'Fill', 3, '“Mama always said life was like a box of chocolates. You never know what you''re gonna get.”'),

	('Movie', 'Bool', 4, 'La la Land was Filmed entirely in Vancouver?'),
	('Movie', 'Bool', 4, 'The Lion featured in MGM''s production logo is the same lion that appeared in the Wizard of Oz?'),
	('Movie', 'Bool', 4, 'Superman made his first movie appearance in the 1940?'),
	('Movie', 'Bool', 4, 'Snow White and the Seven Dwarfs was the first full length animated movie released by Disney?'),
	('Movie', 'Bool', 4, 'Leonardo DiCaprio made the original nude sketch of Kate Winslet in ''Titanic'' (1997).'),

	('Movie', 'Fill', 5, 'Which movie did this quote come from? “Houston, we have a problem.”'),
	('Movie', 'Fill', 5, 'Which movie did this quote come from? “Here''s Johnny!”'),
	('Movie', 'Bool', 5, 'O.J. Simpson almost played the Terminator, but James Cameron thought his persona was "too pleasant" to portray such a dark character'),
	('Movie', 'Bool', 5, 'Nicolas Cage actually turned down the role of Gandalf in the Lord of the Rings series'),
	('Movie', 'Multiple', 5, 'Tom Cruise returned to the big screen in the third instalment of which movie series in 2006?');

-- movie answers
INSERT INTO TP2.Answers (QId, AAnswer, Correct) VALUES
	(26, 'Best Actor', 1),
	(26, 'Best Actress', 0),
	(26, 'Best Picture', 0),
	(26, 'Best Supporting Actor', 0),

	(27, 'Magnum Force', 0),
	(27, 'Dirty Harry', 1),
	(27, 'Tightrope', 0),
	(27, 'Sudden Impact', 0),

	(28, 'Marie Lou', 0),
	(28, 'Freddy', 0),
	(28, 'Jack Black', 0),
	(28, 'Jason', 1),

	(29, 'Skull Island', 1),
	(29, 'Planet of Apes', 0),
	(29, 'Ape Island', 0),
	(29, 'Blue Lagoon', 0),

	(30, 'The Sound of Music', 0),
	(30, 'Victor/Victoria', 0),
	(30, 'Mary Poppins', 1),
	(30, 'Queen Elizabeth', 0),

	(31, 'Donald Duck and Daffy Duck', 0),
	(31, 'Speedy Gonzales and Minnie Mouse', 0),
	(31, 'Bambi and Bullwinkle', 1),
	(31, 'Garfield and Sylvester', 0),

	(32, 'Harold and Maude', 0),
	(32, 'Fight Club', 1),
	(32, 'A Clockwork Orange', 0),
	(32, 'Pulp Fiction', 0),

	(33, 'Lord of the Rings', 0),
	(33, 'Alice in Wonderland', 0),
	(33, 'X Men', 0),
	(33, 'The Matrix', 1),

	(34, 'Night of the Living Dorks', 0),
	(34, 'Shaun of the Dead', 1),
	(34, 'Zombieland', 0),
	(34, 'Frankenstein', 0),

	(35, 'It''s a wonderful life', 1),
	(35, 'Mr. Smith Goes to Washington', 0),
	(35, 'Rooster Cogburn', 0),
	(35, 'I Am Legend', 0),

	(36, 'Dog', 1),
	(37, 'The Godfather', 1),
	(38, 'White Heat', 1),
	(39, 'Casabanca', 1),
	(40, 'Forest Gump', 1),

	(41, 'True', 0),
	(41, 'False', 1),

	(42, 'True', 0),
	(42, 'False', 1),

	(43, 'True', 1),
	(43, 'False', 0),

	(44, 'True', 1),
	(44, 'False', 0),

	(45, 'True', 0),
	(45, 'False', 1),

	(46, 'Apollo 13', 1),
	(47, 'The Shining', 1),

	(48, 'True', 1),
	(48, 'False', 0),

	(49, 'True', 0),
	(49, 'False', 1),

	(50, 'The Expendables', 0),
	(50, 'War of the Worlds', 0),
	(50, 'Tropic Thunder', 0),
	(50, 'Mission Impossible', 1);