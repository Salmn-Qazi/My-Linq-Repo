using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsEntities db = new StudentsEntities();

            //var studentList = from student in db.Students
            //                  where student.Address.Equals("Charsadda")
            //                  orderby student.Name
            //                  select new { student.Name };

            //foreach (var students in studentList)
            //    Console.WriteLine("{0}", students.Name);

            //var innerJoin = from students in db.Students
            //                join marks in db.Marks on students.ID equals
            //                marks.ID
            //                where marks.DLD >= 50 && marks.DSP >= 50 && marks.DSD >= 50
            //                orderby students.Name
            //                select new { students.Name, marks.DLD, marks.DSP, marks.DSD };

            //foreach (var student in innerJoin)
              //  Console.WriteLine("Name: {0} \nMarks: {1}-{2}-{3}\n\n", student.Name, student.DLD, student.DSP, student.DSD);

            var groupJoin = from students in db.Students
                            orderby students.Name
                            join marks in db.Marks on students.ID equals
                            marks.ID into marksGroup
                            select new
                            {
                                Marks = from marks2 in marksGroup select marks2
                            };

            foreach(var studentWithMarks in groupJoin)
            {
                //Console.WriteLine(studentWithMarks.Name + "\n");
                foreach (var marks in studentWithMarks.Marks)
                    Console.WriteLine("{0}-{1}-{2}", marks.DLD, marks.DSP, marks.DSD);
            }


            Console.ReadLine();
        }
    }
}
