using Microsoft.AspNetCore.Mvc;
using municipalService.Models;
using municipalService.Storage;
using System.Linq;

namespace municipalService.Controllers
{
    public class ServiceController : Controller
    {
        private static readonly ServiceRequestBST bst = new();

        public IActionResult StatusPage()
        {
            var sortedRequests = bst.InOrderTraversal()
                .OrderBy(r => r.Priority)          
                .ThenBy(r => r.SubmittedAt)
                .ToList();

            return View(sortedRequests);
        }

        [HttpPost]
        public IActionResult TrackRequest(string id)
        {
            var request = bst.Search(id);
            if (request == null)
            {
                ViewBag.Message = "Request not found.";
                return View(new List<ServiceRequest>());
            }

            ViewBag.Message = $"Status: {request.Status}, Progress: {request.Progress}%";

            // ✅ Still sort the full list for consistency
            var sortedRequests = bst.InOrderTraversal()
                .OrderBy(r => r.Priority)
                .ThenBy(r => r.SubmittedAt)
                .ToList();

            return View(sortedRequests);
        }
    }
}