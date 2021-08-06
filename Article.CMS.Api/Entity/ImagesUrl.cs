namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 文章内容图片实体
    /// </summary>
    public class ImagesUrl : BaseEntity
    {
        //文件原名
        public string OriginName { get; set; }
        //文件原名
        public string CurrentName { get; set; }
        //内容路径
        public string ATImageUrl { get; set; }

        //用户Id
        public int UserId {get;set;}

    }
}