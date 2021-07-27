

namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class UserInfos : BaseEntity
    {
        //用户id
        public virtual Users User { get; set; }

        //用户昵称
        public string NickName { get; set; }

        //用户性别
        public string Sex { get; set; }

        //用户头像
        public byte[] MyProperty { get; set; }

    }
}