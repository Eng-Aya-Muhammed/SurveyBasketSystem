﻿using Microsoft.EntityFrameworkCore;
using SurveyBasket.API.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveyBasket.API.Extensions;
namespace SurveyBasket.API.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteAnswer> VoteAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var cascadeFKs = modelBuilder.Model
                    .GetEntityTypes()
                    .SelectMany(t => t.GetForeignKeys())
                    .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();

            foreach (var entityEntry in entries)
            {
                var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId()!;

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x => x.CreatedById).CurrentValue = currentUserId;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x => x.UpdatedById).CurrentValue = currentUserId;
                    entityEntry.Property(x => x.UpdatedOn).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}