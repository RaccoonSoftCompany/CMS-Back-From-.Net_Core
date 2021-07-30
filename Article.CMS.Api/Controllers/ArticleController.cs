using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Microsoft.AspNetCore.Authorization;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// 创建用户存储仓库
        /// </summary>
        /// <typeparam name="Users">用户实体</typeparam>
        /// <returns></returns>
        private IRepository<Articles> _articleRepository;

        public ArticleController(IConfiguration configuration, IRepository<Articles> articleRepository)
        {
            _articleRepository = articleRepository;
        }
        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var articles = _articleRepository.Table.ToList();
            return JsonHelper.Serialize(new DataStatus().DataSuccess(articles));
        }

        [HttpPost]
        /// <summary>
        /// 添加文章数据
        /// </summary>
        /// <param name="newUser">传入前端数据实体</param>
        /// <returns></returns>
        public dynamic Register(GetArticle newArticle)
        {
            var title = newArticle.ATitle.Trim();
            var userId = newArticle.UserId;
            var articleText = newArticle.AText.Trim();

            if(string.IsNullOrEmpty(title))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var articles = new Articles
            {
                ATitle = newArticle.ATitle,
                UserId = newArticle.UserId    
            };

            _articleRepository.Insert(articles);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(articles));
        }

        /// <summary>
        /// 修改文章标题
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public dynamic UpdateArticle(int id,GetArticle updateArticle)
        {
            var title = updateArticle.ATitle.Trim();
            var userId = updateArticle.UserId;

            if(string.IsNullOrEmpty(title))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var article = _articleRepository.GetId(id);

            if(article==null)
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            article.ATitle = updateArticle.ATitle;

            _articleRepository.Update(article);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(article));
        }



        [HttpDelete("{id}")]
        /// <summary>
        /// 删除文章标题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            _articleRepository.Delete(id);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        }   
    }
}