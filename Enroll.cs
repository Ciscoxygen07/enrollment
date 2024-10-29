using System.IO;
using System.Linq;
using System.Text;
using System;
public class Enroll
{
    public int CourseId { get; set;}
    public int StudentId { get; set;} 
public Enroll ()
{}

public Enroll ( int courseid  , int studentid)
{
    CourseId = courseid;
    StudentId = studentid;
}
}

