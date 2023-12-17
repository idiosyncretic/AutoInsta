# AutoInsta
AutoInsta is a C# project to automate the process of following random users who liked a post from your feed. It uses a timer to execute the follow logic at regular intervals.

# How it works
The project consists of two classes: ReferenceData and TimerHelper.

The ReferenceData class contains some fields that store the username, password, hashtags, and time interval for the project. It also contains a static method that writes a message to the console with a specified color.

The TimerHelper class contains methods to start and stop a timer, and a private method to follow a random user. The timer is created with the time interval specified in the ReferenceData class, and it triggers the follow logic on each elapsed event. The follow logic does the following steps:

Get the posts from your feed using the GetUserTimelineFeedAsync method from the Instagram API.
Filter out the posts that are older than 2 days.
Randomly select one of the posts.
Get the list of users who liked the post using the GetMediaLikersAsync method from the Instagram API.
Randomly select one of the likers.
Follow the liker using the FollowUserAsync method from the Instagram API and check the result.
The project also handles any errors that may occur during the process, such as failed API calls or exceptions, and writes them to the console.

# How to use
To use this project, you need to install the InstagramApiSharp library using the NuGet Package Manager.

You can clone or download this project from GitHub and open it in Visual Studio. You need to modify the ReferenceData class to enter your own username and password, and optionally change the hashtags and time interval.


