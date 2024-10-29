using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
 public class AdminTable
 {
    private static List<Admin> adm = new List<Admin>();
    private static List <Course> course = new List <Course> ();
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

    public static void CreateAdminTb()
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "Create table if not exists SchoolDataBase.Admin(Admin_Id int primary key not null unique auto_increment,  Email varchar (255) not null , Password varchar (255) not null );";

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

   public static bool AdminLog(Admin admin)
   {
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Password : ");
        string password = Console.ReadLine();
        foreach (var use in adm)
        {
            if (use.Email == "admin123@gmail.com" && use.Password == "123")
            {
            return true;     
            }
        }
     
        using(MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            MySqlCommand insert =  new MySqlCommand($"insert into Admin(EMAIL,PASSWORD) values ( '{admin.Email = email}' , '{admin.Password = password}');" , connection);
            var execute = insert.ExecuteNonQuery();
            if(execute == 0)
            {
                Console.WriteLine("Admin Created Succesfully");
            }
        }
        Console.WriteLine("You have successfully logged in as an admin");
            return false;
   }




    public static void CreateCourse(Course students)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            Console.WriteLine("Enter courseunit ");
            int courseunit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter coursename ");
            string coursename = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter course title ");
            string coursetitle = Console.ReadLine().ToLower();
            Console.WriteLine("Enter Teachername ");
            string instructor = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the day of teaching");
            string dateTime = Console.ReadLine();
            var set = new Course ( coursename , courseunit ,coursetitle, instructor , dateTime);
            course.Add (set);
            MySqlCommand insert = new MySqlCommand($"insert into SchoolDataBase.Course(coursename , coursetitle , courseunit , Teachername , datetime) values ('{students.Coursename = coursename}' , '{students.Coursetitle = coursetitle}' , '{students.Courseunit = courseunit}' , '{students.Instructor = instructor}' , '{students.Deadline = dateTime}')" , connection);
            var execute =insert.ExecuteNonQuery();
            if (execute <= 5)
            {
               Console.WriteLine("courses and instructor created created successfully");
            }
            else
            {
                Console.WriteLine("Unable to Create courses and instructor created created successfully");
            }
        }
    }
}