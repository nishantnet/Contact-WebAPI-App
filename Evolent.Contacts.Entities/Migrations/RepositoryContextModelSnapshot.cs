// <auto-generated />
using Evolent.Contacts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evolent.Contacts.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evolent.Contacts.Entities.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ContactsInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "James.Smith@test.com",
                            FirstName = "James",
                            LastName = "Smith",
                            PhoneNumber = "486-9852-452",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "John.Johnson@test.com",
                            FirstName = "John",
                            LastName = "Johnson",
                            PhoneNumber = "561-7852-632",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "Robert.Williams@test.com",
                            FirstName = "Robert",
                            LastName = "Williams",
                            PhoneNumber = "865-7521-632",
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "Michael.Brown@test.com",
                            FirstName = "Michael",
                            LastName = "Brown",
                            PhoneNumber = "965-7852-632",
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            Email = "William.Jones@test.com",
                            FirstName = "William",
                            LastName = "Jones",
                            PhoneNumber = "632-8956-412",
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            Email = "David.Miller@test.com",
                            FirstName = "David",
                            LastName = "Miller",
                            PhoneNumber = "632-8965-412",
                            Status = 1
                        },
                        new
                        {
                            Id = 7,
                            Email = "Mary.Davis@test.com",
                            FirstName = "Mary",
                            LastName = "Davis",
                            PhoneNumber = "695-9632-541",
                            Status = 1
                        },
                        new
                        {
                            Id = 8,
                            Email = "Patricia.Garcia@test.com",
                            FirstName = "Patricia",
                            LastName = "Garcia",
                            PhoneNumber = "632-8512-453",
                            Status = 1
                        },
                        new
                        {
                            Id = 9,
                            Email = "Jennifer.Anderson@test.com",
                            FirstName = "Jennifer",
                            LastName = "Anderson",
                            PhoneNumber = "632-1563-167",
                            Status = 1
                        },
                        new
                        {
                            Id = 10,
                            Email = "Barbara.Martinez@test.com",
                            FirstName = "Barbara",
                            LastName = "Martinez",
                            PhoneNumber = "852-7415-951",
                            Status = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
