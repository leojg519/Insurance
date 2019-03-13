using Insurance.Models;
using System.Collections.Generic;

namespace Insurance.Repositories.Interfaces
{
    /// <summary>
    /// Coverage Repository Interface
    /// </summary>
    public interface ICoverageRepository
    {
        /// <summary>
        /// Get all coverage
        /// </summary>
        /// <returns>Coverages</returns>
        IList<Coverage> Get();

        /// <summary>
        /// Get coverages by policy ID
        /// </summary>
        /// <param name="policyId">Policy ID</param>
        /// <returns>Coverages by policy ID</returns>
        IList<Coverage> GetByPolicy(int policyId);
    }
}
