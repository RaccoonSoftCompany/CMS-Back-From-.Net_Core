using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
// using Article.CMS.Api.Params;
using Article.CMS.Api.Utils;
using System.Linq;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// 创建用户存储仓库
        /// </summary>
        /// <typeparam name="Users">用户实体</typeparam>
        /// <returns></returns>
        private IRepository<Users> _usersRepository;

        public UsersController(IConfiguration configuration, IRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [HttpGet]
        public dynamic Get()
        {

            var users = _usersRepository.Table.ToList();
            return JsonHelper.Serialize(new
            {
                Code = 1000,
                Data = users,
                Msg = "获取用户表成功！"
            });
        }

        [HttpPost]
        public dynamic Post()
        {

            return new
            {
                Code = 1000,
                Data = "",
                Msg = "添加成功"
            };
        }

        [HttpPut]
        public dynamic Put()
        {
            return new
            {
                Code = 1000,
                Data = "",
                Msg = "更新成功"
            };
        }

        [HttpDelete]
        public dynamic Delete()
        {
            return new 
            {
                Code=1000,
                Data="",
                Msg="删除成功"
            };
        }
    }
}