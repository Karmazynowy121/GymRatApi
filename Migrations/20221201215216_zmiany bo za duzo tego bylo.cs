using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRatApi.Migrations
{
    /// <inheritdoc />
    public partial class zmianybozaduzotegobylo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPart",
                table: "TrainingParts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountPart",
                table: "TrainingParts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
