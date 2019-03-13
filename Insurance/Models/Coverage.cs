using Insurance.Enums;
using System.Collections.Generic;

namespace Insurance.Models
{
    public class Coverage
    {
        public int Id { get; set; }

        public CoverageType Type { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}