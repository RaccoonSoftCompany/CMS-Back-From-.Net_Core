using System.Collections.Generic;

namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章内容实体
    /// </summary>
    public class ArticleTexts : BaseEntity
    {
        //文章id
        public int ArticleId { get; set; }
        public Articles Article { get; set; }

        //文章内容
        public string AText { get; set; }

    }
}