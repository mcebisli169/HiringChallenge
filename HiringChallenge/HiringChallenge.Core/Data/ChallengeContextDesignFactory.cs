using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.Data
{
    public class ChallengeContextDesignFactory : IDesignTimeDbContextFactory<ChallengeContext>
    {
        public ChallengeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChallengeContext>();
         
            optionsBuilder.UseSqlServer("server=MCEBISLI\\SQLEXPRESS;database=HiringChallenge;uid=sa;pwd=123");

            return new ChallengeContext(optionsBuilder.Options);
        }
    }
}
