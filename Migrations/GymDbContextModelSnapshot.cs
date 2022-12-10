﻿// <auto-generated />
using System;
using GymRatApi.Entieties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymRatApi.Migrations
{
    [DbContext(typeof(GymDbContext))]
    partial class GymDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("GymRatApi.Entieties.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HowManyExercisesPerWeek")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("BodyParts");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId")
                        .IsUnique();

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Interval")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TrainingDuration")
                        .HasColumnType("TEXT");

                    b.Property<int>("TrainingScheuldeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrainingScheuldeId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("GymRatApi.Entieties.TrainingPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountSeries")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BodyWeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BreakBetweenSeries")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrainingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId")
                        .IsUnique();

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingParts");
                });

            modelBuilder.Entity("GymRatApi.Entieties.TrainingScheulde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TrainingScheulde");
                });

            modelBuilder.Entity("GymRatApi.Entieties.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TrainingScheuldeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TrainingScheuldeId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId")
                        .IsUnique();

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("GymRatApi.Entieties.BodyPart", b =>
                {
                    b.HasOne("GymRatApi.Entieties.Exercise", "Exercise")
                        .WithMany("BodyParts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Sport", b =>
                {
                    b.HasOne("GymRatApi.Entieties.Exercise", "Exercise")
                        .WithOne("Sport")
                        .HasForeignKey("GymRatApi.Entieties.Sport", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Training", b =>
                {
                    b.HasOne("GymRatApi.Entieties.TrainingScheulde", "TrainingScheulde")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingScheuldeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingScheulde");
                });

            modelBuilder.Entity("GymRatApi.Entieties.TrainingPart", b =>
                {
                    b.HasOne("GymRatApi.Entieties.Exercise", "Exercise")
                        .WithOne("TrainingPart")
                        .HasForeignKey("GymRatApi.Entieties.TrainingPart", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymRatApi.Entieties.Training", "Training")
                        .WithMany("TrainingParts")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("GymRatApi.Entieties.User", b =>
                {
                    b.HasOne("GymRatApi.Entieties.TrainingScheulde", "TrainingScheulde")
                        .WithOne("User")
                        .HasForeignKey("GymRatApi.Entieties.User", "TrainingScheuldeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingScheulde");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Video", b =>
                {
                    b.HasOne("GymRatApi.Entieties.Exercise", "Exercise")
                        .WithOne("Video")
                        .HasForeignKey("GymRatApi.Entieties.Video", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GymRatApi.Entieties.Exercise", b =>
                {
                    b.Navigation("BodyParts");

                    b.Navigation("Sport")
                        .IsRequired();

                    b.Navigation("TrainingPart")
                        .IsRequired();

                    b.Navigation("Video")
                        .IsRequired();
                });

            modelBuilder.Entity("GymRatApi.Entieties.Training", b =>
                {
                    b.Navigation("TrainingParts");
                });

            modelBuilder.Entity("GymRatApi.Entieties.TrainingScheulde", b =>
                {
                    b.Navigation("Trainings");

                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
