using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash" },
                values: new object[] { "d90ace67-70f8-4da9-8605-2fccf370b09a", "", "AQAAAAIAAYagAAAAEHvaxw0NGYfACwAKQT8MNfcjRGxJye+NcyxpyUHgGQvW7iyqOqIZDeInF8phu21p/g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2413312d-8caf-46a8-a3af-e1dfce568e41", "AQAAAAIAAYagAAAAEIPhtVG8bnCTK4ZM1plxmgr2+QScs5fOLvkpp4CnBw1y/w0EgQc/CKTaxvW5ePtYHw==" });
        }
    }
}
