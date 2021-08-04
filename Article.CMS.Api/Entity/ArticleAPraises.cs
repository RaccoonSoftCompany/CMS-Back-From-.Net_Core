namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章评点赞实体
    /// </summary>
    public class ArticleAPraises : BaseEntity
    {
        //用户id
        public int UserId { get; set; }

        //文章id
        public int ArticleId { get; set; }
        public Articles Article { get; set; }
    }
}