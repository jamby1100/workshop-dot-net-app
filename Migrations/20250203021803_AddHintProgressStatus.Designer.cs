﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkshopApp.Models;

#nullable disable

namespace WorkshopApp.Migrations
{
    [DbContext(typeof(WorkshopAppDbContext))]
    [Migration("20250203021803_AddHintProgressStatus")]
    partial class AddHintProgressStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkshopApp.Models.Challenge", b =>
                {
                    b.Property<int>("ChallengeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChallengeId"));

                    b.Property<string>("ChallengeBriefMarkdown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EstimateTimeToFinish")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("ChallengeId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("WorkshopApp.Models.ChallengeProgress", b =>
                {
                    b.Property<int>("ChallengeProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChallengeProgressId"));

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<string>("ChallengeStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("ChallengeProgressId");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("ChallengeProgresses");
                });

            modelBuilder.Entity("WorkshopApp.Models.Hint", b =>
                {
                    b.Property<int>("HintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HintId"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("HintId");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Hints");
                });

            modelBuilder.Entity("WorkshopApp.Models.HintProgress", b =>
                {
                    b.Property<int>("HintProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HintProgressId"));

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<string>("HintStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("HintProgressId");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("HintProgresses");
                });

            modelBuilder.Entity("WorkshopApp.Models.PointsLedgerEntry", b =>
                {
                    b.Property<int>("PointsLedgerEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PointsLedgerEntryId"));

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("PointsLedgerEntryId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("PointsLedgerEntries");
                });

            modelBuilder.Entity("WorkshopApp.Models.Workshop", b =>
                {
                    b.Property<int>("WorkshopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkshopId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EstimateTimeToFinish")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.HasKey("WorkshopId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("WorkshopApp.Models.WorkshopProgress", b =>
                {
                    b.Property<int>("WorkshopProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkshopProgressId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("WorkshopProgressId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("WorkshopProgresses");
                });

            modelBuilder.Entity("WorkshopApp.Models.Challenge", b =>
                {
                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany("Challenges")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.ChallengeProgress", b =>
                {
                    b.HasOne("WorkshopApp.Models.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.Hint", b =>
                {
                    b.HasOne("WorkshopApp.Models.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.HintProgress", b =>
                {
                    b.HasOne("WorkshopApp.Models.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.PointsLedgerEntry", b =>
                {
                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.WorkshopProgress", b =>
                {
                    b.HasOne("WorkshopApp.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("WorkshopApp.Models.Workshop", b =>
                {
                    b.Navigation("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
