using BlogSubscriptionSystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSubscriptionSystem.Model
{
    public class BlogSubscriber
    {
        public string Name { get; set; }

        public BlogSubscriber(string name)
        {
            Name = name;
        }

        // Event handler that will be called when a new post is published
        public void OnNewPostPublished(object sender, BlogPostEventArgs e)
        {
            Console.WriteLine($"{Name} received notification: New post published! \nTitle: {e.Title}");
            Console.WriteLine($"Content: {e.Content}\n");
        }
    }
}
