using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Article.CMS.Api.Database;
using System.Web;


namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackArticleController : ControllerBase
    {
        /// <summary>
        /// 创建文章存储仓库
        /// </summary>
        /// <typeparam name="Articles">文章实体</typeparam>
        /// <returns></returns>
        private IRepository<Articles> _ArticlesRepository;
        ArticleCmsdb _Context = new ArticleCmsdb();

        public BackArticleController(IConfiguration configuration, IRepository<Articles> ArticlesRepository)
        {
            _ArticlesRepository = ArticlesRepository;
        }

        [HttpPost]
        [Route("addArticle")]
        public dynamic addArticle(addArticleandTextParams ArticleandText)
        {
            var title = ArticleandText.ATitle;
            var aIntro = ArticleandText.AIntro;
            var text = ArticleandText.AText;

            var Article = new Articles
            {
                UserId = ArticleandText.UserId,
                ATitle = title,
                AIntro = aIntro
            };

            _ArticlesRepository.Insert(Article);

            var aid = Article.Id;

            var ATtext = new ArticleTexts
            {
                ArticleId = aid,
                AText = HttpUtility.HtmlEncode(text)
            };

            _Context.ArticleTexts.Add(ATtext);
            _Context.SaveChanges();


            return DataStatus.DataSuccess(1000, ATtext, "插入文章成功");

        }













        // [HttpGet]
        // /// <summary>
        // /// 获取数据请求
        // /// </summary>
        // /// <returns></returns>
        // public dynamic Get()
        // {
        //     var html = _Context.ArticleTexts.Where(x => x.Id == 6).SingleOrDefault().AText;
        //     var temp = HttpUtility.HtmlDecode(html);
        //     return DataStatus.DataSuccess(1000, temp, "测试");
        // }
    }
}