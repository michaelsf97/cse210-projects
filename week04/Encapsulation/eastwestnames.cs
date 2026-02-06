// A code template for category of things known as Person.
// The responsibility of a Person is to hold and display information.

public class Person
{
    // The C# convention is to start member variables with an underscore _
    private string _givenname = "";
    private string _familyname = "";

    // A special method, called a constructor that is invoked using the
    // new keyword followed by the class name.

    public Person()
    {
        
    }

    // A method that displays the person's full name as used in eastern
    // countries or <family name> <given name>.

    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyname} {_givenname}");
    }

    // A method that displays the person's full name as used in western
    // countries or <given name> <family name>.

    public void ShowWesternName()
    {
        Console.WriteLine($"{_givenname} {_familyname}");
    }
}