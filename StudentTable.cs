using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
public class StudentTable
 {
    private  static List <Student> student = new List <Student>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User = root; password = Oxygen07";
    private static string ConnectionString = "Server = localhost; User = root; database = SchoolDataBase;  password = Oxygen07";

    public static void CreateDatabase()
    {
        using (var connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists SchoolDataBase";

            MySqlCommand command = new MySqlCommand(query,connection);
            var execute = command.ExecuteNonQuery();
            if (execute > 0)
            {
               Console.WriteLine("Database created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Database");
            }
        }
    } 

    public static void CreateStudentTb()
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "Create table if not exists SchoolDataBase.Student(Student_Id int primary key not null unique auto_increment, Name varchar (255) not null , Email varchar (255) not null unique , Password varchar (255) not null , Gender char (1) not null);";

            MySqlCommand command = new MySqlCommand(query,connection);
            var execute = command.ExecuteNonQuery();
            if (execute == 0)
            {
               Console.WriteLine("Database created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Database");
            }
        } 
    }

    public static void CreateStudent(Student students)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
              connection.Open();
            Console.WriteLine("Enter name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter gender");
            char gender = char.Parse(Console.ReadLine());
            var set = new Student ( name ,  email, password , gender );
            student.Add (set);
            MySqlCommand insert = new MySqlCommand($"insert into SchoolDataBase.Student( name , email , password , gender ) values ('{students.Name = name}'  , '{students.Email = email}' ,  '{students.Password = password}' ,'{students.Gender = gender}');" , connection);
            var execute =insert.ExecuteNonQuery();
            if (execute > 0)
            {
               Console.WriteLine("Student created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create student");
            }
        }
    }

    public static Student  Login(string email, string password)
    {
         using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = $"SELECT Name, Email , Password From SchoolDataBase.Student where Email = '{email}' and Password = '{password}';";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                      Student use = new Student();
                      use.Email = reader.GetString(0);
                      use.Password = reader.GetString(1);
                      use.Name = reader.GetString(2);
                      Console.WriteLine($"welcome : {use.Name} ");
                      return use;
                    }
                }
            }
        } 
         return null;
    }
   
    public static Course checkcourseandinstructor()
    {
        Console.WriteLine("Enter course code");
        int coursecode = int.Parse(Console.ReadLine());
        using (var connection = new MySqlConnection())
        {
             connection.Open();
            string query = $"select  coursecode , coursename , Instructor from Courses where CourseCode = {coursecode};";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course admin = new Course ();
                        admin.Courseunit = reader.GetInt32(0);
                        admin.Deadline = reader.GetString(1);
                        admin.Coursename = reader.GetString(2);
                        admin.Instructor = reader.GetString(3);
                        admin.Coursetitle = reader.GetString(4);
                        Console.WriteLine($"courseid : {reader["course_id"]} , coursename : {reader["coursename"]} , coursetitle : {reader["coursetitle"]} , courseunit : {reader["courseunit"]} , Instructor: {reader["Instructor"]} , deadline : {reader["deadline"]}");
                    }
                }
            }
        }
         return null;
    }
}