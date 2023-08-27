using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PCDoctor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataIntoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "CPU" },
                    { 2, 2, "Graphics Card" },
                    { 3, 3, "Hard Disks" },
                    { 4, 4, "SSD" },
                    { 5, 5, "PC Peripherals" },
                    { 6, 6, "CPU Coolers" },
                    { 7, 7, "Gaming Chairs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Core Count= 6, Clock Speed= 3.7GHz, Boost Speed= 4.6GHz, TDP=65W,Integrated Graphics=None", "Intel", "Intel Core i5-13600K", 345 },
                    { 2, 1, "Core Count= 16, Clock Speed= 4.7GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", "Intel", "Intel Core i9-13900K", 654 },
                    { 3, 1, "Core Count= 6, Clock Speed= 4.2GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 5 7600X", 343 },
                    { 4, 1, "Core Count= 8, Clock Speed= 4.7GHz, Boost Speed= 5GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", "Intel", "Intel Core i7-13700K", 532 },
                    { 5, 1, "Core Count= 8, Clock Speed= 3.7GHz, Boost Speed= 4GHz, TDP=120W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 7 5800X", 245 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
