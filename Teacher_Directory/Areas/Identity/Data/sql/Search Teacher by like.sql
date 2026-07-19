SELECT Id, Firstname, Lastname, Email
FROM Teacher
WHERE Firstname LIKE '%an%'
   OR Lastname LIKE '%an%';