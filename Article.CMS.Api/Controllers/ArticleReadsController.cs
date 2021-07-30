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
//     public class ArticleReadsController : ControllerBase
//     {
//         /// <summary>
//         /// 创建用户存储仓库
//         /// </summary>
//         /// <typeparam name="Users">用户实体</typeparam>
//         /// <returns></returns>
//         private IRepository<ArticleReads> _articleReadsRepository;

//         public ArticleReadsController(IConfiguration configuration, IRepository<ArticleReads> articleReadsRepository)
//         {
//             _articleReadsRepository = articleReadsRepository;
//         }
//         [HttpGet]
//         /// <summary>
//         /// 获取数据请求
//         /// </summary>
//         /// <returns></returns>
//         public dynamic Get()
//         {
//             var articles = _articleReadsRepository.Table.ToList();
//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articles));
//         }

//         [HttpPost]
//         /// <summary>
//         /// 添加
//         /// </summary>
//         /// <param name="newUser">传入前端数据实体</param>
//         /// <returns></returns>
//         public dynamic Register(ArticleReadsParams newArticleReads)
//         {
//             var userId = newArticleReads.UserId;
//             var articleId=newArticleReads.ArticleId;
//             var count = newArticleReads.count;

//             var articleReads = new ArticleReads
//             {
//                 UserId = newArticleReads.UserId,
//                 ArticleId = newArticleReads.ArticleId,
//                 count = newArticleReads.count
//             };

//             _articleReadsRepository.Insert(articleReads);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleReads));
//         }

//         /// <summary>
//         /// 修改
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="updateUser"></param>
//         /// <returns></returns>
//         [HttpPut("{id}")]
//         public dynamic UpdateArticlReads(int id,ArticleReadsParams updateArticleReads)
//         {
//             var userId = updateArticleReads.UserId;
//             var articleId = updateArticleReads.ArticleId;
//             var count = updateArticleReads.count;

//             var articleRead=_articleReadsRepository.GetId(id);

//             if(articleRead==null)
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             articleRead.count = updateArticleReads.count;

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleRead));
//         }



//         [HttpDelete("{id}")]
//         /// <summary>
//         /// 删除
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public dynamic Delete(int id)
//         {
//             _articleReadsRepository.Delete(id);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
//         }   
//     }
// }