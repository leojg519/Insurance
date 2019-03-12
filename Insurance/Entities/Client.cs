using System.Collections.Generic;

namespace Insurance.Entities
{
    /// <summary>
    /// Client Entity
    /// </summary>
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public IList<Policy> Policies { get; set; }
    }
}