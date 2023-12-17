using AutoInsta.Tools;


namespace InstagramAutomation
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            // Initialize the Instagram API and login
            await InstagramApiHelper.InitInstagramApiAsync();

            // Start the timer
            TimerHelper.StartTimer();

            // Prompt the user to press any key to exit
            ReferenceData.WriteLine("Press any key to exit...", ConsoleColor.Yellow);

            // Wait for the user to press any key
            Console.ReadKey();

            // Stop the timer and dispose it
            TimerHelper.StopTimer();
        } 
    }
}
