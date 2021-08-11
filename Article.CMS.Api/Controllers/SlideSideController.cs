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
    /// <summary>
    /// 这是站点的控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SlideSideController : ControllerBase
    {
        /// <summary>
        /// 创建站点存储仓库
        /// </summary>
        /// <returns></returns>
        private IRepository<SlideShow> _SlideShowRepository;
        /// <summary>
        /// 所有数据库
        /// </summary>
        /// <returns></returns>
        ArticleCmsdb _Context = new ArticleCmsdb();

        public SlideSideController(IConfiguration configuration, IRepository<SlideShow> SlideShowRepository)
        {
            _SlideShowRepository = SlideShowRepository;
        }

        [HttpGet]
        /// <summary>
        /// 获取所有轮播图给后台
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var SlideShow = _SlideShowRepository.Table.ToList();
            return DataStatus.DataSuccess(1000, SlideShow, "轮播图获取成功！");
        }

        /// <summary>
        /// 轮播图是否启用
        /// </summary>
        /// <param name="id">轮播图ID</param>
        /// <param name="UpIsActived">前端返回是否启用数据</param>
        /// <returns></returns>
        [HttpPut]
        [Route("IsActived/{id}")]
        public dynamic IsActived(int id, SlideShowParams UpIsActived)
        {
            var isActived = UpIsActived.IsActived;
            var dbSlideShow = _SlideShowRepository.GetId(id);
            if (dbSlideShow == null)
            {
                return DataStatus.DataError(1221, "该轮播图不存在！");
            }
            dbSlideShow.IsActived = isActived;
            _SlideShowRepository.Update(dbSlideShow);
            return DataStatus.DataSuccess(1000, dbSlideShow, "轮播图获取成功！");
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <returns></returns>
        public dynamic Delete(int id)
        {
            _SlideShowRepository.Delete(id);
            return DataStatus.DataSuccess(1000, new { Id = id }, "轮播图删除成功！");
        }

    }
}
