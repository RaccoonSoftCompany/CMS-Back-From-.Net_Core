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
    public class QRCodeController : ControllerBase
    {
        /// <summary>
        /// 创建站点存储仓库
        /// </summary>
        /// <typeparam name="Matters">权限实体</typeparam>
        /// <returns></returns>
        private IRepository<QRCode> _QRCodeRepository;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public QRCodeController(IConfiguration configuration, IRepository<QRCode> QRCodeRepository)
        {
            _QRCodeRepository = QRCodeRepository;
        }

        [HttpGet("{id}")]
        /// <summary>
        /// 获取所有站点信息请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get(int id)
        {
            var QRImage = _QRCodeRepository.Table.Where(x=>x.WebSideId==id).ToList();
            return DataStatus.DataSuccess(1000,QRImage , "站点信息获取成功！");
        }
    }
}
