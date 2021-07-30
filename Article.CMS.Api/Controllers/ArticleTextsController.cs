// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Article.CMS.Api.Repository;
// using Article.CMS.Api.Entity;
// using Article.CMS.Api.Utils;
// using System.Linq;
// using Article.CMS.Api.Params;
// using Microsoft.AspNetCore.Authorization;

// namespace Article.CMS.Api.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class ArticleTextsController : ControllerBase
//     {
//         /// <summary>
//         /// 创建用户存储仓库
//         /// </summary>
//         /// <typeparam name="Users">用户实体</typeparam>
//         /// <returns></returns>
//         private IRepository<ArticleTexts> _articleTextRepository;

//         public ArticleTextsController(IConfiguration configuration, IRepository<ArticleTexts> articleTextRepository)
//         {
//             _articleTextRepository = articleTextRepository;
//         }
//         [HttpGet]
//         /// <summary>
//         /// 获取数据请求
//         /// </summary>
//         /// <returns></returns>
//         public dynamic Get()
//         {
//             var articles = _articleTextRepository.Table.ToList();
//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articles));
//         }

//         [HttpPost]
//         /// <summary>
//         /// 添加文章数据
//         /// </summary>
//         /// <param name="newUser">传入前端数据实体</param>
//         /// <returns></returns>
//         public dynamic Register(ArticleTextParams newArticleText)
//         {
//             var articleId = newArticleText.ArticleId;
//             var AText = newArticleText.AText.Trim();
//             var isATimage = newArticleText.isATimage;

//             if (string.IsNullOrEmpty(AText))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleText = new ArticleTexts
//             {
//                 ArticleId = newArticleText.ArticleId,
//                 AText = newArticleText.AText,
//                 isATimage = newArticleText.isATimage
//             };

//             _articleTextRepository.Insert(articleText);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleText));
//         }

//         /// <summary>
//         /// 修改文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="updateUser"></param>
//         /// <returns></returns>
//         [HttpPut("{id}")]
//         public dynamic UpdateArticle(int id, ArticleTextParams updateArticleText)
//         {
//             var articleId = updateArticleText.ArticleId;
//             var AText = updateArticleText.AText.Trim();
//             var isATimage = updateArticleText.isATimage;


//             if (string.IsNullOrEmpty(AText))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleTexts = _articleTextRepository.GetId(id);

//             if (articleTexts == null)
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             articleTexts.AText = updateArticleText.AText;

//             _articleTextRepository.Update(articleTexts);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTexts));
//         }



//         [HttpDelete("{id}")]
//         /// <summary>
//         /// 删除文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public dynamic DeleteUser(int id)
//         {
//             _articleTextRepository.Delete(id);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
//         }
//     }
// }