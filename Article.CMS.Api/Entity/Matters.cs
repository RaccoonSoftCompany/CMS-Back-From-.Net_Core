using System.Collections.Generic;

namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 问题实体
    /// </summary>
    public class Matters : BaseEntity
    {
        //问题名称
        public string MName { get; set; }

        

        public virtual IEnumerable<Users> Users { get; set; }

    }
}