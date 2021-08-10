using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Article.CMS.Api.Migrations
{
    public partial class 文章管理系统 : Migration
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
                name: "WebSide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebName = table.Column<string>(type: "text", nullable: true),
                    ICPCase = table.Column<string>(type: "text", nullable: true),
                    PSecurit = table.Column<string>(type: "text", nullable: true),
                    Copyright = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSide", x => x.Id);
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
                name: "QRCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebSideId = table.Column<int>(type: "integer", nullable: false),
                    QRUrl = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRCode_WebSide_WebSideId",
                        column: x => x.WebSideId,
                        principalTable: "WebSide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlideShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WebSideId = table.Column<int>(type: "integer", nullable: false),
                    SlideSideUrl = table.Column<string>(type: "text", nullable: true),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlideShow_WebSide_WebSideId",
                        column: x => x.WebSideId,
                        principalTable: "WebSide",
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
                    { 1, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7701), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7707) },
                    { 2, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7711), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7712) },
                    { 3, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7714), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7716) },
                    { 4, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7717), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7719) },
                    { 5, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7721), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(7722) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8923), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8927) },
                    { 2, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8931), true, false, "管理员", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8933) },
                    { 3, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8935), true, false, "用户", "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(8936) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 10, 20, 42, 35, 259, DateTimeKind.Local).AddTicks(374), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(8351) },
                    { 2, new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9242), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9249) },
                    { 3, new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9252), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9253) },
                    { 4, new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9255), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9256) },
                    { 5, new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9259), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 10, 20, 42, 35, 260, DateTimeKind.Local).AddTicks(9261) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImageUrl", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", "UploadFiles/Article.jpg", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1771), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1776), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", "UploadFiles/Article.jpg", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1780), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1781), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", "UploadFiles/Article.jpg", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1784), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1785), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", "UploadFiles/Article.jpg", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1787), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1789), 1 },
                    { 5, "这里是简介5", "歌单", "UploadFiles/Article.jpg", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1791), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(1792), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6332), "UploadFiles/DefaultImg.png", true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6357), 1 },
                    { 2, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6364), "UploadFiles/DefaultImg.png", true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6366), 2 },
                    { 3, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6368), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6370), 3 },
                    { 4, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6372), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6373), 4 },
                    { 5, new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6375), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 10, 20, 42, 35, 262, DateTimeKind.Local).AddTicks(6376), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4725), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4726), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4728), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4729), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4716), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4720), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4732), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4733), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4735), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4736), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4738), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4740), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4742), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4743), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4745), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4746), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4748), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4749), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4751), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4753), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4754), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(4756), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3181), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3186) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3190), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3192) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3193), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3195) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3197), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3198) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3200), true, false, "种子数据", new DateTime(2021, 8, 10, 20, 42, 35, 263, DateTimeKind.Local).AddTicks(3201) }
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
                name: "IX_QRCode_WebSideId",
                table: "QRCode",
                column: "WebSideId");

            migrationBuilder.CreateIndex(
                name: "IX_SlideShow_WebSideId",
                table: "SlideShow",
                column: "WebSideId");

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
                name: "QRCode");

            migrationBuilder.DropTable(
                name: "SlideShow");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "WebSide");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "Powers");
        }
    }
}
