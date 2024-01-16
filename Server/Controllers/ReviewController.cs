using Greenspaces_Finder.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Greenspaces_Finder.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greenspaces_Finder.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ReviewController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/v1/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _appDbContext.Reviews.ToListAsync();
        }

        // GET: api/v1/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _appDbContext.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // POST: api/v1/Review
        [HttpPost]
        public IActionResult PostReview([FromBody] Review review)
        {
            try
            {
                _appDbContext.Reviews.Add(review);
                _appDbContext.SaveChanges();

                return Ok("Message: Save successfully");
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/v1/Review/5
        [HttpPut("{id}")]
        public IActionResult PutReview(int id, [FromBody] Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _appDbContext.Entry(review).State = EntityState.Modified;

            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/v1/Review/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var review = _appDbContext.Reviews.Find(id);

            if (review == null)
            {
                return NotFound();
            }

            _appDbContext.Reviews.Remove(review);
            _appDbContext.SaveChanges();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return _appDbContext.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
