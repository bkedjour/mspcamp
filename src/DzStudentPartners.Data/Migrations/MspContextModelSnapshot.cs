using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DzStudentPartners.Data;

namespace DzStudentPartners.Data.Migrations
{
    [DbContext(typeof(MspContext))]
    partial class MspContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DzStudentPartners.Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Wilaya");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.Msp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CampId");

                    b.Property<string>("Name");

                    b.Property<double>("Points");

                    b.Property<int>("Rank");

                    b.Property<string>("Region");

                    b.Property<string>("Twitter");

                    b.Property<string>("University");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.ToTable("Msps");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.MspCamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MspId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MspId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.Msp", b =>
                {
                    b.HasOne("DzStudentPartners.Domain.MspCamp", "Camp")
                        .WithMany("Msps")
                        .HasForeignKey("CampId");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.MspCamp", b =>
                {
                    b.HasOne("DzStudentPartners.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("DzStudentPartners.Domain.Skill", b =>
                {
                    b.HasOne("DzStudentPartners.Domain.Msp")
                        .WithMany("Skills")
                        .HasForeignKey("MspId");
                });
        }
    }
}
