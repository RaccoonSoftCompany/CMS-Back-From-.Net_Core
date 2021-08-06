using System;

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端文章信息
    /// </summary>
    public class ArticleViewParams
    {
        //主键
        public int Id { get; set; }
        //用户id
        public int UserId { get; set; }
        //用户头像
        public string UImageURL { get; set; }
        //用户昵称
        public string NickName { get; set; }
        //文章标题
        public string ATitle { get; set; }
        //文章标题图片
        public string AImageUrl { get; set; }
        //文章简介
        public string AIntro { get; set; }
        //文章内容
        public string AText { get; set; }
        //创建时间
        public DateTime CreatedTime { get; set; }
        //阅读量
        public int AReadCount { get; set; }
        //评论量
        public int ATalkCount { get; set; }
        //点赞量
        public int APraiseCount { get; set; }
        //备注
        public string Remarks { get; set; }
    }
}