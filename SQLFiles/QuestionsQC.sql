-- sample insert
SELECT *
FROM TP2.Questions

SELECT *
FROM TP2.Answers

SELECT q.QString, a.AAnswer, a.Correct
FROM TP2.Answers AS a
	INNER JOIN TP2.Questions AS q ON a.QId = q.QId
WHERE q.QCategory = 'QC';

-- let's make some QC questions
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 1, 'What is Git?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Bool', 1, 'More than one style sheet can be used in an HTML page');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 1, 'The class selector in CSS uses a');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 1, 'What does the controller in MVC do?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 1, 'What is a technical debt?');

Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 2, 'How do you create a new branch in Git?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 2, 'What is SonarQube?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Bool', 2, 'Nuget provides dependency resolution');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 2, 'Big Bang, Spiral, and Agile are part of what type of model?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 2, 'Which Agile framework does not use sprints and believes in continuous flow?');

Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 3, 'What is a strongly typed view in ASP.NET MVC?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Bool', 3, 'Is Sticky a CSS position value?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 3, 'What property value is positioned relative to its first positioned (not static) ancestor element?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 3, 'Which HTML Structural element is not new in HTML5?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 3, 'Which of the below is not a HTTP request?');

Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 4, 'Which one of these is a PaaS?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 4, 'Which one of these is a IaaS?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 4, 'Which of the following is an 8-byte Integer?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Bool', 4, 'Can a Partial View have a @Layout page reference?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 4, 'What specifies the location of the service, and the methods of the service');

Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 5, 'Which one below is not a Docker Orchestration tool?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Bool', 5, 'Nuget provides automatic dependency resolution.');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Multiple', 5, 'What is the difference between WHERE and HAVING in TSQL');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 5, 'INSERT, SELECT, UPDATE, and DELETE is a part of what sublanguage?');
Insert TP2.Questions(QCategory, QType, QRating, QString)
	VALUES('QC', 'Fill', 5, 'Which normalized form introduces the concept of enforcing primary keys and removing composite columns? (First, Second, ...)');


-- WARNING! since there will be a lot of questions from a variety of people,
-- QId may not be in the correct order numerically so make sure to consult the table for QId
-- insertion for answers/options

-- answers for difficulty 1
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(51, 'A version control tool', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(51, 'A build automaton tool', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(51, 'An automation server', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(51, 'A container management system', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(52, 'True', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(52, 'False', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(53, '(~) symbol', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(53, '(*) symbol', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(53, '(.) symbol', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(53, '(#) symbol', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(53, '(+) symbol', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(54, 'Communicates only to the view', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(54, 'Uses Razor syntax to render a page with C#', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(54, 'Controls the styling on an HTML page', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(54, 'Communication between model and view', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(55, 'Bugs that breaks the system and causes compile time errors', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(55, 'An estimate on the amount of time needed to fix "Lazy" solutions', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(55, 'Pieces of code that can cause future potential problems', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(55, 'You owe money for some online database hosting your project', 0);

-- answers for difficulty 2
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(56, 'git checkout -nb <newBranch>', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(56, 'git checkout <newBranch>', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(56, 'git checkout -b <newBranch> ', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(56, 'git checkout -n <newBranch> ', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(57, 'an open source platform that performs static analysis of code to determine code quality.', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(57, 'a closed source platform for testing your code for bugs.', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(57, 'cloud computing service created by Microsoft for building, testing, deploying, and managing applications and services through Microsoft-managed data centers.', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(57, 'an open-source project for automating the deployment of applications as portable, self-sufficient containers that can run on the cloud or on-premises', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(58, 'True', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(58, 'False', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(59, 'iterative', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(60, 'kanban', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(61, 'A partial view.', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(61, 'A view that returns a different type of ActionResult other than ViewResult', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(61, 'A view used to render a specific type of model.', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(61, 'A view that does not have a defined model to render.', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(62, 'True', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(62, 'False', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(63, 'absolute', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(64, 'footer', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(64, 'main', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(64, 'nav', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(64, 'header', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(64, 'head', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(65, 'GET', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(65, 'REMOVE', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(65, 'HEAD', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(65, 'PUT', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(65, 'POST', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(66, 'AWS', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(66, 'Dropbox', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(66, 'Microsoft Azure', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(66, 'Gmail', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(66, 'Heroku', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(67, 'Slack', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(67, 'AWS Elastic Beanstalk', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(67, 'Microsoft Azure', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(67, 'Azure Cloud Services', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(67, 'Office 365', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(68, 'Byte', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(68, 'Long', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(68, 'Int', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(68, 'Short', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(68, 'Char', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(69, 'True', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(69, 'False', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(70, 'WSDL', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(71, 'AWS Elastic Container Service', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(71, 'Kubernetes', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(71, 'Docker Toolbox', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(71, 'Docker Swarm', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(72, 'True', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(72, 'False', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(73, 'There is no difference', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(73, 'WHERE is used to filter data from the selected table, having is used to filter data from a joined table', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(73, 'HAVING is used to specify the conditions for joining tables ', 0);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(73, 'WHERE filters data prior to aggregation, HAVING filters data after aggregation', 1);
Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(73, 'None of the above', 0);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(74, 'DML', 1);

Insert Tp2.Answers(QId, AAnswer, Correct)
	VALUES(75, 'First', 1);