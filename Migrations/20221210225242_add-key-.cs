using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRatApi.Migrations
{
    /// <inheritdoc />
    public partial class addkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainingParts_ExerciseId",
                table: "TrainingParts");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParts_ExerciseId",
                table: "TrainingParts",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainingParts_ExerciseId",
                table: "TrainingParts");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingParts_ExerciseId",
                table: "TrainingParts",
                column: "ExerciseId",
                unique: true);
        }
    }
}
