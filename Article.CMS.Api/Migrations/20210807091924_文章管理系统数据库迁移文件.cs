using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Parameters = table.Column<string>(type: "text", nullable: true),
                    BrowserInfo = table.Column<string>(type: "text", nullable: true),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientIpAddress = table.Column<string>(type: "text", nullable: true),
                    ExecutionDuration = table.Column<int>(type: "integer", nullable: false),
                    ExecutionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnValue = table.Column<string>(type: "text", nullable: true),
                    Exception = table.Column<string>(type: "text", nullable: true),
                    MethodName = table.Column<string>(type: "text", nullable: true),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    UserInfo = table.Column<string>(type: "text", nullable: true),
                    CustomData = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OriginName = table.Column<string>(type: "text", nullable: true),
                    CurrentName = table.Column<string>(type: "text", nullable: true),
                    ATImageUrl = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesUrl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MName = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PName = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UName = table.Column<string>(type: "text", nullable: true),
                    UEmail = table.Column<string>(type: "text", nullable: true),
                    Upassword = table.Column<string>(type: "text", nullable: true),
                    MatterId = table.Column<int>(type: "integer", nullable: false),
                    MKey = table.Column<string>(type: "text", nullable: true),
                    PowerId = table.Column<int>(type: "integer", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ATitle = table.Column<string>(type: "text", nullable: true),
                    AIntro = table.Column<string>(type: "text", nullable: true),
                    ATitleImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    ATText = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    AText = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
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
                    { 1, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9153), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9160) },
                    { 2, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9167), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9168) },
                    { 3, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9170), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9171) },
                    { 4, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9173), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9174) },
                    { 5, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9175), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(9176) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(190), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(195) },
                    { 2, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(200), true, false, "管理员", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(202) },
                    { 3, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(203), true, false, "用户", "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(205) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 17, 19, 23, 531, DateTimeKind.Local).AddTicks(6398), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(860) },
                    { 2, new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1717), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1723) },
                    { 3, new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1727), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1728) },
                    { 4, new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1730), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1731) },
                    { 5, new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1734), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 7, 17, 19, 23, 533, DateTimeKind.Local).AddTicks(1736) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImageUrl", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1846), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1851), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1855), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1856), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1858), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1859), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1861), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1862), 1 },
                    { 5, "这里是简介5", "歌单", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1864), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(1865), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8122), "UploadFiles/DefaultImg.png", true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8145), 1 },
                    { 2, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8150), "UploadFiles/DefaultImg.png", true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8151), 2 },
                    { 3, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8154), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8155), 3 },
                    { 4, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8156), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8158), 4 },
                    { 5, new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8160), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 7, 17, 19, 23, 534, DateTimeKind.Local).AddTicks(8161), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4389), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4390), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4392), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4394), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4377), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4384), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4395), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4396), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4398), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4399), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4402), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4404), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4405), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4406), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4408), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4409), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4411), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4412), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4414), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4415), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4417), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(4418), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2940), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2945) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2948), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2949) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2951), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2952) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2954), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2955) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2957), true, false, "种子数据", new DateTime(2021, 8, 7, 17, 19, 23, 535, DateTimeKind.Local).AddTicks(2958) }
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
