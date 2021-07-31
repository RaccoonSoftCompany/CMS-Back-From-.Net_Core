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
        /// <returns>状态码</returns>
        private IRepository<UserInfos> _UserInfosRepository;

        public UserInfosController(IConfiguration configuration, IRepository<UserInfos> UserInfosRepository)
        {
            _UserInfosRepository = UserInfosRepository;
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var UserInfos = _UserInfosRepository.Table.ToList();
            var userInfo=UserInfos.Where(x=>x.UserId==id).SingleOrDefault();
            if(userInfo==null){
                return DataStatus.DataError(1221, "该用户不存在！");
            }
            return DataStatus.DataSuccess(1000, userInfo, "获取当前用户信息成功！");
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="PasswordInfo">传入前端数据实体</param>
        /// <returns>状态码</returns>
        [HttpPut]
        [Route("ChangeUserInfo/{id}")]
        public dynamic ChangeUserInfo(int id, UserInfoParams UpUserInfo)
        {
            var userInfos = _UserInfosRepository.Table.ToList();
            var userInfo = userInfos.Where(x => x.UserId == id).SingleOrDefault();
            if (userInfo == null)
            {
                return DataStatus.DataError(1221, "该用户不存在！");
            }
            var dbuserInfoNickName = userInfo.NickName;
            var dbsex = userInfo.Sex;

            var UpNickName = UpUserInfo.NickName == null ? dbuserInfoNickName : UpUserInfo.NickName.Trim();
            var UpSex = UpUserInfo.Sex == null ? dbsex : UpUserInfo.Sex.Trim();
            if (UpSex != null && !(UpSex == "男" | UpSex == "女"))
            {
                return DataStatus.DataError(1222, "用户性别不正确请检查！");
            }

            userInfo.NickName = UpNickName;
            userInfo.Sex = UpSex;

            _UserInfosRepository.Update(userInfo);
            return DataStatus.DataSuccess(1000, userInfo, "用户信息修改成功！");

        }
    }
}