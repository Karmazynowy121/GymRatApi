using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRatApi.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationvideoexercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Sports_SportId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Videos_VideoId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_SportId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_VideoId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Videos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Sports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "BodyParts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ExerciseId",
                table: "Videos",
                column: "ExerciseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_ExerciseId",
                table: "Sports",
                column: "ExerciseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Exercises_ExerciseId",
                table: "Sports",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Exercises_ExerciseId",
                table: "Videos",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Exercises_ExerciseId",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Exercises_ExerciseId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ExerciseId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Sports_ExerciseId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Sports");

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Exercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "BodyParts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_SportId",
                table: "Exercises",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_VideoId",
                table: "Exercises",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Sports_SportId",
                table: "Exercises",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Videos_VideoId",
                table: "Exercises",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
