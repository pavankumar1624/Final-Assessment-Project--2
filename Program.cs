using System;
using System.Collections.Generic;
using System.IO;

class Teacher
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

class Program
{
    static List<Teacher> teachers = new List<Teacher>();
    const string filePath = "C:\\Users\\Pavan\\OneDrive\\Desktop\\project directory 3\\students data1";

    static void Main()
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Update Teacher");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTeacher();
                    break;
                case 2:
                    UpdateTeacher();
                    break;
                case 3:
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddTeacher()
    {
        Teacher teacher = new Teacher();
        Console.Write("Enter ID: ");
        teacher.ID = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        teacher.Name = Console.ReadLine();

        Console.Write("Enter Class and Section: ");
        teacher.ClassAndSection = Console.ReadLine();

        teachers.Add(teacher);
        Console.WriteLine("Teacher added successfully!");
    }

    static void UpdateTeacher()
    {
        Console.Write("Enter the ID of the teacher to update: ");
        int id = int.Parse(Console.ReadLine());

        Teacher teacher = teachers.Find(t => t.ID == id);

        if (teacher != null)
        {
            Console.Write("Enter updated Name: ");
            teacher.Name = Console.ReadLine();

            Console.Write("Enter updated Class and Section: ");
            teacher.ClassAndSection = Console.ReadLine();

            Console.WriteLine("Teacher updated successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found with the given ID.");
        }
    }

    static void LoadData()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Teacher teacher = new Teacher
                {
                    ID = int.Parse(parts[0]),
                    Name = parts[1],
                    ClassAndSection = parts[2]
                };
                teachers.Add(teacher);
            }
        }
    }

    static void SaveData()
    {
        List<string> lines = new List<string>();
        foreach (Teacher teacher in teachers)
        {
            lines.Add($"{teacher.ID},{teacher.Name},{teacher.ClassAndSection}");
        }

        File.WriteAllLines(filePath, lines);
    }
}
