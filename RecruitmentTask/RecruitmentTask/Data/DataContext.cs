using Microsoft.EntityFrameworkCore;
using RecruitmentTask.DataObjects;

namespace RecruitmentTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

    }
}
