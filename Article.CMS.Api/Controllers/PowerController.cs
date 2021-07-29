using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Article.CMS.Api.Repository;
using Article.CMS.Api.Entity;
// using Article.CMS.Api.Params;
using Article.CMS.Api.Utils;
using System.Linq;
using Article.CMS.Api.Params;

namespace Article.CMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowersController : ControllerBase
    {
        /// <summary>
        /// 创建用户存储仓库
        /// </summary>
        /// <typeparam name="Users">用户实体</typeparam>
        /// <returns></returns>
        private IRepository<Powers> _powersRepository;

        public PowersController(IConfiguration configuration, IRepository<Powers> powersRepository)
        {
            _powersRepository = powersRepository;
        }
        [HttpGet]
        /// <summary>
        /// 获取数据请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {

            var powers = _powersRepository.Table.ToList();
            return JsonHelper.Serialize(new DataStatus().DataSuccess(powers));
        }

        [HttpPost]
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public dynamic AddPower(PowersParams newPower)
        {
            var powerName = newPower.PName.Trim();

            if(string.IsNullOrEmpty(powerName))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var powers = new Powers
            {
                PName=newPower.PName
            };

            _powersRepository.Insert(powers);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(powers));
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public dynamic UpdatePower(int id, PowersParams updatePower)
        {
            var powerName = updatePower.PName.Trim();

            if(string.IsNullOrEmpty(powerName))
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            var powers = _powersRepository.GetId(id);

            if(powers == null)
            {
                return JsonHelper.Serialize(new DataStatus().DataError());
            }

            powers.PName = updatePower.PName;

            _powersRepository.Update(powers);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(powers));
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic DeletePower(int id)
        {
            _powersRepository.Delete(id);

            return JsonHelper.Serialize(new DataStatus().DataSuccess(id));
        }        
    }
}