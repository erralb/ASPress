using System;
using System.Collections.Generic;

namespace ASPress.Models
{
    public partial class Roles
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Permissions { get; set; }
    }
}
