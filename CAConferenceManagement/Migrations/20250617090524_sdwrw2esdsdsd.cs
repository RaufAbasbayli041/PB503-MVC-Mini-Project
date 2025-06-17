using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAConferenceManagement.Migrations
{
    /// <inheritdoc />
    public partial class sdwrw2esdsdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_EventId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Organizers");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LocationId", "OrganizerId" },
                values: new object[] { 0, 2 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LocationId", "OrganizerId" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EventId",
                table: "Locations",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
