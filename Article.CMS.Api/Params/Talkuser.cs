using System.Collections.Generic;

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端评论用户显示实体
    /// </summary>
    public class Talkuser
    {
        //评论id
        public int TalkId { get; set; }
        //用户id
        public int UserId { get; set; }
        //用户头像
        public string UImageURL { get; set; }
        //用户昵称
        public string UNickName { get; set; }
        //评论内容
        public string TalkText { get; set; }

    }
}
