using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PCDoctor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Core Count= 6, Clock Speed= 3.7GHz, Boost Speed= 4.6GHz, TDP=65W,Integrated Graphics=None", "Intel", "Intel Core i5-13600K", 345 },
                    { 2, "Core Count= 16, Clock Speed= 4.7GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", "Intel", "Intel Core i9-13900K", 654 },
                    { 3, "Core Count= 6, Clock Speed= 4.2GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 5 7600X", 343 },
                    { 4, "Core Count= 8, Clock Speed= 4.7GHz, Boost Speed= 5GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", "Intel", "Intel Core i7-13700K", 532 },
                    { 5, "Core Count= 8, Clock Speed= 3.7GHz, Boost Speed= 4GHz, TDP=120W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 7 5800X", 245 },
                    { 6, "Core Count= 16, Clock Speed= 3.4GHz, Boost Speed= 3.4GHz, TDP=105W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 7 7800X3D", 435 },
                    { 7, "Core Count= 6, Clock Speed= 4.3GHz, Boost Speed= 4GHz, TDP=105W,Integrated Graphics=None", "AMD", "AMD Ryzen 5 5600X", 100 },
                    { 8, "Core Count= 16, Clock Speed= 5.2GHz, Boost Speed= 6.7GHz, TDP=130W,Integrated Graphics=Intel UHD Graphics 770", "Intel", "Intel Core i7-12700K", 412 },
                    { 9, "Core Count= 8, Clock Speed= 4.7GHz, Boost Speed= 5GHz, TDP=65W,Integrated Graphics=Radeon", "AMD", "AMD Ryzen 7 5700X", 242 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
