SELECT
    d.DepartmentName,
    COUNT(s.Id) AS NumberOfSubjects
FROM Department AS d
INNER JOIN Subject AS s
    ON d.Id = s.DepartmentId
GROUP BY
    d.Id,
    d.DepartmentName
HAVING COUNT(s.Id) >= 2;