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
        /// 创建站点存储仓库
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
            return DataStatus.DataSuccess(1000, WebSide.OrderBy(x => x.Id), "站点信息获取成功！");
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
            var pSecurit = newWeb.PSecurit.Trim();
            var copyright = newWeb.Copyright.Trim();

            if (string.IsNullOrEmpty(webName) || string.IsNullOrEmpty(iCPCase) || string.IsNullOrEmpty(pSecurit) || string.IsNullOrEmpty(copyright))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var WebSide = new WebSide
            {
                WebName = webName,
                ICPCase = iCPCase,
                PSecurit = pSecurit,
                Copyright = copyright
            };

            _WebSideRepository.Insert(WebSide);

            WebSide.IsActived = false;
            _WebSideRepository.Update(WebSide);
            return DataStatus.DataSuccess(1000, WebSide, "站点添加成功！");
        }

        /// <summary>
        /// 修改问题
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spUserAndInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpWeb/{id}")]
        public dynamic UpWeb(int id, Webparams UpWebparams)
        {
            var webName = UpWebparams.WebName.Trim();
            var iCPCase = UpWebparams.ICPCase.Trim();
            var pSecurit = UpWebparams.PSecurit.Trim();
            var copyright = UpWebparams.Copyright.Trim();

            if (string.IsNullOrEmpty(webName) || string.IsNullOrEmpty(iCPCase) || string.IsNullOrEmpty(pSecurit) || string.IsNullOrEmpty(copyright))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var isWeb = _WebSideRepository.GetId(id);
            if (isWeb == null)
            {
                return DataStatus.DataError(1221, "该站点不存在！");
            }

            var dbWeb = _WebSideRepository.Table.Where(x => x.Id == id).SingleOrDefault();
            dbWeb.WebName = webName;
            dbWeb.ICPCase = iCPCase;
            dbWeb.PSecurit = pSecurit;
            dbWeb.Copyright = copyright;
            _WebSideRepository.Update(dbWeb);

            return DataStatus.DataSuccess(1000, dbWeb, "修改站点信息成功");
        }

        /// <summary>
        /// 是否启用站点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UpWebparams"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("IsWeb/{id}")]
        public dynamic IsWeb(int id, Webparams UpWebparams)
        {
            var isWeb = _WebSideRepository.GetId(id);
            if (isWeb == null)
            {
                return DataStatus.DataError(1221, "该站点不存在！");
            }

            var isActived = UpWebparams.IsActived;
            if (isActived)
            {
                var IsOneWebTrue = _WebSideRepository.Table.Where(x => x.IsActived == true).SingleOrDefault();
                IsOneWebTrue.IsActived = false;
                _WebSideRepository.Update(IsOneWebTrue);
                isWeb.IsActived = isActived;
                _WebSideRepository.Update(isWeb);
                var WebSide = _WebSideRepository.Table.ToList();
                return DataStatus.DataSuccess(1000, WebSide.OrderBy(x => x.Id), "启用站点信息成功,已关闭原站点信息");
            }
            var dbWebSide = _WebSideRepository.Table.ToList();
            return DataStatus.DataSuccess(12221, dbWebSide.OrderBy(x => x.Id), "请启用其他站点信息即可禁用！");

        }

        [HttpGet]
        [Route("GetTrueWeb")]
        /// <summary>
        /// 获取所有启用站点信息请求
        /// </summary>
        /// <returns></returns>
        public dynamic GetTrue()
        {
            var WebSide = _WebSideRepository.Table.Where(x=>x.IsActived==true).SingleOrDefault();
            return DataStatus.DataSuccess(1000, WebSide, "站点信息获取成功！");
        }




    }
}


