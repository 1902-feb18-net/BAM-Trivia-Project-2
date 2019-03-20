-- SELECT Statements

SELECT *
FROM TP2.Questions

SELECT *
FROM TP2.Answers

SELECT q.QString, a.AAnswer, a.Correct
FROM TP2.Answers AS a
	INNER JOIN TP2.Questions AS q ON a.QId = q.QId
WHERE q.QCategory = 'Beer';

-- INSERT Statements

INSERT INTO TP2.Questions (QCategory, QType, QRating, QString) VALUES
	('Beer', 'Bool', 1, 'Dark beers have more alcohol than light beers.'),
	('Beer', 'Bool', 1, 'The oldest known recipe is for beer.'),
	('Beer', 'Bool', 1, 'Root beer has real beer in it.'),
	('Beer', 'Bool', 1, 'Michelob Ultra is a dark beer.'),
	('Beer', 'Bool', 1, 'Everyone drank beer in the Middle Ages in England.'),
	('Beer', 'Multiple', 2, 'What is the largest brewery in the US?'),
	('Beer', 'Multiple', 2, 'What is the most common brewing ingredient used as a starch source?'),
	('Beer', 'Fill', 2, 'What year was St. James''s Gate Brewery founded?'),
	('Beer', 'Fill', 2, 'What year was Anheuser-Busch founded?'),
	('Beer', 'Multiple', 2, 'Which country was the first to brew beer?'),
	('Beer', 'Fill', 3, 'What is the ingredient in beer primarly attributed for bitterness?'),
	('Beer', 'Fill', 3, 'Are IPAs top or bottom fermented?'),
	('Beer', 'Multiple', 3, 'What kind of beer is Guinness?'),
	('Beer', 'Fill', 3, 'What causes the fermentation process in beer?'),
	('Beer', 'Bool', 3, 'Can a person survive on a diet composed entirely of beer?'),
	('Beer', 'Fill', 4, 'What kind of beer is bottom fermented?'),
	('Beer', 'Fill', 4, 'In what country did Lagers initially evolve?'),
	('Beer', 'Multiple', 4, 'Which beer from this list has the highest alcohol content by volume?'),
	('Beer', 'Multiple', 4, 'Which beer on this list has the most IBUs (hoppiest)?'),
	('Beer', 'Multiple', 4, 'Which country drinks the most beer per capita?'),
	('Beer', 'Multiple', 5, 'Which country produces the most hops in the world?'),
	('Beer', 'Fill', 5, 'What generally gives beer its sweet taste?'),
	('Beer', 'Fill', 5, 'What is the main ingredient of root beer?'),
	('Beer', 'Multiple', 5, 'What is the science of brewing beer called?'),
	('Beer', 'Fill', 5, 'What is another word for honey beer?');
	
INSERT INTO TP2.Answers (QId, AAnswer, Correct) VALUES
	(1, 'True', 1),
	(1, 'False', 0),
	(2, 'True', 1),
	(2, 'False', 0),
	(3, 'True', 0),
	(3, 'False', 1),
	(4, 'True', 0),
	(4, 'False', 1),
	(5, 'True', 1),
	(5, 'False', 0),
	(6, 'Anheuser-Busch', 1),
	(6, 'Boston Beer', 0),
	(6, 'MillerCoors', 0),
	(6, 'Pabst Brewing', 0),
	(7, 'Barley', 1),
	(7, 'Hops', 0),
	(7, 'Sorghum', 0),
	(7, 'Wheat', 0),
	(8, '1759', 1),
	(9, '1852', 1),
	(10, 'Sumeria', 1),
	(10, 'Mesopotamia', 0),
	(10, 'Egypt', 0),
	(10, 'Persia', 0),
	(11, 'Hops', 1),
	(12, 'Top fermented', 1),
	(13, 'Stout', 1),
	(13, 'Ale', 0),
	(13, 'Lager', 0),
	(13, 'Porter', 0),
	(14, 'Yeast', 1),
	(15, 'True', 1),
	(15, 'False', 0),
	(16, 'Lager', 1),
	(17, 'Bavaria', 1),
	(18, 'Brewmeister Snake Venom', 1),
	(18, 'Schorschbrau Schorschbock', 0),
	(18, 'BrewDog Sing The Bismarck', 0),
	(18, 'Struise Black Damnation VI', 0),
	(19, 'Arbor FF #13 - 2012 Double Black IPA', 1),
	(19, 'Mikkeler X Hop Juice 2007', 0),
	(19, 'Zaftig Shadowed Mistress ESBlack', 0),
	(19, 'Invicta', 0),
	(20, 'Czech Republic', 1),
	(20, 'Namibia', 0),
	(20, 'Austria', 0),
	(20, 'Germany', 0),
	(21, 'Germany', 1),
	(21, 'United States', 0),
	(21, 'China', 0),
	(21, 'United Kingdom', 0),
	(22, 'Malt', 1),
	(23, 'Sassafras', 1),
	(24, 'Zymology', 1),
	(24, 'Viticulture', 0),
	(24, 'Medicandi', 0),
	(24, 'Lasciate', 0),
	(25, 'Braggot', 1);
	

	