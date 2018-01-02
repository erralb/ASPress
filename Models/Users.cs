using System;
using System.Collections.Generic;

namespace ASPress.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public string DateLastLogin { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
