-- Users related queries
SELECT Id, UserName
FROM Users;

INSERT INTO Users (Id, UserName)
VALUES(1,"Bob");

INSERT INTO Users (Id, UserName)
VALUES(2,"Tom");

INSERT INTO Users (Id, UserName)
VALUES(3,"Jane");

DELETE FROM Users where Id=4