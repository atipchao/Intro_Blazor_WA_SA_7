using Intro_Blazor_WA_SA_7.Server.Models;
using Intro_Blazor_WA_SA_7.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intro_Blazor_WA_SA_7.Server.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase 
    {
        private readonly ApplicationDbContext _dbContext;

        public PeopleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return await _dbContext.People.ToListAsync();
        }

        [HttpGet("{id}", Name="GetPerson")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            return await _dbContext.People.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            _dbContext.Add(person);
            await _dbContext.SaveChangesAsync();
            return new CreatedAtRouteResult("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut] 
        public async Task<ActionResult> Put(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult> Delete(int id)
        {
            var person = new Person { Id = id };
            _dbContext.Remove(person);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
