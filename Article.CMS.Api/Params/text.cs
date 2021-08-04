using System;
namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 用户以及用户信息实体
    /// </summary>
    public class text
    {
        //用户id
        public int Id { get; set; }
        //用户名
        public string UName { get; set; }
        //密码
        public string Upassword { get; set; }
        //权限id
        public int PowerId { get; set; }
        //问题id
        public int MatterId { get; set; }
        //答案
        public string MKey { get; set; }
        //用户昵称
        public string NickName { get; set; }
        //用户性别
        public string Sex { get; set; }
        //备注
        public string Remarks { get; set; }
    }
}