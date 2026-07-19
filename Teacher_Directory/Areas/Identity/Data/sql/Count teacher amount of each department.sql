SELECT
    d.DepartmentName,
    COUNT(t.Id) AS NumberOfTeachers
FROM Department AS d
LEFT JOIN Teacher AS t
    ON d.Id = t.DepartmentId
GROUP BY d.Id, d.DepartmentName
ORDER BY NumberOfTeachers DESC;