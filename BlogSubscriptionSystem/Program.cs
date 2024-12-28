using BlogSubscriptionSystem.Events;
using BlogSubscriptionSystem.Model;

namespace BlogSubscriptionSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var blogPublisher = new BlogPublisher();
            var subscribers = new List<BlogSubscriber>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("**********Blog Subscription System**********");
                Console.WriteLine("1. Subscribe to notifications");
                Console.WriteLine("2. Unsubscribe from notifications");
                Console.WriteLine("3. Publish a new blog post");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Subscribe
                        Console.Write("\nEnter your name to subscribe: ");
                        string nameToSubscribe = Console.ReadLine();
                        var newSubscriber = new BlogSubscriber(nameToSubscribe);
                        blogPublisher.NewPostPublished += newSubscriber.OnNewPostPublished;
                        subscribers.Add(newSubscriber);
                        Console.WriteLine($"\n{nameToSubscribe} has been subscribed to new blog posts!");
                        break;

                    case "2":
                        // Unsubscribe
                        Console.Write("\nEnter your name to unsubscribe: ");
                        string nameToUnsubscribe = Console.ReadLine();
                        var subscriberToRemove = subscribers.Find(s => s.Name == nameToUnsubscribe);
                        if (subscriberToRemove != null)
                        {
                            blogPublisher.NewPostPublished -= subscriberToRemove.OnNewPostPublished;
                            subscribers.Remove(subscriberToRemove);
                            Console.WriteLine($"\n{nameToUnsubscribe} has been unsubscribed from new blog posts!");
                        }
                        else
                        {
                            Console.WriteLine($"\nNo subscriber found with the name {nameToUnsubscribe}.");
                        }
                        break;

                    case "3":
                        // Publish a new blog post
                        Console.Write("\nEnter the title of the blog post: ");
                        string title = Console.ReadLine();
                        Console.Write("\nEnter the content of the blog post: ");
                        string content = Console.ReadLine();
                        Console.WriteLine();
                        blogPublisher.PublishNewPost(title, content);
                        break;

                    case "4":
                        // Exit the application
                        Console.WriteLine("\nExiting the application. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }

                // Wait for user input to continue
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
