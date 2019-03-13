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
        public Policy Get(int id) => db.Policies.Include(policy => policy.Coverages).FirstOrDefault(policy => policy.Id == id);

        /// <summary>
        /// Get policies by client ID
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <returns>Policies by client ID</returns>
        public IList<Policy> GetByClient(int clientId) => db.Clients.Find(clientId).Policies.ToList();


        /// <summary>
        /// Create a new policy
        /// </summary>
        /// <param name="policy">New policy</param>
        public void Post(Policy policy)
        {
            policy = verifyRisk(policy);
            db.Policies.Add(policy);
            db.SaveChanges();
        }

        /// <summary>
        /// Update existing policy
        /// </summary>
        /// <param name="policy">New policy</param>
        public void Put(Policy policy)
        {
            policy = verifyRisk(policy);
            db.Entry(policy).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Add coverages to existing policy
        /// </summary>
        /// <param name="policyId">Policy ID</param>
        /// <param name="coverages">Coverages ID</param>
        public void SavePolicyCoverages(int policyId, List<int> coverages)
        {
            Policy policy = Get(policyId);

            if (policy != null)
            {
                if (policy.Coverages == null)
                {
                    policy.Coverages = new List<Coverage>();
                }
                else
                {
                    policy.Coverages.Clear();
                }

                foreach (var coverageId in coverages)
                {
                    Coverage policyCoverage = db.Coverages.Find(coverageId);

                    if (policyCoverage != null)
                    {
                        policy.Coverages.Add(policyCoverage);
                        db.Entry(policy).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
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

        /// <summary>
        /// Verify risk level and coverage percent for the policy
        /// </summary>
        /// <param name="policy">Current policy</param>
        /// <returns>Policy with the right coverage value</returns>
        private Policy verifyRisk(Policy policy)
        {
            if (policy.Risk == Enums.RiskType.High && policy.CoverPercentage > 50)
            {
                policy.CoverPercentage = 50;
            }

            return policy;
        }
    }
}