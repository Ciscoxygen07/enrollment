using System.IO;
using System.Linq;
using System.Text;
using System;
public class Result
{
    public int Course_id { get; set; }
    public int Student_id { get; set; }
    public int Score { get; set; }
    public string Coursename { get; set; }
    public int Courseunit { get; set; }
    public char Grade { get; set; }
public Result ()
{}

public Result (int course_id, int student_id, int score , string coursename , int courseunit ,  char grade  )
{
 Course_id = course_id;
 Student_id = student_id;   
 Score = score;
 Coursename = coursename;
 Courseunit = courseunit;
 Grade = grade;
}

}

