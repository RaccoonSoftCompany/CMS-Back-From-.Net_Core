﻿// <auto-generated />
using System;
using Article.CMS.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Article.CMS.Api.Migrations
{
    [DbContext(typeof(ArticleCmsdb))]
    partial class ArticleCmsdbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleReads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleReads");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTalks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ATText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleTalks");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTextImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ATImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ATImageRank")
                        .HasColumnType("int");

                    b.Property<int>("ArticleTextId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArticleTextId");

                    b.ToTable("ArticleTextImages");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTexts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isATimage")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleTexts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AText = "测试数据",
                            ArticleId = 1,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8465),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8470),
                            isATimage = false
                        },
                        new
                        {
                            Id = 2,
                            AText = "测试数据",
                            ArticleId = 2,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8474),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8475),
                            isATimage = false
                        },
                        new
                        {
                            Id = 3,
                            AText = "测试数据",
                            ArticleId = 3,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8477),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8478),
                            isATimage = false
                        },
                        new
                        {
                            Id = 4,
                            AText = "测试数据",
                            ArticleId = 4,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8480),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8481),
                            isATimage = false
                        },
                        new
                        {
                            Id = 5,
                            AText = "测试数据",
                            ArticleId = 5,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8483),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(8484),
                            isATimage = false
                        });
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Articles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ATitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ATitleImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ATitle = "震惊！一男子从天桥上面路过",
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7122),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7127),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ATitle = "震惊！东京奥运会竟然出现这种裁判",
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7130),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7132),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ATitle = "震惊！日本选手竟然是这样的人",
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7133),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7134),
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            ATitle = "震惊！台风进入真的靠近福建了",
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7136),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7137),
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            ATitle = "歌单",
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7139),
                            IsActived = true,
                            IsDeleted = false,
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(7140),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.AuditInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrowserInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExecutionDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditInfo");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Matters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Matters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5045),
                            IsActived = true,
                            IsDeleted = false,
                            MName = "你最喜欢的动物",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5055)
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5059),
                            IsActived = true,
                            IsDeleted = false,
                            MName = "你最喜欢的人",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5060)
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5062),
                            IsActived = true,
                            IsDeleted = false,
                            MName = "你的童年阴影",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5063)
                        },
                        new
                        {
                            Id = 4,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5064),
                            IsActived = true,
                            IsDeleted = false,
                            MName = "最想去的地方",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5066)
                        },
                        new
                        {
                            Id = 5,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5067),
                            IsActived = true,
                            IsDeleted = false,
                            MName = "最喜欢的东西",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5068)
                        });
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Powers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Powers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5961),
                            IsActived = true,
                            IsDeleted = false,
                            PName = "超级管理员",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5965)
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5968),
                            IsActived = true,
                            IsDeleted = false,
                            PName = "管理员",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5969)
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5971),
                            IsActived = true,
                            IsDeleted = false,
                            PName = "用户",
                            Remarks = "种子数据",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 953, DateTimeKind.Local).AddTicks(5972)
                        });
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.UserInfos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatterId")
                        .HasColumnType("int");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Upassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MatterId");

                    b.HasIndex("PowerId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 950, DateTimeKind.Local).AddTicks(9575),
                            IsActived = true,
                            IsDeleted = false,
                            MKey = "没有答案",
                            MatterId = 1,
                            PowerId = 1,
                            Remarks = "种子数据",
                            UName = "Admin",
                            Upassword = "113",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(1356)
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2114),
                            IsActived = true,
                            IsDeleted = false,
                            MKey = "没有答案",
                            MatterId = 1,
                            PowerId = 3,
                            Remarks = "种子数据",
                            UName = "User",
                            Upassword = "113",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2120)
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2123),
                            IsActived = true,
                            IsDeleted = false,
                            MKey = "没有答案",
                            MatterId = 1,
                            PowerId = 3,
                            Remarks = "种子数据",
                            UName = "Active",
                            Upassword = "113",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2124)
                        },
                        new
                        {
                            Id = 4,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2126),
                            IsActived = true,
                            IsDeleted = false,
                            MKey = "没有答案",
                            MatterId = 1,
                            PowerId = 3,
                            Remarks = "种子数据",
                            UName = "God",
                            Upassword = "113",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2127)
                        },
                        new
                        {
                            Id = 5,
                            CreatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2129),
                            IsActived = true,
                            IsDeleted = false,
                            MKey = "没有答案",
                            MatterId = 1,
                            PowerId = 3,
                            Remarks = "种子数据",
                            UName = "Wooz",
                            Upassword = "113",
                            UpdatedTime = new DateTime(2021, 7, 31, 14, 20, 36, 952, DateTimeKind.Local).AddTicks(2130)
                        });
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleReads", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Articles", "Article")
                        .WithMany("ArticleReads")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTalks", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Articles", "Article")
                        .WithMany("ArticleTalks")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTextImages", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.ArticleTexts", "ArticleText")
                        .WithMany("ArticleTextImages")
                        .HasForeignKey("ArticleTextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleText");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTexts", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Articles", "Article")
                        .WithMany("ArticleTexts")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Articles", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Users", "user")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.UserInfos", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Users", "User")
                        .WithMany("UserInfos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Users", b =>
                {
                    b.HasOne("Article.CMS.Api.Entity.Matters", "Matter")
                        .WithMany("Users")
                        .HasForeignKey("MatterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Article.CMS.Api.Entity.Powers", "Power")
                        .WithMany("Users")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matter");

                    b.Navigation("Power");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.ArticleTexts", b =>
                {
                    b.Navigation("ArticleTextImages");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Articles", b =>
                {
                    b.Navigation("ArticleReads");

                    b.Navigation("ArticleTalks");

                    b.Navigation("ArticleTexts");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Matters", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Powers", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Article.CMS.Api.Entity.Users", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("UserInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
