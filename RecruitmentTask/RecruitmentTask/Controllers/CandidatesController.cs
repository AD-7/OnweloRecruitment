using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace RecruitmentTask.Controllers
{
    public class CandidatesController : BaseApiController
    {

        public CandidatesController(DataContext context) : base(context) { }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetCandidates()
        {
            return Ok(await _ctx.Candidates.OrderByDescending(c => c.Votes).ToListAsync());
        }

        [HttpPost("add/{name}")]
        public async Task<ActionResult<Candidate>> AddCandidate(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name cannot be empty");
            if (await _ctx.Candidates.AnyAsync(c => c.Name == name)) return BadRequest("Candidate already exsists");
            Candidate candidate = new Candidate()
            {
                Name = name
            };
            _ctx.Candidates.Add(candidate);
            await _ctx.SaveChangesAsync();
            return Ok(candidate);
        }

    }
}
