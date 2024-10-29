using System.IO;
using System.Linq;
using System.Text;
using System;
public class Course
{
    public string Coursename { get; set;}
     public string Coursetitle { get; set;}
    public int Courseunit { get; set;}
    public string Instructor { get; set;}
    public string Deadline { get; set;}


    
public Course ()
{}

public Course (string coursename , int courseunit , string coursetitle, string instructor , string deadline )
{
    Coursename = coursename;
    Coursetitle = coursetitle;
    Courseunit = courseunit;
    Instructor = instructor;
    Deadline = deadline;
}

}

