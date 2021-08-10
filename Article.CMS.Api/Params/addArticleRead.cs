using System.Collections.Generic;

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端点赞实体
    /// </summary>
    public class addArticleRead
    {
        //用户id
        public int UserId { get; set; }
        //文章id
        public int ArticleId { get; set; }
    }
}