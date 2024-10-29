using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
 public class EnrollmentTable
 {
    private  static List <Enroll> student = new List <Enroll>();
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

    public static void CreateEnrollmentTb()
    {
      using (var connection = new MySqlConnection(ConnectionString))
      {
        connection.Open();
        string query = "Create table if not exists SchoolDataBase.Enrollment(enrollment_id int primary key not null unique auto_increment , course_id int (255) not null  , student_id int (255) not null  , FOREIGN KEY (student_id) REFERENCES SchoolDataBase.Student(Student_Id) , FOREIGN KEY (course_id) REFERENCES SchoolDataBase.Course(course_id));";
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

    public static void CreateEnroll(Enroll admin)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
             int Count = 0;
        Console.WriteLine ("choose atmost 11 courses you want to register for");
        int input = int.Parse (Console.ReadLine());

        if (input <= 11)
        {
            for (int i = 0;i <input;i++)
            {
                Console.WriteLine("Enter your student id ");
                int studentid = int.Parse(Console.ReadLine().ToLower());
                Console.WriteLine("enter the course using the ID ");
                int courseid = int.Parse(Console.ReadLine());
                var set = new Enroll ( studentid , courseid);
                student.Add (set);
                MySqlCommand insert = new MySqlCommand($"insert into SchoolDataBase.Enrollment(student_id, course_id ) values ('{admin.StudentId = studentid}' ,'{admin.CourseId = courseid}')" , connection);
                var execute =insert.ExecuteNonQuery();
                if (execute <= 5)
                {
                Console.WriteLine("Enroll created successfully");
                }
                else
                {
                    Console.WriteLine("Unable to Create Enroll");
                }
            }
        }
        else
        {
          Console.WriteLine("Enter a number less than 12");
        }
    }
  }

  public static void getTheTotalNumberOfCourseUnit()
  {
    using MySqlConnection connection = new MySqlConnection(ConnectionString);
    {
      connection.Open();
      Console.WriteLine ("");
      int student_id = int.Parse (Console.ReadLine());
      string selectQuery = $"select sum(course.courseunit) as totalcourseunit from student inner join course on Student_Id = {student_id};";
      using ( MySqlCommand insert = new MySqlCommand(selectQuery, connection))
      {
        using (MySqlDataReader reader = insert.ExecuteReader())
        {
          while (reader.Read())
          {
          Console.WriteLine($"total unit of course : {reader["totalunit"]}");
          }
        }
      }
    }
  }

  public static void GetAllCourseAndTeacher()
  {
    using MySqlConnection connection = new MySqlConnection(ConnectionString);
    {
        connection.Open();
        string selectQuery = "select  student.Student_Id, student.Name, course.coursename, course.courseunit, course.Teachername  from student inner join course on Student_Id = 1;";
      using ( MySqlCommand insert = new MySqlCommand(selectQuery, connection))
      {
        using (MySqlDataReader reader = insert.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine($"Student_ID: {reader["Student_Id"]}, Name: {reader["Name"]}, coursename : {reader["coursename"]}, courseunit: {reader["courseunit"]} , Teachername: {reader["Teachername"]}")  ;
          }
        }
      }
    }
  }
}