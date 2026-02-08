using System;

public class Person
{
    public string GetName()
    {
        return "Joseph";    
    }
}

public class Student : Person
{
    public string GetNumber()
    {
        return "12345";
    }
}

class Example
{
    static void Main(string[] args)
    {
        Student student = new Student();
        Console.WriteLine(student);
    }
}