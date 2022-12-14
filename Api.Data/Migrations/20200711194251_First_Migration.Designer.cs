// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200711194251_First_Migration")]
    partial class First_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.ChampionshipEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampeaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TerceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ViceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CampeaoId");

                    b.HasIndex("TerceiroId");

                    b.HasIndex("ViceId");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChampionshipEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Goals1")
                        .HasColumnType("int");

                    b.Property<int>("Goals2")
                        .HasColumnType("int");

                    b.Property<Guid?>("Time1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Time2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipEntityId");

                    b.HasIndex("Time1Id");

                    b.HasIndex("Time2Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Domain.Entities.PontuacaoChampionshipEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChampionshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<Guid?>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("TimeId");

                    b.ToTable("ChampionshipPoints");
                });

            modelBuilder.Entity("Domain.Entities.TimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Time");
                });

            modelBuilder.Entity("Domain.Entities.ChampionshipEntity", b =>
                {
                    b.HasOne("Domain.Entities.TimeEntity", "Championship")
                        .WithMany()
                        .HasForeignKey("CampeaoId");

                    b.HasOne("Domain.Entities.TimeEntity", "Third")
                        .WithMany()
                        .HasForeignKey("TerceiroId");

                    b.HasOne("Domain.Entities.TimeEntity", "Vice")
                        .WithMany()
                        .HasForeignKey("ViceId");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.HasOne("Domain.Entities.ChampionshipEntity", null)
                        .WithMany("matches")
                        .HasForeignKey("ChampionshipEntityId");

                    b.HasOne("Domain.Entities.TimeEntity", "Time1")
                        .WithMany()
                        .HasForeignKey("Time1Id");

                    b.HasOne("Domain.Entities.TimeEntity", "Time2")
                        .WithMany()
                        .HasForeignKey("Time2Id");
                });

            modelBuilder.Entity("Domain.Entities.PontuacaoChampionshipEntity", b =>
                {
                    b.HasOne("Domain.Entities.ChampionshipEntity", "Championship")
                        .WithMany()
                        .HasForeignKey("ChampionshipId");

                    b.HasOne("Domain.Entities.TimeEntity", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId");
                });
#pragma warning restore 612, 618
        }
    }
}
