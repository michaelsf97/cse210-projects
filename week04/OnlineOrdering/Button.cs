using System;

public class Button
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void Click()
    {
        Console.WriteLine("Button clicked!");
    }
}

public class TextButton : Button
{
    public string Text { get; set; }
}

public class ImageButton : Button
{
    public string ImagePath { get; set; }
}

public class Button
{
    static void Main(string[] args)
    {
        TextButton tb = new TextButton();
        tb.Width = 100;
        tb.Height = 30;
        tb.Text = "Click Me!";
        tb.Click();

        ImageButton ib = new ImageButton();
        ib.Width = 100;
        ib.Height = 30;
        ib.ImagePath = "iconbutton.png";
        ib.Click();
    }
}