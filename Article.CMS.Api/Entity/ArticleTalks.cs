namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章评论实体
    /// </summary>
    public class ArticleTalks : BaseEntity
    {
        //用户id
        public int UserId { get; set; }
        public Users user { get; set; }

        //文章id
        public int ArticleId { get; set; }
        public Articles Article { get; set; }

        //评论内容
        public string ATText { get; set; }

    }
}