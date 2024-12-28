using BlogSubscriptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSubscriptionSystem.Events
{
    public class BlogPublisher
    {
        public event EventHandler<BlogPostEventArgs> NewPostPublished;

        public void PublishNewPost(string title, string content)
        {
            // Create BlogPostEventArgs with the post details
            var args = new BlogPostEventArgs
            {
                Title = title,
                Content = content
            };

            // Raise the event to notify subscribers
            OnNewPostPublished(args);
        }

        // Method to trigger the event
        protected virtual void OnNewPostPublished(BlogPostEventArgs e)
        {
            NewPostPublished?.Invoke(this, e);
        }
    }
}
