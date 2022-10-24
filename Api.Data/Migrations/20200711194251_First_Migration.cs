using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CampeaoId = table.Column<Guid>(nullable: true),
                    ViceId = table.Column<Guid>(nullable: true),
                    TerceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championship_Time_CampeaoId",
                        column: x => x.CampeaoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championship_Time_TerceiroId",
                        column: x => x.TerceiroId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championship_Time_ViceId",
                        column: x => x.ViceId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Time1Id = table.Column<Guid>(nullable: true),
                    Goals1 = table.Column<int>(nullable: false),
                    Time2Id = table.Column<Guid>(nullable: true),
                    Goals2 = table.Column<int>(nullable: false),
                    ChampionshipEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Championship_ChampionshipEntityId",
                        column: x => x.ChampionshipEntityId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_Time1Id",
                        column: x => x.Time1Id,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_Time2Id",
                        column: x => x.Time2Id,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    TimeId = table.Column<Guid>(nullable: true),
                    ChampionshipId = table.Column<Guid>(nullable: true),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontuacaoChampionship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontuacaoChampionship_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontuacaoChampionship_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_CampeaoId",
                table: "Championship",
                column: "CampeaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_TerceiroId",
                table: "Championship",
                column: "TerceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_ViceId",
                table: "Championship",
                column: "ViceId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_ChampionshipEntityId",
                table: "Match",
                column: "ChampionshipEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_Time1Id",
                table: "Match",
                column: "Time1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_Time2Id",
                table: "Match",
                column: "Time2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoChampionship_ChampionshipId",
                table: "ChampionshipPoints",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoChampionship_TimeId",
                table: "ChampionshipPoints",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_name",
                table: "Time",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "ChampionshipPoints");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
