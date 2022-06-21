using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrsDbApi.Models;
using PrsDbSpecs.Models;

namespace PrsDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequestsController : ControllerBase
    {
        private const string APPROVED = "Approved";
        private const string REJECTED = "Rejected";
        private const string REVIEW = "Review";
        private const string PAID = "Paid";

        private readonly AppDbContext _context;

        public RequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
          if (_context.Request == null)
          {
              return NotFound();
          }
            return await _context.Request.Include(x => x.User).ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
          if (_context.Request == null)
          {
              return NotFound();
          }
            var request = await _context.Request.Include(x => x.User).Include(x => x.RequestLines).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        [HttpGet("review/{id}")]
        public async Task<ActionResult<IEnumerable<Request>>> ReviewsRequest(int id) {

            
         return await _context.Request.Include(x => x.User).Where(x => x.Status == REVIEW && x.UserId != id).ToListAsync();

        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        [HttpPut("Review/{id}")]
        public async Task<IActionResult> ReviewRequest(int id, Request request) {
            if (request == null) {
                return NotFound();
            }
            request.Status = (request.Total <= 50) ? APPROVED : REVIEW;
                return await PutRequest(id, request);

        }
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> ApproveRequest(int id, Request request) {
            if (request == null) {
                return NotFound();
            }
            if (request.Status == APPROVED) {
                return Ok(request.Status);
            }

            request.Status = APPROVED;
            await _context.SaveChangesAsync();
            return await PutRequest(id, request);

        }
        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> RejectRequest(int id, Request request) {
            if (request == null) {
                return NotFound();
            }
            if (request.Status == REJECTED) {
                return Ok(request.Status);
            }

            request.Status = REJECTED;
            await _context.SaveChangesAsync();
            return await PutRequest(id, request);

        }



        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
          if (_context.Request == null)
          {
              return Problem("Entity set 'AppDbContext.Request'  is null.");
          }
            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            if (_context.Request == null)
            {
                return NotFound();
            }
            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return (_context.Request?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
