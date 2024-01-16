using Greenspaces_Finder.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Greenspaces_Finder.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Greenspaces_Finder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class ReviewController : ControllerBase
        {
            // Database context for handling reviews
            private readonly AppDbContext _context;

            // Constructor to inject the database context
            public ReviewController(AppDbContext context)
            {
                _context = context;
            }

            // GET api/<ReviewController>
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
            {
                // Retrieve all reviews asynchronously from the database
                return await _context.Reviews.ToListAsync();
            }

            // GET api/<ReviewController>/id
            [HttpGet("{id}")]
            public async Task<ActionResult<Review>> GetReview(int id)
            {
                // Find a review by its ID in the database
                var review = await _context.Reviews.FindAsync(id);

                // Check if the review with the specified ID exists
                if (review == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the review is not found
                }

                return review; // Return the found review
            }

            // POST api/<ReviewController>
            [HttpPost]
            public async Task<ActionResult<Review>> PostReview(Review review)
            {
                // Add a new review to the database
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                // Return a 201 Created response with the details of the newly created review
                return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
            }

            // PUT api/<ReviewController>/id
            [HttpPut("{id}")]
            public async Task<IActionResult> PutReview(int id, Review review)
            {
                // Check if the provided ID matches the review's ID
                if (id != review.ReviewId)
                {
                    return BadRequest(); // Return a 400 Bad Request response if the IDs do not match
                }

                // Mark the review entity as modified and update it in the database
                _context.Entry(review).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency conflicts
                    if (!ReviewExists(id))
                    {
                        return NotFound(); // Return a 404 Not Found response if the review is not found
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent(); // Return a 204 No Content response on successful update
            }

            // DELETE api/<ReviewController>/id
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReview(int id)
            {
                // Find a review by its ID in the database
                var review = await _context.Reviews.FindAsync(id);

                // Check if the review with the specified ID exists
                if (review == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the review is not found
                }

                // Remove the review from the database and save changes
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();

                return NoContent(); // Return a 204 No Content response on successful deletion
            }

            // Helper method to check if a review with a given ID exists
            private bool ReviewExists(int id)
            {
                return _context.Reviews.Any(e => e.ReviewId == id);
            }
        }
    }

