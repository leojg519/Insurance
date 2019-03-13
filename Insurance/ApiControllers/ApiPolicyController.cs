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
    public class ApiPolicyController : ApiController
    {
        /// <summary>
        /// Private policy repository
        /// </summary>
        private IPolicyRepository policyRepository = new PolicyRepository();


        // GET api/policies
        public IList<Policy> Get()
        {
            return policyRepository.Get();
        }

        // GET api/policies/5
        public Policy Get(int id)
        {
            return policyRepository.Get(id);
        }        

        // GET api/policies/client/5
        [Route("api/policies/client/clientId")]
        public IList<Policy> GetByClient(int clientId)
        {
            return policyRepository.GetByClient(clientId);
        }

        // POST api/policies
        public void Post([FromBody]Policy policy)
        {
            policyRepository.Post(policy);
        }

        // PUT api/policies/5
        public void Put([FromBody]Policy policy)
        {
            policyRepository.Put(policy);
        }

        // DELETE api/policies/5
        public void Delete(int id)
        {
            policyRepository.Delete(id);
        }
    }
}
