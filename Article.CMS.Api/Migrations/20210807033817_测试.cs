using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Article.CMS.Api.Migrations
{
    public partial class 测试 : Migration
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
                    { 1, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7601), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7605) },
                    { 2, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7608), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7609) },
                    { 3, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7611), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7612) },
                    { 4, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7613), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7614) },
                    { 5, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7616), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(7617) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8441), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8446) },
                    { 2, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8449), true, false, "管理员", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8450) },
                    { 3, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8451), true, false, "用户", "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(8452) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 11, 38, 16, 760, DateTimeKind.Local).AddTicks(6057), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(3520) },
                    { 2, new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4199), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4204) },
                    { 3, new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4207), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4208) },
                    { 4, new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4210), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4211) },
                    { 5, new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4213), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 7, 11, 38, 16, 761, DateTimeKind.Local).AddTicks(4214) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImageUrl", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9837), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9842), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9845), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9846), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9848), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9849), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9850), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9851), 1 },
                    { 5, "这里是简介5", "歌单", "UploadFiles/Article.jpg", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9853), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(9854), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6811), "UploadFiles/DefaultImg.png", true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6825), 1 },
                    { 2, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6829), "UploadFiles/DefaultImg.png", true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6830), 2 },
                    { 3, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6832), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6833), 3 },
                    { 4, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6835), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6836), 4 },
                    { 5, new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6837), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 7, 11, 38, 16, 762, DateTimeKind.Local).AddTicks(6838), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2060), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2061), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2063), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2064), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2053), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2057), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2065), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2066), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2068), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2069), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2070), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2071), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2073), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2073), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2075), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2076), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2077), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2078), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2080), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2081), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2082), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(2083), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(773), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(777) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(780), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(781) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(783), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(784) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(785), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(786) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(788), true, false, "种子数据", new DateTime(2021, 8, 7, 11, 38, 16, 763, DateTimeKind.Local).AddTicks(789) }
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
