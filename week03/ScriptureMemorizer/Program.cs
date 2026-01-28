using System;

class Program
{
    static void Main(string[] args)
    
    {
        Console.WriteLine("Welcome to the Scripture Memorizer");

        
        List<string> scriptures = new List<string>();
        var rand = new Random();
        scriptures.Add("John 3:16 ¶ For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scriptures.Add("Proverbs 3:5-6 5 ¶ Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        scriptures.Add("Philippians 4:13 ¶ I can do all things through Christ which strengtheneth me.");
        scriptures.Add("Psalm 23:1 ¶ The Lord is my shepherd; I shall not want.");
        scriptures.Add("Romans 8:28 ¶ And we know that all things work together for good to them that love God, to them who are the called according to his purpose.");
        scriptures.Add("Isaiah 41:10 ¶ Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness.");
        scriptures.Add("Matthew 11:28 ¶ Come unto me, all ye that labour and are heavy laden, and I will give you rest.");
        scriptures.Add("2 Timothy 1:7 ¶ For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind.");
        scriptures.Add("Hebrews 11:1 ¶ Now faith is the substance of things hoped for, the evidence of things not seen.");
        scriptures.Add("Jeremiah 29:11 ¶ For I know the thoughts that I think toward you, saith the Lord, thoughts of peace, and not of evil, to give you an expected end.");

        foreach (string scripture in scriptures)
        {

            Console.WriteLine(scripture);
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            var words = scripture.Split(' ');
            var hidden = new bool[words.Length];
            // use the same Random instance for better randomness
            while (Array.Exists(hidden, h => !h))
            {
                Console.Clear();
                for (int i = 0; i < words.Length; i++)
                    Console.Write(hidden[i] ? "_____ " : words[i] + " ");
                Console.WriteLine();
                Console.WriteLine("\nPress Enter to hide more words");
                Console.ReadKey(true);
                int count = 0;
                while (count < 2 && Array.Exists(hidden, h => !h))
                {
                    int index = rand.Next(words.Length);
                    if (!hidden[index]) { hidden[index] = true; count++; }
                }
            }
            // After all words are hidden, show the fully hidden scripture one last time
            Console.Clear();
            for (int i = 0; i < words.Length; i++)
                Console.Write("_____ ");
            Console.WriteLine();
        }

        Console.Clear();
    Console.WriteLine("Press Enter to exit...");
    Console.ReadLine();
    }
}