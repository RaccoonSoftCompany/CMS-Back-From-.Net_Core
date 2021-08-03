using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;

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
            if (string.IsNullOrEmpty(mName))
            {
                return DataStatus.DataError(1111, "请检查必填项目是否填写！");
            }

            var matters = _mattersRepository.Table.ToList();
            var dbmattet = matters.Where(x => x.MName.Equals(mName)).SingleOrDefault();
            if (dbmattet != null)
            {
                return DataStatus.DataError(1331, "请勿添加相同问题！");
            }

            var matter = new Matters
            {
                MName = mName
            };

            _mattersRepository.Insert(matter);
            return DataStatus.DataSuccess(1000, matter, "问题添加成功！");
        }

    }
}