using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Params;
using Article.CMS.Api.Utils;
using System.Linq;
using System;
using System.IO;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfosController : ControllerBase
    {
        /// <summary>
        /// 创建用户信息存储仓库
        /// </summary>
        /// <typeparam name="UserInfos">用户信息实体</typeparam>
        /// <returns></returns>
        private IRepository<UserInfos> _UserInfosRepository;

        public UserInfosController(IConfiguration configuration, IRepository<UserInfos> UserInfosRepository)
        {
            _UserInfosRepository = UserInfosRepository;
        }
        [HttpGet]
        public dynamic Get()
        {

            var userInfos = _UserInfosRepository.Table.ToList();
            return JsonHelper.Serialize(new
            {
                Code = 1000,
                Data = userInfos,
                Msg = "获取用户信息表成功！"
            });
        }

    }
}