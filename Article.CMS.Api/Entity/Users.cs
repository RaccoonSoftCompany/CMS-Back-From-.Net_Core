namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class Users : BaseEntity
    {
        //用户名
        public string UName { get; set; }

        //密码
        public string Upassword { get; set; }

        //权限id
        public virtual Powers Power { get; set; }

        //问题id
        public virtual Matters Matter { get; set; }

    }
}