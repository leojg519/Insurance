using Insurance.Enums;
using System;

namespace Insurance.Entities
{
    /// <summary>
    /// Insurance policy entity
    /// </summary>
    public class Policy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CoverageType Coverage { get; set; }
        
        public int CoverPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public int CoverMonths { get; set; }

        public int Price { get; set; }

        public RiskType Risk { get; set; }
    }
}