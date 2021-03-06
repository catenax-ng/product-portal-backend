using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatenaX.NetworkServices.PortalBackend.Migrations.Migrations
{
    public partial class CPLP748AddAppSubscriptionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "app_subscription_status_id",
                schema: "portal",
                table: "company_assigned_apps",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "app_subscription_statuses",
                schema: "portal",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    label = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_subscription_statuses", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "portal",
                table: "app_subscription_statuses",
                columns: new[] { "id", "label" },
                values: new object[,]
                {
                    { 1, "PENDING" },
                    { 2, "ACTIVE" },
                    { 3, "INACTIVE" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_company_assigned_apps_app_subscription_status_id",
                schema: "portal",
                table: "company_assigned_apps",
                column: "app_subscription_status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_company_assigned_apps_app_subscription_statuses_app_subscri",
                schema: "portal",
                table: "company_assigned_apps",
                column: "app_subscription_status_id",
                principalSchema: "portal",
                principalTable: "app_subscription_statuses",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_assigned_apps_app_subscription_statuses_app_subscri",
                schema: "portal",
                table: "company_assigned_apps");

            migrationBuilder.DropTable(
                name: "app_subscription_statuses",
                schema: "portal");

            migrationBuilder.DropIndex(
                name: "ix_company_assigned_apps_app_subscription_status_id",
                schema: "portal",
                table: "company_assigned_apps");

            migrationBuilder.DropColumn(
                name: "app_subscription_status_id",
                schema: "portal",
                table: "company_assigned_apps");
        }
    }
}
