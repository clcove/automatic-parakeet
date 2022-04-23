-- CREATE TABLE users
-- (
--    UserID INT(4) PRIMARY KEY AUTO_INCREMENT
--  , UserName varchar(32) NOT NULL
--  , NickName VARCHAR(32) NOT NULL
--  , RoleID int(4) NOT NULL
--  , Email VARCHAR(20) NOT NULL
--  , Phone VARCHAR(20) NOT NULL
--  , EncryptedPassword VARCHAR(64) NOT NULL
--  , `Status` int(1) 
--  , UpdatedBy int(4) not NULL
--  , TimeUpdated DATETIME
--  , CreatedBy INT(4) NOT NULL
--  , TimeCreated DATETIME
-- );

SELECT
   COUNT(1)
FROM users
WHERE users.UserName = 'Admin'
AND users.EncryptedPassword = '1'
;