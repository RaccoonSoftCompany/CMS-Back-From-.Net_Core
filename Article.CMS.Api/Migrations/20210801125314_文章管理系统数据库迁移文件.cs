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
                    { 1, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9020), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9024) },
                    { 2, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9033), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9034) },
                    { 3, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9036), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9037) },
                    { 4, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9039), true, false, "最想去的地方", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9040) },
                    { 5, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9041), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9042) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9965), true, false, "超级管理员", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9969) },
                    { 2, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9973), true, false, "管理员", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9974) },
                    { 3, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9976), true, false, "用户", "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(9977) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 1, 20, 53, 13, 578, DateTimeKind.Local).AddTicks(8417), true, false, "没有答案", 1, 1, "种子数据", null, "Admin", "113", new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(1929) },
                    { 2, new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2769), true, false, "没有答案", 1, 3, "种子数据", null, "User", "113", new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2775) },
                    { 3, new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2777), true, false, "没有答案", 1, 3, "种子数据", null, "Active", "113", new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2779) },
                    { 4, new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2780), true, false, "没有答案", 1, 3, "种子数据", null, "God", "113", new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2782) },
                    { 5, new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2784), true, false, "没有答案", 1, 3, "种子数据", null, "Wooz", "113", new DateTime(2021, 8, 1, 20, 53, 13, 580, DateTimeKind.Local).AddTicks(2785) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ATitle", "ATitleImage", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "震惊！一男子从天桥上面路过", null, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1159), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1163), 1 },
                    { 2, "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1167), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1168), 1 },
                    { 3, "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1170), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1171), 1 },
                    { 4, "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1173), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1174), 1 },
                    { 5, "歌单", null, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1176), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(1177), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreatedTime", "ImageURL", "IsActived", "IsDeleted", "NickName", "Remarks", "Sex", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8060), null, true, false, "超管测试", "种子数据", "男", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8076), 1 },
                    { 2, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8082), null, true, false, "管理员测试", "种子数据", "女", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8083), 2 },
                    { 3, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8085), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8086), 3 },
                    { 4, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8088), null, true, false, "用户测试", "种子数据", "女", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8089), 4 },
                    { 5, new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8091), null, true, false, "用户测试", "种子数据", "男", new DateTime(2021, 8, 1, 20, 53, 13, 581, DateTimeKind.Local).AddTicks(8092), 5 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "isATimage" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2736), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2741), false },
                    { 2, "测试数据", 2, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2746), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2747), false },
                    { 3, "测试数据", 3, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2749), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2750), false },
                    { 4, "测试数据", 4, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2752), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2753), false },
                    { 5, "测试数据", 5, new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2755), true, false, "种子数据", new DateTime(2021, 8, 1, 20, 53, 13, 582, DateTimeKind.Local).AddTicks(2756), false }
                });

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
