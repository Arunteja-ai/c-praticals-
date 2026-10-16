using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Practical7_FeedbackManagementMVC.Models;

namespace Practical7_FeedbackManagementMVC.Controllers
{
    public class FeedbackController : Controller
    {
        // In-memory data store for feedbacks
        private static readonly List<Feedback> _feedbacks = new List<Feedback>
        {
            new Feedback
            {
                Id = 1,
                FullName = "Gandu Arunteja",
                Email = "arunteja@marwadiuniversity.ac.in",
                Category = "Lab & Infrastructure",
                Rating = 5,
                Comments = "High-configuration computer lab systems with .NET 10 and Visual Studio configured seamlessly. Excellent lab environment!",
                WouldRecommend = true,
                SubmittedAt = DateTime.Now.AddDays(-2)
            },
            new Feedback
            {
                Id = 2,
                FullName = "Pooja Patel",
                Email = "pooja.patel@example.com",
                Category = "Faculty & Teaching",
                Rating = 5,
                Comments = "Chetankumar Sir explains ASP.NET Core MVC concepts, Partial Views, and Model Validation with great practical depth.",
                WouldRecommend = true,
                SubmittedAt = DateTime.Now.AddDays(-1)
            },
            new Feedback
            {
                Id = 3,
                FullName = "Rohan Sharma",
                Email = "rohan.sharma@example.com",
                Category = "Course Curriculum",
                Rating = 4,
                Comments = "The syllabus covers relevant modern web frameworks like MVC, Razor Views, and Web APIs required for industry readiness.",
                WouldRecommend = true,
                SubmittedAt = DateTime.Now.AddHours(-6)
            }
        };

        private static readonly List<string> _categories = new List<string>
        {
            "Course Curriculum",
            "Faculty & Teaching",
            "Lab & Infrastructure",
            "Campus Facilities",
            "General Feedback"
        };

        // GET: /Feedback or /Feedback/Index
        public IActionResult Index(string? category)
        {
            var list = _feedbacks.AsEnumerable();
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                list = list.Where(f => f.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            var feedbackList = list.OrderByDescending(f => f.SubmittedAt).ToList();

            var viewModel = new FeedbackDashboardViewModel
            {
                Feedbacks = feedbackList,
                TotalCount = _feedbacks.Count,
                AverageRating = _feedbacks.Count > 0 ? Math.Round(_feedbacks.Average(f => f.Rating), 1) : 0,
                PositiveFeedbackCount = _feedbacks.Count(f => f.Rating >= 4),
                RecommendPercentage = _feedbacks.Count > 0 ? Math.Round((double)_feedbacks.Count(f => f.WouldRecommend) / _feedbacks.Count * 100, 1) : 0,
                SelectedCategory = category,
                Categories = _categories
            };

            return View(viewModel);
        }

        // GET: /Feedback/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _categories;
            return View(new Feedback());
        }

        // POST: /Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback model)
        {
            // Server-side Validation
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categories;
                return View(model);
            }

            // Generate next ID and assign submission timestamp
            model.Id = _feedbacks.Count > 0 ? _feedbacks.Max(f => f.Id) + 1 : 1;
            model.SubmittedAt = DateTime.Now;

            _feedbacks.Add(model);

            TempData["SuccessMessage"] = $"Thank you, {model.FullName}! Your feedback has been recorded successfully.";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Feedback/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _feedbacks.FirstOrDefault(f => f.Id == id);
            if (item != null)
            {
                _feedbacks.Remove(item);
                TempData["SuccessMessage"] = "Feedback deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
