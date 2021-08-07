using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Article.CMS.Api.Database;
using System.Web;
using System;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// 创建文章存储仓库
        /// </summary>
        /// <typeparam name="Articles">文章实体</typeparam>
        /// <returns></returns>
        private IRepository<Articles> _ArticlesRepository;
        ArticleCmsdb _Context = new ArticleCmsdb();

        public ArticlesController(IConfiguration configuration, IRepository<Articles> ArticlesRepository)
        {
            _ArticlesRepository = ArticlesRepository;
        }
        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var articles = _Context.Articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                UserId = per.UserId,
                NickName = per.NickName,
                ATitle = pet.ATitle,
                AImageUrl=pet.ATitleImageUrl,
                AIntro = pet.AIntro,
                CreatedTime = pet.CreatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count()
            });
            return DataStatus.DataSuccess(1000, articles.OrderByDescending(x => x.CreatedTime), "获取文章列表成功");
        }


        [HttpGet]
        [Route("ArticleTexts/{aId}")]
        /// <summary>
        /// 获取文章内容请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get(int aId)
        {

            //获取文章表    
            var articles = _ArticlesRepository.Table.Where(x => x.Id == aId).ToList();
            var Articleview = articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                UserId = per.UserId,
                NickName = per.NickName,
                ATitle = pet.ATitle,
                AImageUrl=pet.ATitleImageUrl,
                AIntro = pet.AIntro,
                AText = HttpUtility.HtmlDecode(_Context.ArticleTexts.Where(x => x.ArticleId == pet.Id).SingleOrDefault().AText),
                CreatedTime = pet.CreatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count()
            });

            return DataStatus.DataSuccess(1000, Articleview, "获取文章模块成功");
        }

        [HttpGet]
        [Route("TheFirstReadCount")]
        /// <summary>
        /// 获取48小时数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic TheFirstReadCount()
        {
            var articles = _Context.Articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                UserId = per.UserId,
                NickName = per.NickName,
                ATitle = pet.ATitle,
                AImageUrl=pet.ATitleImageUrl,
                AIntro = pet.AIntro,
                CreatedTime = pet.CreatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count()
            }).OrderByDescending(x => x.AReadCount).ToList();

            var TheFirstArticles = articles.Where(x => (DateTime.Now - x.CreatedTime).TotalDays <= 2);
            return DataStatus.DataSuccess(1000, TheFirstArticles, "获取48小时评论文章成功");
        }

        [HttpGet]
        [Route("TheTenPraiseCount")]
        /// <summary>
        /// 获取48小时数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic TheTenPraiseCount()
        {
            var articles = _Context.Articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                UserId = per.UserId,
                NickName = per.NickName,
                ATitle = pet.ATitle,
                AImageUrl=pet.ATitleImageUrl,
                AIntro = pet.AIntro,
                CreatedTime = pet.CreatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count()
            }).OrderByDescending(x => x.APraiseCount).ToList();

            var TheFirstArticles = articles.Where(x => (DateTime.Now - x.CreatedTime).TotalDays <= 10);
            return DataStatus.DataSuccess(1000, TheFirstArticles, "获取10天点赞文章成功");
        }

        [HttpGet]
        [Route("TheTenTalkCount")]
        /// <summary>
        /// 获取48小时数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic TheTenTalkCount()
        {
            var articles = _Context.Articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                UserId = per.UserId,
                NickName = per.NickName,
                ATitle = pet.ATitle,
                AImageUrl=pet.ATitleImageUrl,
                AIntro = pet.AIntro,
                CreatedTime = pet.CreatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count()
            }).OrderByDescending(x => x.ATalkCount).ToList();

            var TheFirstArticles = articles.Where(x => (DateTime.Now - x.CreatedTime).TotalDays <= 10);
            return DataStatus.DataSuccess(1000, TheFirstArticles, "获取10天评论文章成功");
        }
    }
}





