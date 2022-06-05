﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PanGainsAPI.Data;

#nullable disable

namespace PanGainsAPI.Migrations
{
    [DbContext(typeof(PanGainsAPIContext))]
    [Migration("20220605152628_RemovedRequired")]
    partial class RemovedRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PanGainsAPI.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AverageChallengePos")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.Property<bool>("Notifications")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<bool>("Private")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("AccountID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PanGainsAPI.Models.ChallengeStats", b =>
                {
                    b.Property<int>("ChallengeStatsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("ChallengeTotalReps")
                        .HasColumnType("int");

                    b.Property<int>("LeaderboardID")
                        .HasColumnType("int");

                    b.HasKey("ChallengeStatsID");

                    b.ToTable("ChallengeStats");
                });

            modelBuilder.Entity("PanGainsAPI.Models.CompletedWorkout", b =>
                {
                    b.Property<int>("CompletedWorkoutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("RoutineID")
                        .HasColumnType("int");

                    b.Property<double>("TotalWeightLifted")
                        .HasColumnType("double");

                    b.HasKey("CompletedWorkoutID");

                    b.ToTable("CompletedWorkout");
                });

            modelBuilder.Entity("PanGainsAPI.Models.DaysWorkedOut", b =>
                {
                    b.Property<int>("DaysWorkedOutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("DaysWorkedOutID");

                    b.ToTable("DaysWorkedOut");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Folder", b =>
                {
                    b.Property<int>("FolderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("FolderLikes")
                        .HasColumnType("int");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FolderID");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Leaderboard", b =>
                {
                    b.Property<int>("LeaderboardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("LeaderboardDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalParticipants")
                        .HasColumnType("int");

                    b.HasKey("LeaderboardID");

                    b.ToTable("Leaderboard");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Routine", b =>
                {
                    b.Property<int>("RoutineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FolderID")
                        .HasColumnType("int");

                    b.Property<string>("RoutineName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoutineID");

                    b.ToTable("Routine");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Set", b =>
                {
                    b.Property<int>("SetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Kg")
                        .HasColumnType("int");

                    b.Property<string>("Previous")
                        .HasColumnType("longtext");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("SetRow")
                        .HasColumnType("int");

                    b.Property<string>("SetType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("YourExerciseID")
                        .HasColumnType("int");

                    b.HasKey("SetID");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Social", b =>
                {
                    b.Property<int>("SocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("FollowingID")
                        .HasColumnType("int");

                    b.HasKey("SocialID");

                    b.ToTable("Social");
                });

            modelBuilder.Entity("PanGainsAPI.Models.Statistics", b =>
                {
                    b.Property<int>("StatisticsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("AvgReps")
                        .HasColumnType("int");

                    b.Property<int>("AvgSets")
                        .HasColumnType("int");

                    b.Property<int>("AvgWorkoutTime")
                        .HasColumnType("int");

                    b.Property<double>("TotalLifted")
                        .HasColumnType("double");

                    b.Property<int>("TotalWorkouts")
                        .HasColumnType("int");

                    b.HasKey("StatisticsID");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("PanGainsAPI.Models.UserAuth", b =>
                {
                    b.Property<int>("UserAuthID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserAuthID");

                    b.ToTable("UserAuth");
                });

            modelBuilder.Entity("PanGainsAPI.Models.YourExercise", b =>
                {
                    b.Property<int>("YourExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<int>("RoutineID")
                        .HasColumnType("int");

                    b.HasKey("YourExerciseID");

                    b.ToTable("YourExercise");
                });
#pragma warning restore 612, 618
        }
    }
}
