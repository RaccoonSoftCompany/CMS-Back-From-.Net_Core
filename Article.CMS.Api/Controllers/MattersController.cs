using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MattersController : ControllerBase
    {
        /// <summary>
        /// 创建问题存储仓库
        /// </summary>
        /// <typeparam name="Matters">问题实体</typeparam>
        /// <returns></returns>
        private IRepository<Matters> _mattersRepository;

        public MattersController(IConfiguration configuration, IRepository<Matters> mattersRepository)
        {
            _mattersRepository = mattersRepository;
        }
        [HttpGet]
        /// <summary>
        /// 获取所有问题请求
        /// </summary>
        /// <returns></returns>
       public dynamic Get([FromQuery] PagerParams pager)
        {
            var pageIndex = pager.PageIndex;
            var pageSize = pager.PageSize;
            var matters = _mattersRepository.Table;
            var matter = matters.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return JsonHelper.Serialize(new
            {
                Code = 1000,
                Data = new { Data = matter, Pager = new { pageIndex, pageSize, rowsTotal = matters.Count() } },
                Msg = "获取用户列表成功^_^"
            });
        }

    }
}