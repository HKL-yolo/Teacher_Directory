SELECT
    s.SubjectName,
    d.DepartmentName
FROM Subject AS s
INNER JOIN Department AS d
    ON s.DepartmentId = d.Id
ORDER BY d.DepartmentName, s.SubjectName;