using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Produces("application/json")]
    [Route("api/players")]
    [Authorize(Roles = "Admin")]
    public class PlayersApiController : Controller
    {
        private readonly ProjectContext _context;

        public PlayersApiController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/PlayersApi
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Player> GetPlayer()
        {
            return _context.Player;
        }

        // GET: api/PlayersApi/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.PlayerId == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/PlayersApi/5
        /*[HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/PlayersApi
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/PlayersApi/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerId == id);
        } */
    }
}