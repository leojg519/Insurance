using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Insurance.ApiControllers
{
    /// <summary>
    /// API Client controller
    /// </summary>
    public class ApiClientController : ApiController
    {
        /// <summary>
        /// Private client repository
        /// </summary>
        private IClientRepository clientRepository = new ClientRepository();

        /// <summary>
        /// Private policy repository
        /// </summary>
        private IPolicyRepository policyRepository = new PolicyRepository();


        // GET api/values
        public IList<Client> Get()
        {
            return clientRepository.Get();
        }

        // GET api/values/5
        public Client Get(int id)
        {
            return clientRepository.Get(id);
        }

        // POST api/values
        public void Post([FromBody]Client client)
        {
            clientRepository.Post(client);
        }

        // POST api/client/5/1
        [Route("api/client/{clientId}/add")]
        public void AddPolicyToClient(int clientId, List<int> policies)
        {
            clientRepository.SaveClientPolicies(clientId, policies);
        }

        // PUT api/values/5
        public void Put([FromBody]Client client)
        {
            clientRepository.Put(client);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            clientRepository.Delete(id);
        }
    }
}
