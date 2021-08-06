using System;
namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 用户以及用户信息显示实体
    /// </summary>
    public class UserInfoViewParams
    {
        //用户头像
        public int UImageId {get;set;}
        //用户id
        public int Id { get; set; }
        //用户名
        public string UName { get; set; }
        //邮箱
        public string UEmail { get; set; }
        //密码
        public string Upassword { get; set; }
        //权限id
        public int PowerId { get; set; }
        //权限名称
        public string PName { get; set; }
        //问题id
        public int MatterId { get; set; }
        //问题名称
        public string MName { get; set; }
        //答案
        public string MKey { get; set; }
        //用户昵称
        public string NickName { get; set; }
        //用户性别
        public string Sex { get; set; }
        //是否启用
        public bool IsActived { get; set; }
        //是否删除
        public bool IsDeleted { get; set; }
        //创建时间
        public DateTime CreatedTime { get; set; }
        //更新时间
        public DateTime UpdatedTime { get; set; }
        //备注
        public string Remarks { get; set; }
    }
}