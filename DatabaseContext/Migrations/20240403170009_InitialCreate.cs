using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chakatons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Dates = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Direction = table.Column<string>(type: "text", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: false),
                    Links = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chakatons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: false),
                    Post = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    HardSkills = table.Column<string>(type: "text", nullable: false),
                    Links = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Direction = table.Column<string>(type: "text", nullable: false),
                    Requirements = table.Column<string>(type: "text", nullable: false),
                    LeaderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChakatonTeam",
                columns: table => new
                {
                    ChakatonsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChakatonTeam", x => new { x.ChakatonsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_ChakatonTeam_Chakatons_ChakatonsId",
                        column: x => x.ChakatonsId,
                        principalTable: "Chakatons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChakatonTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    RequestText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.MembersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_TeamUser_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamUser_Users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestTeam",
                columns: table => new
                {
                    RequestsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTeam", x => new { x.RequestsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_RequestTeam_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chakatons_Name",
                table: "Chakatons",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChakatonTeam_TeamsId",
                table: "ChakatonTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TeamId",
                table: "Requests",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTeam_TeamsId",
                table: "RequestTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_TeamsId",
                table: "TeamUser",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChakatonTeam");

            migrationBuilder.DropTable(
                name: "RequestTeam");

            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropTable(
                name: "Chakatons");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
