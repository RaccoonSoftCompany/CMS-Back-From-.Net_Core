using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;
using Article.CMS.Api.Database;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackPowersController : ControllerBase
    {
        /// <summary>
        /// 创建权限存储仓库
        /// </summary>
        /// <typeparam name="Matters">权限实体</typeparam>
        /// <returns></returns>
        private IRepository<Powers> _PowersRepository;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public BackPowersController(IConfiguration configuration, IRepository<Powers> PowersRepository)
        {
            _PowersRepository = PowersRepository;
        }

        [HttpGet]
        /// <summary>
        /// 获取所有权限请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var powers = _PowersRepository.Table.ToList();
            return DataStatus.DataSuccess(1000, powers, "获取密保问题成功！");
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        [Route("AddPower")]
        [HttpPost]
        public dynamic AddPower(PowerParams newPower)
        {
            var pName = newPower.PName.Trim();
            var remarks = newPower.Remarks == null ? null : newPower.Remarks.Trim();
            if (string.IsNullOrEmpty(pName))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var matters = _PowersRepository.Table.ToList();
            var dbmattet = matters.Where(x => x.PName.Equals(pName)).SingleOrDefault();
            if (dbmattet != null)
            {
                return DataStatus.DataError(1441, "已存在该权限！");
            }

            var Power = new Powers
            {
                PName = pName,
                Remarks = remarks

            };

            _PowersRepository.Insert(Power);
            return DataStatus.DataSuccess(1000, Power, "权限添加成功！");
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="upMatter">传入前端数据实体</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        [Route("ChangePowers/{id}")]
        public dynamic ChangePowers(int id, PowerParams upPower)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return DataStatus.DataError(1224, "初始化权限无法修改！");
            }
            var Power = _PowersRepository.GetId(id);
            var remarks = upPower.Remarks == null ? "" : upPower.Remarks.Trim();


            if (Power == null)
            {
                return DataStatus.DataError(1224, "数据不存在，无法执行修改操作！");
            }

            var pName = upPower.PName.Trim();
            if (string.IsNullOrEmpty(pName))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var Powers = _PowersRepository.Table.ToList();
            var dbPower = Powers.Where(x => x.PName.Equals(pName) && x.Id != id).SingleOrDefault();
            if (dbPower != null)
            {
                return DataStatus.DataError(1331, "请勿使用相同问题！");
            }

            Power.PName = pName;
            Power.Remarks = remarks;
            _PowersRepository.Update(Power);

            return DataStatus.DataSuccess(1000, Power, "修改成功");
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletePower/{id}")]
        public dynamic deletePower(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return DataStatus.DataError(1224, "初始化权限无法删除！");
            }

            var dbusersPower = _Context.Users.Where(x => x.PowerId == id).Count();
            if (dbusersPower != 0)
            {
                return DataStatus.DataError(1332, "删除失败，权限使用中！");
            }

            _PowersRepository.Delete(id);
            return DataStatus.DataSuccess(1000, new { id = id }, "删除成功！");
        }

        // /// <summary>
        // /// 模糊查询问题
        // /// </summary>
        // /// <param name="mName"></param>
        // /// <returns></returns>
        // [HttpGet]
        // [Route("likeMname/{mName}")]
        // public dynamic likeMname(string mName)
        // {
        //     var dbLikeMName = _mattersRepository.Table.Where(x => x.MName.Contains(mName)).ToList();
        //     return DataStatus.DataSuccess(1000, dbLikeMName, "查询成功！");

        // }
    }
}
