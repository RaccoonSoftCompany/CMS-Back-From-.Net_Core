using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Microsoft.AspNetCore.Authorization;

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
            var pageIndex = int.Parse(Request.Query["pageIndex"][0]);
            var pageSize = int.Parse(Request.Query["pageSize"][0]);

            var users = _usersRepository.Table;

            var u = users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return JsonHelper.Serialize(
                new
                {
                    Code = 1000,
                    Data = new { Data = u, Pager = new { pageIndex, pageSize, rowsTotal = users.Count() } },
                    Msg = "获取用户列表成功^_^"
                }
            );
        }

        [HttpPost]
        [Route("register")]
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public dynamic Register(UsersParams newUser)
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
                PowerId = powerId,
                MatterId = matterId
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
        public dynamic UpdatePower(int id, UsersParams updateUser)
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

            if (users == null)
            {
                return new DataStatus().DataError();
            }

            users.UName = updateUser.UName;
            users.Upassword = updateUser.Upassword;
            users.UEmail = updateUser.UEmail;
            users.MKey = updateUser.MKey;
            users.PowerId = updateUser.PowerId;
            users.MatterId = updateUser.MatterId;

            _usersRepository.Update(users);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(users));
        }

        [HttpPut("{id}")]
        [Route("changePwd")]
        public dynamic ChangePassword(int id, PasswordInfo PasswordInfo)
        {
            var OldPwd = PasswordInfo.oldPassword.Trim();
            var NewPwd = PasswordInfo.newPassword.Trim();
            var user = _usersRepository.GetId(id);
            if (string.IsNullOrEmpty(OldPwd) || string.IsNullOrEmpty(NewPwd))
            {
                return new
                {
                    Code = 200,
                    Data = "",
                    Msg = "原密码与新密码不能为空,请确认后重试！"
                };
            }
            // else if (user.Upassword != OldPwd)
            // {
            //     return new
            //     {
            //         Code = 200,
            //         Data = "",
            //         Msg = "原密码错误,请确认后重试!"
            //     };
            // }
            if (user != null)
            {
                user.Upassword = PasswordInfo.newPassword;
                _usersRepository.Update(user);
            }
            return new
            {
                Code = 1000,
                Data = user,
                Msg = "修改密码成功!"
            };
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic DeleteUser(int id)
        {
            _usersRepository.Delete(id);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public dynamic Login(LoginParams loginData)
        {
            var username = loginData.UName.Trim();
            var password = loginData.Upassword.Trim();

            var users = _usersRepository.Table.ToList();

            foreach (var user in users)
            {
                if (user.UName == username && user.Upassword == password)
                {
                    return JsonHelper.Serialize(new DataStatus().DataSuccess(user));
                }
            }

            return JsonHelper.Serialize(new DataStatus().DataError());
        }

    }
}