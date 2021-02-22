--Initial Schema and Table creation
CREATE SCHEMA TimedChallenge

--DROP TABLE Products
CREATE TABLE Products(
	ID INT IDENTITY(1, 1) NOT NULL,
	Name NVARCHAR(100) UNIQUE NOT NULL,
	Price MONEY NOT NULL,
	CONSTRAINT Prod_PK PRIMARY KEY (ID)
);

--DROP TABLE Customers
CREATE TABLE Customers(
	ID INT IDENTITY(1, 1) NOT NULL,
	Firstname NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Cardnumber BIGINT NOT NULL CHECK (Cardnumber > 2999999999999 AND Cardnumber < 9999999999999999),
	CONSTRAINT Cust_PK PRIMARY KEY (ID)
);  

--DROP TABLE Orders
CREATE TABLE Orders(
	ID INT IDENTITY(1, 1) NOT NULL,
	ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ID),
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(ID)
);

--Initial data population
INSERT INTO Products (Name, Price) VALUES ('GALAXY NOTE 9', $300);
INSERT INTO Products (Name, Price) VALUES ('LG G5', $250);
INSERT INTO Products (Name, Price) VALUES ('PIXEL2', $400);

INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES ('STEVE', 'ROGERS', 5414624251219994);
INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES ('STEVE', 'BANNON', 4454542412017545);
INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES ('TONY', 'STARK', 3432145541257);

INSERT INTO Orders (ProductID, CustomerID) VALUES (1, 1);
INSERT INTO Orders (ProductID, CustomerID) VALUES (2, 3);
INSERT INTO Orders (ProductID, CustomerID) VALUES (3, 2);

--Challenges

INSERT INTO Products (Name, Price) VALUES ('IPhone', $200);
INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES ('Tina', 'Smith', 5447682541217952);
INSERT INTO Orders (ProductID, CustomerID) VALUES (4, 4);

SELECT o.* FROM Orders AS o
	INNER JOIN Customers AS c ON c.ID = o.CustomerID
WHERE c.Firstname = 'Tina' AND c.Lastname = 'Smith';

SELECT Name, COUNT(ord.ID), SUM(prod.Price) FROM Products AS prod
	INNER JOIN Orders AS ord ON ord.ProductID = prod.ID
WHERE prod.Name = 'IPhone';

UPDATE Products 
SET Price = $250
WHERE Name = 'IPhone';



