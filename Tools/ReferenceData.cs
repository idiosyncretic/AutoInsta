namespace AutoInsta.Tools
{
    public static partial class ReferenceData
    {

        static public void WriteLine(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public const string USERNAME = "Add Your Username here";
        public const string PASSWORD = "Add Your Password here";
        // Define a list of hashtags to search for //this isn't being used currently
        /*
        public static readonly List<string> HASHTAGS = new List<string>
        {
            "travel",
            "photography",
            "art",
            "fitness",
            "food"
        }; */

        // Define a time interval to follow random users (in milliseconds)
        public const int TIME_INTERVAL = 40000;
    }

    // A function that writes a message to the console with a specified color


}
