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

        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {

            var articles = _Context.Articles.Join(_Context.UserInfos, pet => pet.UserId, per => per.UserId, (pet, per) => new ArticleViewParams
            {
                Id = pet.Id,
                NickName = per.NickName,
                UImageURL = per.ImageURL,
                ATitle = pet.ATitle,
                AIntro = pet.AIntro,
                CreatedTime = pet.CreatedTime,
                UpdatedTime = _Context.ArticleTexts.Where(x => x.ArticleId == pet.Id).SingleOrDefault().UpdatedTime > pet.UpdatedTime ? _Context.ArticleTexts.Where(x => x.ArticleId == pet.Id).SingleOrDefault().UpdatedTime : pet.UpdatedTime,
                AReadCount = _Context.ArticleReads.Where(x => x.ArticleId == pet.Id).Count(),
                ATalkCount = _Context.ArticleTalks.Where(x => x.ArticleId == pet.Id).Count(),
                APraiseCount = _Context.ArticleAPraises.Where(x => x.ArticleId == pet.Id).Count(),
                Remarks = pet.Remarks
            });

            return DataStatus.DataSuccess(1000, articles.OrderByDescending(x => x.CreatedTime), "获取文章成功");
        }

        [HttpGet]
        [Route("AReadUser/{id}")]
        /// <summary>
        /// 阅读人员信息
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        public dynamic GetAReadUser(int id)
        {
            var aReads = _Context.ArticleReads.Where(x => x.ArticleId == id).ToList();
            var AReadUser =aReads.Join(_Context.UserInfos,pet=>pet.UserId,per=>per.UserId,(Pet,per)=>new{
                NickName=per.NickName,
                Count=Pet.count,
                CreatedTime=Pet.CreatedTime
            });
            return DataStatus.DataSuccess(1000,AReadUser , "获取阅读用户成功");
        }

        [HttpGet]
        [Route("APraiseUser/{id}")]
        /// <summary>
        /// 点赞人员信息
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        public dynamic GetAPraiseUser(int id)
        {
            var aReads = _Context.ArticleAPraises.Where(x => x.ArticleId == id).ToList();
            var aPraiseUser =aReads.Join(_Context.UserInfos,pet=>pet.UserId,per=>per.UserId,(Pet,per)=>new{
                NickName=per.NickName,
                CreatedTime=Pet.CreatedTime,
            });
            return DataStatus.DataSuccess(1000,aPraiseUser , "获取点赞用户成功");
        }

        [HttpGet]
        [Route("ATalkUser/{id}")]
        /// <summary>
        /// 评论人员信息
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        public dynamic GetATalkUser(int id)
        {
            var aReads = _Context.ArticleTalks.Where(x => x.ArticleId == id).ToList();
            var aTalkUser =aReads.Join(_Context.UserInfos,pet=>pet.UserId,per=>per.UserId,(Pet,per)=>new{
                NickName=per.NickName,
                ATText=Pet.ATText,
                CreatedTime=Pet.CreatedTime
            });
            return DataStatus.DataSuccess(1000,aTalkUser , "获取评论用户成功");
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
                ATitleImageUrl = uImageURL,
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

    }
}