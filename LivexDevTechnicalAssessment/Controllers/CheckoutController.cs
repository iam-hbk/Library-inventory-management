using LivexDevTechnicalAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivexDevTechnicalAssessment.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CheckoutController : ControllerBase
	{
		private readonly AppDbContext local_context;

		public CheckoutController(AppDbContext context)
		{
			local_context = context;
		}

		[HttpGet("logs")]
		public async Task<ActionResult<IEnumerable<Checkout>>> GetCheckouts()
		{
			/* 
             * GET: api/checkout/logs
             * 
             * Returns all the checkouts that have been made.
             */
			return await local_context.Checkouts.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Checkout>> Checkout(Checkout checkout)
		{
			/* 
             * POST: api/checkout
             * 
             * This endpoint checks out a library item.
             */
			var item = await local_context.InventoryItems.FindAsync(checkout.InventoryItemId);
			if (item == null || item.Quantity < checkout.Quantity)
			{
				return BadRequest(new { error = "Insufficient quantity or item not found." }); // Return JSON error message
			}

			// Reduce the item quantity in the library.
			item.Quantity -= checkout.Quantity;

			local_context.Checkouts.Add(checkout);
			await local_context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetCheckouts), new { id = checkout.Id }, checkout);
		}

		[HttpPut("return/{id}")]
		public async Task<ActionResult> ReturnItem(int id)
		{
			/* 
             * PUT: api/checkout/return/{id}
             * 
             * Endpoint to return a checked-out item in the library using its ID.
             */

			// Verify first if the item was actually checked out.
			var checkout = await local_context.Checkouts.FindAsync(id);
			if (checkout == null || checkout.ReturnDate != null)
			{
				return BadRequest(new { error = "Invalid checkout record." });
			}

			// Verify if the item even exists.
			var item = await local_context.InventoryItems.FindAsync(checkout.InventoryItemId);
			if (item == null)
			{
				return BadRequest(new { error = "Item not found." }); 
			}

			// Update the store with the returned item.
			item.Quantity += checkout.Quantity;

			checkout.ReturnDate = DateTime.Now;

			await local_context.SaveChangesAsync();

			return NoContent();
		}
	}
}
