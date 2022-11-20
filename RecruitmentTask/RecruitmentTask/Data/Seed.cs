using Microsoft.EntityFrameworkCore;
using RecruitmentTask.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (await context.Voters.AnyAsync() || await context.Candidates.AnyAsync()) return;
            context.Voters.AddRange( new List<Voter>()
            {
                new Voter { Name = "Klopp"},
                new Voter { Name = "Guardiola"}
            });
            context.Candidates.AddRange(new List<Candidate>()
            {
                new Candidate{Name = "Lewandowski"},
                new Candidate{Name = "Messi"},
                new Candidate{Name = "Ronaldo"}
            });
            await context.SaveChangesAsync();
        }

    }
}
