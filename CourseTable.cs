using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZstdSharp.Unsafe;
public class CourseTable
 {
    private  static List <Course> student = new List <Course>();
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

     public static void CourseTb()
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "Create table if not exists SchoolDataBase.Course(course_id int primary key  not null unique auto_increment , coursetitle varchar (255) not null unique , coursename varchar (255) not null unique ,  courseunit int (25) not null , Teachername varchar (255) not null , datetime varchar (255) not null );";
            MySqlCommand command = new MySqlCommand(query,connection);
            var execute = command.ExecuteNonQuery();
            if (execute == 0)
            {
               Console.WriteLine("Course Table created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Database");
            }
        } 
    }

    public static Course  GetAllCourses( )
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * From SchoolDataBase.Course ";
            
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    Console.WriteLine($"Course Id: {reader["course_id"]}, Course Name: {reader["coursename"]}, Course title: {reader["coursetitle"]}, Course unit : {reader["courseunit"]}  , Teacher Name : {reader["Teachername"]}, Date : {reader["datetime"]}");
                    }
                return null;
                }
            }
        }
    }

     public static void DeleteCourse()
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Choose the course id of the  name of instructor to be deleted subbject");
            int instruct = int.Parse(Console.ReadLine());
            string query = $"delete from SchoolDataBase.Course  where course_id = '{instruct}';";

            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery();

            if (execute <= 5)
            {
                Console.WriteLine("Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Unable To Delete.");
            }
        }
    }

    public  static void UpdateCourseTeacher()
   {
        using(MySqlConnection connection=new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Choose the course id of the  name of instructor/teacher");
            int instruct = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the name of the new instructor/teacher");
            string newinstruct = Console.ReadLine();
            string query = $"UPDATE SchoolDataBase.Course SET Teachername = '{newinstruct}'  where course_id = '{instruct}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery(); 
            if (execute <= 5)
            {
                Console.WriteLine("instructor/teacher has been updated successfully");
            }
            else
            {
                Console.WriteLine("unable to update teacher/instructor ");
            }
        }
    }

    public  static void UpdateCoursename()
   {
        using(MySqlConnection connection=new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Choose the course id of the course name");
            int instruct = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the name of a new coursename");
            string newcoursename = Console.ReadLine().ToUpper();
            string query = $"UPDATE SchoolDataBase.Course SET coursename = '{newcoursename}'  where course_id = '{instruct}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery(); 
            if (execute > 0)
            {
                Console.WriteLine("product table updated successfully");
            }
            else
            {
                Console.WriteLine("unable to update product ");
            }
        }
    }

  public  static void UpdateCoursecode()
   {
        using(MySqlConnection connection=new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("enter the coursecode you want to change to");
            int newcoursecode = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the old coursecode of you want to change ");
            int oldcoursecode = int.Parse(Console.ReadLine());
            string query = $"UPDATE SchoolDataBase.Course SET coursecode = '{newcoursecode}'  where course_id = '{oldcoursecode}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            var execute = command.ExecuteNonQuery(); 
            if (execute > 0)
            {
                Console.WriteLine("product table updated successfully");
            }
            else
            {
                Console.WriteLine("unable to update product ");
            }
        }
    }
}
