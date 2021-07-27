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
            modelBuilder.Entity<Users> ().HasData(
                new Users(){
                    Id=1,
                    UName="Admin",
                    UEmail="112358@qq.com",
                    Upassword="113",
                    IsActived=true,
                    IsDeleted=false,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                    Remarks=null
                },           
                new Users(){
                    Id=2,
                    UName="User",
                    UEmail="112358@qq.com",
                    Upassword="113",
                    IsActived=true,
                    IsDeleted=false,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                    Remarks=null
                },  
                new Users(){
                    Id=3,
                    UName="Active",
                    UEmail="112358@qq.com",
                    Upassword="113",
                    IsActived=true,
                    IsDeleted=false,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                    Remarks=null
                }, 
                new Users(){
                    Id=4,
                    UName="God",
                    UEmail="112358@qq.com",
                    Upassword="113",
                    IsActived=true,
                    IsDeleted=false,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                    Remarks=null
                },   
                new Users(){
                    Id=5,
                    UName="Wooz",
                    UEmail="112358@qq.com",
                    Upassword="113",
                    IsActived=true,
                    IsDeleted=false,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                    Remarks=null
                }   
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}