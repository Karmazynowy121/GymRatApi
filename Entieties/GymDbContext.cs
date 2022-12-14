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
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingScheulde> TrainingScheulde { get; set; }
        public DbSet<UserTrainingScheulde> UserTrainingScheuldes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(g => g.Description)
                .HasMaxLength(200);
                entity.HasOne(g => g.Video)
                  .WithOne(v => v.Exercise)
                  .HasForeignKey<Video>(v => v.ExerciseId);
                entity.HasMany(e => e.BodyParts)
                .WithOne(p => p.Exercise);
                entity.HasOne(b => b.Sport)
                .WithOne(i => i.Exercise)
                .HasForeignKey<Sport>(b => b.ExerciseId);
                entity.HasOne(g => g.TrainingPart)
                .WithOne(tp => tp.Exercise)
                .HasForeignKey<TrainingPart>(e => e.ExerciseId);
            });

            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.Property(g => g.HowManyExercisesPerWeek);
                entity.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(25);
                entity.HasOne(e => e.Exercise)
                .WithMany(p => p.BodyParts)
                .HasForeignKey(e => e.ExerciseId);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(g => g.Name);
                entity.HasOne(g => g.Exercise)
                .WithOne(e => e.Sport);
                
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(g => g.Title);
                entity.Property(g => g.Path)
                .IsRequired();
                entity.HasOne(g => g.Exercise);
                
            });

            modelBuilder.Entity<TrainingPart>(entity =>
            {
                entity.HasOne(g => g.Exercise).WithOne(g => g.TrainingPart)
                .HasForeignKey<TrainingPart>(t => t.ExerciseId);

                entity.HasOne(g => g.Training)
                .WithMany(t => t.TrainingParts)
                .HasForeignKey(tp => tp.TrainingId);

                entity.Property(g => g.BreakBetweenSeries);
                entity.Property(g => g.AmountSeries);
                entity.Property(g => g.BodyWeight);
                entity.Property(g => g.Reps);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(g => g.Name)
                .HasMaxLength(25);
                entity.Property(g => g.Password)
                .IsRequired();
                entity.Property(g => g.Email)
                .IsRequired();
                entity.Property(g => g.CreateAt);
                entity.Property(g => g.UpdateAt);
                entity.Property(g => g.LastLogin);
                entity.HasMany(t => t.TrainingScheuldes)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId);
             });
            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(g => g.Interval);
                entity.Property(g => g.TrainingDuration);
                entity.Property(g => g.TrainingDate)
                .IsRequired();

                entity.HasMany(g => g.TrainingParts)
                .WithOne(t => t.Training);
                entity.HasOne(t => t.TrainingScheulde)
                .WithMany(g => g.Trainings)
                .HasForeignKey(t => t.TrainingScheuldeId);
            });
            modelBuilder.Entity<TrainingScheulde>(entity =>
            {
                entity.HasOne(g => g.User)
                .WithOne(u => u.TrainingScheulde)
                .HasForeignKey<UserTrainingScheulde>(tr => tr.UserId);
                entity.HasMany(g => g.Trainings)
                .WithOne(t => t.TrainingScheulde)
                .HasForeignKey(g => g.TrainingScheuldeId);
            });

            modelBuilder.Entity<UserTrainingScheulde>(entity =>
            {
                entity.HasOne(g => g.User)
                .WithMany(u => u.TrainingScheuldes)
                .HasForeignKey(t => t.UserId);
                entity.HasOne(g => g.TrainingScheulde)
                .WithOne(t => t.User)
                .HasForeignKey<UserTrainingScheulde>(u => u.TrainingScheuldeId);
            });

        }
        

        
    }
    
}
