using System.IO;
using System.Linq;
using System.Text;
using System;
public class Teacher
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Email { get; set;}
    public string Password { get; set;}
    
public Teacher ()
{}

public Teacher ( string name , string email  , string password)
{
    Name = name;
    Email = email;
    Password = password;
}
}

