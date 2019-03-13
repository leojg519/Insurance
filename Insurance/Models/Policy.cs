using Insurance.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    /// <summary>
    /// Policy model
    /// </summary>
    public class Policy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CoverPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        public int CoverMonths { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public int Price { get; set; }

        public RiskType Risk { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Coverage> Coverages { get; set; }
    }
}