﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Org.CatenaX.Ng.Portal.Backend.PortalBackend.Migrations.Migrations
{
    public partial class CPLP1417RemoveCompanyAssignedUserRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION portal.LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.Sql("DROP FUNCTION portal.LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.Sql("DROP FUNCTION portal.LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "portal",
                table: "company_user_assigned_roles");

            migrationBuilder.CreateTable(
                name: "audit_company_user_assigned_role20221012",
                schema: "portal",
                columns: table => new
                {
                    audit_v1id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_editor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    audit_v1last_editor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    audit_v1operation_id = table.Column<int>(type: "integer", nullable: false),
                    audit_v1date_last_changed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_company_user_assigned_role20221012", x => x.audit_v1id);
                });

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221012 (\"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT OLD.company_user_id, \r\n  OLD.user_role_id, \r\n  OLD.last_editor_id, \r\n  gen_random_uuid(), \r\n  3, \r\n  CURRENT_DATE, \r\n  OLD.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE AFTER DELETE\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE();");

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221012 (\"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT NEW.company_user_id, \r\n  NEW.user_role_id, \r\n  NEW.last_editor_id, \r\n  gen_random_uuid(), \r\n  1, \r\n  CURRENT_DATE, \r\n  NEW.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE AFTER INSERT\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE();");

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221012 (\"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT NEW.company_user_id, \r\n  NEW.user_role_id, \r\n  NEW.last_editor_id, \r\n  gen_random_uuid(), \r\n  2, \r\n  CURRENT_DATE, \r\n  NEW.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE AFTER UPDATE\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE();");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.Sql("DROP FUNCTION LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.Sql("DROP FUNCTION LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE() CASCADE;");

            migrationBuilder.DropTable(
                name: "audit_company_user_assigned_role20221012",
                schema: "portal");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "portal",
                table: "company_user_assigned_roles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221005 (\"id\", \"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT OLD.id, \r\n  OLD.company_user_id, \r\n  OLD.user_role_id, \r\n  OLD.last_editor_id, \r\n  gen_random_uuid(), \r\n  3, \r\n  CURRENT_DATE, \r\n  OLD.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE AFTER DELETE\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_DELETE_COMPANYUSERASSIGNEDROLE();");

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221005 (\"id\", \"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT NEW.id, \r\n  NEW.company_user_id, \r\n  NEW.user_role_id, \r\n  NEW.last_editor_id, \r\n  gen_random_uuid(), \r\n  1, \r\n  CURRENT_DATE, \r\n  NEW.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE AFTER INSERT\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_INSERT_COMPANYUSERASSIGNEDROLE();");

            migrationBuilder.Sql("CREATE FUNCTION portal.LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE() RETURNS trigger as $LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE$\r\nBEGIN\r\n  INSERT INTO portal.audit_company_user_assigned_role20221005 (\"id\", \"company_user_id\", \"user_role_id\", \"last_editor_id\", \"audit_v1id\", \"audit_v1operation_id\", \"audit_v1date_last_changed\", \"audit_v1last_editor_id\") SELECT NEW.id, \r\n  NEW.company_user_id, \r\n  NEW.user_role_id, \r\n  NEW.last_editor_id, \r\n  gen_random_uuid(), \r\n  2, \r\n  CURRENT_DATE, \r\n  NEW.last_editor_id;\r\nRETURN NEW;\r\nEND;\r\n$LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE$ LANGUAGE plpgsql;\r\nCREATE TRIGGER LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE AFTER UPDATE\r\nON portal.company_user_assigned_roles\r\nFOR EACH ROW EXECUTE PROCEDURE portal.LC_TRIGGER_AFTER_UPDATE_COMPANYUSERASSIGNEDROLE();");
        }
    }
}