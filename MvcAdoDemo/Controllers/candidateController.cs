using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcAdoDemo.Models;

namespace MvcAdoDemo.Controllers
{
    // Keep original route/controller naming for compatibility with the archived views.
    public class candidateController : Controller
    {
        private readonly CandidateDataAccessLayer data = new CandidateDataAccessLayer();

        public IActionResult Index()
        {
            return View(data.GetAllCandidate().ToList());
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(candidate value)
        {
            if (!ModelState.IsValid) return View(value);
            data.AddCandidate(value);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return NotFound();
            var value = data.GetCandidateData(id);
            if (value == null) return NotFound();
            return View(value);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return NotFound();
            var value = data.GetCandidateData(id);
            if (value == null) return NotFound();
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, candidate value)
        {
            if (id != value.Regno) return NotFound();
            if (!ModelState.IsValid) return View(value);
            if (data.GetCandidateData(id) == null) return NotFound();
            data.UpdateCandidate(value);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();
            var value = data.GetCandidateData(id);
            if (value == null) return NotFound();
            return View(value);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue || data.GetCandidateData(id) == null) return NotFound();
            data.DeleteCandidate(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
