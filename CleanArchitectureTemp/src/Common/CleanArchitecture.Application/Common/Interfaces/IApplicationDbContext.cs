using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<DefaultSetting> DefaultSetting { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<Unit> Unit { get; set; }
        DbSet<ExecuteResult> ExecuteResult { get; set; }
        DbSet<QueryResult> QueryResult { get; set; }
         DbSet<AmountDetail> AmountDetails { get; set; }

         DbSet<AmountGiven> AmountGivens { get; set; }

         DbSet<AmountReFund> AmountReFunds { get; set; }

         DbSet<User> User { get; set; }
         DbSet<Member> Members { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
