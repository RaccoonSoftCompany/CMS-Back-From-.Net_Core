using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Article.CMS.Api.Utils
{
    public class JsonHelper
    {
        /// <summary>
        /// 数据库json处理，日期处理
        /// </summary>
        /// <param name="obj">数据</param>
        /// <returns></returns>
        public static string Serialize(dynamic obj)
        {
            var datetimeFormat = "yyyy年MM月dd日 HH:mm:ss";

            var setting = new JsonSerializerSettings();

            setting.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            setting.DateFormatString = datetimeFormat;

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeFormat };

            var result = JsonConvert.SerializeObject(obj, Formatting.Indented, setting);
            return result;
        }
    }
}