using System;
using System.Collections.Generic;
using System.Linq;
using Insurance.DAL;
using Insurance.Models;
using Insurance.Repositories.Interfaces;

namespace Insurance.Repositories.Implementations
{
    /// <summary>
    /// Client respository
    /// </summary>
    public class CoverageRepository : ICoverageRepository, IDisposable
    {
        /// <summary>
        /// Db access
        /// </summary>
        private InsuranceContext db = new InsuranceContext();

        /// <summary>
        /// Get all coverages
        /// </summary>
        /// <returns>Coverages</returns>
        public IList<Coverage> Get() => db.Coverages.ToList();

        /// <summary>
        /// Get coverages by policy ID
        /// </summary>
        /// <param name="policyId">Policy ID</param>
        /// <returns>Coverages by policy ID</returns>
        public IList<Coverage> GetByPolicy(int policyId) => db.Policies.Find(policyId).Coverages.ToList();
                
        /// <summary>
        /// Disposable implementation
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }
    }
}