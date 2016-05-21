using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestProject.Controllers {
    [Route("/api/[controller]")]
    public class ProfilesController : Controller {
        private readonly DTPContext _context;
        public ProfilesController(DTPContext context) {
            _context = context;
        }

        [HttpGet]
        public Task<List<Profile>> Get() {
            return _context.Profiles.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public Task<Profile> Get(int id) {
            return _context.Profiles.SingleOrDefaultAsync(a => a.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Profile newProfile) {
            _context.Profiles.Add(newProfile);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = newProfile.Id }, newProfile);
        }
    }
}
