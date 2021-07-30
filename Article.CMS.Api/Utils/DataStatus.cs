using Article.CMS.Api.Utils;

namespace Article.CMS.Api.Repository
{
    public class DataStatus
    {
        /// <summary>
        /// 接口操作提示返回值（操作异常）
        /// </summary>
        /// <returns></returns>
        public static dynamic DataError(int code, string msg)
        {
            return new
            {
                Code = code,
                Data = "",
                Msg = msg
            };
        }

        /// <summary>
        /// 接口操作提示返回值（操作成功）
        /// </summary>
        /// <returns></returns>
        public static dynamic DataSuccess(int code, dynamic data, string msg)
        {
            return JsonHelper.Serialize(new
            {
                Code = code,
                Data = data,
                Msg = msg
            });

        }
    }
}