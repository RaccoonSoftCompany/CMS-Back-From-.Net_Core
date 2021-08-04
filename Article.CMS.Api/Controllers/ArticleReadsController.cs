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
    public class ArticleReadsController : ControllerBase
    {
        /// <summary>
        /// 创建文章点赞存储仓库
        /// </summary>
        /// <typeparam name="Articles">文章实体</typeparam>
        /// <returns></returns>
        private IRepository<ArticleReads> _ArticleReadsRepository;
        ArticleCmsdb _Context = new ArticleCmsdb();

        public ArticleReadsController(IConfiguration configuration, IRepository<ArticleReads> ArticleReadsRepository)
        {
            _ArticleReadsRepository = ArticleReadsRepository;
        }

        [HttpPost]
        [Route("addRead")]
        /// <summary>
        /// 添加文章访问数据
        /// </summary>
        /// <param name="addRead">传入前端数据实体</param>
        /// <returns></returns>
        public dynamic addRead(addArticleRead newRead)
        {
            var userId = newRead.UserId;
            var articleId = newRead.ArticleId;

            var isdbRead = _ArticleReadsRepository.Table.Where(x => x.UserId == userId && x.ArticleId == articleId).SingleOrDefault();

            if (isdbRead != null)
            {
                isdbRead.count+=1;
                 _ArticleReadsRepository.Update(isdbRead);
            return DataStatus.DataSuccess(1000, isdbRead, "已经访问！");
            }

            var ArticleRead = new ArticleReads
            {
                UserId = userId,
                ArticleId = articleId,
                count=1
            };

            _ArticleReadsRepository.Insert(ArticleRead);
            return DataStatus.DataSuccess(1000, ArticleRead, "访问+1！");
        }

    }
}