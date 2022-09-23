using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Student
{
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
        };

        // Упражнение 7.2. Изменение запроса
        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery = from student in students
                                                
                                                // Добавление дополнительного условия фильтра
                                                // where student.Scores[0] > 90 // комм. п.1
                                                where student.Scores[0] > 90 && student.Scores[3] < 80 // new п.1

                                                // Упорядочение результатов
                                                orderby student.Last ascending // new п.1
                                                orderby student.Scores[0] descending // new п.2
                                                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine(); // пробел чтобы отделить значение от командной строки
                // Console.WriteLine("{0}, {1}", student.Last, student.First); // комм. п.3
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]); // new п.3
            }

            // Группировка результатов 
            var studentQuery2 = from student in students group student by student.Last[0]; // п.1

            // п.2
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }
        }
    }
}
