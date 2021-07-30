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

            ArticleCmsdb _Context = new ArticleCmsdb();
            

            return JsonHelper.Serialize(new DataStatus().DataSuccess(_Context.ArticleTexts.Join(_Context.Articles, pet => pet.ArticleId, per => per.Id, (pet, per) => new GetArticle
            {
                Id = per.Id,
                UserId = per.UserId,
                ATitle = per.ATitle,
                AText = pet.AText

            })
            .ToList()));
        }
    }
}





