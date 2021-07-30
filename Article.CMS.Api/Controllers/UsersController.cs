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
    /// <summary>
    /// 用户控制器
    /// </summary>
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

        [HttpPost]
        [Route("register")]
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="newUser">传入前端数据实体</param>
        /// <returns></returns>
        public dynamic Register(UsersParams newUser)
        {
            var uName = newUser.UName.Trim();
            var uPassword = newUser.Upassword.Trim();
            var reUpassword = newUser.reUpassword.Trim();
            var uEmail = newUser.UEmail;
            var matterId = newUser.MatterId;
            var mKey = newUser.MKey.Trim();
            var powerId = 3;
            var remarks = "普通注册";

            if (string.IsNullOrEmpty(uName) || string.IsNullOrEmpty(uPassword) || string.IsNullOrEmpty(reUpassword) || matterId == 0 || string.IsNullOrEmpty(mKey))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }
            
            var users = _usersRepository.Table.ToList();
            var dbUname=users.Where(x=>x.UName.Equals(uName)).ToList();//获取用户名
            if (dbUname.Count!=0)
            {
                return DataStatus.DataSuccess(1112, dbUname,"用户名已存在请更改！");
            }

            if (uPassword != reUpassword)
            {
                return DataStatus.DataError(1113, "两次密码不一致！");
            }

            var user = new Users
            {
                UName = uName,
                Upassword = uPassword,
                UEmail = newUser.UEmail,
                MatterId = matterId,
                MKey = mKey,
                PowerId = powerId,
                Remarks = remarks
            };

            _usersRepository.Insert(user);
            return DataStatus.DataSuccess(1000, user, "新用户注册成功！");
        }

        // /// <summary>
        // /// 修改密码
        // /// </summary>
        // /// <param name="id">用户id</param>
        // /// <param name="PasswordInfo">传入前端数据实体</param>
        // /// <returns></returns>
        // [HttpPut("{id}")]
        // [Route("changePwd")]
        // public dynamic ChangePassword(int id, UsersParams PasswordInfo)
        // {
        //     var OldPwd = PasswordInfo.inUpassword.Trim();
        //     var NewPwd = PasswordInfo.Upassword.Trim();
        //     var reNewPwd = PasswordInfo.reUpassword.Trim();

        //     var user = _usersRepository.GetId(id);

        //     if (user == null)
        //     {
        //         return DataStatus.DataError(1113, "该用户不存在无法执行修改密码操作！");
        //     }

        //     if (string.IsNullOrEmpty(OldPwd) || string.IsNullOrEmpty(NewPwd) || string.IsNullOrEmpty(reNewPwd))
        //     {
        //         return DataStatus.DataError(1114, "请检查必填项目是否填写！");
        //     }

        //     if ()
        //     {

        //     }
        //     user.Upassword = PasswordInfo.newPassword;
        //     _usersRepository.Update(user);

        //     return new
        //     {
        //         Code = 1000,
        //         Data = user,
        //         Msg = "修改密码成功!"
        //     };
        // }

        // [HttpDelete("{id}")]
        // /// <summary>
        // /// 删除数据
        // /// </summary>
        // /// <param name="id"></param>
        // /// <returns></returns>
        // public dynamic DeleteUser(int id)
        // {
        //     _usersRepository.Delete(id);

        //     return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        // }

        // /// <summary>
        // /// 登录
        // /// </summary>
        // /// <param name="loginData"></param>
        // /// <returns></returns>
        // [HttpPost]
        // [Route("login")]
        // public dynamic Login(LoginParams loginData)
        // {
        //     var username = loginData.UName.Trim();
        //     var password = loginData.Upassword.Trim();

        //     var users = _usersRepository.Table.ToList();

        //     foreach (var user in users)
        //     {
        //         if (user.UName == username && user.Upassword == password)
        //         {
        //             return JsonHelper.Serialize(new DataStatus().DataSuccess(user));
        //         }
        //     }

        //     return JsonHelper.Serialize(new DataStatus().DataError());
        // }

    }
}