using System.IO;
using System.Linq;
using System.Text;
using System;
public class Admin
{
    public int Id { get; set;}
    public string Email { get; set;}
    public string Password { get; set;}
    
public Admin ()
{}

public Admin ( string email  , string password)
{
    Email = email;
    Password = password;
}

}

