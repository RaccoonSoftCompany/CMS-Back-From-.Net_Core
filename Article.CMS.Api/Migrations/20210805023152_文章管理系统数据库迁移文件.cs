using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Article.CMS.Api.Migrations
{
    public partial class 文章管理系统数据库迁移文件 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterId = table.Column<int>(type: "int", nullable: false),
                    MKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ATitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATitleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleAPraises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAPraises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleAPraises_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleReads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleReads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleReads_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTalks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ATText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTalks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTalks_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    AText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isATimage = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTexts_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTextImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTextId = table.Column<int>(type: "int", nullable: false),
                    ATImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATImageRank = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTextImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTextImages_ArticleTexts_ArticleTextId",
                        column: x => x.ArticleTextId,
                        principalTable: "ArticleTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matters",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5462), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5467) },
                    { 2, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5471), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5472) },
                    { 3, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5474), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5475) },
                    { 4, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5534), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5535) },
                    { 5, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5538), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(5539) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6725), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6730) },
                    { 2, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6733), true, false, "管理员", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6734) },
                    { 3, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6736), true, false, "用户", "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(6737) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 5, 10, 31, 52, 276, DateTimeKind.Local).AddTicks(3197), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(7220) },
                    { 2, new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8051), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8057) },
                    { 3, new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8061), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8062) },
                    { 4, new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8064), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8065) },
                    { 5, new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8067), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 5, 10, 31, 52, 277, DateTimeKind.Local).AddTicks(8068) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImage", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8441), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8446), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8450), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8451), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8452), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8454), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8455), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8456), 1 },
                    { 5, "这里是简介5", "歌单", null, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8459), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(8460), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4540), null, true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4555), 1 },
                    { 2, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4560), null, true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4561), 2 },
                    { 3, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4563), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4564), 3 },
                    { 4, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4566), null, true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4567), 4 },
                    { 5, new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4570), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 5, 10, 31, 52, 279, DateTimeKind.Local).AddTicks(4571), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1658), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1659), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1661), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1662), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1650), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1655), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1664), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1665), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1667), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1668), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1669), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1671), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1672), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1673), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1675), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1676), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1678), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1679), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1680), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1681), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1683), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(1684), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "isATimage" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(155), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(159), false },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(164), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(165), false },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(167), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(168), false },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(170), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(171), false },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(173), true, false, "种子数据", new DateTime(2021, 8, 5, 10, 31, 52, 280, DateTimeKind.Local).AddTicks(174), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAPraises_ArticleId",
                table: "ArticleAPraises",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReads_ArticleId",
                table: "ArticleReads",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTalks_ArticleId",
                table: "ArticleTalks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTextImages_ArticleTextId",
                table: "ArticleTextImages",
                column: "ArticleTextId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTexts_ArticleId",
                table: "ArticleTexts",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserId",
                table: "UserInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MatterId",
                table: "Users",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PowerId",
                table: "Users",
                column: "PowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleAPraises");

            migrationBuilder.DropTable(
                name: "ArticleReads");

            migrationBuilder.DropTable(
                name: "ArticleTalks");

            migrationBuilder.DropTable(
                name: "ArticleTextImages");

            migrationBuilder.DropTable(
                name: "AuditInfo");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "ArticleTexts");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "Powers");
        }
    }
}
