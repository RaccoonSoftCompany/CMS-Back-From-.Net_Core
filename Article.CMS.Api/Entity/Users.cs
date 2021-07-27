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
        public int PowerId { get; set; }

        public virtual Powers Powers { get; set; }

        //问题id
        public int MatterId { get; set; }
        public virtual Matters Matters { get; set; }

    }
}