using System.Web.Mvc;
using System.Linq;
using Insurance.Models;
using Insurance.Repositories.Implementations;
using Insurance.Repositories.Interfaces;
using System.Collections.Generic;
using System;

namespace Insurance.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IPolicyRepository policyRepository = new PolicyRepository();
        private readonly ICoverageRepository coverageRepository = new CoverageRepository();

        // GET: Policies
        public ActionResult Index()
        {
            var policies = policyRepository.Get();

            return View(policies);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            ViewBag.Coverages = coverageRepository.Get().Select(coverage => new SelectListItem
            {
                Text = coverage.Type.ToString(),
                Value = coverage.Id.ToString()
            });

            return View();
        }

        // GET: Policies/5
        [Route("Policy/{id}")]
        public ActionResult Edit(int id)
        {
            Policy policy = policyRepository.Get(id);
            IList<Coverage> policyCoverages = coverageRepository.GetByPolicy(id);

            ViewBag.Coverages = coverageRepository.Get().Except(policyCoverages).Select(coverage => new SelectListItem
            {
                Text = coverage.Type.ToString(),
                Value = coverage.Id.ToString()
            });

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
                policyRepository.Post(policy);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // PUT: Policies/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Coverage,CoverPercentage,StartDate,CoverMonths,Price,Risk")] Policy policy)
        {
            List<int> coveragesId = Request.Form["Coverages"].Split(',').Select(id => Convert.ToInt32(id)).ToList();

            if (ModelState.IsValid)
            {
                policyRepository.Put(policy);
                policyRepository.SavePolicyCoverages(policy.Id, coveragesId);

                return RedirectToAction(nameof(Index));
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        public ActionResult Delete(int id)
        {
            policyRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }        
    }
}
