using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.DataObjects;
using RecruitmentTask.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Controllers
{
    public class VotingController : BaseApiController
    {
        public VotingController(DataContext context): base(context)
        {

        }

        [HttpPut]
        public async Task<ActionResult<bool>> Vote(VoteDto voteDto)
        {
            var voter = await _ctx.Voters.SingleOrDefaultAsync(v => v.Id == voteDto.VoterId);
            var candidate = await _ctx.Candidates.SingleOrDefaultAsync(c => c.Id == voteDto.CandidateId);
            if (voter == null) return BadRequest("Voter does not exists");
            if (candidate == null) return BadRequest("Candidate does not exists");

            voter.HasVoted = true;
            _ctx.Entry(voter).State = EntityState.Modified;
            candidate.Votes += 1;
            _ctx.Entry(candidate).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return Ok(true);

        }

    }
}
