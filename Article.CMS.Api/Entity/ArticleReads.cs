namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章访问实体
    /// </summary>
    public class ArticleReads : BaseEntity
    {
        //用户id
        public int UserId { get; set; }
        public Users user { get; set; }

        //文章id
        public int ArticleId { get; set; }
        public Articles Article { get; set; }

    }
}