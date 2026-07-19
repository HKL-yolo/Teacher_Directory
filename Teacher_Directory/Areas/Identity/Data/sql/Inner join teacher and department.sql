SELECT
    t.Id,
    t.Firstname,
    t.Lastname,
    d.DepartmentName
FROM Teacher AS t
INNER JOIN Department AS d
    ON t.DepartmentId = d.Id;