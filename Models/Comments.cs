using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPress.Models
{
    public partial class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public long PostId { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }

        public Posts Post { get; set; }
    }
}
