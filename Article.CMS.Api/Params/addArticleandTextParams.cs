namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端文章实体
    /// </summary>
    public class addArticleandTextParams
    {
        //用户id
        public int UserId { get; set; }
        //文章标题
        public string ATitle { get; set; }
        //文章简介
        public string AIntro { get; set; }
        //文章内容
        public string AText { get; set; }
    }
}