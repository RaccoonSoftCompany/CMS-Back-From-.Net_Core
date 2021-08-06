using System.Collections.Generic;

namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 前端文章评论添加实体
    /// </summary>
    public class addArticleTalkParams
    {
        //用户id
        public int UserId { get; set; }
        //文章id
        public int ArticleId { get; set; }
        //评论内容
        public string ATtext { get; set; }

    }
}
