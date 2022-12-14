using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRatApi.Migrations
{
    /// <inheritdoc />
    public partial class relationwithUserTrainingScheulde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingScheuldes_TrainingScheulde_UserId",
                table: "UserTrainingScheuldes");

            migrationBuilder.DropIndex(
                name: "IX_UserTrainingScheuldes_UserId",
                table: "UserTrainingScheuldes");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingScheuldes_TrainingScheuldeId",
                table: "UserTrainingScheuldes",
                column: "TrainingScheuldeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingScheuldes_UserId",
                table: "UserTrainingScheuldes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingScheuldes_TrainingScheulde_TrainingScheuldeId",
                table: "UserTrainingScheuldes",
                column: "TrainingScheuldeId",
                principalTable: "TrainingScheulde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingScheuldes_TrainingScheulde_TrainingScheuldeId",
                table: "UserTrainingScheuldes");

            migrationBuilder.DropIndex(
                name: "IX_UserTrainingScheuldes_TrainingScheuldeId",
                table: "UserTrainingScheuldes");

            migrationBuilder.DropIndex(
                name: "IX_UserTrainingScheuldes_UserId",
                table: "UserTrainingScheuldes");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingScheuldes_UserId",
                table: "UserTrainingScheuldes",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingScheuldes_TrainingScheulde_UserId",
                table: "UserTrainingScheuldes",
                column: "UserId",
                principalTable: "TrainingScheulde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
