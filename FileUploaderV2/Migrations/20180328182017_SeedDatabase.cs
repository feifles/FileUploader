using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FileUploaderV2.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add to Makes
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company1')");
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company2')");
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company3')");

            //Add to Models
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company1-GroupA', (SELECT ID FROM Companies WHERE Name='Company1' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company1-GroupB', (SELECT ID FROM Companies WHERE Name='Company1' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company1-GroupC', (SELECT ID FROM Companies WHERE Name='Company1' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company2-GroupA', (SELECT ID FROM Companies WHERE Name='Company2' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company2-GroupB', (SELECT ID FROM Companies WHERE Name='Company2' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company2-GroupC', (SELECT ID FROM Companies WHERE Name='Company2' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company3-GroupA', (SELECT ID FROM Companies WHERE Name='Company3' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company3-GroupB', (SELECT ID FROM Companies WHERE Name='Company3' ))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId) VALUES ('Company3-GroupC', (SELECT ID FROM Companies WHERE Name='Company3' ))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Companies WHERE Name IN ('Company1', 'Company2', 'Company3')");
        }
    }
}
