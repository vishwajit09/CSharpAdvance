using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherInformation.Migrations
{
    /// <inheritdoc />
    public partial class Changedatabasekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherInfos",
                table: "WeatherInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WeatherInfos");

            migrationBuilder.AlterColumn<string>(
                name: "datetime",
                table: "WeatherInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "WeatherInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherInfos",
                table: "WeatherInfos",
                columns: new[] { "city", "datetime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherInfos",
                table: "WeatherInfos");

            migrationBuilder.AlterColumn<string>(
                name: "datetime",
                table: "WeatherInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "WeatherInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WeatherInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherInfos",
                table: "WeatherInfos",
                column: "Id");
        }
    }
}
