namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章内容图片实体
    /// </summary>
    public class ArticleTextImages : BaseEntity
    {
        //内容id
        public int ArticleTextId { get; set; }
        public ArticleTexts ArticleText{get;set;}

        //内容图片
        public string ATImage { get; set; }

        //图片显示顺序（这是为了防止数据库插入时出现先后不一的情况）
        public int ATImageRank { get; set; }

    }
}