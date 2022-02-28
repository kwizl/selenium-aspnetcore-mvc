using Microsoft.EntityFrameworkCore.Migrations;

namespace Selenium.Data.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OtherEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
