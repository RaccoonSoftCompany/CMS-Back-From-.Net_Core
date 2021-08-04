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
    public class ArticleAPraisesController : ControllerBase
    {
        /// <summary>
        /// 创建文章点赞存储仓库
        /// </summary>
        /// <typeparam name="Articles">文章实体</typeparam>
        /// <returns></returns>
        private IRepository<ArticleAPraises> _ArticleAPraisesRepository;
        ArticleCmsdb _Context = new ArticleCmsdb();

        public ArticleAPraisesController(IConfiguration configuration, IRepository<ArticleAPraises> ArticleAPraisesRepository)
        {
            _ArticleAPraisesRepository = ArticleAPraisesRepository;
        }

        [HttpPost]
        [Route("addPraises")]
        /// <summary>
        /// 添加文章评论数据
        /// </summary>
        /// <param name="addPraises">传入前端数据实体</param>
        /// <returns></returns>
        public dynamic addPraises(addArticleAPraises newPraise)
        {
            var userId = newPraise.UserId;
            var articleId = newPraise.ArticleId;

            var isdbPraise = _ArticleAPraisesRepository.Table.Where(x => x.UserId == userId && x.ArticleId == articleId).SingleOrDefault();

            if (isdbPraise != null)
            {
                return DataStatus.DataError(6666, "已点赞！");

            }

            var ArticleAPraise = new ArticleAPraises
            {
                UserId = userId,
                ArticleId = articleId
            };

            _ArticleAPraisesRepository.Insert(ArticleAPraise);
            return DataStatus.DataSuccess(1000, ArticleAPraise, "点赞成功！");
        }

    }
}