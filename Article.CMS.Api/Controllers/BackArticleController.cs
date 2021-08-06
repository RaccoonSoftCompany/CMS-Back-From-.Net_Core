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

        /// <summary>
        /// 插入文章
        /// </summary>
        /// <param name="ArticleandText"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addArticle")]
        public dynamic addArticle(addArticleandTextParams ArticleandText)
        {
            var isUser = _Context.Users.Where(x => x.Id == ArticleandText.UserId).SingleOrDefault();
            if (isUser == null)
            {
                return DataStatus.DataError(1114, "该用户不存在无法执行修改密码操作！");
            }

            var aTitle = ArticleandText.ATitle;
            var uImageURL = ArticleandText.UImageURL;
            var aIntro = ArticleandText.AIntro;
            var aText = ArticleandText.AText;

            if (string.IsNullOrEmpty(aTitle) || string.IsNullOrEmpty(uImageURL) || string.IsNullOrEmpty(aIntro) || string.IsNullOrEmpty(aText))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var Article = new Articles
            {
                UserId = isUser.Id,
                ATitle = aTitle,
                ATitleImageUrl=uImageURL,
                AIntro = aIntro
            };

            _ArticlesRepository.Insert(Article);

            var AId = Article.Id;

            var ATtext = new ArticleTexts
            {
                ArticleId = AId,
                AText = HttpUtility.HtmlEncode(aText)
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