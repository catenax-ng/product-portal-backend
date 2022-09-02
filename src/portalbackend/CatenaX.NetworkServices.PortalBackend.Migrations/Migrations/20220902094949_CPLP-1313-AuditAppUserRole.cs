using System;
using Microsoft.EntityFrameworkCore.Migrations;
using CatenaX.NetworkServices.PortalBackend.PortalEntities.AuditEntities;
#nullable disable

namespace CatenaX.NetworkServices.PortalBackend.Migrations.Migrations
{
    public partial class CPLP1313AuditAppUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "last_editor_id",
                schema: "portal",
                table: "user_roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "date_last_changed",
                schema: "portal",
                table: "apps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "last_editor_id",
                schema: "portal",
                table: "apps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description_short",
                schema: "portal",
                table: "app_descriptions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "description_long",
                schema: "portal",
                table: "app_descriptions",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096);

            migrationBuilder.CreateTable(
                name: "audit_apps_cplp_1313_audit_app_user_role",
                schema: "portal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    audit_id = table.Column<Guid>(type: "uuid", nullable: false),
                    audit_operation_id = table.Column<int>(type: "integer", nullable: false),
                    date_last_changed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    date_created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date_released = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    thumbnail_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    marketing_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact_number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    provider = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_core_component = table.Column<bool>(type: "boolean", nullable: false),
                    sales_manager_id = table.Column<Guid>(type: "uuid", nullable: true),
                    provider_company_id = table.Column<Guid>(type: "uuid", nullable: true),
                    last_editor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    app_status_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_apps_cplp_1313_audit_app_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audit_user_roles_cplp_1313_audit_app_user_role",
                schema: "portal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    audit_id = table.Column<Guid>(type: "uuid", nullable: false),
                    audit_operation_id = table.Column<int>(type: "integer", nullable: false),
                    date_last_changed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    user_role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    app_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_editor_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_user_roles_cplp_1313_audit_app_user_role", x => x.id);
                });

            migrationBuilder.AddAuditTrigger<AuditApp>("cplp_1313_audit_app_user_role");
            migrationBuilder.AddAuditTrigger<AuditUserRole>("cplp_1313_audit_app_user_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropAuditTrigger<AuditApp>();
            migrationBuilder.DropAuditTrigger<AuditUserRole>();
            migrationBuilder.DropTable(
                name: "audit_apps_cplp_1313_audit_app_user_role",
                schema: "portal");

            migrationBuilder.DropTable(
                name: "audit_user_roles_cplp_1313_audit_app_user_role",
                schema: "portal");

            migrationBuilder.DeleteData(
                schema: "portal",
                table: "company_roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "last_editor_id",
                schema: "portal",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "last_editor_id",
                schema: "portal",
                table: "apps");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "date_last_changed",
                schema: "portal",
                table: "apps",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "description_short",
                schema: "portal",
                table: "app_descriptions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description_long",
                schema: "portal",
                table: "app_descriptions",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096,
                oldNullable: true);
        }
    }
}
