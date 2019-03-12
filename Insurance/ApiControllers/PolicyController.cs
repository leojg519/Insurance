using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Insurance.ApiControllers
{
    /// <summary>
    /// API Policy controller
    /// </summary>
    public class PolicyController : ApiController
    {
        /// <summary>
        /// Private policy repository
        /// </summary>
        private IPolicyRepository policyRepository = new PolicyRepository();

        // GET api/values
        public IList<Policy> Get()
        {
            return policyRepository.Get();
        }

        // GET api/values/5
        public Policy Get(int id)
        {
            return policyRepository.Get(id);
        }

        // POST api/values
        public void Post([FromBody]Policy policy)
        {
            policyRepository.Post(policy);
        }

        // PUT api/values/5
        public void Put([FromBody]Policy policy)
        {
            policyRepository.Put(policy);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            policyRepository.Delete(id);
        }
    }
}
