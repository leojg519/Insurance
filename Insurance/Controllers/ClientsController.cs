using System.Data.Entity;
using System.Web.Mvc;
using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;

namespace Insurance.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository clientRepository = new ClientRepository();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = clientRepository.Get();

            return View(clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Address,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientRepository.Post(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            Client client= clientRepository.Get(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // PUT: Clients/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientRepository.Put(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clientRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
