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
                    ATitleImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1788), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1794) },
                    { 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1798), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1799) },
                    { 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1801), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1802) },
                    { 4, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1804), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1805) },
                    { 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1807), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(1808) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2634), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2638) },
                    { 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2642), true, false, "管理员", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2643) },
                    { 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2645), true, false, "用户", "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(2646) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 27, 59, 995, DateTimeKind.Local).AddTicks(6059), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(4558) },
                    { 2, new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5372), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5378) },
                    { 3, new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5381), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5382) },
                    { 4, new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5384), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5385) },
                    { 5, new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5387), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 6, 20, 27, 59, 997, DateTimeKind.Local).AddTicks(5388) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImageUrl", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5335), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5348), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5352), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5354), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5356), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5357), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5359), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5360), 1 },
                    { 5, "这里是简介5", "歌单", null, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5362), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(5363), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(856), "http://localhost:5000/UploadFiles/DefaultImg.png", true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(877), 1 },
                    { 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(882), "http://localhost:5000/UploadFiles/DefaultImg.png", true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(883), 2 },
                    { 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(885), "http://localhost:5000/UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(886), 3 },
                    { 4, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(888), "http://localhost:5000/UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(889), 4 },
                    { 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(891), "http://localhost:5000/UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(892), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8332), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8333), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8335), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8336), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8319), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8325), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8338), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8339), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8341), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8342), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8343), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8345), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8346), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8347), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8350), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8351), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8352), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8353), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8355), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8356), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8358), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(8359), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6843), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6849) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6854), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6856) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6857), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6858) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6860), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6861) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6863), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 27, 59, 999, DateTimeKind.Local).AddTicks(6864) }
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
