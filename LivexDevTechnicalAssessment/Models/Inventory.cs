using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivexDevTechnicalAssessment.Models
{

	public enum InventoryType
	{
		Book,
		Media, //CDs, DVDs...
		Electronic //Laptop, printer...
	}
	public class Inventory
	{
		public int Id { get; set; } // a unique identifier for an item in the inventoryItem table (Auto-increments)
		[Required]
		public string Name { get; set; } //required will help us raise an error when the item name is Null 
		[Required]
		public double Price { get; set; } // the cost of that item
		public int Quantity { get; set; } //What's left in stock
		[Required]
		// This took me some time to figrue out T_T . So Enums are saved using the index of their values,
		// they need to be serialized so that the client can receive the values instead of  indexes   
		[JsonConverter(typeof(JsonStringEnumConverter))] 
		public InventoryType type { get; set; }


	}
}
