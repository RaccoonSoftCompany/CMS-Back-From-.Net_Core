
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 轮播图实体
    /// </summary>
    public class SlideShow : BaseEntity
    {
        //站点Id
        public int WebSideId { get; set; }
        public virtual WebSide WebSid { get; set; }
        //轮播图
        public string SlideSideUrl { get; set; }
    }
}