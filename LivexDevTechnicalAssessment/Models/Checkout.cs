using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LivexDevTechnicalAssessment.Models
{
    public class Checkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //The ID of this transaction for tracking purposes

        public int CustomerId { get; set; } //The ID of the customer that has been checked out 
        public int InventoryItemId { get; set; } //The ID of the item that has been checked out
        public DateTime CheckoutDate { get; set; } //The time when this transaction happened 
        public DateTime? ReturnDate { get; set; } //In case a library item is returned
        public int Quantity { get; set; } //The amount of items that are being checked out 

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("InventoryItemId")]
        public Inventory? InventoryItem { get; set; }
    }
}
