using Microsoft.EntityFrameworkCore; //引入EF
using Article.CMS.Api.Entity; //引入数据表类
using System;

namespace Article.CMS.Api.Database
{
    public class ArticleCmsdb : DbContext   //这里要记得继承EF的接口
    {
        public ArticleCmsdb()
        {

        }
        public ArticleCmsdb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; } //要生成的用户数据表
        public DbSet<Matters> Matters { get; set; } //要生成的问题数据表
        public DbSet<Powers> Powers { get; set; } //要生成的权限数据表
        public DbSet<UserInfos> UserInfos { get; set; } //要生成的用户信息数据表
        public DbSet<Articles> Articles { get; set; } //要生成的文章数据表
        public DbSet<ArticleTexts> ArticleTexts { get; set; } //要生成的文章内容数据表
        public DbSet<ImagesUrl> ImagesUrl { get; set; } //要生成的文章内容图片数据表
        public DbSet<ArticleTalks> ArticleTalks { get; set; } //要生成的文章评论数据表
        public DbSet<ArticleReads> ArticleReads { get; set; } //要生成的文章访问数据表
        public DbSet<ArticleAPraises> ArticleAPraises { get; set; } //要生成的文章点赞数据表
        public DbSet<AuditInfo> AuditInfo { get; set; } //要生成的审计日志数据表

