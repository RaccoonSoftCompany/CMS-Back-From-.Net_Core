using System;

namespace Article.CMS.Api.Params
{
    public class GetArticle
    {
        //主键
        public int Id { get; set; }
        //用户id
        public int UserId { get; set; }
        //文章标题
        public string ATitle { get; set; }
        //文章标题图片
        public string ATitleImage { get; set; }
        //文章内容
        public string AText { get; set; }
        //是否有图片
        public bool isATimage { get; set; }
        //是否启用
        public bool IsActived { get; set; }
        //是否删除
        public bool IsDeleted { get; set; }
        //创建时间
        public DateTime CreatedTime { get; set; }
        //更新时间
        public DateTime UpdatedTime { get; set; }
        //备注
        public string Remarks { get; set; }    }    
}