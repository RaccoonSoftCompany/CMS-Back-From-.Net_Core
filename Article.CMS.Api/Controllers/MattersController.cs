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
    public class MattersController : ControllerBase
    {
        /// <summary>
        /// 创建用户存储仓库
        /// </summary>
        /// <typeparam name="Users">用户实体</typeparam>
        /// <returns></returns>
        private IRepository<Matters> _mattersRepository;

        public MattersController(IConfiguration configuration, IRepository<Matters> mattersRepository)
        {
            _mattersRepository = mattersRepository;
        }
        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {

            var matters = _mattersRepository.Table.ToList();
            return JsonHelper.Serialize(new DataStatus().DataSuccess(matters));
        }

        [HttpPost]
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public dynamic Addmatter(MattersParams newMatter)
        {
            var matterName = newMatter.MName.Trim();

            if(string.IsNullOrEmpty(matterName))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var matters = new Matters
            {
                MName=newMatter.MName
            };

            _mattersRepository.Insert(matters);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(matters));
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public dynamic Updatematter(int id, MattersParams updateMatter)
        {
            var matterName = updateMatter.MName.Trim();

            if(string.IsNullOrEmpty(matterName))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var matters = _mattersRepository.GetId(id);

            if(matters == null)
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            matters.MName = updateMatter.MName;

            _mattersRepository.Update(matters);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(matters));
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic Deletematter(int id)
        {
            _mattersRepository.Delete(id);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        }        
    }
}