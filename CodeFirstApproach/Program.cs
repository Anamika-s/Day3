using CodeFirstApproach.Context;
using CodeFirstApproach.Models;

namespace CodeFirstApproach
{
    internal class Program
    {
        static StudentDbContext db = new StudentDbContext();
        static void Main(string[] args)
        {
            int c;
            Console.WriteLine("Enter choice");
            c = byte.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Batch");
                        string batch = Console.ReadLine();
                        Console.WriteLine("Enter Marks");
                        int marks = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        string address = Console.ReadLine();
                        Student student = new Student()
                        {
                            Name = name,
                            Address = address,
                            Batch = batch,
                            Marks = marks
                        };
                        InsertRecord(student);

                        break;
                    }
                case 2:
                    {
                        List<Student> list = GetStudents();
                        if (list == null)
                            Console.WriteLine("There are no records");
                        else
                            foreach (Student student in list)
                            {
                                Console.WriteLine(student.Name);
                            }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter name to search");
                        string name = Console.ReadLine();
                        Student student = SearchRecord(name);
                        if (student == null)
                            Console.WriteLine("No record with this name");
                        else
                            Console.WriteLine(student.Name + " " + student.Address);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter id to delete");
                        int id = Byte.Parse(Console.ReadLine());
                        bool flag = DeleteRecord(id);
                        if (flag == false)
                            Console.WriteLine("No record with this id");
                        else
                            Console.WriteLine("DeletedRecord ");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter id to edit");
                        int id = Byte.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new Batch");
                        string batch = Console.ReadLine();
                        Console.WriteLine("Enter new Marks");
                        int marks = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new Address");
                        string address = Console.ReadLine();
                        Student temp = new Student()
                        {
                             
                            Address = address,
                            Batch = batch,
                            Marks = marks
                        };
                        bool flag = EditRecord(id, temp);
                        if (flag == false)
                            Console.WriteLine("No record with this id");
                        else
                            Console.WriteLine("DeletedRecord ");
                        break;
                    }

            }
        }

        static void InsertRecord(Student student)
        {
            db.Students.Add(student);

            db.SaveChanges();
        }

        static List<Student> GetStudents()
        {
            if (db.Students.ToList().Count == 0)
                return null;
            else
                return db.Students.ToList();
        }
        static Student SearchRecord(string name)
        {
            var record = db.Students.Where(x => x.Name.Contains(name)).FirstOrDefault();
            return record;
        }
        static bool EditRecord(int id, Student temp)
        {
            if (db.Students.Find(id) == null)
            {
                return false;

            }
            else
            {
                Student student = db.Students.Find(id);
                student.Batch = temp.Batch;
                student.Marks = temp.Marks;
                student.Address = temp.Address;
                db.SaveChanges();
                return true;
            }
        }
            static bool DeleteRecord(int id)
            {
                if (db.Students.Find(id) == null)
                {
                    return false;

                }
                else
                {
                    Student student = db.Students.Find(id);
                    db.Students.Remove(student);
                    db.SaveChanges();
                    return true;
                }
                
            }
        }
    }

