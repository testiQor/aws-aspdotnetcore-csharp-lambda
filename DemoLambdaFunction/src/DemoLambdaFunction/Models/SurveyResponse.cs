using System;
using System.ComponentModel.DataAnnotations;

namespace DemoLambdaFunction.Models
{
    public class SurveyResponse
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string RoleSatisfaction { get; set; }

        [Required]
        public required string ManagerSupport { get; set; }

        [Required]
        public required string ValueRecognition { get; set; }

        [Required]
        public required string GrowthOpportunities { get; set; }

        [Required]
        public required string CompanyRecommendation { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
