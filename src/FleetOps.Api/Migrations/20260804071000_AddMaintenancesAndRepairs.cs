using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetOps.Api.Migrations
{
    public partial class AddMaintenancesAndRepairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "MaintenanceTypes", columns: table => new { Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false) }, constraints: table => table.PrimaryKey("PK_MaintenanceTypes", x => x.Id));
            migrationBuilder.CreateTable(name: "RepairTypes", columns: table => new { Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false) }, constraints: table => table.PrimaryKey("PK_RepairTypes", x => x.Id));
            migrationBuilder.CreateTable(name: "Maintenances", columns: table => new { Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false), MaintenanceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false), PlannedDate = table.Column<DateOnly>(type: "date", nullable: false), CompletedDate = table.Column<DateOnly>(type: "date", nullable: true), Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1) }, constraints: table => { table.PrimaryKey("PK_Maintenances", x => x.Id); table.ForeignKey(name: "FK_Maintenances_MaintenanceTypes_MaintenanceTypeId", column: x => x.MaintenanceTypeId, principalTable: "MaintenanceTypes", principalColumn: "Id"); table.ForeignKey(name: "FK_Maintenances_Vehicles_VehicleId", column: x => x.VehicleId, principalTable: "Vehicles", principalColumn: "Id"); });
            migrationBuilder.CreateTable(name: "Repairs", columns: table => new { Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false), RepairTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false), Description = table.Column<string>(type: "nvarchar(max)", nullable: false), Cost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false), Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1), CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false) }, constraints: table => { table.PrimaryKey("PK_Repairs", x => x.Id); table.ForeignKey(name: "FK_Repairs_RepairTypes_RepairTypeId", column: x => x.RepairTypeId, principalTable: "RepairTypes", principalColumn: "Id"); table.ForeignKey(name: "FK_Repairs_Vehicles_VehicleId", column: x => x.VehicleId, principalTable: "Vehicles", principalColumn: "Id"); });
            migrationBuilder.CreateIndex(name: "IX_MaintenanceTypes_Name", table: "MaintenanceTypes", column: "Name", unique: true);
            migrationBuilder.CreateIndex(name: "IX_Maintenances_MaintenanceTypeId", table: "Maintenances", column: "MaintenanceTypeId");
            migrationBuilder.CreateIndex(name: "IX_Maintenances_VehicleId_PlannedDate", table: "Maintenances", columns: new[] { "VehicleId", "PlannedDate" });
            migrationBuilder.CreateIndex(name: "IX_RepairTypes_Name", table: "RepairTypes", column: "Name", unique: true);
            migrationBuilder.CreateIndex(name: "IX_Repairs_RepairTypeId", table: "Repairs", column: "RepairTypeId");
            migrationBuilder.CreateIndex(name: "IX_Repairs_VehicleId_CreatedAt", table: "Repairs", columns: new[] { "VehicleId", "CreatedAt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Maintenances");
            migrationBuilder.DropTable(name: "Repairs");
            migrationBuilder.DropTable(name: "MaintenanceTypes");
            migrationBuilder.DropTable(name: "RepairTypes");
        }
    }
}
