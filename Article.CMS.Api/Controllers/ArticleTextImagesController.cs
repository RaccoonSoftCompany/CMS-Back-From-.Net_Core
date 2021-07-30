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
//     public class ArticleTextImagesController : ControllerBase
//     {
//         /// <summary>
//         /// 创建用户存储仓库
//         /// </summary>
//         /// <typeparam name="Users">用户实体</typeparam>
//         /// <returns></returns>
//         private IRepository<ArticleTextImages> _articleTextImagesRepository;

//         public ArticleTextImagesController(IConfiguration configuration, IRepository<ArticleTextImages> articleTextImagesRepository)
//         {
//             _articleTextImagesRepository = articleTextImagesRepository;
//         }
//         [HttpGet]
//         /// <summary>
//         /// 获取数据请求
//         /// </summary>
//         /// <returns></returns>
//         public dynamic Get()
//         {
//             var articles = _articleTextImagesRepository.Table.ToList();
//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articles));
//         }

//         [HttpPost]
//         /// <summary>
//         /// 添加文章数据
//         /// </summary>
//         /// <param name="newUser">传入前端数据实体</param>
//         /// <returns></returns>
//         public dynamic Register(ArticleTextImagesParams newArticleTextImages)
//         {
//             var articleTextId = newArticleTextImages.ArticleTextId;
//             var ATImage = newArticleTextImages.ATImage.Trim();
//             var ATImageRank = newArticleTextImages.ATImageRank;

//             if(string.IsNullOrEmpty(ATImage))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleTextImages = new ArticleTextImages
//             {
//                 ArticleTextId = newArticleTextImages.ArticleTextId,
//                 ATImage = newArticleTextImages.ATImage,
//                 ATImageRank = newArticleTextImages.ATImageRank
//             };

//             _articleTextImagesRepository.Insert(articleTextImages);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTextImages));
//         }

//         /// <summary>
//         /// 修改文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="updateUser"></param>
//         /// <returns></returns>
//         [HttpPut("{id}")]
//         public dynamic UpdateArticle(int id,ArticleTextImagesParams updateArticleTextImages)
//         {
//             var articleTextId = updateArticleTextImages.ArticleTextId;
//             var ATImage = updateArticleTextImages.ATImage.Trim();
//             var ATImageRank = updateArticleTextImages.ATImageRank;

//             if(string.IsNullOrEmpty(ATImage))
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             var articleTextImages = _articleTextImagesRepository.GetId(id);

//             if(articleTextImages==null)
//             {
//                 return JsonHelper.Serialize(new DataStatus().DataError());
//             }

//             articleTextImages.ATImage = updateArticleTextImages.ATImage;

//             _articleTextImagesRepository.Update(articleTextImages);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(articleTextImages));
//         }



//         [HttpDelete("{id}")]
//         /// <summary>
//         /// 删除文章标题
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public dynamic DeleteUser(int id)
//         {
//             _articleTextImagesRepository.Delete(id);

//             return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
//         }   
//     }
// }