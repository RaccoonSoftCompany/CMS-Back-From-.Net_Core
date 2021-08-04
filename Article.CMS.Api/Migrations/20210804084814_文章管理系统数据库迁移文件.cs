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
                    { 1, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5357), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5365) },
                    { 2, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5369), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5370) },
                    { 3, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5372), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5373) },
                    { 4, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5374), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5375) },
                    { 5, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5377), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(5378) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6590), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6597) },
                    { 2, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6601), true, false, "管理员", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6602) },
                    { 3, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6603), true, false, "用户", "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(6605) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 4, 16, 48, 13, 628, DateTimeKind.Local).AddTicks(2340), true, false, "没有答案", 1, 1, "种子数据", null, "admin", "113", new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(5147) },
                    { 2, new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6321), true, false, "没有答案", 1, 3, "种子数据", null, "user", "113", new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6335) },
                    { 3, new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6343), true, false, "没有答案", 1, 3, "种子数据", null, "active", "113", new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6344) },
                    { 4, new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6346), true, false, "没有答案", 1, 3, "种子数据", null, "god", "113", new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6347) },
                    { 5, new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6349), true, false, "没有答案", 1, 3, "种子数据", null, "wooz", "113", new DateTime(2021, 8, 4, 16, 48, 13, 629, DateTimeKind.Local).AddTicks(6351) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ATitle", "ATitleImage", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7852), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7856), 1 },
                    { 2, "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7860), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7861), 1 },
                    { 3, "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7863), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7864), 1 },
                    { 4, "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7866), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7867), 1 },
                    { 5, "歌单", null, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7869), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(7870), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3897), null, true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3940), 1 },
                    { 2, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3945), null, true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3946), 2 },
                    { 3, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3948), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3949), 3 },
                    { 4, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3951), null, true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3952), 4 },
                    { 5, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3954), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(3955), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTalks",
                columns: new[] { "Id", "ATText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 2, "什么居然有人敢走天桥？？？", 1, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(831), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(832), 3 },
                    { 3, "那可是天桥啊，传说走过的人都没了", 1, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(834), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(835), 2 },
                    { 1, "盲人裁判，太真实了吧", 2, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(823), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(827), 3 },
                    { 4, "中国加油，冲冲冲！！！", 2, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(837), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(838), 1 },
                    { 5, "果然如此a", 3, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(840), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(841), 4 },
                    { 6, "这没有犯规？这裁判属实有点水准啊", 3, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(843), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(844), 3 },
                    { 7, "什么台风要来了？？", 4, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(845), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(847), 5 },
                    { 8, "不慌，根本不在沿海", 4, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(848), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(849), 1 },
                    { 9, "清明雨上", 5, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(851), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(852), 4 },
                    { 10, "不负如来不负卿", 5, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(854), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(855), 5 },
                    { 11, "请君一战", 5, new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(857), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 632, DateTimeKind.Local).AddTicks(858), 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "isATimage" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9367), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9372), false },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9376), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9377), false },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9379), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9380), false },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9382), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9383), false },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9385), true, false, "种子数据", new DateTime(2021, 8, 4, 16, 48, 13, 631, DateTimeKind.Local).AddTicks(9386), false }
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
