using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZstdSharp.Unsafe;
public class ResultTable
 {
    private  static List <Result> student = new List <Result>();
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

    public static void ResultTb()
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "Create table if not exists SchoolDataBase.Result(result_id int primary key not null unique auto_increment , course_id int (255) not null  , student_id int (255) not null  , score double (25 , 2) not null , grade char (1) not null , coursename varchar (255) not null , courseunit int not null , FOREIGN KEY (student_id) REFERENCES SchoolDataBase.Student(Student_Id) , FOREIGN KEY (course_id) REFERENCES SchoolDataBase.Course(course_id));";
            MySqlCommand command = new MySqlCommand(query,connection);
            var execute = command.ExecuteNonQuery();
            if (execute == 0)
            {
               Console.WriteLine("Result Table created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create Result");
            }
        } 
    }

    public static void CreateResult(Result admin)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            //  int Count = 0;
            Console.WriteLine ("choose the number of score of student you want to enter");
            int input = int.Parse (Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                Console.WriteLine("Enter your student id ");
                int studentid = int.Parse(Console.ReadLine().ToLower());
                Console.WriteLine("enter the course using the ID ");
                int courseid = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the score of student");
                int score = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the grade of student");
                char grade = char.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine("enter the coursename of student");
                string coursename = Console.ReadLine().ToUpper();
                Console.WriteLine("enter the unit of course of student");
                int courseunit = int.Parse(Console.ReadLine());
                var set = new Result ( studentid , courseid , score , coursename , courseunit ,  grade );
                student.Add (set);
                MySqlCommand insert = new MySqlCommand($"insert into SchoolDataBase.Result(student_id, course_id, score,  grade , coursename , courseunit) values ('{admin.Student_id = studentid}' , '{admin.Course_id = courseid}'  ,'{admin.Score = score}' , '{admin.Grade = grade}' ,'{admin.Coursename = coursename}' , '{admin.Courseunit = courseunit}')" , connection);
                var execute =insert.ExecuteNonQuery();
                if (execute <= 5)
                {
                Console.WriteLine("Result  created successfully");
                }
                else
                {
                    Console.WriteLine("Unable to Create Result");
                }
            } 
       }
   }

    public static void GetResultAndScore()
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        {
            connection.Open();
            Console.WriteLine("Enter student id to check result");
            int stu_id = int.Parse(Console.ReadLine());
            string selectQuery = $"select  student_id , course_id , score , grade, coursename , courseunit from Result where result.student_id = {stu_id};";
            using ( MySqlCommand insert = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = insert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    Console.WriteLine($"Student_ID: {reader["student_id"]}, course id : {reader["course_id"]}, score : {reader["score"]}, grade: {reader["grade"]} , coursename: {reader["coursename"]} , courseunit : {reader["courseunit"]};");
                    }
                }
            }
       }
    }

    public static void GetResultByTeacher()
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        {
            connection.Open();
            Console.WriteLine("Enter course id to check results of students");
            int stu_id = int.Parse(Console.ReadLine());
            string selectQuery = $"select  student_id , course_id , score , grade, coursename , courseunit from Result where result.course_id = {stu_id};";
            using ( MySqlCommand insert = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataReader reader = insert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Student_ID: {reader["student_id"]}, course id : {reader["course_id"]}, score : {reader["score"]}, grade: {reader["grade"]} , coursename: {reader["coursename"]} , courseunit : {reader["courseunit"]};");
                    }
                }
            }
        }
    }

}
