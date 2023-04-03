using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiddenGarden.Models;

namespace HiddenGarden.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BackyardsController : ControllerBase
  {
    private readonly HiddenGardenContext _db;

    public BackyardsController(HiddenGardenContext db)
    {
      _db = db;
    }

    // GET: api/backyards?page=1&pagesize=20
    [HttpGet]
    public async Task<IActionResult> GetBackyards( int id, string address, string service, string description, string instructions, int page = 1, int pageSize = 5)
    {
      IQueryable<Backyard> query = _db.Backyards.AsQueryable();

      if (service != null)
      {
        query = query.Where(entry => entry.Service == service);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (address != null)
      {  
        query = query.Where(entry => entry.Address == address);
      }
      if (id != 0)
      {  
        query = query.Where(entry => entry.BackyardId  == id);
      }
      if (instructions != null)
      {
        query = query.Where(entry => entry.Instructions == instructions);
      }  
      
      
        // Calculate the number of items to skip based on the page size and requested page. 
        int skip = (page - 1) * pageSize;

        // Retrieve the data from your data source, applying the pagination parameters.  
        List<Backyard> backyards = await query
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        // Determine the total number of items in your data source.
        int totalCount = _db.Backyards.Count();

        // Create a response object to hold the paginated data and total count.
        var response = new
        {
            Data = backyards,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };

        // Return the paginated data to the client.
        return Ok(response);
    }

    // GET: api/backyards/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Backyard>> GetBackyard(int id)
    {
      Backyard backyard = await _db.Backyards.FindAsync(id);

      if (backyard == null)
      {
        return NotFound();
      }

      return backyard;
    }
    
    // POST api/backyards
    [HttpPost]
    public async Task<ActionResult<Backyard>> Post(Backyard backyard)
    {
      _db.Backyards.Add(backyard);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBackyard), new { id = backyard.BackyardId }, backyard);
    }

    // PUT: api/Backyards/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Backyard backyard)
    {
      if (id != backyard.BackyardId)
      {
        return BadRequest();
      }

      _db.Backyards.Update(backyard);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BackyardExists(id))
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

    // DELETE: api/Backyards/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBackyard(int id)
    {
      Backyard Backyard = await _db.Backyards.FindAsync(id);
      if (Backyard == null)
      {
        return NotFound();
      }

      _db.Backyards.Remove(Backyard);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool BackyardExists(int id)
    {
      return _db.Backyards.Any(e => e.BackyardId == id);
    }
  }
}