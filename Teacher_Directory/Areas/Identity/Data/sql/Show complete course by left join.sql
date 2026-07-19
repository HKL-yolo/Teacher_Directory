SELECT
    c.CourseName,
    c.Year,
    c.Room_Num,
    s.SubjectName,
    t.Firstname + ' ' + t.Lastname AS TeacherName
FROM Course AS c
LEFT JOIN Subject AS s
    ON c.SubjectId = s.Id
LEFT JOIN Teacher AS t
    ON c.TeacherId = t.Id;