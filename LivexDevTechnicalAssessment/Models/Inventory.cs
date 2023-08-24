using System.ComponentModel.DataAnnotations;

namespace LivexDevTechnicalAssessment.Models
{
    public class Inventory
    {
        public int Id { get; set; } // a unique identifier for an item in the inventoryItem table (Auto-increments)
        [Required]
        public string Name { get; set; } //required will help us raise an error when the item name is Null 
        [Required]
        public double Price { get; set; } // the cost of that item
        public int Quantity { get; set; } //What's left in stock


    }
}
