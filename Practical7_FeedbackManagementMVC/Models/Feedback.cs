using System;
using System.ComponentModel.DataAnnotations;

namespace Practical7_FeedbackManagementMVC.Models
{
    /// <summary>
    /// Model representing user feedback with comprehensive data annotations for validation.
    /// </summary>
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [Display(Name = "Student / Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a feedback category.")]
        [Display(Name = "Feedback Category")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
        [Display(Name = "Overall Rating (1 - 5)")]
        public int Rating { get; set; } = 5;

        [Required(ErrorMessage = "Feedback comments are required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Comments must be between 10 and 500 characters.")]
        [Display(Name = "Your Detailed Feedback")]
        public string Comments { get; set; } = string.Empty;

        [Display(Name = "Would you recommend this course / facility to others?")]
        public bool WouldRecommend { get; set; } = true;

        [Display(Name = "Submission Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy, hh:mm tt}")]
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
