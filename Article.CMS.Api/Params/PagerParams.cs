

namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 数据分页
    /// </summary>
    public class PagerParams
    {
        private int _pageIndex;
        private int _pageSize;
        public PagerParams()
        {
            _pageSize = 1;
            _pageSize = 5;
        }
        // 页码（当前第几页）
        public int PageIndex
        {
            get
            {
                if (_pageIndex < 1)
                {
                    _pageIndex = 1;
                }
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        // 页大小（一页里面行的数量）
        public int PageSize
        {
            get
            {
                if (_pageSize < 5)
                {
                    _pageSize = 5;
                }
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        // 总记录数量
        public int RowsTotal { get; set; }

        // public string SearchText { get; set; }
    }
}