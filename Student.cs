using System.IO;
using System.Linq;
using System.Text;
using System;
public class Student
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Email { get; set;}
    public string Password { get; set;}
    public DateTime Created { get; set;}
    public char Gender { get; set;}
    public string Coursesenrollment { get; set;}


    
public Student ()
{}

public Student ( string name , string password,  string email , char gender)
{
    Name = name;
    Email = email;
  Password = password;
  Gender = gender;
}

}

