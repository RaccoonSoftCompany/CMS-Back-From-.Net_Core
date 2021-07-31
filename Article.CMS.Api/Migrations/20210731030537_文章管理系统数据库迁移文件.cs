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
                    { 1, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5956), true, false, "你最喜欢的动物", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5965) },
                    { 2, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5969), true, false, "你最喜欢的人", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5970) },
                    { 3, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5972), true, false, "你的童年阴影", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5973) },
                    { 4, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5974), true, false, "最想去的地方", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5975) },
                    { 5, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5977), true, false, "最喜欢的东西", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(5978) }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "PName", "Remarks", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6909), true, false, "超级管理员", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6914) },
                    { 2, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6918), true, false, "管理员", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6919) },
                    { 3, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6920), true, false, "用户", "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(6921) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "IsActived", "IsDeleted", "MKey", "MatterId", "PowerId", "Remarks", "UEmail", "UName", "Upassword", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 31, 11, 5, 36, 993, DateTimeKind.Local).AddTicks(8451), true, false, "没有答案", 1, 1, "种子数据", null, "Admin", "113", new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(2368) },
                    { 2, new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3137), true, false, "没有答案", 1, 1, "种子数据", null, "User", "113", new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3144) },
                    { 3, new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3147), true, false, "没有答案", 1, 1, "种子数据", null, "Active", "113", new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3148) },
                    { 4, new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3150), true, false, "没有答案", 1, 1, "种子数据", null, "God", "113", new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3151) },
                    { 5, new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3153), true, false, "没有答案", 1, 1, "种子数据", null, "Wooz", "113", new DateTime(2021, 7, 31, 11, 5, 36, 995, DateTimeKind.Local).AddTicks(3154) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ATitle", "ATitleImage", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, "震惊！一男子从天桥上面路过", null, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8081), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8086), 1 },
                    { 2, "震惊！东京奥运会竟然出现这种裁判", null, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8090), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8091), 1 },
                    { 3, "震惊！日本选手竟然是这样的人", null, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8146), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8147), 1 },
                    { 4, "震惊！台风进入真的靠近福建了", null, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8149), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8150), 1 },
                    { 5, "歌单", null, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8152), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(8153), 1 }
                });

            migrationBuilder.InsertData(
                table: "ArticleTexts",
                columns: new[] { "Id", "AText", "ArticleId", "CreatedTime", "IsActived", "IsDeleted", "Remarks", "UpdatedTime", "isATimage" },
                values: new object[,]
                {
                    { 1, "测试数据", 1, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9548), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9554), false },
                    { 2, "测试数据", 2, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9558), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9559), false },
                    { 3, "测试数据", 3, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9561), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9562), false },
                    { 4, "测试数据", 4, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9563), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9564), false },
                    { 5, "测试数据", 5, new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9566), true, false, "种子数据", new DateTime(2021, 7, 31, 11, 5, 36, 996, DateTimeKind.Local).AddTicks(9567), false }
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
