using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Evaluated> Evaluateds { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<EvaluatedEvaluation> EvaluatedEvaluations { get; set; }


        public Db(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvaluatedEvaluation>()
                .HasKey(ee => new { ee.EvaluatedId, ee.EvaluationId });

            modelBuilder.Entity<EvaluatedEvaluation>()
                .HasOne(ee => ee.Evaluated)
                .WithMany(e => e.EvaluatedEvaluations)
                .HasForeignKey(ee => ee.EvaluatedId);

            modelBuilder.Entity<EvaluatedEvaluation>()
                .HasOne(ee => ee.Evaluation)
                .WithMany(e => e.EvaluatedEvaluations)
                .HasForeignKey(ee => ee.EvaluationId);
        }
    }
}
