using Teacher_Directory.Models;
using System;
using System.Linq;
using Teacher_Directory.Areas.Identity.Data;

namespace Teacher_Directory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Department.Any())
            {
                return;   // DB has been seeded
            }

            var Departments = new Department[]
            {
                new Department{DepartmentName="STEM Innovation"},
                new Department{DepartmentName="Creative Arts"},
                new Department{DepartmentName="Communication Studies"},
                new Department{DepartmentName="Global Languages"},
                new Department{DepartmentName="Health and Wellbeing"},
                new Department{DepartmentName="Future Technologies"},
                new Department{DepartmentName="Business and Enterprise"},
                new Department{DepartmentName="Human Society"},
                new Department{DepartmentName="Student Development"},
                new Department{DepartmentName="Applied Learning"}
            };
            foreach (Department d in Departments)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();

            // Look for any students.
            if (context.Subject.Any())
            {
                return;   // DB has been seeded
            }

            var subjects = new Subject[]
            {
                new Subject{SubjectName="Math", DepartmentId=1},
                new Subject{SubjectName="English", DepartmentId=3},
                new Subject{SubjectName="Science", DepartmentId=1},
                new Subject{SubjectName="History", DepartmentId=8},
                new Subject{SubjectName="Geography", DepartmentId=8},
                new Subject{SubjectName="Biology", DepartmentId=1},
                new Subject{SubjectName="Chemistry", DepartmentId=1},
                new Subject{SubjectName="Physics", DepartmentId=1},
                new Subject{SubjectName="Computer Science", DepartmentId=6},
                new Subject{SubjectName="Art", DepartmentId=2}
            };
            foreach (Subject s in subjects)
            {
                context.Subject.Add(s);
            }
            context.SaveChanges();


            if (context.Teacher.Any())
            {
                return;   // DB has been seeded
            }

            var Teachers = new Teacher[]
            {
               new Teacher{Teachercode="AJO",Email="alex.johnson@school.com",Firstname="Alex",Lastname="Johnson",Gender=Gender.Male,PhotoURL="/images/teacher_man.png",DepartmentId=1,Position="Head of Department",OfficeLocation = "A101"},
               new Teacher{Teachercode="ECL",Email="emma.clark@school.com",Firstname="Emma",Lastname="Clark",Gender=Gender.Female,PhotoURL="/images/teacher_woman.png",DepartmentId=2,Position="Senior Teacher",OfficeLocation = "B204"},
               new Teacher{Teachercode="LHA",Email="lucas.harris@school.com",Firstname="Lucas",Lastname="Harris",Gender=Gender.Male,PhotoURL="/images/teacher_man.png",DepartmentId=3,Position="Teacher",OfficeLocation = "B204"},
               new Teacher{Teachercode="SCO",Email="sophia.cooper@school.com",Firstname="Sophia",Lastname="Cooper",Gender=Gender.Female,PhotoURL="/images/teacher_woman.png",DepartmentId=4,Position="Curriculum Leader",OfficeLocation = "C110"},
               new Teacher{Teachercode="NWA",Email="noah.walker@school.com",Firstname="Noah",Lastname="Walker",Gender=Gender.Male,PhotoURL="/images/teacher_man.png",DepartmentId=5,Position="Teacher",OfficeLocation = "D301"},
               new Teacher{Teachercode="GLE",Email="grace.lewis@school.com",Firstname="Grace",Lastname="Lewis",Gender=Gender.Female,PhotoURL="/images/teacher_woman.png",DepartmentId=6,Position="Teacher",OfficeLocation = "B204"},
               new Teacher{Teachercode="ETH",Email="ethan.thomas@school.com",Firstname="Ethan",Lastname="Thomas",Gender=Gender.Male,PhotoURL="/images/teacher_man.png",DepartmentId=7,Position="Assistant Head",OfficeLocation = "C110"},
               new Teacher{Teachercode="AMO",Email="amelia.moore@school.com",Firstname="Amelia",Lastname="Moore",Gender=Gender.Female,PhotoURL="/images/teacher_woman.png",DepartmentId=8,Position="Teacher",OfficeLocation = "C110"},
               new Teacher{Teachercode="OWI",Email="oliver.wilson@school.com",Firstname="Oliver",Lastname="Wilson",Gender=Gender.Male,PhotoURL="/images/teacher_man.png",DepartmentId=9,Position="Teacher",OfficeLocation = "D301"},
               new Teacher{Teachercode="CAD",Email="charlotte.davis@school.com",Firstname="Charlotte",Lastname="Davis",Gender=Gender.Female,PhotoURL="/images/teacher_woman.png",DepartmentId=10,Position="Dean",OfficeLocation = "A101"}
            };
            foreach (Teacher t in Teachers)
            {
                context.Teacher.Add(t);
            }
            context.SaveChanges();

            if (context.Course.Any())
            {
                return;   // DB has been seeded
            }

            var Courses = new Course[]
            {
               new Course{CourseName = "Year 9 Mathematics",Room_Num="A01",Year=9,TeacherId=1,SubjectId=1},
               new Course{CourseName = "Year 10 English",Room_Num="A12",Year=10,TeacherId=2,SubjectId=2},
               new Course{CourseName = "Year 11 Science",Room_Num="A23",Year=11,TeacherId=3,SubjectId=3},
               new Course{CourseName = "Year 12 History",Room_Num="B08",Year=12,TeacherId=4,SubjectId=4},
               new Course{CourseName = "Year 13 Geography",Room_Num="B15",Year=13,TeacherId=5,SubjectId=5},
               new Course{CourseName = "Year 9 Biology",Room_Num="C09",Year=9,TeacherId=6,SubjectId=6},
               new Course{CourseName = "Year 10 Chemistry",Room_Num="C18",Year=10,TeacherId=7,SubjectId=7},
               new Course{CourseName = "Year 11 Physics",Room_Num="D21",Year=11,TeacherId=8,SubjectId=8},
               new Course{CourseName = "Year 12 Computer Science",Room_Num="D30",Year=12,TeacherId=9,SubjectId=9},
               new Course{CourseName = "Year 13 Art",Room_Num="E11",Year=13,TeacherId=10,SubjectId=10}
            };
            foreach (Course c in Courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();


        }
    }
}