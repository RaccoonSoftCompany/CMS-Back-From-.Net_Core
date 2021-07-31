namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 查询分页
    /// </summary>
    public class QueryWithPagerParams
    {
        public QueryWithPagerParams(){
            Pager=new PagerParams();
        }
        public string Keyword { get; set; }
        public PagerParams Pager { get; set; }
    }
}