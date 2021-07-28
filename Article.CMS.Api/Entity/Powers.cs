using System.Collections.Generic;
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 权限实体
    /// </summary>
    public class Powers : BaseEntity
    {
        //权限名称
        public string PName { get; set; }

        

        public virtual IEnumerable<Users> Users { get; set; }
    }
}