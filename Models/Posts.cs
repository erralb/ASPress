using System;
using System.Collections.Generic;

namespace ASPress.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Visibility { get; set; }
        public string Password { get; set; }
        public long AuthorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DatePublish { get; set; }

        public Users Author { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
