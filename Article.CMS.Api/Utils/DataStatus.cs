

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

        public dynamic DataSuccess(dynamic user)
        {
            return new
            {
                Code=1000,
                Data=user,
                Msg="执行成功"
            };
        }
    }
}