using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FileUploaderV2.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add to Companies
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company1')");
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company2')");
            migrationBuilder.Sql("INSERT INTO Companies (Name) VALUES ('Company3')");

            //Add DbConfig
            migrationBuilder.Sql("INSERT INTO DBConfigs (Server, DatabaseName, Username, Password) VALUES ('Server1', 'DB1', 'Username', 'Password')");
            migrationBuilder.Sql("INSERT INTO DBConfigs (Server, DatabaseName, Username, Password) VALUES ('Server2', 'DB2', 'Username', 'Password')");
            migrationBuilder.Sql("INSERT INTO DBConfigs (Server, DatabaseName, Username, Password) VALUES ('Server3', 'DB3', 'Username', 'Password')");

            //Add to AddGroups
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company1-GroupA', (SELECT ID FROM Companies WHERE Name='Company1' ), (SELECT ID FROM DBConfigs WHERE Server='Server1'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company1-GroupB', (SELECT ID FROM Companies WHERE Name='Company1' ), (SELECT ID FROM DBConfigs WHERE Server='Server1'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company1-GroupC', (SELECT ID FROM Companies WHERE Name='Company1' ), (SELECT ID FROM DBConfigs WHERE Server='Server1'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company2-GroupA', (SELECT ID FROM Companies WHERE Name='Company2' ), (SELECT ID FROM DBConfigs WHERE Server='Server2'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company2-GroupB', (SELECT ID FROM Companies WHERE Name='Company2' ), (SELECT ID FROM DBConfigs WHERE Server='Server2'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company2-GroupC', (SELECT ID FROM Companies WHERE Name='Company2' ), (SELECT ID FROM DBConfigs WHERE Server='Server2'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company3-GroupA', (SELECT ID FROM Companies WHERE Name='Company3' ), (SELECT ID FROM DBConfigs WHERE Server='Server3'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company3-GroupB', (SELECT ID FROM Companies WHERE Name='Company3' ), (SELECT ID FROM DBConfigs WHERE Server='Server3'))");
            migrationBuilder.Sql("INSERT INTO Groups (Name, CompanyId, DBConfigId) VALUES ('Company3-GroupC', (SELECT ID FROM Companies WHERE Name='Company3' ), (SELECT ID FROM DBConfigs WHERE Server='Server3'))");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Companies WHERE Name IN ('Company1', 'Company2', 'Company3')");
        }
    }
}
