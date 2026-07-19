SELECT TOP 1 WITH TIES
    d.DepartmentName,
    COUNT(s.Id) AS NumberOfSubjects
FROM Department AS d
LEFT JOIN Subject AS s
    ON d.Id = s.DepartmentId
GROUP BY
    d.Id,
    d.DepartmentName
ORDER BY COUNT(s.Id) DESC;