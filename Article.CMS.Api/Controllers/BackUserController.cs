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
    /// 管理员用户控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BackUserController : ControllerBase
    {
        /// <summary>
        /// 创建用户存储仓库
        /// </summary>
        /// <typeparam name="Users">用户实体</typeparam>
        /// <returns></returns>
        private IRepository<Users> _usersRepository;
        private IConfiguration _configuration;
        private TokenParameter _tokenParameter;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public BackUserController(IConfiguration configuration, IRepository<Users> usersRepository)
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
        /// <param name="loginData"></param>
        /// <returns></returns>
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
            else if (!(user.PowerId == 1 || user.PowerId == 2))
            {
                return DataStatus.DataError(1118, "该用户权限不足！");
            }

            return DataStatus.DataSuccess(1000, user, "登录成功！");
        }

        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            //获取用户表
            var articles = _usersRepository.Table.ToList();
            //把用户表和用户信息表链接拿出所需值赋给UserInfoViewParams实体
            var UserInfoViewParams = _Context.UserInfos.Join(_Context.Users, Pet => Pet.UserId, per => per.Id, (pet, per) => new UserInfoViewParams
            {
                Id = per.Id,
                UName = per.UName,
                Upassword = per.Upassword,
                PowerId = per.PowerId,
                PName = _Context.Powers.Where(x => x.Id == per.PowerId).SingleOrDefault().PName,
                MatterId = per.MatterId,
                MName = _Context.Matters.Where(x => x.Id == per.MatterId).SingleOrDefault().MName,
                MKey = per.MKey,
                NickName = pet.NickName,
                Sex = pet.Sex,
                IsActived = per.IsActived,
                IsDeleted = per.IsDeleted,
                CreatedTime = per.CreatedTime,
                UpdatedTime = per.UpdatedTime > pet.UpdatedTime ? per.UpdatedTime : pet.UpdatedTime,
                Remarks = pet.Remarks
            });

            return DataStatus.DataSuccess(1000, UserInfoViewParams, "获取用户模块成功");
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spUserAndInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ChangeuserInfo/{id}")]
        public dynamic ChangeuserInfo(int id, UserInfoViewParams upUserAndInfo)
        {
            var upUName = upUserAndInfo.UName.Trim();
            var upUPassword = upUserAndInfo.Upassword.Trim();
            var upPowerId = upUserAndInfo.PowerId;
            var upMatterId = upUserAndInfo.MatterId;
            var upMKey = upUserAndInfo.MKey.Trim();
            var upRemarks = upUserAndInfo.Remarks == null ? null : upUserAndInfo.Remarks.Trim();

            var dbuserInfo = _Context.UserInfos.Where(x => x.UserId == id).SingleOrDefault();
            var dbnickName = dbuserInfo.NickName;
            var dbsex = dbuserInfo.Sex;

            var upNickName = upUserAndInfo.NickName == null ? dbnickName : upUserAndInfo.NickName.Trim();
            var upSex = upUserAndInfo.Sex == null ? dbsex : upUserAndInfo.Sex.Trim();

            if (string.IsNullOrEmpty(upUName) || string.IsNullOrEmpty(upUPassword) || upPowerId == 0 || upMatterId == 0 || string.IsNullOrEmpty(upMKey))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            if (upSex != null && !(upSex == "男" | upSex == "女"))
            {
                return DataStatus.DataError(1222, "用户性别不正确请检查！");
            }

            //先对用户进行查找确定是否存在
            var user = _usersRepository.GetId(id);
            if (user == null)
            {
                return DataStatus.DataError(1114, "该用户不存在！");
            }
            //用户存在判断修改的用户名是否重复不重复直接执行修改操作
            var users = _usersRepository.Table.ToList();
            var dbUname = users.Where(x => x.UName.Equals(upUName) && x.Id != id).ToList();//获取用户名
            if (dbUname.Count != 0)
            {
                return DataStatus.DataError(1112, "用户名已存在请更改！");
            }
            user.UName = upUName;
            user.Upassword = upUPassword;
            user.PowerId = upPowerId;
            user.MatterId = upMatterId;
            user.MKey = upMKey;
            user.Remarks =upRemarks;
            _usersRepository.Update(user);

            //利用用户id查找用户信息表对应的用户信息
            dbuserInfo.NickName = upNickName;
            dbuserInfo.Sex = upNickName;
            dbuserInfo.UpdatedTime = DateTime.Now;
            _Context.SaveChanges();
            //对用户信息修改
            var UserInfoViewParams = new UserInfoViewParams
            {
                Id = id,
                UName = upUName,
                Upassword = upUPassword,
                PowerId = upPowerId,
                PName = _Context.Powers.Where(x => x.Id == upPowerId).SingleOrDefault().PName,
                MatterId = upMatterId,
                MName = _Context.Matters.Where(x => x.Id == upMatterId).SingleOrDefault().MName,
                MKey = upMKey,
                NickName = upNickName,
                Sex = upSex,
                IsActived = user.IsActived,
                IsDeleted = user.IsDeleted,
                CreatedTime = user.CreatedTime,
                UpdatedTime = user.UpdatedTime > dbuserInfo.UpdatedTime ? user.UpdatedTime : dbuserInfo.UpdatedTime,
                Remarks = user.Remarks
            };

            return DataStatus.DataSuccess(1000, UserInfoViewParams, "修改用户信息成功");
        }


        /// <summary>
        /// 创建token验证
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, Route("token")]
        public dynamic GetToken(UsersParams newUser)
        {
            var username = newUser.UName.Trim();
            var password = newUser.Upassword.Trim();

            var user =
                _usersRepository
                    .Table
                    .Where(x =>
                        x.UName == username && x.Upassword == password)
                    .FirstOrDefault();

            if (user == null)
            {
                return DataStatus.DataError(1117, "账号或密码不正确！");
            }

            var token =
                TokenHelper.GenerateToekn(_tokenParameter, user.UName);
            var refreshToken = "112358";

            return DataStatus.DataSuccess(1000, new { Token = token, refreshToken = refreshToken }, "登录成功！");
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

            return DataStatus.DataSuccess(1000, new { Token = token, refreshToken = refreshToken }, "刷新token成功");
        }

    }
}