

namespace Article.CMS.Api.Repository
{
    public class DataStatus 
    {
        /// <summary>
        /// 接口操作提示返回值（操作异常）
        /// </summary>
        /// <returns></returns>
        public dynamic DataError()
        {
            return new
            {
                Code=1000,
                Data="",
                Msg="该操作出错啦"
            };
        }

        /// <summary>
        /// 接口操作提示返回值（操作成功）
        /// </summary>
        /// <returns></returns>
        public dynamic DataSuccess(dynamic data)
        {
            return new
            {
                Code=200,
                Data=data,
                Msg="执行成功"
            };
        }
    }
}