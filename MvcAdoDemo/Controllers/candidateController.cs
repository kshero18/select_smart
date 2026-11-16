using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcAdoDemo.Models;
namespace MvcAdoDemo.Controllers
{
    public class candidateController : Controller
    {
        CandidateDataAccessLayer objcandidate = new CandidateDataAccessLayer();
        public IActionResult Index()
        {
            List<candidate> lstcandidate = new List<candidate>();
            lstcandidate = objcandidate.GetAllCandidate().ToList();
            return View(lstcandidate);
        }
        [HttpGet]  public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  [ValidateAntiForgeryToken]  public IActionResult Create([Bind] candidate candidate)
        {
            if (ModelState.IsValid)
            {
                objcandidate.AddCandidate(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);
        }
        [HttpGet]  public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            candidate candidate = objcandidate.GetCandidateData(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }
        [HttpPost]  [ValidateAntiForgeryToken]  public IActionResult Edit(int id, [Bind]candidate candidate)
        {
            if (id != candidate.Regno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objcandidate.UpdateCandidate(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);
        }
        [HttpGet]  public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            candidate candidate = objcandidate.GetCandidateData(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }
        [HttpGet]  public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            candidate candidate = objcandidate.GetCandidateData(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }
        [HttpPost, ActionName("Delete")]  [ValidateAntiForgeryToken]  public IActionResult DeleteConfirmed(int? id)
        {
            objcandidate.DeleteCandidate(id);
            return RedirectToAction("Index");
        }

    }
}