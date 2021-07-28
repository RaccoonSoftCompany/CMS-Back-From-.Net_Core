

namespace Article.CMS.Api.Repository
{
    public class DataStatus 
    {
        public dynamic DataError()
        {
            return new
            {
                Code=200,
                Data="",
                Msg="该操作出错啦"
            };
        }

        public dynamic DataSuccess(dynamic data)
        {
            return new
            {
                Code=1000,
                Data=data,
                Msg="执行成功"
            };
        }
    }
}