        protected override void OnConfiguring(DbContextOptionsBuilder options)  //重写这个方法并且连上我们的数据库
        {
            options.UseSqlServer(@"server=.;database=ArticleCms;uid=sa;pwd=123456");
        }

        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// 用户表的种子数据
            /// </summary>
            /// <param name="Users("></param>
            /// <typeparam name="Users"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<Users>().HasData(
                new Users()
                {
                    Id = 1,
                    UName = "admin",
                    Upassword = "113",
                    PowerId = 1,
                    MatterId = 1,
                    MKey = "没有答案",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Users()
                {
                    Id = 2,
                    UName = "user",
                    Upassword = "113",
                    PowerId = 3,
                    MatterId = 1,
                    MKey = "没有答案",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Users()
                {
                    Id = 3,
                    UName = "active",
                    Upassword = "113",
                    PowerId = 3,
                    MatterId = 1,
                    MKey = "没有答案",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Users()
                {
                    Id = 4,
                    UName = "god",
                    Upassword = "113",
                    PowerId = 3,
                    MatterId = 1,
                    MKey = "没有答案",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Users()
                {
                    Id = 5,
                    UName = "wooz",
                    Upassword = "113",
                    PowerId = 3,
                    MatterId = 1,
                    MKey = "没有答案",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            /// <summary>
            /// 用户信息种子数据
            /// </summary>
            /// <param name="UserInfos("></param>
            /// <typeparam name="UserInfos"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<UserInfos>().HasData(
                new UserInfos()
                {
                    Id = 1,
                    UserId = 1,
                    NickName = "超管测试",
                    Sex = "男",
                    ImageURL = "UploadFiles/DefaultImg.png",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new UserInfos()
                {
                    Id = 2,
                    UserId = 2,
                    NickName = "管理员测试",
                    Sex = "女",
                    ImageURL = "UploadFiles/DefaultImg.png",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new UserInfos()
                {
                    Id = 3,
                    UserId = 3,
                    NickName = "用户测试",
                    Sex = "男",
                    ImageURL = "UploadFiles/DefaultImg.png",

                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new UserInfos()
                {
                    Id = 4,
                    UserId = 4,
                    NickName = "用户测试",
                    Sex = "女",
                    ImageURL = "UploadFiles/DefaultImg.png",

                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new UserInfos()
                {
                    Id = 5,
                    UserId = 5,
                    NickName = "用户测试",
                    Sex = "男",
                    ImageURL = "UploadFiles/DefaultImg.png",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            /// <summary>
            /// 问题表的种子数据
            /// </summary>
            /// <param name="Matters("></param>
            /// <typeparam name="Matters"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<Matters>().HasData(
                new Matters()
                {
                    Id = 1,
                    MName = "你最喜欢的动物",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Matters()
                {
                    Id = 2,
                    MName = "你最喜欢的人",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Matters()
                {
                    Id = 3,
                    MName = "你的童年阴影",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Matters()
                {
                    Id = 4,
                    MName = "最想去的地方",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Matters()
                {
                    Id = 5,
                    MName = "最喜欢的东西",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            /// <summary>
            /// 权限表的种子数据
            /// </summary>
            /// <param name="Powers("></param>
            /// <typeparam name="Powers"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<Powers>().HasData(
                new Powers()
                {
                    Id = 1,

                    PName = "超级管理员",

                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Powers()
                {
                    Id = 2,

                    PName = "管理员",

                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Powers()
                {
                    Id = 3,
                    PName = "用户",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            /// <summary>
            /// 文章表的种子数据
            /// </summary>
            /// <param name="Articles("></param>
            /// <typeparam name="Articles"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<Articles>().HasData(
                new Articles()
                {
                    Id = 1,
                    UserId = 1,
                    ATitle = "震惊！一男子从天桥上面路过",
                    AIntro = "这里是简介1",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new Articles()
                {
                    Id = 2,
                    UserId = 1,
                    ATitle = "震惊！东京奥运会竟然出现这种裁判",
                    AIntro = "这里是简介2",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new Articles()
                {
                    Id = 3,
                    UserId = 1,
                    ATitle = "震惊！日本选手竟然是这样的人",
                    AIntro = "这里是简介3",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new Articles()
                {
                    Id = 4,
                    UserId = 1,
                    ATitle = "震惊！台风进入真的靠近福建了",
                    AIntro = "这里是简介4",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new Articles()
                {
                    Id = 5,
                    UserId = 1,
                    ATitle = "歌单",
                    AIntro = "这里是简介5",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            modelBuilder.Entity<ArticleTexts>().HasData(
                new ArticleTexts()
                {
                    Id = 1,
                    ArticleId = 1,
                    AText = "测试数据",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTexts()
                {
                    Id = 2,
                    ArticleId = 2,
                    AText = "测试数据",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new ArticleTexts()
                {
                    Id = 3,
                    ArticleId = 3,
                    AText = "测试数据",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new ArticleTexts()
                {
                    Id = 4,
                    ArticleId = 4,
                    AText = "测试数据",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }, new ArticleTexts()
                {
                    Id = 5,
                    ArticleId = 5,
                    AText = "测试数据",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            /// <summary>
            /// 文章评论的种子数据
            /// </summary>
            /// <param name="ArticleTalks("></param>
            /// <typeparam name="ArticleTalks"></typeparam>
            /// <returns></returns>
            modelBuilder.Entity<ArticleTalks>().HasData(
                new ArticleTalks()
                {
                    Id = 1,
                    UserId = 3,
                    ArticleId = 2,
                    ATText = "盲人裁判，太真实了吧",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 2,
                    UserId = 3,
                    ArticleId = 1,
                    ATText = "什么居然有人敢走天桥？？？",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 3,
                    UserId = 2,
                    ArticleId = 1,
                    ATText = "那可是天桥啊，传说走过的人都没了",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 4,
                    UserId = 1,
                    ArticleId = 2,
                    ATText = "中国加油，冲冲冲！！！",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 5,
                    UserId = 4,
                    ArticleId = 3,
                    ATText = "果然如此a",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 6,
                    UserId = 3,
                    ArticleId = 3,
                    ATText = "这没有犯规？这裁判属实有点水准啊",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 7,
                    UserId = 5,
                    ArticleId = 4,
                    ATText = "什么台风要来了？？",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 8,
                    UserId = 1,
                    ArticleId = 4,
                    ATText = "不慌，根本不在沿海",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 9,
                    UserId = 4,
                    ArticleId = 5,
                    ATText = "清明雨上",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 10,
                    UserId = 5,
                    ArticleId = 5,
                    ATText = "不负如来不负卿",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                },
                new ArticleTalks()
                {
                    Id = 11,
                    UserId = 2,
                    ArticleId = 5,
                    ATText = "请君一战",
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = "种子数据"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}