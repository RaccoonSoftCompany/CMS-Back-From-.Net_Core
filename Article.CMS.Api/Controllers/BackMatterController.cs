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
    public class BackMatterController : ControllerBase
    {
        /// <summary>
        /// 创建问题存储仓库
        /// </summary>
        /// <typeparam name="Matters">问题实体</typeparam>
        /// <returns></returns>
        private IRepository<Matters> _mattersRepository;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public BackMatterController(IConfiguration configuration, IRepository<Matters> mattersRepository)
        {
            _mattersRepository = mattersRepository;
        }

        /// <summary>
        /// 添加问题
        /// </summary>
        /// <returns></returns>
        [Route("AddMatter")]
        [HttpPost]
        public dynamic AddMatter(MatterParams newMatter)
        {
            var mName = newMatter.MName.Trim();
            var remarks = newMatter.Remarks == null ? null : newMatter.Remarks.Trim();
            if (string.IsNullOrEmpty(mName))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var matters = _mattersRepository.Table.ToList();
            var dbmattet = matters.Where(x => x.MName.Equals(mName)).SingleOrDefault();
            if (dbmattet != null)
            {
                return DataStatus.DataError(1331, "请勿使用相同问题！");
            }

            var matter = new Matters
            {
                MName = mName,
                Remarks = remarks

            };

            _mattersRepository.Insert(matter);
            return DataStatus.DataSuccess(1000, matter, "问题添加成功！");
        }

        /// <summary>
        /// 修改问题
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="upMatter">传入前端数据实体</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        [Route("Changematter/{id}")]
        public dynamic Changematter(int id, MatterParams upMatter)
        {
            var matter = _mattersRepository.GetId(id);
            var remarks = upMatter.Remarks == null ? "" : upMatter.Remarks.Trim();


            if (matter == null)
            {
                return DataStatus.DataError(1114, "数据不存在，无法执行修改操作！");
            }

            var mName = upMatter.MName.Trim();
            if (string.IsNullOrEmpty(mName))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var matters = _mattersRepository.Table.ToList();
            var dbmattet = matters.Where(x => x.MName.Equals(mName) && x.Id!=id).SingleOrDefault();
            if (dbmattet != null)
            {
                return DataStatus.DataError(1331, "请勿使用相同问题！");
            }

            matter.MName = mName;
            matter.Remarks=remarks;
            _mattersRepository.Update(matter);

            return DataStatus.DataSuccess(1000, matter, "修改成功");
        }

        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteMatter/{id}")]
        public dynamic deleteMatter(int id)
        {
            var dbusersmatter = _Context.Users.Where(x => x.MatterId == id).Count();
            if (dbusersmatter != 0)
            {
                return DataStatus.DataError(1332, "删除失败，问题使用中！");
            }

            _mattersRepository.Delete(id);
            return DataStatus.DataSuccess(1000, new { id = id }, "删除成功！");
        }

        /// <summary>
        /// 模糊查询问题
        /// </summary>
        /// <param name="mName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("likeMname/{mName}")]
        public dynamic likeMname(string mName)
        {
            var dbLikeMName = _mattersRepository.Table.Where(x => x.MName.Contains(mName)).ToList();
            return DataStatus.DataSuccess(1000, dbLikeMName, "查询成功！");

        }
    }
}