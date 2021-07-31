

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 数据分页
    /// </summary>
    public class PagerParams
    {  
        // 页码（当前第几页）
        public int PageIndex{get;set;}
        

        // 页大小（一页里面行的数量）
        public int PageSize{get;set;}
       

        // 总记录数量
        public int RowsTotal { get; set; }
    }
}