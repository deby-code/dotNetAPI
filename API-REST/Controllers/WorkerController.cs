#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_REST.Models;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly TodoContext _context;

        public WorkerController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Worker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorker()
        {
            return await _context.Worker.ToListAsync();
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(long id)
        {
            var worker = await _context.Worker.FindAsync(id);
            _context.Worker.Include(t => t.Department);
            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Worker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(long id, Worker worker)
        {
            if (id != worker.Id)
            {
                return BadRequest();
            }

            _context.Entry(worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Worker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
          //  var department = await _context.Department.FindAsync(worker.Department.Id);
            //worker.Department = department;
            _context.Worker.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(long id)
        {
            var worker = await _context.Worker.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Worker.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkerExists(long id)
        {
            return _context.Worker.Any(e => e.Id == id);
        }
    }
}
