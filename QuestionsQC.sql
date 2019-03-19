-- sample insert
--Insert Project0.ItemProducts(ItemName, ItemDescription, ItemPrice)
--	VALUES('shirt', 'short sleeves t-shirt', 15.00)

-- let's make some QC questions
Insert TP2.Questions(QCategory, QType, QRating)
	VALUES('QC', 'Multiple', 1);
Insert TP2.Questions(QCategory, QType, QRating)
	VALUES('QC', 'Bool', 2);
Insert TP2.Questions(QCategory, QType, QRating)
	VALUES('QC', 'Bool', 3);
Insert TP2.Questions(QCategory, QType, QRating)
	VALUES('QC', 'Multiple', 4);
Insert TP2.Questions(QCategory, QType, QRating)
	VALUES('QC', 'Multiple', 5);


-- insertion for answers/options
