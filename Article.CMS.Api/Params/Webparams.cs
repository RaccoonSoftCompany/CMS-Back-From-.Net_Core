namespace Article.CMS.Api.Params
{
    /// <summary>
    /// 前端添加站点信息实体
    /// </summary>
    public class Webparams
    {
        //站点名称
        public string WebName { get; set; }
        //ICP备案号
        public string ICPCase { get; set; }
        //公安备案
        public string PSecurit { get; set; }
        //版权信息
        public string Copyright { get; set; }

    }
}