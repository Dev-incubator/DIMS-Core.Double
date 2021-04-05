using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DIMS_Core.BusinessLayer.Converters;
using DIMS_Core.Common.Enums;

namespace DIMS_Core.Models
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        [JsonPropertyName("Name")]
        public string FullName { get; set; }

        [Required]
        [JsonPropertyName("Your direction")]

        // TODO: Task 19
        // You need to review custom DirectionConverter realization
        [JsonConverter(typeof(DirectionConverter))]
        public int DirectionId { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Birth date")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Start date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [JsonPropertyName("University average score")]
        public double UniversityAverageScore { get; set; }

        [Required]
        [JsonPropertyName("Math score")]
        public double MathScore { get; set; }

        [Required]
        [JsonIgnore]
        public SexType Sex { get; set; }

        [DataType(DataType.Text)]
        [JsonIgnore]
        public string Skype { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Roles Role { get; set; }

        [DataType(DataType.PhoneNumber)]
        [JsonPropertyName("Mobile")]
        public string MobilePhone { get; set; }
    }
}