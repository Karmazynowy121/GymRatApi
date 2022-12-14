using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRatApi.Migrations
{
    /// <inheritdoc />
    public partial class usertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TrainingScheulde_TrainingScheuldeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TrainingScheuldeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingScheuldeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TrainingScheulde");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TrainingScheulde",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingDuration",
                table: "Training",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "UserTrainingScheuldes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingScheuldeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainingScheuldes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainingScheuldes_TrainingScheulde_UserId",
                        column: x => x.UserId,
                        principalTable: "TrainingScheulde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrainingScheuldes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingScheuldes_UserId",
                table: "UserTrainingScheuldes",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTrainingScheuldes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TrainingScheulde");

            migrationBuilder.AddColumn<int>(
                name: "TrainingScheuldeId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TrainingScheulde",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrainingDuration",
                table: "Training",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrainingScheuldeId",
                table: "Users",
                column: "TrainingScheuldeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TrainingScheulde_TrainingScheuldeId",
                table: "Users",
                column: "TrainingScheuldeId",
                principalTable: "TrainingScheulde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
