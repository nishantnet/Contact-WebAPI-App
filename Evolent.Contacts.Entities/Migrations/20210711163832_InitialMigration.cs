using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolent.Contacts.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactsInfo",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, "James.Smith@test.com", "James", "Smith", "486-9852-452", 1 },
                    { 2, "John.Johnson@test.com", "John", "Johnson", "561-7852-632", 0 },
                    { 3, "Robert.Williams@test.com", "Robert", "Williams", "865-7521-632", 1 },
                    { 4, "Michael.Brown@test.com", "Michael", "Brown", "965-7852-632", 1 },
                    { 5, "William.Jones@test.com", "William", "Jones", "632-8956-412", 0 },
                    { 6, "David.Miller@test.com", "David", "Miller", "632-8965-412", 1 },
                    { 7, "Mary.Davis@test.com", "Mary", "Davis", "695-9632-541", 1 },
                    { 8, "Patricia.Garcia@test.com", "Patricia", "Garcia", "632-8512-453", 1 },
                    { 9, "Jennifer.Anderson@test.com", "Jennifer", "Anderson", "632-1563-167", 1 },
                    { 10, "Barbara.Martinez@test.com", "Barbara", "Martinez", "852-7415-951", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsInfo");
        }
    }
}
