USE pocazurefunction;

SELECT * FROM Customer;


INSERT INTO customer (Name, Email) VALUES ('John Doe', 'johndoe@example.com');
INSERT INTO Customer (Name, Email)VALUES ('Pam Beesly', 'pam.beesly@example.com');
INSERT INTO Customer (Name, Email)VALUES ('Jim Halpert', 'jim.halpert@example.com');


UPDATE Customer
SET IsDeleted = TRUE, az_func_updated_at = CURRENT_TIMESTAMP
WHERE Id = 4;

