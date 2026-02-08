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
    public static void Run()
    {
        Student student = new Student();
        Console.WriteLine($"Name: {student.GetName()}");
        Console.WriteLine($"Number: {student.GetNumber()}");
    }
}