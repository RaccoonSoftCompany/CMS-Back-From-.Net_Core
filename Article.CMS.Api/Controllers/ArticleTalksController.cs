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
//     public class ArticleTalksController : ControllerBase
//     {
//         /// <summary>
//         /// 创建用户存储仓库
//         /// </summary>
//         /// <typeparam name="Users">用户实体</typeparam>
//         /// <returns></returns>
//         private IRepository<ArticleTalks> _articleTalkRepository;

//         public ArticleTalksController(IConfiguration configuration, IRepository<ArticleTalks> articleTalkRepository)
//         {
//             _articleTalkRepository = articleTalkRepository;
//         }
//         [HttpGet]
//         /// <summary>
//         /// 获取数据请求
//         /// </summary>
//         /// <returns></returns>
//         public dynamic Get()
//         {
//             var articleTalk = _articleTalkRepository.Table.ToList();
//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTalk));
//         }

//         [HttpPost]
//         /// <summary>
//         /// 添加文章数据
//         /// </summary>
//         /// <param name="newUser">传入前端数据实体</param>
//         /// <returns></returns>
//         public dynamic Register(ArticleTalksParams newArticleTalks)
//         {
//             var userId = newArticleTalks.UserId;
//             var articleId = newArticleTalks.ArticleId;
//             var ATText = newArticleTalks.ATText.Trim();

//             if(string.IsNullOrEmpty(ATText))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleTalk = new ArticleTalks
//             {
//                 UserId = newArticleTalks.UserId,
//                 ArticleId = newArticleTalks.ArticleId,
//                 ATText = newArticleTalks.ATText
//             };

//             _articleTalkRepository.Insert(articleTalk);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTalk));
//         }

//         /// <summary>
//         /// 修改文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="updateUser"></param>
//         /// <returns></returns>
//         [HttpPut("{id}")]
//         public dynamic UpdateArticle(int id,ArticleTalksParams updateArticleTalks)
//         {
//             var userId = updateArticleTalks.UserId;
//             var articleId = updateArticleTalks.ArticleId;
//             var ATText = updateArticleTalks.ATText.Trim();

//             if(string.IsNullOrEmpty(ATText))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleTalk = _articleTalkRepository.GetId(id);

//             if(articleTalk==null)
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             articleTalk.ATText = updateArticleTalks.ATText;

//             _articleTalkRepository.Update(articleTalk);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTalk));
//         }



//         [HttpDelete("{id}")]
//         /// <summary>
//         /// 删除文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public dynamic DeleteUser(int id)
//         {
//             _articleTalkRepository.Delete(id);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
//         }   
//     }
// }