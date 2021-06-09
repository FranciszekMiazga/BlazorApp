using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApplication.Data
{
    public class StudentsService
    {
         
        private static readonly List<Student> StudentsList =new List<Student>
        {
            new Student{IdStudent=1,Avatar=1,FirstName="Jan",LastName="Kowalski",Birthdate=DateTime.Parse("12/12/1990"),Studies="Informatyka"},
            new Student{IdStudent=2,Avatar=2,FirstName="Kamil",LastName="Nowak",Birthdate=DateTime.Parse("11/08/2002"),Studies="Zarzadzanie"},
            new Student{IdStudent=3,Avatar=3,FirstName="Krzysztof",LastName="Markowicz",Birthdate=DateTime.Parse("03/01/1993"),Studies="Ekonomia"},
            new Student{IdStudent=4,Avatar=4,FirstName="Artur",LastName="Jankowski",Birthdate=DateTime.Parse("01/11/2014"),Studies="Zarzadzanie"},
            new Student{IdStudent=5,Avatar=5,FirstName="Marek",LastName="Kowalski",Birthdate=DateTime.Parse("04/03/2004"),Studies="Grafika komputerowa"}
        };
        public Task<List<Student>> GetStudentsAsync()
        {
            return Task<List<Student>>.FromResult(StudentsList);
        }
        public void AddStudent(Student student)
        {
            var maxIndex = StudentsList.Max(e=>e.IdStudent)+1;
            student.IdStudent = maxIndex;
            StudentsList.Add(student);
        }
        public void DeleteStudent(int IdStudent)
        {
            var student = StudentsList.Where(e => e.IdStudent == IdStudent).FirstOrDefault();

            StudentsList.Remove(student);
        }
        public List<Student> EditStudent(Student student)
        {
            var studentNew = StudentsList.Where(e => e.IdStudent == student.IdStudent).FirstOrDefault();
            if (studentNew != null) {
                StudentsList.Remove(studentNew);
                StudentsList.Insert(student.IdStudent-1,student);
            }
            return StudentsList;
        }
        public List<Student> SortRecAsc(string HeaderName)
        {
            List<Student> sortedListAsc=null;
            if(HeaderName=="Last Name")
                sortedListAsc = StudentsList.OrderBy(e=>e.LastName).ToList();
            else if(HeaderName=="First Name")
                sortedListAsc = StudentsList.OrderBy(e => e.FirstName).ToList();
            else if (HeaderName == "Birth Date")
                sortedListAsc = StudentsList.OrderBy(e => e.Birthdate).ToList();
            else if (HeaderName == "Studies")
                sortedListAsc = StudentsList.OrderBy(e => e.Studies).ToList();


            return sortedListAsc;

        }
        public List<Student> SortRecDesc(string HeaderName)
        {
            List<Student> sortedListDesc=null;
            if (HeaderName == "Last Name")
                sortedListDesc = StudentsList.OrderByDescending(e => e.LastName).ToList();
            else if (HeaderName == "First Name")
                sortedListDesc = StudentsList.OrderByDescending(e => e.FirstName).ToList();
            else if (HeaderName == "Birth Date")
                sortedListDesc = StudentsList.OrderByDescending(e => e.Birthdate).ToList();
            else if (HeaderName == "Studies")
                sortedListDesc = StudentsList.OrderByDescending(e => e.Studies).ToList();
            return sortedListDesc;
        }
    }
}
