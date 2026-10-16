using System.Collections.Generic;

namespace Practical7_FeedbackManagementMVC.Models
{
    public class FeedbackDashboardViewModel
    {
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public int TotalCount { get; set; }
        public double AverageRating { get; set; }
        public int PositiveFeedbackCount { get; set; }
        public double RecommendPercentage { get; set; }
        public string? SelectedCategory { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
