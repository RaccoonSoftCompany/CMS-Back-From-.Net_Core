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
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {

            var users = _usersRepository.Table.ToList();
            return JsonHelper.Serialize(new DataStatus().DataSuccess(users));
        }

        [HttpPost]
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public dynamic Post(UsersParams newUser)
        {
            var uName = newUser.UName.Trim();
            var uPassword = newUser.Upassword.Trim();
            var uEmail = newUser.UEmail.Trim();
            var mKey = newUser.MKey.Trim();
            var powerId = newUser.PowerId;
            var matterId = newUser.MatterId;

            if (string.IsNullOrEmpty(uName) || string.IsNullOrEmpty(uPassword) || string.IsNullOrEmpty(uEmail) || string.IsNullOrEmpty(mKey))
            {
                return new DataStatus().DataError();
            }

            var users = new Users
            {
                UName = newUser.UName,
                Upassword = newUser.Upassword,
                UEmail = newUser.UEmail,
                MKey = newUser.MKey,
                PowerId=powerId,
                MatterId=matterId
            };

            _usersRepository.Insert(users);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(users));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public dynamic Put(int id, UsersParams updateUser)
        {
            var UName = updateUser.UName.Trim();
            var Upassword = updateUser.Upassword.Trim();
            var UEmail = updateUser.UEmail.Trim();
            var MKey = updateUser.MKey.Trim();

            if (string.IsNullOrEmpty(UName) || string.IsNullOrEmpty(Upassword) || string.IsNullOrEmpty(UEmail) || string.IsNullOrEmpty(MKey))
            {
                return new DataStatus().DataError();
            }

            var users = _usersRepository.GetId(id);

            if(users==null)
            {
                return new DataStatus().DataError();
            }

            users.UName=updateUser.UName;
            users.Upassword=updateUser.Upassword;
            users.UEmail=updateUser.UEmail;
            users.MKey=updateUser.MKey;
            users.PowerId=updateUser.PowerId;
            users.MatterId=updateUser.MatterId;

            _usersRepository.Update(users);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(users));
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

            return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        }
    }
}