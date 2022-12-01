using Microsoft.EntityFrameworkCore;

namespace GymRatApi.Entieties
{
    public class GymDbContext : DbContext
    {
        
        public GymDbContext(DbContextOptions<GymDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
       
            
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<TrainingPart> TrainingParts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.Property(g => g.HowManyExercisesPerWeek)
                .IsRequired();
                entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(25);
                entity.HasOne(e => e.Exercise)
                .WithMany(p => p.Parts)
                .HasForeignKey(e => e.ExerciseId);
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.HasOne(g => g.Video)
                  .WithOne(v => v.Exercise)
                  .HasForeignKey<Video>(v => v.ExerciseId);
                entity.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(200);
                entity.HasMany(e => e.Parts)
                .WithOne(p => p.Exercise);
                entity.HasOne(b => b.Sport)
                .WithOne(i => i.Exercise)
                .HasForeignKey<Sport>(b => b.ExerciseId);

            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(g => g.Name)
                .IsRequired();
                entity.HasOne(g => g.Exercise)
                .WithOne(e => e.Sport);
                
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(g => g.Title)
                .IsRequired();
                entity.HasOne(g => g.Exercise);
                
            });

            modelBuilder.Entity<TrainingPart>(entity =>
            {
                entity.Property(g => g.AmountPart)
                .IsRequired();
                entity.Property(g => g.AmountSeries)
                .IsRequired();
                entity.Property(g => g.BodyWeight)
                .IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(25);
                entity.Property(g => g.Password)
                .IsRequired();
                entity.Property(g => g.Email)
                .IsRequired();
                entity.Property(g => g.CreateAt)
                .IsRequired();
                entity.Property(g => g.UpdateAt)
                .IsRequired();
                entity.Property(g => g.LastLogin);
             });
                
        }
        

        
    }
    
}
