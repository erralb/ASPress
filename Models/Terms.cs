using System;
using System.Collections.Generic;

namespace ASPress.Models
{
    public partial class Terms
    {
        public Terms()
        {
            InverseParent = new HashSet<Terms>();
        }

        public long Id { get; set; }
        public string PostType { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public long? ParentId { get; set; }
        public long? ImageId { get; set; }

        public Terms Parent { get; set; }
        public ICollection<Terms> InverseParent { get; set; }
    }
}
