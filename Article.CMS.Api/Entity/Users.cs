using System.Collections.Generic;
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class Users : BaseEntity
    {
        //用户名
        public string UName { get; set; }

        //用户邮箱
        public string UEmail { get; set; }

        //密码
        public string Upassword { get; set; }

        //问题id
        public int MatterId { get; set; }
        public virtual Matters Matter { get; set; }

        //问题答案
        public string MKey { get; set; }

        //权限id
        public int PowerId { get; set; }

        public virtual Powers Power { get; set; }


        public virtual IEnumerable<UserInfos> UserInfos { get; set; }
        public virtual IEnumerable<Articles> Articles { get; set; }
        public virtual IEnumerable<ArticleReads> ArticleReads { get; set; }
        public virtual IEnumerable<ArticleTalks> ArticleTalks { get; set; }

    }
}