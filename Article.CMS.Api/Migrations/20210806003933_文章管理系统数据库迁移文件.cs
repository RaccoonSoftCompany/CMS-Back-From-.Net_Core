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
                name: "ImagesUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesUrl", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Matters",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(378), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(383) },
                    { 2, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(387), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(388) },
                    { 3, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(390), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(391) },
                    { 4, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(392), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(393) },
                    { 5, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(395), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(396) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1377), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1382) },
                    { 2, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1386), true, false, "管理员", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1387) },
                    { 3, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1388), true, false, "用户", "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(1389) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 8, 39, 32, 881, DateTimeKind.Local).AddTicks(337), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(4472) },
                    { 2, new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5296), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5303) },
                    { 3, new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5306), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5307) },
                    { 4, new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5309), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5310) },
                    { 5, new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5312), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 6, 8, 39, 32, 882, DateTimeKind.Local).AddTicks(5313) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImage", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2816), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2821), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2825), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2826), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2827), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2829), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2830), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2831), 1 },
                    { 5, "这里是简介5", "歌单", null, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2833), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(2834), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9464), null, true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9473), 1 },
                    { 2, new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9477), null, true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9479), 2 },
                    { 3, new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9481), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9482), 3 },
                    { 4, new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9484), null, true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9485), 4 },
                    { 5, new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9487), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 8, 39, 32, 883, DateTimeKind.Local).AddTicks(9488), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5159), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5160), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5161), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5163), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5150), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5154), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5165), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5166), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5167), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5168), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5170), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5171), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5173), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5174), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5176), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5177), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5178), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5179), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5181), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5182), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5184), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(5185), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3866), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3871) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3875), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3876) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3877), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3878) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3880), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3881) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3883), true, false, "种子数据", new DateTime(2021, 8, 6, 8, 39, 32, 884, DateTimeKind.Local).AddTicks(3884) }
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
                name: "ArticleTexts");

            migrationBuilder.DropTable(
                name: "AuditInfo");

            migrationBuilder.DropTable(
                name: "ImagesUrl");

            migrationBuilder.DropTable(
                name: "UserInfos");

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
