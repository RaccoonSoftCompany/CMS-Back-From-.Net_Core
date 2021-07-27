using System;
namespace Article.CMS.Api.Entity
{
    /// <summary>
    /// 基础实体
    /// </summary>
    public abstract class BaseEntity
    {
        //主键
        public int Id { get; set; }
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