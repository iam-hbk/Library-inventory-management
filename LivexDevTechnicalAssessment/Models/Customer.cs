using System.ComponentModel.DataAnnotations;

namespace LivexDevTechnicalAssessment.Models
{
    public class Customer
    {
        public int Id { get; set; } // a unique identifier for an item in the inventoryItem table (Auto-increments)
        [Required]
        public string Name { get; set; } //required will help raise an error when the item name is Null 
        public string Email { get; set; } //The customer's email

    }
}
