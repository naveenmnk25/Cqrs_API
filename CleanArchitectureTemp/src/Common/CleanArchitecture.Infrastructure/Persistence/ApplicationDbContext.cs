using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext :IdentityDbContext<Entity.ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions options,ICurrentUserService currentUserService,IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public DbSet<DefaultSetting> DefaultSetting { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<ExecuteResult> ExecuteResult { get; set; }
        public DbSet<QueryResult> QueryResult { get; set; }
        public  DbSet<AmountDetail> AmountDetails { get; set; }

        public  DbSet<AmountGiven> AmountGivens { get; set; }

        public  DbSet<AmountReFund> AmountReFunds { get; set; }

        public DbSet<Member> Members { get; set; }
        public  DbSet<User> User { get; set; }
        public ApplicationDbContext Entity()
        {
            return this;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = 1; //_currentUserService.UserId;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = 1; // _currentUserService.UserId;
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    
        }

       
    }

