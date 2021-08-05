using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Microsoft.AspNetCore.Authorization;
using Article.CMS.Api.Database;
using System;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleTalksController : ControllerBase
    {
        /// <summary>
        /// 创建文章评论存储仓库
        /// </summary>
        /// <typeparam name="Users">评论实体</typeparam>
        /// <returns></returns>
        private IRepository<ArticleTalks> _articleTalkRepository;

        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public ArticleTalksController(IConfiguration configuration, IRepository<ArticleTalks> articleTalkRepository)
        {
            _articleTalkRepository = articleTalkRepository;
        }

        [HttpGet("{id}")]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            var dbTalks = _articleTalkRepository.Table.Where(x => x.ArticleId == id).ToList();
            var Talks = dbTalks.Join(_Context.UserInfos, Pet => Pet.UserId, per => per.UserId, (pet, per) => new Talkuser
            {
                TalkId = pet.Id,
                UserId=per.UserId,
                UNickName = per.NickName,
                TalkText = pet.ATText
            });

            return DataStatus.DataSuccess(1000, Talks, "获取文章评论模块成功");
        }

        [HttpPost]
        [Route("addTalk")]
        /// <summary>
        /// 添加文章评论数据
        /// </summary>
        /// <param name="newUser">传入前端数据实体</param>
        /// <returns></returns>
        public dynamic addTalk(ArticleTalkParams newArticleTalks)
        {
            var userId = newArticleTalks.UserId;
            var articleId = newArticleTalks.ArticleId;
            var ATText = newArticleTalks.ATtext.Trim();

            if (string.IsNullOrEmpty(ATText))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var articleTalk = new ArticleTalks
            {
                UserId = userId,
                ArticleId = articleId,
                ATText = ATText
            };
            _articleTalkRepository.Insert(articleTalk);
            var Talkuser= new Talkuser
            {
                TalkId = articleTalk.Id,
                UserId=userId,
                UNickName = _Context.UserInfos.Where(x=>x.UserId==userId).SingleOrDefault().NickName,
                TalkText = ATText
            };

            return DataStatus.DataSuccess(1000, Talkuser, "评论添加成功！");
        }

        [HttpDelete]
        [Route("deleteTalk/{id}")]
        /// <summary>
        /// 删除文章评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic deleteTalk(int id)
        {

            _articleTalkRepository.Delete(id);

            return DataStatus.DataSuccess(1000, new{id=id}, "评论删除成功！");
        }
    }
}