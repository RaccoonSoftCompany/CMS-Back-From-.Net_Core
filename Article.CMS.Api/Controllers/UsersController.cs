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
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public dynamic Post(CreateUser newUser)
        {
            var UName = newUser.UName.Trim();
            var Upassword = newUser.Upassword.Trim();
            var UEmail = newUser.UEmail.Trim();
            var MKey = newUser.MKey.Trim();

            if (string.IsNullOrEmpty(UName) || string.IsNullOrEmpty(Upassword) || string.IsNullOrEmpty(UEmail) || string.IsNullOrEmpty(MKey))
            {
                return new
                {
                    Code = 1000,
                    Data = "",
                    Msg = "插入失败"
                };
            }

            var user = new Users
            {
                UName = newUser.UName,
                Upassword = newUser.Upassword,
                UEmail = newUser.UEmail,
                MKey = newUser.MKey
            };

            _usersRepository.Insert(user);

            return JsonHelper.Serialize(new
            {
                Code = 1000,
                Data = user,
                Msg = "添加成功"
            });
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public dynamic Put(int id, CreateUser updateUser)
        {
            var UName = updateUser.UName.Trim();
            var Upassword = updateUser.Upassword.Trim();
            var UEmail = updateUser.UEmail.Trim();
            var MKey = updateUser.MKey.Trim();

            if (string.IsNullOrEmpty(UName) || string.IsNullOrEmpty(Upassword) || string.IsNullOrEmpty(UEmail) || string.IsNullOrEmpty(MKey))
            {
                return new
                {
                    Code = 1000,
                    Data = "",
                    Msg = "更新失败"
                };
            }

            var user = _usersRepository.GetId(id);

            if(user==null)
            {
                return new
                {
                    Code=1000,
                    Data="",
                    Msg="更新的内容不能为空"
                };
            }

            user.UName=updateUser.UName;
            user.Upassword=updateUser.Upassword;
            user.UEmail=updateUser.UEmail;
            user.MKey=updateUser.MKey;

            _usersRepository.Update(user);

            return new
            {
                Code = 1000,
                Data = user,
                Msg = "更新成功"
            };
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            _usersRepository.Delete(id);

            return new
            {
                Code = 1000,
                Data = id,
                Msg = "删除成功"
            };
        }
    }
}