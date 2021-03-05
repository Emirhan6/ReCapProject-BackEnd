Create TABLE Cars(

	Id int primary key identity (1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId)
)


CREATE TABLE Colors(
	ColorId int primary key identity(1,1),
	ColorName nvarchar(25),
)



CREATE TABLE Brands(
	BrandId int primary key identity(1,1),
	BrandName nvarchar(25),
)


INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','2015','200','Manuel'),
	('2','1','2014','100','Otomatik'),
	('3','3','2006','300','Manuel'),
	('2','3','2010','400','Otomatik');

INSERT INTO Colors(ColorName)
VALUES
	('Siyah'),
	('Beyaz'),
	('Kırmızı');

INSERT INTO Brands(BrandName)
VALUES
	('Mercedes'),
	('Hyundai'),
	('BMW');

SELECT * FROM Cars
SELECT * FROM Brands
SELECT * FROM Colors