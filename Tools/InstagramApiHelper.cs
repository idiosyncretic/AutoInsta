using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using System.IO;

namespace AutoInsta.Tools
{
    public class InstagramApiHelper
    {
        // Create an instance of the Instagram API
        public static IInstaApi _instaApi;

        public static async Task InitInstagramApiAsync()
        {
            // Create a user session data with your credentials
            var userSession = new UserSessionData
            {
                UserName = ReferenceData.USERNAME,
                Password = ReferenceData.PASSWORD
            };

            // Create a new instance of the API
            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .Build();

            // Try to load the session data from a file
            var stateFile = "state.bin";
            if (File.Exists(stateFile))
            {
                ReferenceData.WriteLine("Loading state from file", ConsoleColor.Yellow);
                using (var fs = File.OpenRead(stateFile))
                {
                    _instaApi.LoadStateDataFromStream(fs);
                }
            }

            // Check if the user is logged in
            if (!_instaApi.IsUserAuthenticated)
            {
                // Login and check the result
                var loginResult = await _instaApi.LoginAsync();
                if (loginResult.Succeeded)
                {
                    ReferenceData.WriteLine($"Logged in as {ReferenceData.USERNAME}", ConsoleColor.Green);
                    // Save the session data to a file
                    var state = _instaApi.GetStateDataAsStream();
                    using (var fileStream = File.Create(stateFile))
                    {
                        state.Seek(0, SeekOrigin.Begin);
                        state.CopyTo(fileStream);
                    }
                }
                else
                {
                    ReferenceData.WriteLine($"Login failed: {loginResult.Info.Message}", ConsoleColor.Red);
                    Environment.Exit(1);
                }
            }
            else
            {
                ReferenceData.WriteLine($"Already logged in as {ReferenceData.USERNAME}", ConsoleColor.Yellow);
            }
        }
    }
}
