# AutoInsta
AutoInsta is a C# project to automate the process of following random users who liked a post from your feed. It uses a timer to execute the follow logic at regular intervals.

# How it works
1 - Get the posts from your feed.

2 - Filter out the posts that are older than 2 days.
Randomly select one of the posts.

3 - Get the list of users who liked the post.
Randomly select one of the likers.

4- Follow the liker and check the result.
The project also handles any errors that may occur during the process, such as failed API calls or exceptions, and writes them to the console.

# How to use
To use this project, you need to install the InstagramApiSharp library using the NuGet Package Manager.

You can clone or download this project from GitHub and open it in Visual Studio.
Find the ReferenceData file in the `Tools` folder, You need to modify the ReferenceData class to enter your own username and password, and optionally change the hashtags and time interval.


