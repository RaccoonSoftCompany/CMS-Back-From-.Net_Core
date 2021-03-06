using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Microsoft.AspNetCore.Authorization;
using Article.CMS.Api.Database;
using System;
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

        /// <summary>
        /// 所以数据库
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// token实体
        /// </summary>
        private TokenParameter _tokenParameter;

        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public UsersController(IConfiguration configuration, IRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _tokenParameter =
                _configuration
                    .GetSection("TokenParameter")
                    .Get<TokenParameter>();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginData">前端返回的登录信息</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        [Route("login")]
        public dynamic Login(UsersParams loginData)
        {
            var username = loginData.UName.Trim();
            var password = loginData.Upassword.Trim();

            var users = _usersRepository.Table.ToList();

            var user = users.Where(x => x.UName.Equals(username) && x.Upassword.Equals(password)).SingleOrDefault();

            if (user == null)
            {
                return DataStatus.DataError(1117, "账号或密码不正确！");
            }

            var token = TokenHelper.GenerateToekn(_tokenParameter, user.UName);
            var refreshToken = "112358";

            var userInfos = _Context.UserInfos.Where(x => x.UserId == user.Id).SingleOrDefault();
            var nickName = userInfos == null ? user.UName : userInfos.NickName;
            var uImageUrl = userInfos == null ? null : userInfos.ImageURL;
            return DataStatus.DataSuccess(1000, new { ID = user.Id, UName = user.UName, NickName = nickName, UImageUrl = uImageUrl, Token = token, refreshToken = refreshToken }, "登录成功！");
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="newUser">前端新用户数据</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        [Route("register")]
        public dynamic Register(UsersParams newUser)
        {
            var uName = newUser.UName.Trim().ToLower();
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
            var dbUname = users.Where(x => x.UName.Equals(uName)).ToList();//获取用户名
            if (dbUname.Count != 0)
            {
                return DataStatus.DataError(1112, "用户名已存在请更改！");
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

            //注册用户成功后，直接创建该用户信息
            var Isuser = _usersRepository.Table.Where(x => x.UName.Equals(uName)).SingleOrDefault();
            var UserInfo = new UserInfos
            {
                UserId = Isuser.Id,
                NickName = "newU-" + Isuser.Id,
                Sex = null,
                ImageURL="UploadFiles/DefaultImg.png",
                IsActived = true,
                IsDeleted = false,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Remarks = null
            };
            _Context.UserInfos.Add(UserInfo);
            _Context.SaveChanges();

            return DataStatus.DataSuccess(1000, user, "新用户注册成功！");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="PasswordInfo">传入前端数据实体</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        [Route("changePwd/{id}")]
        public dynamic ChangePassword(int id, UsersParams PasswordInfo)
        {
            var inPwd = PasswordInfo.inUpassword.Trim();
            var NewPwd = PasswordInfo.Upassword.Trim();
            var reNewPwd = PasswordInfo.reUpassword.Trim();

            var user = _usersRepository.GetId(id);

            if (user == null)
            {
                return DataStatus.DataError(1114, "该用户不存在无法执行修改密码操作！");
            }

            if (string.IsNullOrEmpty(inPwd) || string.IsNullOrEmpty(NewPwd) || string.IsNullOrEmpty(reNewPwd))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var dbpwd = user.Upassword.ToString();

            if (!dbpwd.Equals(inPwd))
            {
                return DataStatus.DataError(1115, "原密码不正确！");
            }

            if (NewPwd != reNewPwd)
            {
                return DataStatus.DataError(1113, "两次密码不一致！");
            }

            user.Upassword = reNewPwd;
            _usersRepository.Update(user);

            return DataStatus.DataSuccess(1000, user, "密码修改成功！");
        }

        /// <summary>
        /// 忘记密码/获取问题
        /// </summary>
        /// <param name="uName">用户名</param>
        /// <returns>对应问题</returns>
        [HttpGet]
        [Route("ForgetPwdMatters/{uname}")]
        public dynamic ForgetPasswordMatters(string uName)
        {
            //获取用户表
            var users = _usersRepository.Table.ToList();
            //查找用户是否存在
            var dbUser = users.Where(x => x.UName.Equals(uName)).SingleOrDefault();//获取用户名
            if (dbUser == null)
            {
                return DataStatus.DataError(1114, "该用户不存在无法执行忘记密码操作！");
            }

            var matterId = dbUser.MatterId;
            var matter = _Context.Matters.Where(x => x.Id == matterId).SingleOrDefault();//获取问题
            var matterName = matter.MName.ToString();
            var uId = dbUser.Id;

            return DataStatus.DataSuccess(1000, new { UId = uId, MName = matterName }, "该用户的问题获取成功！");
        }

        /// <summary>
        /// 忘记密码/答案判断
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="PasswordInfo">传入前端数据实体</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        [Route("ForgetPwd/{id}")]
        public dynamic ForgetPwd(int id, UsersParams PasswordInfo)
        {
            var mKey = PasswordInfo.MKey.Trim();
            var NewPwd = PasswordInfo.Upassword.Trim();
            var reNewPwd = PasswordInfo.reUpassword.Trim();

            var user = _usersRepository.GetId(id);

            if (user == null)
            {
                return DataStatus.DataError(1114, "该用户不存在无法执行忘记密码操作！");
            }

            if (string.IsNullOrEmpty(mKey) || string.IsNullOrEmpty(NewPwd) || string.IsNullOrEmpty(reNewPwd))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var dbMKey = user.MKey.ToString();

            if (!dbMKey.Equals(mKey))
            {
                return DataStatus.DataError(1116, "密保答案不正确！");
            }

            if (NewPwd != reNewPwd)
            {
                return DataStatus.DataError(1113, "两次密码不一致！");
            }

            user.Upassword = reNewPwd;
            _usersRepository.Update(user);

            return DataStatus.DataSuccess(1000, user, "密码修改成功！");
        }

        /// <summary>
        /// 刷新token验证
        /// </summary>
        /// <param name="refresh"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, Route("refreshtoken")]
        public dynamic RefreshToken(RefreshTokenDTO refresh)
        {
            var username = TokenHelper.ValidateToken(_tokenParameter, refresh);

            if (string.IsNullOrEmpty(username))
            {
                return new { Code = 1002, Data = "", Msg = "token验证失败" };
            }

            var token = TokenHelper.GenerateToekn(_tokenParameter, username);
            var refreshToken = "112358";

            return new
            {
                Code = 1000,
                Data = new { Token = token, refreshToken = refreshToken },
                Msg = "刷新token成功^_^"
            };
        }

    }
}