using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetOps.Api.Migrations
{
    public partial class AddRoutesAndTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Routes", columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
            }, constraints: table => table.PrimaryKey("PK_Routes", x => x.Id));

            migrationBuilder.CreateTable(name: "RoutePoints", columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                OrderNumber = table.Column<int>(type: "int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_RoutePoints", x => x.Id);
                table.ForeignKey(name: "FK_RoutePoints_Routes_RouteId", column: x => x.RouteId, principalTable: "Routes", principalColumn: "Id");
            });

            migrationBuilder.CreateTable(name: "Trips", columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Trips", x => x.Id);
                table.ForeignKey(name: "FK_Trips_Drivers_DriverId", column: x => x.DriverId, principalTable: "Drivers", principalColumn: "Id");
                table.ForeignKey(name: "FK_Trips_Routes_RouteId", column: x => x.RouteId, principalTable: "Routes", principalColumn: "Id");
                table.ForeignKey(name: "FK_Trips_Vehicles_VehicleId", column: x => x.VehicleId, principalTable: "Vehicles", principalColumn: "Id");
            });

            migrationBuilder.CreateIndex(name: "IX_Routes_Name", table: "Routes", column: "Name", unique: true);
            migrationBuilder.CreateIndex(name: "IX_RoutePoints_RouteId_OrderNumber", table: "RoutePoints", columns: new[] { "RouteId", "OrderNumber" }, unique: true);
            migrationBuilder.CreateIndex(name: "IX_Trips_DriverId_StartTime", table: "Trips", columns: new[] { "DriverId", "StartTime" });
            migrationBuilder.CreateIndex(name: "IX_Trips_RouteId", table: "Trips", column: "RouteId");
            migrationBuilder.CreateIndex(name: "IX_Trips_VehicleId_StartTime", table: "Trips", columns: new[] { "VehicleId", "StartTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "RoutePoints");
            migrationBuilder.DropTable(name: "Trips");
            migrationBuilder.DropTable(name: "Routes");
        }
    }
}
