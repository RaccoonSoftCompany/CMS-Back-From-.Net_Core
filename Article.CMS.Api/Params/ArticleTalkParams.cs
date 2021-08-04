using System.Collections.Generic;

namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 前端问题实体
    /// </summary>
    public class ArticleTalkParams
    {
        //用户id
        public int UserId { get; set; }
        //文章id
        public int ArticleId { get; set; }
        //评论内容
        public string ATtext { get; set; }

    }
}
