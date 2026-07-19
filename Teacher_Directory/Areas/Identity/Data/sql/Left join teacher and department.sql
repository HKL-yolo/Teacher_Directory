SELECT
    t.Firstname,
    t.Lastname,
    d.DepartmentName
FROM Teacher AS t
LEFT JOIN Department AS d
    ON t.DepartmentId = d.Id;