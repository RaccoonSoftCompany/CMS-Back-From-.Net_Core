namespace Article.CMS.Api.Params
{
    public class QueryWithPagerParams
    {
        public QueryWithPagerParams(){
            Pager=new PagerParams();
        }
        public string Keyword { get; set; }
        public PagerParams Pager { get; set; }
    }
}