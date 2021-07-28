using Microsoft.EntityFrameworkCore; //引入EF
using Article.CMS.Api.Entity; //引入数据表类
using System;

namespace Article.CMS.Api.Database
{
    public class ArticleCmsdb : DbContext   //这里要记得继承EF的接口
    {
        public ArticleCmsdb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; } //要生成的数据表
        public DbSet<Matters> Matters { get; set; } //要生成的数据表
        public DbSet<Powers> Powers { get; set; } //要生成的数据表
        public DbSet<UserInfos> UserInfos { get; set; } //要生成的数据表
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
            modelBuilder.Entity<Users>().HasData(
                new Users()
                {
                    Id = 1,
                    UName = "Admin",
                    UEmail = "112358@qq",
                    Upassword="113",
                    PowerId = 1,
                    MatterId = 1,
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Users()
                {
                    Id = 2,
                    UName = "User",
                    UEmail = "112358@qq.com",
                    Upassword = "113",
                    PowerId = 1,
                    MatterId = 1,
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Users()
                {
                    Id = 3,
                    UName = "Active",
                    UEmail = "112358@qq.com",
                    Upassword = "113",
                    PowerId = 1,
                    MatterId = 1,
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Users()
                {
                    Id = 4,
                    UName = "God",
                    UEmail = "112358@qq.com",
                    Upassword = "113",
                    PowerId = 1,
                    MatterId = 1,
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Users()
                {
                    Id = 5,
                    UName = "Wooz",
                    UEmail = "112358@qq.com",
                    Upassword = "113",
                    PowerId = 1,
                    MatterId = 1,
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                }
            );

            modelBuilder.Entity<Matters>().HasData(
                new Matters()
                {
                    Id = 1,
                    MName="你最喜欢的动物",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Matters()
                {
                    Id = 2,
                    MName="你最喜欢的人",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Matters()
                {
                    Id = 3,
                    MName="你的童年阴影",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Matters()
                {
                    Id = 4,
                    MName="最想去的地方",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Matters()
                {
                    Id = 5,
                    MName="最喜欢的东西",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                }
            );
            modelBuilder.Entity<Powers>().HasData(
                new Powers()
                {
                    Id = 1,
                    PName="修改",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Powers()
                {
                    Id = 2,
                    PName="添加",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Powers()
                {
                    Id = 3,
                    PName="删除",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                },
                new Powers()
                {
                    Id = 4,
                    PName="查询",                    
                    IsActived = true,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    Remarks = null
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}