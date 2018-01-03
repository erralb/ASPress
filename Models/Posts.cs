
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;    

namespace ASPress.Models
{
    public class Posts
    {
        public Posts() => Comments = new HashSet<Comments>();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Display(Name = "Created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        
        public Nullable<DateTime> DateModified { get; set; }

        [Display(Name = "Published")]
        [DataType(DataType.Date)]
        
        public DateTime DatePublish { get; set; }

        public Users Author { get; set; }
        public ICollection<Comments> Comments { get; set; }

    }
}
