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
    [Migration("20250129154915_WorkshopChallenges")]
    partial class WorkshopChallenges
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

                    b.ToTable("Challenge");
                });

            // Workshop workshopOne = 

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

                    b.HasData(new Workshop {
                            WorkshopId = 1,
                            Name = "Serverless Challenge III",
                            Description = "This is a challenge that will teach you all you need to know about serverless.",
                            EstimateTimeToFinish = 120,
                            Published = true,
                            Challenges = [
                                new Challenge {
                                    Name = "Starting your Serverless Application",
                                    Description = "Let's get started with your first serverless app deployment",
                                    EstimateTimeToFinish = 10,
                                    ChallengeBriefMarkdown = "# This is it [some link](https://google.com)"
                                },
                                new Challenge {
                                    Name = "Adding DynamoDB Capability",
                                    Description = "Let's add a real database",
                                    EstimateTimeToFinish = 30,
                                    ChallengeBriefMarkdown = "# This is it [some link](https://google.com)"
                                }
                            ]
                        }
                    );
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

            modelBuilder.Entity("WorkshopApp.Models.Workshop", b =>
                {
                    b.Navigation("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
