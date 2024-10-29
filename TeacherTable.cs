using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
 public class TeacherTable
 {
    private  static List <Teacher> student = new List <Teacher>();
    private static string ConnectionStringWithoutDB = "Server = localhost; User = root; password = Oxygen07";
    private static string ConnectionString = "Server = localhost; User = root; database = SchoolDataBase;  password = Oxygen07";

    public static void CreateDatabase()
    {
        using (var connection = new MySqlConnection(ConnectionStringWithoutDB))
        {
            connection.Open();
            string query = "Create Database if not exists SchoolDataBase";

            MySqlCommand mySqlCommandcmd = new MySqlCommand(query,connection);
            var execute = mySqlCommandcmd.ExecuteNonQuery();
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
            string query = "Create table if not exists SchoolDataBase.Teacher(teacher_id int primary key not null unique auto_increment , Name varchar (255) not null , Email varchar (255) not null , Password varchar (255) not null);";
            MySqlCommand mySqlCommandcmd = new MySqlCommand(query,connection);
            var execute = mySqlCommandcmd.ExecuteNonQuery();
            if (execute == 0)
            {
               Console.WriteLine("Table created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Table");
            }
        } 
    }

    public static void CreateTeacher(Teacher admin)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter name ");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Enter email ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password ");
            string password = Console.ReadLine();
            var set = new Teacher (name , email , password);
            student.Add (set);
            MySqlCommand insert = new MySqlCommand($"insert into SchoolDataBase.Teacher(name , email , password ) values ('{admin.Name = name}' ,'{admin.Email = email}' , '{admin.Password = password}')" , connection);
            var execute =insert.ExecuteNonQuery();
            if (execute <= 5)
            {
               Console.WriteLine("Admin created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Admin");
            }
        }
    }

    public static Teacher  Login(string email, string password)
    {
         using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = $"SELECT  Name, Email , Password From SchoolDataBase.Teacher where Email =  '{email}' and Password =  '{password}'; ";
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                      Teacher use = new Teacher();
                      use.Name = reader.GetString(0);
                      use.Email = reader.GetString(1);
                      use.Password = reader.GetString(2);
                      Console.WriteLine($"welcome : {use.Name} ");
                      return use;
                    }
                }
            }
        } 
         return null;
    }

    public static Course  GetTeacherCourse( )
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter your course id");
            int courseid = int.Parse(Console.ReadLine());
            string selectQuery = $"SELECT  course_id , coursecode , coursename , Teachername , datetime  From SchoolDataBase.Course where course_id = '{courseid}';";
            
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Course Id: {reader["course_id"]}, Course Code: {reader["coursecode"]}, Course Name: {reader["coursename"]}, Teacher Name : {reader["Teachername"]}, Date : {reader["datetime"]}");
                    }
                    return null;
                }
            }
        }
    }

    public static Course  GetAllStudentOfferingMyCourse()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter name of teacher to check students allocated");
            string teachname = Console.ReadLine();
            string selectQuery = $"select  student.Name, course.coursename, course.courseunit, course.Teachername  from student inner join course on Teachername = '{teachname}';";
            
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    Console.WriteLine($"Course Name: {reader["coursename"]}, Course title: {reader["coursetitle"]}, Course unit : {reader["courseunit"]}  , Teacher Name : {reader["Teachername"]}, Date : {reader["datetime"]}");
                    }
                    return null;
                }
            }
        }
    }
}