using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAConferenceManagement.Migrations
{
    /// <inheritdoc />
    public partial class ewdfwr324sdawdqw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Organizers");

            migrationBuilder.CreateTable(
                name: "EventOrganizer",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    OrganizersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizer", x => new { x.EventsId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_EventOrganizer_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizer_OrganizersId",
                table: "EventOrganizer",
                column: "OrganizersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventOrganizer");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Organizers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
