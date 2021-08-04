using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Article.CMS.Api.Database;

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

            var articles = _ArticlesRepository.Table.ToList();//获取文章表            

            var ArticleParams = _Context.ArticleTexts.Join(_Context.Articles, pet => pet.ArticleId, per => per.Id, (pet, per) => new ArticleViewParams
            {
                Id = per.Id,
                UserId = per.UserId,
                NickName=_Context.UserInfos.Where(x=>x.UserId==per.UserId).SingleOrDefault().NickName,
                ATitle = per.ATitle,
                AText = pet.AText,
                isATimage = pet.isATimage,
                CreatedTime = pet.CreatedTime,
                UpdatedTime = pet.UpdatedTime > per.UpdatedTime ? pet.UpdatedTime : per.UpdatedTime,
                AReadCount=_Context.ArticleReads.Where(x=>x.ArticleId==per.Id).Count(),
                ATalkCount=_Context.ArticleTalks.Where(x=>x.ArticleId==per.Id).Count()
            });

            return DataStatus.DataSuccess(1000, ArticleParams, "获取文章模块成功");
        }
    }
}





