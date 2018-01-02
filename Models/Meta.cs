using System;
using System.Collections.Generic;

namespace ASPress.Models
{
    public partial class Meta
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public long ModelId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
