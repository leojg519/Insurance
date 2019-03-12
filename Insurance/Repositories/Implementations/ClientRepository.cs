using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Insurance.DAL;
using Insurance.Models;
using Insurance.Repositories.Interfaces;

namespace Insurance.Repositories.Implementations
{
    /// <summary>
    /// Client respository
    /// </summary>
    public class ClientRepository : IClientRepository, IDisposable
    {
        /// <summary>
        /// Db access
        /// </summary>
        private InsuranceContext db = new InsuranceContext();

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        public IList<Client> Get() => db.Clients.ToList();

        /// <summary>
        /// Get specific client by ID
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Client by ID</returns>
        public Client Get(int id) => db.Clients.Find(id);

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="client">New client</param>
        public void Post(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        /// <summary>
        /// Update existing client
        /// </summary>
        /// <param name="client">New client</param>
        public void Put(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Delete existing client
        /// </summary>
        /// <param name="id">Client ID</param>
        public void Delete(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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