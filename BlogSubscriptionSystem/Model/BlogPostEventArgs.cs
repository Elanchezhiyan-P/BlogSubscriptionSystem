using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSubscriptionSystem.Model
{
    public class BlogPostEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
