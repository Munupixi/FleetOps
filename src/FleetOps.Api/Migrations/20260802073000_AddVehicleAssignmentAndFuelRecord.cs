using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetOps.Api.Migrations
{
    public partial class AddVehicleAssignmentAndFuelRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "FuelRecords", columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FuelType = table.Column<int>(type: "int", nullable: false),
                Volume = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                Mileage = table.Column<int>(type: "int", nullable: false),
                RefueledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_FuelRecords", x => x.Id);
                table.ForeignKey(name: "FK_FuelRecords_Vehicles_VehicleId", column: x => x.VehicleId, principalTable: "Vehicles", principalColumn: "Id");
            });

            migrationBuilder.CreateTable(name: "VehicleAssignments", columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UnassignedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_VehicleAssignments", x => x.Id);
                table.ForeignKey(name: "FK_VehicleAssignments_Drivers_DriverId", column: x => x.DriverId, principalTable: "Drivers", principalColumn: "Id");
                table.ForeignKey(name: "FK_VehicleAssignments_Vehicles_VehicleId", column: x => x.VehicleId, principalTable: "Vehicles", principalColumn: "Id");
            });

            migrationBuilder.CreateIndex(name: "IX_FuelRecords_VehicleId_RefueledAt", table: "FuelRecords", columns: new[] { "VehicleId", "RefueledAt" });
            migrationBuilder.CreateIndex(name: "IX_VehicleAssignments_DriverId", table: "VehicleAssignments", column: "DriverId");
            migrationBuilder.CreateIndex(name: "IX_VehicleAssignments_VehicleId_UnassignedAt", table: "VehicleAssignments", columns: new[] { "VehicleId", "UnassignedAt" }, unique: true, filter: "[UnassignedAt] IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FuelRecords");
            migrationBuilder.DropTable(name: "VehicleAssignments");
        }
    }
}
