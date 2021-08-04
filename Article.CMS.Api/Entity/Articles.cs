using System.Collections.Generic;
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章实体
    /// </summary>
    public class Articles : BaseEntity
    {
        //用户id
        public int UserId { get; set; }
        public Users user { get; set; }

        //文章标题
        public string ATitle { get; set; }

        //文章标题图片
        public string ATitleImage { get; set; }

        public virtual IEnumerable<ArticleTexts> ArticleTexts { get; set; }
        public virtual IEnumerable<ArticleReads> ArticleReads { get; set; }
        public virtual IEnumerable<ArticleTalks> ArticleTalks { get; set; }
        public virtual IEnumerable<ArticleAPraises> ArticleAPraises { get; set; }

    }
}