using LivexDevTechnicalAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
	private readonly AppDbContext local_context;

	public CustomersController(AppDbContext context)
	{
		local_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
	{
		/*
         * GET: api/customers
         * 
         * Returns all records in the customer table.
         */
		return await local_context.Customers.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Customer>> GetCustomer(int id)
	{
		/*
         * GET: api/customers/[id]
         * 
         * Finds a customer based on the ID. Returns a 404 if the customer
         * doesn't exist.
         */
		var customer = await local_context.Customers.FindAsync(id);

		if (customer == null)
		{
			return NotFound(new { error = "Customer not found" });
		}

		return customer;
	}

	[HttpPost]
	public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
	{
		/*
         * POST: api/customer
         * 
         * Creates a new customer. The customer must be a valid Customer object.
         */
		local_context.Customers.Add(customer);

		// Register changes to the cloud DB
		await local_context.SaveChangesAsync();

		// Returns the newly created customer object
		return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
	{
		/* 
         * PUT: api/customer/[id]
         * 
         * This endpoint updates the customer's details using the ID. The data given
         * in the object will overwrite the existing one.
         * The ID is required.
         */

		// This is more of a safeguard to ensure that the correct customer is being updated (for the client).
		// It ensures that the Id in the URL matches the Id in the object, adding an extra layer of validation.
		if (id != customer.Id)
		{
			return BadRequest(new { error = "Mismatched customer ID" });
		}

		// Check if the customer to update exists before making changes
		var customerToUpdate = await local_context.Customers.FindAsync(id);
		if (customerToUpdate == null)
		{
			return NotFound(new { error = "Customer to update not found" }); // Return JSON error message
		}

		local_context.Entry(customer).State = EntityState.Modified;
		await local_context.SaveChangesAsync();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCustomer(int id)
	{
		/* 
         * DELETE: api/customer/[id]
         * 
         * This endpoint deletes a customer using the ID.
         */

		var customer = await local_context.Customers.FindAsync(id);

		if (customer == null)
		{
			return NotFound(new { error = "Customer to delete not found" }); 
		}

		local_context.Customers.Remove(customer);
		await local_context.SaveChangesAsync();

		return NoContent();
	}
}
