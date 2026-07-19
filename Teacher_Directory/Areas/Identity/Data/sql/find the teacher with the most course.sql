SELECT TOP 1 WITH TIES
    t.Id,
    t.Firstname,
    t.Lastname,
    COUNT(c.Id) AS NumberOfCourses
FROM Teacher AS t
LEFT JOIN Course AS c
    ON t.Id = c.TeacherId
GROUP BY t.Id, t.Firstname, t.Lastname
ORDER BY COUNT(c.Id) DESC;