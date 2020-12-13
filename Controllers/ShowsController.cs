using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVLibraryAPI.Data;
using TVLibraryAPI.Models;
using TVLibraryAPI.ViewModel;

namespace TVLibraryAPI.Controllers
{
    /// <summary>
    /// Show Controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly ShowDBContext _context;

        /// <summary>
        /// Constructor with Show DB context
        /// </summary>
        /// <param name="context"></param>
        public ShowsController(ShowDBContext context)
        {
            _context = context;
        }

        // GET: api/Shows
        /// <summary>
        /// GET Method for getting all Shows
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowSummaryViewModel>>> GetShows()
        {
            try
            {
                return await _context.Shows.Include(e=>e.Platform)
                    .Select(s=> new ShowSummaryViewModel
                    {
                        Id=s.Id,
                        Title = s.Title,
                        Summary=s.Summary,
                        Platform=s.Platform.Name,
                        Schedule=s.Schedule
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Shows/5
        /// <summary>
        /// GET Show by id method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Shows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// PUT Method for updating an Show
        /// </summary>
        /// <param name="id"></param>
        /// <param name="show"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
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

        // POST: api/Shows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST Method for updating an Show
        /// </summary>
        /// <param name="show"></param>
        /// <returns></returns>
        [HttpPost]
        //[IgnoreAntiforgeryTokenAttribute]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        // DELETE: api/Shows/5
        /// <summary>
        /// DELETE Method for deleting an Show
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
