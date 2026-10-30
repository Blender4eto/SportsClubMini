using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsClubMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSportsTrainersAndTrainingsNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sport",
                table: "SportClubs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SportClubs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "SportClubs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "SportClubSports",
                columns: table => new
                {
                    SportClubClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportsSportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportClubSports", x => new { x.SportClubClubId, x.SportsSportId });
                    table.ForeignKey(
                        name: "FK_SportClubSports_SportClubs_SportClubClubId",
                        column: x => x.SportClubClubId,
                        principalTable: "SportClubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportClubSports_Sports_SportsSportId",
                        column: x => x.SportsSportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_Trainers_SportClubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "SportClubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Trainings_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportClubSports_SportsSportId",
                table: "SportClubSports",
                column: "SportsSportId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Name",
                table: "Sports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_ClubId",
                table: "Trainers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SportId",
                table: "Trainers",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainerId",
                table: "Trainings",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportClubSports");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SportClubs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "SportClubs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "SportClubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
