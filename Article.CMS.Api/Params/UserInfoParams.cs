namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端用户信息实体修改
    /// </summary>
    public class UserInfoParams
    {
        //用户id
        public int UserId { get; set; }

        //用户昵称
        public string NickName { get; set; }

        //用户性别
        public string Sex { get; set; }

        //用户头像
        public string MyProperty { get; set; }
    }
}