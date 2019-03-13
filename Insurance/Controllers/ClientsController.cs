using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;

namespace Insurance.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository clientRepository = new ClientRepository();
        private readonly IPolicyRepository policyRepository = new PolicyRepository();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = clientRepository.Get();

            return View(clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.Policies = policyRepository.Get().Select(policy => new SelectListItem
            {
                Text = policy.Name,
                Value = policy.Id.ToString()
            });

            return View();
        }

        // GET: Clients/Edit/5
        [Route("Client/{id}")]
        public ActionResult Edit(int id)
        {
            Client client = clientRepository.Get(id);
            IList<Policy> clientPolicies = policyRepository.GetByClient(id);

            ViewBag.Policies = policyRepository.Get().Except(clientPolicies).Select(policy => new SelectListItem
            {
                Text = policy.Name,
                Value = policy.Id.ToString()
            });

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
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

        // PUT: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,Phone")] Client client)
        {
            List<int> policiesId = Request.Form["Policies"].Split(',').Select(id => Convert.ToInt32(id)).ToList();
            
            if (ModelState.IsValid)
            {
                clientRepository.Put(client);
                clientRepository.SaveClientPolicies(client.Id, policiesId);                

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            clientRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
