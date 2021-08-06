using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Article.CMS.Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Article.CMS.Api.Repository;
using Microsoft.Net.Http.Headers;
using Article.CMS.Api.Entity;
using System.Linq;
using Article.CMS.Api.Database;

namespace Article.CMS.Api.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<ImagesUrl> _fileInfoRepository;
        ArticleCmsdb _Context = new ArticleCmsdb();

        public UploadFileController(IConfiguration configuration, IRepository<ImagesUrl> fileInfoRepository)
        {
            _configuration = configuration;
            _fileInfoRepository = fileInfoRepository;
        }

        [HttpPost]
        [Route("userimage/{userId}")]
        public string userimage(int userId, IFormCollection model)
        {
            // 获得当前应用所在的完整路径（绝对地址）
            var filePath = Directory.GetCurrentDirectory();

            // 通过配置文件获得存放文件的相对路径头像
            string path = _configuration["UpUserimage"];

            // 最终存放文件的完整路径
            var preFullPath = Path.Combine(filePath, path);
            // 如果路径不存在，则创建
            if (!Directory.Exists(preFullPath))
            {
                Directory.CreateDirectory(preFullPath);
            }
            var userInfo = _Context.UserInfos.Where(x => x.UserId == userId).SingleOrDefault();

            var resultPath = new List<string>();
            foreach (IFormFile file in model.Files)
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var extName = fileName.Substring(fileName.LastIndexOf("."));//extName包含了“.”
                    var rndName = Guid.NewGuid().ToString("N") + extName;
                    var tempPath = Path.Combine(path, rndName).Replace("\\", "/");
                    using (var stream = new FileStream(Path.Combine(filePath, tempPath), FileMode.CreateNew))//Path.Combine(_env.WebRootPath, fileName)
                    {
                        file.CopyTo(stream);
                    }
                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                    userInfo.ImageURL = tempPath;
                    _Context.SaveChanges();
                }
            }

            return DataStatus.DataSuccess(1000, userInfo.ImageURL, "插入头像成功！");
        }



        /// <summary>
        /// 文件上传接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Aimg/{aId}}")]
        public string UploadFile(int aId, IFormCollection model)
        {
            var articleId = aId;
            var isArticle = _Context.Articles.Where(x => x.Id == articleId).SingleOrDefault();

            if (isArticle == null)
            {
                return DataStatus.DataError(1221, "该文章不存在！");
            }
            // 获得当前应用所在的完整路径（绝对地址）
            var filePath = Directory.GetCurrentDirectory();

            // 通过配置文件获得存放文件的相对路径
            string path = _configuration["UploadFilesPath"];

            // 最终存放文件的完整路径
            var preFullPath = Path.Combine(filePath, path);
            // 如果路径不存在，则创建
            if (!Directory.Exists(preFullPath))
            {
                Directory.CreateDirectory(preFullPath);
            }

            var resultPath = new List<string>();

            foreach (IFormFile file in model.Files)
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var extName = fileName.Substring(fileName.LastIndexOf("."));//extName包含了“.”
                    var rndName = Guid.NewGuid().ToString("N") + extName;
                    var tempPath = Path.Combine(path, rndName).Replace("\\", "/");
                    using (var stream = new FileStream(Path.Combine(filePath, tempPath), FileMode.CreateNew))//Path.Combine(_env.WebRootPath, fileName)
                    {
                        file.CopyTo(stream);
                    }
                    // var tmpFile = new ImagesUrl
                    // {
                    //     OriginName = fileName,
                    //     CurrentName = rndName,
                    //     ATImageUrl = tempPath,
                    //     UserId = userId
                    // };

                    // _fileInfoRepository.Insert(tmpFile);
                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                    isArticle.ATitleImageUrl = tempPath;//插入路径
                }
            }
            _Context.Articles.Update(isArticle);
            _Context.SaveChanges();

            return DataStatus.DataSuccess(1000, isArticle, "插入文章成功！");
        }

        [HttpGet]
        [Route("getimgs")]
        /// <summary>
        /// 获取所有图片请求
        /// </summary>
        /// <returns></returns>
        public dynamic Get()
        {
            var matters = _fileInfoRepository.Table.ToList();
            return DataStatus.DataSuccess(1000, matters, "获取图片成功！");
        }

    }
}