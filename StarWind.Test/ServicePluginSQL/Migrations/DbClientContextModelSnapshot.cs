﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServicePluginSQL.DAL;

namespace ServicePluginSQL.Migrations
{
    [DbContext(typeof(DbClientContext))]
    partial class DbClientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TestCommon.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<long>("INN");

                    b.Property<string>("Name");

                    b.Property<string>("Prof");

                    b.Property<int>("Stage");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 31,
                            INN = 123456789L,
                            Name = "Client_Test",
                            Prof = "C# developer",
                            Stage = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
