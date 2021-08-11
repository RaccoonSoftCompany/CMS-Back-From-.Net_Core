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

        /// <summary>
        /// 头像上传
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// 文章标题图片上传
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TitleImage/{aId}")]
        public string TitleImage(int aId, IFormCollection model)
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
            string path = _configuration["UpTitleImage"];

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
                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                    isArticle.ATitleImageUrl = tempPath;//插入路径
                }
            }
            _Context.Articles.Update(isArticle);
            _Context.SaveChanges();

            return DataStatus.DataSuccess(1000, resultPath, "插入文章标题图片成功！");
        }

        /// <summary>
        /// 文章图片上传
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{uId}")]
        public string UploadFile(int uId, IFormCollection model)
        {
            var userId = uId;
            var isUsers = _Context.Users.Where(x => x.Id == userId).SingleOrDefault();

            if (isUsers == null)
            {
                return DataStatus.DataError(1221, "该用户不存在！");
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
                    var tmpFile = new ImagesUrl
                    {
                        OriginName = fileName,
                        CurrentName = rndName,
                        ATImageUrl = tempPath,
                        UserId = userId
                    };

                    _fileInfoRepository.Insert(tmpFile);
                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                }
            }

            return DataStatus.DataSuccess(1000, resultPath, "插入图片成功！");
        }

        /// <summary>
        /// 站点轮播图上传
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpSlideSide/{wId}")]
        public string UpSlideSide(int wId, IFormCollection model)
        {
            var webId = wId;
            var isweb = _Context.WebSide.Where(x => x.Id == webId).SingleOrDefault();

            if (isweb == null)
            {
                return DataStatus.DataError(1221, "该站点不存在！");
            }

            // 获得当前应用所在的完整路径（绝对地址）
            var filePath = Directory.GetCurrentDirectory();

            // 通过配置文件获得存放文件的相对路径
            string path = _configuration["UpSlideSide"];

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
                    var addSlideShow = new SlideShow
                    {
                        SlideSideUrl = tempPath
                    };
                    _Context.SlideShow.Add(addSlideShow);
                    _Context.SaveChanges();

                    addSlideShow.IsActived=false;
                    _Context.SlideShow.Update(addSlideShow);
                    _Context.SaveChanges();

                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                }
            }

            return DataStatus.DataSuccess(1000, resultPath, "插入图片成功！");
        }

        // /// <summary>
        // /// 站点二维码上传
        // /// </summary>
        // /// <param name="model"></param>
        // /// <returns></returns>
        [HttpPost("{wId}")]
        [Route("UpQRCode/{wId}")]
        public string UpQRCode(int wId, IFormCollection model)
        {
            var webId = wId;
            var isweb = _Context.WebSide.Where(x => x.Id == webId).SingleOrDefault();

            if (isweb == null)
            {
                return DataStatus.DataError(1221, "该站点不存在！");
            }

            // 获得当前应用所在的完整路径（绝对地址）
            var filePath = Directory.GetCurrentDirectory();

            // 通过配置文件获得存放文件的相对路径
            string path = _configuration["UpQRCode"];

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
                    var addQRCode = new QRCode
                    {
                        WebSideId = webId,
                        QRUrl = tempPath
                    };

                    _Context.QRCode.Add(addQRCode);
                    _Context.SaveChanges();
                    // 此处地址可能带有两个反斜杠，虽然也能用，比较奇怪，统一转换成斜杠，这样在任何平台都有一样的表现
                    resultPath.Add(tempPath.Replace("\\", "/"));
                }
            }

            return DataStatus.DataSuccess(1000, resultPath, "插入图片成功！");
        }


    }
}