using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Insurance.ApiControllers;
using Insurance.Models;

namespace Insurance.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApiClientController clientApi = new ApiClientController();
        private readonly ApiPolicyController policyApi = new ApiPolicyController();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = clientApi.Get();

            return View(clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.Policies = policyApi.Get().Select(policy => new SelectListItem
            {
                Text = policy.Name,
                Value = policy.Id.ToString()
            });

            return View();
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            Client client = clientApi.Get(id);
            IList<Policy> clientPolicies = policyApi.GetByClient(client.Id);
            ViewBag.Policies = policyApi.Get().Except(clientPolicies).Select(policy => new SelectListItem
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
                clientApi.Post(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // PUT: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientApi.Put(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            clientApi.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
