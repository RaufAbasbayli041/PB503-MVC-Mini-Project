using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAConferenceManagement.Migrations
{
    /// <inheritdoc />
    public partial class dfwr45yutyutyugh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTypeDTO");

            migrationBuilder.DropTable(
                name: "OrganizerDTO");

            migrationBuilder.DropTable(
                name: "EventDTO");

            migrationBuilder.DropTable(
                name: "LocationDTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationDTO_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizerIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDTO_LocationDTO_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTypeDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTypeDTO_EventDTO_EventId",
                        column: x => x.EventId,
                        principalTable: "EventDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDTOId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizerDTO_EventDTO_EventDTOId",
                        column: x => x.EventDTOId,
                        principalTable: "EventDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDTO_LocationId",
                table: "EventDTO",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypeDTO_EventId",
                table: "EventTypeDTO",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDTO_EventId",
                table: "LocationDTO",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerDTO_EventDTOId",
                table: "OrganizerDTO",
                column: "EventDTOId");
        }
    }
}
