using System.Linq;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Params;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Article.CMS.Api.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AutidInfoController : ControllerBase
    {
        private IConfiguration _configuration;

        private IRepository<AuditInfo> _auditInfoRepository;

        private TokenParameter _tokenParameter;

        public AutidInfoController(
            IConfiguration configuration,
            IRepository<AuditInfo> auditRepository
        )
        {
            _configuration = configuration;
            _auditInfoRepository = auditRepository;
            _tokenParameter =
                _configuration
                    .GetSection("TokenParameter")
                    .Get<TokenParameter>();
        }

        [HttpGet]
        public string Get([FromQuery] PagerParams pager)
        {
            // get请求默认从url中获取参数，如果需要使用实体接收参数，需要FromQuery特性
            var pageIndex=pager.PageIndex;
            var pageSize=pager.PageSize;
            var users = _auditInfoRepository.Table;
            var u=users.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            var res=new {
                Code = 1000,
                Data = new {Data = u,Pager =new {pageIndex,pageSize,rowsTotal=users.Count()}},
                Msg = "获取用户列表成功^_^"
            };
            return JsonHelper.Serialize(res);
        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var user = _auditInfoRepository.GetId(id);
            return new {
                Code = 1000,
                Data = user,
                Msg = "获取指定用户成功^_^"
            };
        }
    }
}
