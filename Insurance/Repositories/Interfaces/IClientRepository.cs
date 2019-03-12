using Insurance.Models;
using System.Collections.Generic;

namespace Insurance.Repositories.Interfaces
{
    /// <summary>
    /// Client Repository Interface
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        IList<Client> Get();

        /// <summary>
        /// Get specific client by ID
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Client by ID</returns>
        Client Get(int id);

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="client">New client</param>
        void Post(Client client);

        /// <summary>
        /// Update existing client
        /// </summary>
        /// <param name="client">New client</param>
        void Put(Client client);

        /// <summary>
        /// Delete existing client
        /// </summary>
        /// <param name="id">Client ID</param>
        void Delete(int id);
    }
}
