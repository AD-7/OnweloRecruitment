using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.DataObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Controllers
{
    public class VotersController : BaseApiController
    {

        public VotersController(DataContext context) : base(context) { }
     

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoters()
        {
            return Ok(await _ctx.Voters.ToListAsync());
        }

        [HttpGet("novoted")]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVotersWhoNotVote()
        {
            return Ok(await _ctx.Voters.Where(v => !v.HasVoted).ToListAsync());
        }

        [HttpPost("add/{name}")]
        public async Task<ActionResult<Candidate>> AddVoter(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name cannot be empty");
            if (await _ctx.Voters.AnyAsync(c => c.Name == name)) return BadRequest("Voter already exsists");
            Voter voter = new Voter()
            {
                Name = name
            };
            _ctx.Voters.Add(voter);
            await _ctx.SaveChangesAsync();
            return Ok(voter);
        }



    }
}
