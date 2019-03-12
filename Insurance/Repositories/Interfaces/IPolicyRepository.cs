﻿using Insurance.Models;
using System.Collections.Generic;

namespace Insurance.Repositories.Interfaces
{
    /// <summary>
    /// Policy Repository Interface
    /// </summary>
    public interface IPolicyRepository
    {
        /// <summary>
        /// Get all policies
        /// </summary>
        /// <returns></returns>
        IList<Policy> Get();

        /// <summary>
        /// Get specific policy by ID
        /// </summary>
        /// <param name="id">Policy ID</param>
        /// <returns>Policy by ID</returns>
        Policy Get(int id);

        /// <summary>
        /// Create a new policy
        /// </summary>
        /// <param name="policy">New policy</param>
        void Post(Policy policy);

        /// <summary>
        /// Update existing policy
        /// </summary>
        /// <param name="policy">New policy</param>
        void Put(Policy policy);

        /// <summary>
        /// Delete existing policy
        /// </summary>
        /// <param name="id">Policy ID</param>
        void Delete(int id);
    }
}