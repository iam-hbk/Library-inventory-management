using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivexDevTechnicalAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivexDevTechnicalAssessment.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InventoryController : ControllerBase
	{
		private readonly AppDbContext local_context;

		public InventoryController(AppDbContext context)
		{
			local_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryItems()
		{
			/*
             * GET: api/inventory
             * 
             * Returns all records in the inventory table
             */
			return await local_context.InventoryItems.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Inventory>> GetInventoryItem(int id)
		{
			/*
             * GET: api/inventory/[id]
             * 
             * Finds an item based on its ID, returns a 404 if the item
             * doesn't exist.
             */
			var item = await local_context.InventoryItems.FindAsync(id);

			if (item == null)
			{
				return NotFound(new { error = "Item not found" });  // Return JSON error message
			}

			return item;
		}

		[HttpPost]
		public async Task<ActionResult<Inventory>> AddInventoryItem(Inventory item)
		{
			/*
             * POST: api/inventory
             * 
             * Adds an Item to the Inventory. The item must be a valid Inventory object.
             * When optional fields are not given, they are set to default values.
             */
			local_context.InventoryItems.Add(item);

			// Update the cloud db
			await local_context.SaveChangesAsync();

			// Returns the newly created object
			return CreatedAtAction(nameof(GetInventoryItem), new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateInventoryItem( Inventory item,int id)
		{
			/* 
             * PUT: api/inventory/[id]
             * 
             * This endpoint updates an item based on its ID. The data given
             * in the object will overwrite the existing one.
             * The ID is required.
             */

			// This is more of a safeguard to ensure that the correct item is being updated (for the client).
			// It ensures that the Id in the URL matches the Id in the object, adding an extra layer of validation.
			if (id != item.Id)
			{
				return BadRequest(new { error = "Mismatched item ID" });  
			}

			// Check if the item to update exists before making changes
			var itemToUpdate = await local_context.InventoryItems.FindAsync(id);
			if (itemToUpdate == null)
			{
				return NotFound(new { error = "Item to update not found" });
			}
			local_context.Entry(itemToUpdate).State = EntityState.Detached; //To avoid entity conflicts
			local_context.Entry(item).State = EntityState.Modified;
			await local_context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteInventoryItem(int id)
		{
			/* 
             * DELETE: api/inventory/[id]
             * 
             * This endpoint deletes an item from the inventory using its ID.
             */
			var item = await local_context.InventoryItems.FindAsync(id);

			if (item == null)
			{
				return NotFound(new { error = "Item to delete not found" });  
			}

			local_context.InventoryItems.Remove(item);
			await local_context.SaveChangesAsync();

			return NoContent();
		}
	}
}
