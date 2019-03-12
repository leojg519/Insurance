using System.Web.Mvc;
using Insurance.ApiControllers;
using Insurance.Models;

namespace Insurance.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly ApiPolicyController policyApi = new ApiPolicyController();

        // GET: Policies
        public ActionResult Index()
        {
            var policies = policyApi.Get();

            return View(policies);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Policies/5
        public ActionResult Edit(int id)
        {
            Policy policy = policyApi.Get(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

            return View(policy);
        }

        // POST: Policies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Coverage,CoverPercentage,StartDate,CoverMonths,Price,Risk")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                policyApi.Post(policy);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // PUT: Policies/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Coverage,CoverPercentage,StartDate,CoverMonths,Price,Risk")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                policyApi.Put(policy);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        public ActionResult Delete(int id)
        {
            policyApi.Delete(id);

            return RedirectToAction(nameof(Index));
        }        
    }
}
