using System.Web.Mvc;
using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;

namespace Insurance.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyRepository policyRepository = new PolicyRepository();

        // GET: Policies
        public ActionResult Index()
        {
            var policies = policyRepository.Get();

            return View(policies);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Policies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Coverage,CoverPercentage,StartDate,CoverMonths,Price,Risk")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                policyRepository.Post(policy);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // GET: Policies/5
        public ActionResult Edit(int id)
        {
            Policy policy = policyRepository.Get(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

            return View(policy);
        }

        // PUT: Policies/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Coverage,CoverPercentage,StartDate,CoverMonths,Price,Risk")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                policyRepository.Put(policy);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            policyRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }        
    }
}
