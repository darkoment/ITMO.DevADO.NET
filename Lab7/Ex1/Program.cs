using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Student
{
    internal class Program
    {
        // Создание расположенного в памяти источника данных
        // пп.1-2
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

        // Упражнение 7.1. Создание и выполнение простого запроса
        static void Main(string[] args)
        {
            // у.7.1. п.1
            IEnumerable<Student> studentQuery = from student in students
                                                where student.Scores[0] > 90
                                                select student;
            // у.7.1. п.2
            foreach (Student student in studentQuery)
            {
                Console.WriteLine(); // пробел чтобы отделить значение от командной строки
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }
        }
    }
}
