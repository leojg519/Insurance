using System.Collections.Generic;
using System.Linq;
using Insurance.DAL;
using Insurance.Models;
using Insurance.Repositories.Interfaces;
using System;
using System.Data.Entity;

namespace Insurance.Repositories.Implementations
{
    /// <summary>
    /// Policy repository
    /// </summary>
    public class PolicyRepository : IPolicyRepository, IDisposable
    {
        /// <summary>
        /// Db access
        /// </summary>
        private InsuranceContext db = new InsuranceContext();

        /// <summary>
        /// Get all policies
        /// </summary>
        /// <returns></returns>
        public IList<Policy> Get() => db.Policies.ToList();

        /// <summary>
        /// Get specific policy by ID
        /// </summary>
        /// <param name="id">Policy ID</param>
        /// <returns>Policy by ID</returns>
        public Policy Get(int id) => db.Policies.Find(id);

        /// <summary>
        /// Create a new policy
        /// </summary>
        /// <param name="policy">New policy</param>
        public void Post(Policy policy)
        {
            if (policy.Risk == Enums.RiskType.High && policy.CoverPercentage > 50)
            {
                policy.CoverPercentage = 50;
            }

            db.Policies.Add(policy);
            db.SaveChanges();
        }

        /// <summary>
        /// Update existing policy
        /// </summary>
        /// <param name="policy">New policy</param>
        public void Put(Policy policy)
        {
            if (policy.Risk == Enums.RiskType.High && policy.CoverPercentage > 50)
            {
                policy.CoverPercentage = 50;
            }

            db.Entry(policy).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Delete existing policy
        /// </summary>
        /// <param name="id">Policy ID</param>
        public void Delete(int id)
        {
            Policy policy = db.Policies.Find(id);
            db.Policies.Remove(policy);
            db.SaveChanges();
        }

        /// <summary>
        /// Disposable implementation
        /// </summary>
        public void Dispose()
        {
            db.Dispose();            
        }
    }
}