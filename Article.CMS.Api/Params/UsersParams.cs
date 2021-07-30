

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端用户实体
    /// </summary>
    public class UsersParams
    {
        //用户名
        public string UName { get; set; }
        //邮箱
        public string UEmail { get; set; }
        //原始密码
        public string inUpassword { get; set; }
        //密码
        public string Upassword { get; set; }
        //确认密码
        public string reUpassword { get; set; }
        //权限
        public int PowerId { get; set; }
        //问题
        public int MatterId { get; set; }
        //答案
        public string MKey { get; set; }
        //是否启用
        public bool IsActived { get; set; }
        //是否删除
        public bool IsDeleted { get; set; }
        //备注
        public string Remarks { get; set; }
    }
}