using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DataContext;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly BookDbContext _context;

        public SubcategoriesController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcategories>>> Getsubcategories()
        {
            return await _context.subcategories.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategories>> GetSubcategories(int id)
        {
            var subcategories = await _context.subcategories.FindAsync(id);

            if (subcategories == null)
            {
                return NotFound();
            }

            return subcategories;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategories(int id, Subcategories subcategories)
        {
            if (id != subcategories.Id)
            {
                return BadRequest();
            }

            _context.Entry(subcategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoriesExists(id))
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

   
        [HttpPost]
        public async Task<ActionResult<Subcategories>> PostSubcategories(Subcategories subcategories)
        {
            _context.subcategories.Add(subcategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcategories", new { id = subcategories.Id }, subcategories);
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategories(int id)
        {
            var subcategories = await _context.subcategories.FindAsync(id);
            if (subcategories == null)
            {
                return NotFound();
            }

            _context.subcategories.Remove(subcategories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubcategoriesExists(int id)
        {
            return _context.subcategories.Any(e => e.Id == id);
        }
    }
}
