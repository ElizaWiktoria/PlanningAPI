﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Planning.Infrastructure.AutoMappers.DataContext;

#nullable disable

namespace Planning.Infrastructure.Migrations
{
    [DbContext(typeof(DataContextEF))]
    partial class DataContextEFModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanningAPI.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoutineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("Plans", "dbo");
                });

            modelBuilder.Entity("PlanningAPI.Models.Routine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FrequencyInDays")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LastDone")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routines", "dbo");
                });

            modelBuilder.Entity("PlanningAPI.Models.Plan", b =>
                {
                    b.HasOne("PlanningAPI.Models.Routine", "Routine")
                        .WithMany("Plans")
                        .HasForeignKey("RoutineId");

                    b.Navigation("Routine");
                });

            modelBuilder.Entity("PlanningAPI.Models.Routine", b =>
                {
                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
