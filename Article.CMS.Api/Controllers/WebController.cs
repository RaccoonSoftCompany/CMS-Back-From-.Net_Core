using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Article.CMS.Api.Database;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebController : ControllerBase
    {
        /// <summary>
        /// 创建权限存储仓库
        /// </summary>
        /// <typeparam name="Matters">权限实体</typeparam>
        /// <returns></returns>
        private IRepository<WebSide> _WebSideRepository;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public WebController(IConfiguration configuration, IRepository<WebSide> WebSideRepository)
        {
            _WebSideRepository = WebSideRepository;
        }

        [HttpGet]
        /// <summary>
        /// 获取所有站点信息请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var WebSide = _WebSideRepository.Table.ToList();
            return DataStatus.DataSuccess(1000, WebSide, "站点信息获取成功！");
        }

        /// <summary>
        /// 添加问题
        /// </summary>
        /// <returns></returns>
        [Route("AddWeb")]
        [HttpPost]
        public dynamic AddWeb(Webparams newWeb)
        {
            var webName = newWeb.WebName.Trim();
            var iCPCase = newWeb.ICPCase.Trim();
            var pSecurit=newWeb.PSecurit.Trim();
            var copyright=newWeb.Copyright.Trim();

            if (string.IsNullOrEmpty(webName) || string.IsNullOrEmpty(iCPCase) || string.IsNullOrEmpty(pSecurit) || string.IsNullOrEmpty(copyright))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var WebSide = new WebSide
            {
                WebName = webName,
                ICPCase = iCPCase,
                PSecurit=pSecurit,
                Copyright=copyright

            };

            _WebSideRepository.Insert(WebSide);
            return DataStatus.DataSuccess(1000, WebSide, "站点添加成功！");
        }

    }
}
