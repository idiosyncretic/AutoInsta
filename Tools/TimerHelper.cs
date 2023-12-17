using InstagramApiSharp;
using InstagramApiSharp.API;

namespace AutoInsta.Tools
{
    public class TimerHelper
    {
        // Create a timer to execute the follow logic
        private static System.Timers.Timer _timer = new System.Timers.Timer(); // Create a new instance of System.Timers.Timer

        public static void StartTimer()
        {
            // Create a new timer with the specified time interval
            _timer = new System.Timers.Timer(ReferenceData.TIME_INTERVAL); // Remove the callback parameter

            // Set the timer to execute the follow logic on each elapsed event
            _timer.Elapsed += async (sender, e) => await FollowRandomUserAsync();

            // Start the timer
            _timer.Enabled = true;
            ReferenceData.WriteLine($"Timer started with interval {ReferenceData.TIME_INTERVAL / 1000}s", ConsoleColor.Cyan);
        }

        public static void StopTimer()
        {
            // Stop the timer
            _timer.Enabled = false;
            ReferenceData.WriteLine("Timer stopped", ConsoleColor.Red);
        }

        private static async Task FollowRandomUserAsync()
        {
            try
            {
                // Get the posts from your feed
                var postsResult = await InstagramApiHelper._instaApi.FeedProcessor.GetUserTimelineFeedAsync(PaginationParameters.MaxPagesToLoad(1));
                if (!postsResult.Succeeded)
                {
                    ReferenceData.WriteLine($"Failed to get posts: {postsResult.Info.Message}", ConsoleColor.Red);
                    return;
                }

                // Filter out the posts that are older than 2 days
                var posts = postsResult.Value.Medias.Where(p => (DateTime.UtcNow - p.TakenAt).TotalDays <= 2).ToList();
                if (posts.Count == 0)
                {
                    ReferenceData.WriteLine("No posts found within 2 days", ConsoleColor.Red);
                    return;
                }

                // Randomly select one of the posts
                var post = posts[new Random().Next(posts.Count)];
                ReferenceData.WriteLine($"Selected post: {post.Code}", ConsoleColor.Green);

                // Get the list of users who liked the post
                var likersResult = await InstagramApiHelper._instaApi.MediaProcessor.GetMediaLikersAsync(post.InstaIdentifier);
                if (!likersResult.Succeeded)
                {
                    ReferenceData.WriteLine($"Failed to get likers: {likersResult.Info.Message}", ConsoleColor.Red);
                    return;
                }

                // Randomly select one of the likers
                var likers = likersResult.Value;
                var liker = likers[new Random().Next(likers.Count)];
                ReferenceData.WriteLine($"Selected liker: {liker.UserName}", ConsoleColor.Green);

                // Follow the liker and check the result
                var followResult = await InstagramApiHelper._instaApi.UserProcessor.FollowUserAsync(liker.Pk);
                if (followResult.Succeeded)
                {
                    ReferenceData.WriteLine($"Followed {liker.UserName}", ConsoleColor.Green);
                }
                else
                {
                    ReferenceData.WriteLine($"Failed to follow {liker.UserName}: {followResult.Info.Message}", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                // Handle any exception that may occur
                ReferenceData.WriteLine($"An error occurred: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
