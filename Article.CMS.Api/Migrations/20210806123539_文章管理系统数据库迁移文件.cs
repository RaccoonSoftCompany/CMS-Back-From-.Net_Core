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
                    { 1, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5861), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5866) },
                    { 2, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5870), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5871) },
                    { 3, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5873), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5874) },
                    { 4, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5876), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5877) },
                    { 5, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5879), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(5880) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6720), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6725) },
                    { 2, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6730), true, false, "管理员", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6731) },
                    { 3, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6732), true, false, "用户", "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(6733) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 35, 38, 538, DateTimeKind.Local).AddTicks(3815), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8007) },
                    { 2, new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8835), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8841) },
                    { 3, new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8845), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8846) },
                    { 4, new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8848), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8849) },
                    { 5, new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8851), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 6, 20, 35, 38, 539, DateTimeKind.Local).AddTicks(8852) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AIntro", "ATitle", "ATitleImageUrl", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "这里是简介1", "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8173), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8178), 1 },
                    { 2, "这里是简介2", "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8182), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8183), 1 },
                    { 3, "这里是简介3", "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8185), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8187), 1 },
                    { 4, "这里是简介4", "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8189), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8190), 1 },
                    { 5, "这里是简介5", "歌单", null, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8191), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(8193), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4696), "UploadFiles/DefaultImg.png", true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4727), 1 },
                    { 2, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4734), "UploadFiles/DefaultImg.png", true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4735), 2 },
                    { 3, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4738), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4739), 3 },
                    { 4, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4741), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4742), 4 },
                    { 5, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4744), "UploadFiles/DefaultImg.png", true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(4745), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(679), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(680), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(682), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(683), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(667), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(672), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(685), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(686), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(688), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(689), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(690), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(691), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(693), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(694), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(696), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(697), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(699), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(700), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(702), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(703), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(705), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 542, DateTimeKind.Local).AddTicks(706), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9323), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9328) },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9332), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9334) },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9335), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9336) },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9338), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9339) },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9341), true, false, "种子数据", new DateTime(2021, 8, 6, 20, 35, 38, 541, DateTimeKind.Local).AddTicks(9342) }
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
